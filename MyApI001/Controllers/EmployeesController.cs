using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApI001.Models;
using MyApI001.Services;
using MyApI001.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace MyApI001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger) {
            _employeeService= employeeService; 
            _logger= logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entity = await _employeeService.GetAll();

                if (entity.Count == 0)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "系統異常，請通知相關人員");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _employeeService.GetId(id);

                if (entity == null) {
                    return NotFound("沒有資料");
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "系統異常，請通知相關人員");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Employees employees)
        {
            try
            {
                await _employeeService.Create(employees);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "系統異常，請通知相關人員");
            }
        }

        [HttpPut]

        public async Task<IActionResult> Put(Employees employees)
        {
            try
            {
                await _employeeService.Create(employees);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "系統異常，請通知相關人員");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "系統異常，請通知相關人員");
            }
        }
    }
}
