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

            // Casting of one of the returned objects to IActionResult is necessary
            // If both of the objects are casted the 'Redundant cast' suggestion will appear
            // If the cast is removed from one of the objects it will still work fine
            // Remove casting on both objects and the types won't be implicitly converted

            return employees != null ? (IActionResult)Ok(employees) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);

            return employee != null ? (IActionResult)Ok(employee) : NotFound();
        }

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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _employeeService.Update(employeeDTO);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _employeeService.Delete(id);

            return result > 0 ? (IActionResult)Ok(result) : BadRequest();
        }
    }
}
