//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Asker.Data;
//using Microsoft.EntityFrameworkCore;

//namespace Asker.Models
//{
//    public class DbInitialize
//    {
//        public static void Seed(ApplicationDbContext context)
//        {

//            if (context.Item.Any())
//            {
//                return;
//            }

//            context.Employees.AddRange(
//            new Employee
//            {
//                Id = 1,
//                fName = "David",
//                lName = "Bowie",
//                age = 81,
//                address = "123 Main St",
//                city = "Hollywood",
//                state = "CA",
//                zipcode = "33019"
//            },
//            new Employee
//            {
//                Id = 2,
//                fName = "Madonna",
//                lName = "Ciccone",
//                age = 61,
//                address = "332 Market St",
//                city = "Detroit",
//                state = "MI",
//                zipcode = "48201"
//            },
//            new Employee
//            {
//                Id = 3,
//                fName = "Cyndi",
//                lName = "Lauper",
//                age = 67,
//                address = "111 George St",
//                city = "Brooklyn",
//                state = "NY",
//                zipcode = "11207"
//            }

//                );

//            context.SaveChanges();

//        }
//    }
//}
