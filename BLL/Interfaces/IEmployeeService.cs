﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectCore;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById(int id);
        Task<EmployeeDTO> Create(EmployeeDTO employee);
        Task<int> Update(EmployeeDTO employee);
        Task<int> Delete(int id);
    }
}
