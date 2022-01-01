using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Common
{
    public static class Helper
    {
        public static async Task<IEnumerable<SelectListItem>> GetSelectList<T>(AskerTrackerDbContext context,
            Expression<Func<T, string>> dataField,
            string dataValueField = "Id", bool selectedValue = false) where T : class
        {
            var dataTextField = GetMemberName(dataField.Body);
            
            var list = await context.Set<T>().ToListAsync();

            var selectItems = list.OrderBy<T, string>(dataField.Compile()).GroupBy(dataField.Compile())
                .Select(y => y.First()).ToList();

            return new SelectList(selectItems, dataValueField, dataTextField, selectedValue);
        }

        public static IEnumerable<SelectListItem> AppendItem(this IEnumerable<SelectListItem> list, SelectListItem item)
        {
            return list.Append(item);
        }

        public static IEnumerable<SelectListItem> AppendTeamPropertyItem(this IEnumerable<SelectListItem> list)
        {
            return list.Append(new SelectListItem("Team property", "", true));
        }
        
        private static string GetMemberName(Expression expression)
        {
            if (expression == null) throw new ArgumentException(ExpressionCannotBeNullMessage);

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression = (MemberExpression) expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression = (MethodCallExpression) expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression) expression;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException(InvalidExpressionMessage);
        }
        
        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression = (MethodCallExpression) unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression) unaryExpression.Operand).Member.Name;
        }

        private const string? ExpressionCannotBeNullMessage = "GetMemberName(): Expression cannot be null.";

        private const string InvalidExpressionMessage = "GetMemberName(): Invalid expression.";
    }
}