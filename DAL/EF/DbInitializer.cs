using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectCore.Models;
using System.Linq;
using System;

namespace DAL.EF
{
    public class DbInitializer
    {
        public static void InitializeDatabase(ApplicationContext applicationContext)
        {
            applicationContext.Database.Migrate();

            List<Gender> genders = new List<Gender>
            {
                new Gender { Name = "Male" },
                new Gender { Name = "Female" }
            };

            List<Position> positions = new List<Position>
            {
                new Position { Title = "CEO", Description = "It is a CEO position" },
                new Position { Title = "CTO", Description = "It is a CTO position" },
                new Position { Title = "General Manager", Description = "It is a General Manager position" },
                new Position { Title = "Manager", Description = "It is a Manager position" },
                new Position { Title = "Technology Officer", Description = "It is a Technology Officer position"},
                new Position { Title = "Senior Developer", Description = "It is a Senior Developer position" },
                new Position { Title = "Intermediate Developer", Description = "It is a Intermediate Developer position" },
                new Position { Title = "Junior Developer", Description = "It is a Junior Developer position" },
                new Position { Title = "Trainee Developer", Description = "It is a Trainee Developer position" },
                new Position { Title = "Human resource", Description = "It is a Human resource position" },
                new Position { Title = "Accountant", Description = "It is an Accountant position" }
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee { FirstName = "Bill", LastName = "Gates", GenderId = 1, PositionId = 1, DateOfBirth = new DateTime(1955, 07, 15)},
                new Employee { FirstName = "Michael", LastName = "Peterson", GenderId = 1, PositionId = 2, DateOfBirth = new DateTime(1974, 01, 20)},
                new Employee { FirstName = "Chloe", LastName = "Maser", GenderId = 2, PositionId = 10, DateOfBirth = new DateTime(1982, 03, 12)},
                new Employee { FirstName = "Mahalia", LastName = "Franceschi", GenderId = 2, PositionId = 11, DateOfBirth = new DateTime(1979, 04, 16)},
                new Employee { FirstName = "Ginny", LastName = "Banker", GenderId = 2, PositionId = 5, DateOfBirth = new DateTime(1985, 09, 14)},
                new Employee { FirstName = "Harold", LastName = "Mcgonigle", GenderId = 1, PositionId = 5, DateOfBirth = new DateTime(1983, 07, 06)},
                new Employee { FirstName = "Johnny", LastName = "Adams", GenderId = 1, PositionId = 3, DateOfBirth = new DateTime(1986, 08, 12)},
                new Employee { FirstName = "Barbara", LastName = "Martin", GenderId = 2, PositionId = 4, DateOfBirth = new DateTime(1988, 06, 11)},
                new Employee { FirstName = "Craig", LastName = "Taylor", GenderId = 1, PositionId = 4, DateOfBirth = new DateTime(1987, 04, 22)},
                new Employee { FirstName = "Brandon", LastName = "Russell", GenderId = 1, PositionId = 6, DateOfBirth = new DateTime(1992, 03, 20)},
                new Employee { FirstName = "Phillips", LastName = "Phillips", GenderId = 1, PositionId = 6, DateOfBirth = new DateTime(1993, 11, 27)},
                new Employee { FirstName = "Perez", LastName = "Perez", GenderId = 1, PositionId = 6, DateOfBirth = new DateTime(1993, 01, 18)},
                new Employee { FirstName = "Rachel", LastName = "Gonzalez", GenderId = 2, PositionId = 7, DateOfBirth = new DateTime(1994, 03, 15)},
                new Employee { FirstName = "Eric", LastName = "Howard", GenderId = 1, PositionId = 7, DateOfBirth = new DateTime(1996, 08, 26)},
                new Employee { FirstName = "Lisa", LastName = "Sanders", GenderId = 2, PositionId = 7, DateOfBirth = new DateTime(1995, 12, 15)},
                new Employee { FirstName = "Brian", LastName = "Carter", GenderId = 1, PositionId = 8, DateOfBirth = new DateTime(1996, 04, 15)},
                new Employee { FirstName = "John", LastName = "Lee", GenderId = 1, PositionId = 8, DateOfBirth = new DateTime(1996, 03, 12)},
                new Employee { FirstName = "David", LastName = "Harris", GenderId = 1, PositionId = 8, DateOfBirth = new DateTime(1997, 04, 25)},
                new Employee { FirstName = "Jennifer", LastName = "Smith", GenderId = 2, PositionId = 9, DateOfBirth = new DateTime(1998, 03, 12)},
                new Employee { FirstName = "Steve", LastName = "Parker", GenderId = 1, PositionId = 9, DateOfBirth = new DateTime(1999, 07, 04)}
            };

            if (!applicationContext.Genders.Any())
            {
                foreach (var gender in genders)
                {
                    applicationContext.Genders.Add(gender);
                    applicationContext.SaveChanges();
                }
            }

            if (!applicationContext.Positions.Any())
            {
                foreach (var position in positions)
                {
                    applicationContext.Positions.Add(position);
                    applicationContext.SaveChanges();
                }
            }

            if (!applicationContext.Employees.Any())
            {
                foreach (var employee in employees)
                {
                    applicationContext.Employees.Add(employee);
                    applicationContext.SaveChanges();
                }
            }
        }
    }
}
