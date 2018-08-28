using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PositionsController : Controller
    {
        readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IList<PositionDTO> positions = await _positionService.GetAll();

            // Casting of one of the returned objects to IActionResult is necessary
            // If both of the objects are casted the 'Redundant cast' suggestion will appear
            // If the cast is removed from one of the objects it will still work fine
            // Remove casting on both objects and the types won't be implicitly converted

            return positions != null ? (IActionResult)Ok(positions) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var position = await _positionService.GetById(id);

            return position != null ? (IActionResult)Ok(position) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PositionDTO positionDTO)
        {
            if (positionDTO == null)
            {
                ModelState.AddModelError("", "Please enter valid data");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _positionService.Create(positionDTO);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]PositionDTO positionDTO)
        {
            if (positionDTO == null)
            {
                return BadRequest();
            }

            var result = await _positionService.Update(positionDTO);

            return ModelState.IsValid ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _positionService.Delete(id);

            return result > 0 ? (IActionResult)Ok(result) : BadRequest();
        }
    }
}
