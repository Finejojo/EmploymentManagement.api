using EmploymentManagement.api.Models.Dtos;
using EmploymentManagement.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentManagement.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDtos employeeDtos)
        {
            var createEmployeeResponse = _employeeRepository.AddEmployee(employeeDtos);

            return Ok(createEmployeeResponse);
        }

        [HttpPost("create-class-of-food")]
        public async Task<IActionResult> CreateFoodClass(FoodClassDto foodClassDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFoodClass = await _employeeRepository.CreateFoodClass(foodClassDto);

            if (createdFoodClass == null)
            {
                return NotFound(createdFoodClass);
            }
            return Ok(createdFoodClass);
        }

        [HttpPut("{foodClassId}/update-foodclass")]
        public async Task<ActionResult> UpdateFoodClass(string foodClassId, [FromBody] FoodClassDto updatedFoodClassDto)
        {
            var response = await _employeeRepository.UpdateFoodClass(foodClassId, updatedFoodClassDto);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
