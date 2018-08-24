using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectCore.Models;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAll();
        Task<Employee>GetById(int id);
        Task<Employee> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Delete(int id);
    }
}
