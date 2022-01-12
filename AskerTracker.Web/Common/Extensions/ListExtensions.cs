using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AskerTracker.Web.Common.Extensions
{
    public static class ListExtensions
    {
        private const string ExpressionCannotBeNullMessage = "The expression cannot be null.";
        private const string InvalidExpressionMessage = "Invalid expression.";

        public static T RemoveAndReturnFirst<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
                // Instead of returning the default,
                // an exception might be more compliant to the method signature.

                return default;

            var currentFirst = list[0];
            list.RemoveAt(0);
            return currentFirst;
        }

        public static IList<T> IncludeMore<T, TT>(this IList<T> list, Expression<Func<T, object>> propertyToChange,
            IList<TT> objects)
        {
            for (var i = 0; i < list.Count; i++) list[i].IncludeMore(propertyToChange, objects[i]);

            return list;
        }

        public static T IncludeMore<T, TT>(this T parent, Expression<Func<T, object>> propertyToChange,
            TT value)
        {
            var propertyName = GetMemberName(propertyToChange.Body);

            parent.SetProperty(propertyName, value);

            return parent;
        }

        public static void SetProperty(this object obj, string propertyName, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return;
            propertyInfo.SetValue(obj, value);
        }

        public static string GetMemberName<T>
            (this T instance, Expression<Func<T, object>> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static List<string> GetMemberNames<T>
            (this T instance, params Expression<Func<T, object>>[] expressions)
        {
            var memberNames = new List<string>();
            foreach (var cExpression in expressions) memberNames.Add(GetMemberName(cExpression.Body));

            return memberNames;
        }

        public static string GetMemberName<T>
            (this T instance, Expression<Action<T>> expression)
        {
            return GetMemberName(expression.Body);
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
    }
}