using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using ProjectCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IList<EmployeeDTO> employees = await _employeeService.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        // TODO Possibly create GetByGender and GetByPosition Actions

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                ModelState.AddModelError("", "Please enter valid data");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _employeeService.Create(employeeDTO);

            return Ok(result);
        }

        // TODO Update Action

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest();
            }

            int result = await _employeeService.Update(employeeDTO);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _employeeService.Delete(id);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
