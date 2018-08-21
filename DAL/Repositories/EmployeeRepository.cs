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
            return await db.Employees.Where(e => e.IsDeleted == false).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await db.Employees.Where(e => e.IsDeleted == false && e.Id == id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<int> Create(Employee employee)
        {
            await db.Set<Employee>().AddAsync(employee);
            int result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            int result = await db.SaveChangesAsync();
            return result;
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
