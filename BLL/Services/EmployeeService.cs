using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using ProjectCore;
using AutoMapper;
using DAL.UnitOfWork;
using ProjectCore.Models;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<EmployeeDTO>> GetAll()
        {
            IList<Employee> employees = await _unitOfWork.Employees.GetAll();
            var result = _mapper.Map<IList<EmployeeDTO>>(employees);
            return result;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            Employee employee = await _unitOfWork.Employees.GetById(id);
            EmployeeDTO result = _mapper.Map<EmployeeDTO>(employee);
            return result;
        }

        public async Task<EmployeeDTO> Create(EmployeeDTO employee)
        {
            await _unitOfWork.Employees.Create(_mapper.Map<Employee>(employee));
            EmployeeDTO result = _mapper.Map<EmployeeDTO>(employee);
            return result;
        }

        public async Task<int> Update(EmployeeDTO employee)
        {
            int result = await _unitOfWork.Employees.Update(_mapper.Map<Employee>(employee));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = await _unitOfWork.Employees.Delete(id);
            return result;
        }
    }
}
