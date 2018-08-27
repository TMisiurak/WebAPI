using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly ApplicationContext db;

        public EmployeeRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
        public async Task<IList<Employee>> GetAll()
        {
            // TODO filter data using LINQ to SQL
            var employees = await db.Employees
                                    .Include(e => e.Position)
                                    .Where(e => e.IsDeleted == false)
                                    .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            // Get entity by id using extension method
            Employee employee = await db.Employees
                                        .Include(e => e.Position)
                                        .Where(e => e.IsDeleted == false && e.Id == id)
                                        .FirstOrDefaultAsync();
            return employee;
        }

        public async Task<Employee> Create(Employee employee)
        {
            await db.Set<Employee>().AddAsync(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<int> Delete(int id)
        {
            // Soft Delete

            Employee employee = await db.Employees.FindAsync(id);
            db.Entry(employee).CurrentValues["IsDeleted"] = true;

            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
