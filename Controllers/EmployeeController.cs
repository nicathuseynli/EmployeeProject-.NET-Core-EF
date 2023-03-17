using Employee_HW_EF.Dto;
using Employee_HW_EF.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_HW_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning("Employee not yet ! ! !");
           var result=await _employeeRepository.CreateAsync(employeeDto);
            _logger.LogInformation("Employee was created ! ! !");
            wastch.Stop();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int Id)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning("Employee will be deleted ! ! !");
            var result = await _employeeRepository.DeleteAsync(Id);
            if (result == false)
                return NotFound();
            _logger.LogInformation("Employee succesfully deleted ! ! !");
            wastch.Stop();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogInformation($"request {DateTime.Now}");
            var result = await _employeeRepository.GetAllAsync();
            wastch.Stop();
            return Ok(result);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning("Invalid Id ");
            var result= await _employeeRepository.GetByIdAsync(Id);
            _logger.LogInformation($"{ result.Id}numbered employee ");
            wastch.Stop();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,EmployeeUpdateDto employeeUpdateDto)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning($"Employee not fount is {id}");
            var result = await _employeeRepository.UpdateAsync(id, employeeUpdateDto);
            _logger.LogInformation("Employee's information succesfully updated ! ! !");
            wastch.Stop();
            return Ok(result);
        }
        

    }
}
