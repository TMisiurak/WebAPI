using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectCore.Models;
using System.Linq;

namespace DAL.EF
{
    public class DbInitializer
    {
        public static void InitializeDatabase(ApplicationContext applicationContext)
        {
            applicationContext.Database.Migrate();

            List<Gender> genders = new List<Gender>
            {
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" }
            };

            List<Position> positions = new List<Position>
            {
                new Position { Id = 1, Title = "CEO", Description = "It is a CEO position" },
                new Position { Id = 2, Title = "CTO", Description = "It is a CTO position" },
                new Position { Id = 3, Title = "General Manager", Description = "It is a General Manager position" },
                new Position { Id = 4, Title = "Manager", Description = "It is a Manager position" },
                new Position { Id = 5, Title = "Technology Officer", Description = "It is a Technology Officer position"},
                new Position { Id = 6, Title = "Senior Developer", Description = "It is a Senior Developer position" },
                new Position { Id = 7, Title = "Intermediate Developer", Description = "It is a Intermediate Developer position" },
                new Position { Id = 8, Title = "Junior Developer", Description = "It is a Junior Developer position" },
                new Position { Id = 9, Title = "Trainee Developer", Description = "It is a Trainee Developer position" },
                new Position { Id = 10, Title = "Human resource", Description = "It is a Human resource position" },
                new Position { Id = 11, Title = "Accountant", Description = "It is an Accountant position" }
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Bill", LastName = "Gates", GenderId = 1, PositionId = 1},
                new Employee { Id = 2, FirstName = "Michael", LastName = "Peterson", GenderId = 1, PositionId = 2},
                new Employee { Id = 3, FirstName = "Chloe", LastName = "Maser", GenderId = 2, PositionId = 10},
                new Employee { Id = 4, FirstName = "Mahalia", LastName = "Franceschi", GenderId = 2, PositionId = 11},
                new Employee { Id = 5, FirstName = "Ginny", LastName = "Banker", GenderId = 2, PositionId = 5},
                new Employee { Id = 6, FirstName = "Harold", LastName = "Mcgonigle", GenderId = 1, PositionId = 5},
                new Employee { Id = 7, FirstName = "Johnny", LastName = "Adams", GenderId = 1, PositionId = 3},
                new Employee { Id = 8, FirstName = "Barbara", LastName = "Martin", GenderId = 2, PositionId = 4},
                new Employee { Id = 9, FirstName = "Craig", LastName = "Taylor", GenderId = 1, PositionId = 4},
                new Employee { Id = 10, FirstName = "Brandon", LastName = "Russell", GenderId = 1, PositionId = 6},
                new Employee { Id = 11, FirstName = "Phillips", LastName = "Phillips", GenderId = 1, PositionId = 6},
                new Employee { Id = 12, FirstName = "Perez", LastName = "Perez", GenderId = 1, PositionId = 6},
                new Employee { Id = 13, FirstName = "Rachel", LastName = "Gonzalez", GenderId = 2, PositionId = 7},
                new Employee { Id = 14, FirstName = "Eric", LastName = "Howard", GenderId = 1, PositionId = 7},
                new Employee { Id = 15, FirstName = "Lisa", LastName = "Sanders", GenderId = 2, PositionId = 7},
                new Employee { Id = 16, FirstName = "Brian", LastName = "Carter", GenderId = 1, PositionId = 8},
                new Employee { Id = 17, FirstName = "John", LastName = "Lee", GenderId = 1, PositionId = 8},
                new Employee { Id = 18, FirstName = "David", LastName = "Harris", GenderId = 1, PositionId = 8},
                new Employee { Id = 19, FirstName = "Jennifer", LastName = "Smith", GenderId = 2, PositionId = 9},
                new Employee { Id = 20, FirstName = "Steve", LastName = "Parker", GenderId = 1, PositionId = 9}
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
