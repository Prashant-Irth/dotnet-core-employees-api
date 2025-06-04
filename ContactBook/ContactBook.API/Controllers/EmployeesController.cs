using ContactBook.API.Models;
using ContactBook.API.Services;
using ContactBook.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMailService _mailService;
        private readonly EmployeesDataStore _employeesDataStore;

        public EmployeesController(ILogger<EmployeesController> logger,
            IMailService mailService, EmployeesDataStore employeesDataStore)
        {
            _logger = logger;
            _mailService = mailService;
            _employeesDataStore = employeesDataStore;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>> GetAllEmployees()
        {
            try
            {
                List<EmployeeDto> employees = _employeesDataStore.Employees;
                return Ok(employees);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "An error occurred while getting all employees.");
                return StatusCode(500, "A error ocurred while handling your request.");
            }
        }

        [HttpGet("{employeeId}")]
        public ActionResult<List<EmployeeDto>> GetEmployeeById(Guid employeeId)
        {
            List<EmployeeDto> employees = _employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                _logger.LogWarning($"Employee with {employeeId} was not found!!!");
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<EmployeeDto> AddEmployee([FromBody] EmployeeDto employee)
        {
            _employeesDataStore.Employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut("{employeeId}")]
        public ActionResult<EmployeeDto> UpdateEmployee(Guid employeeId, [FromBody] EmployeeDto employeeDto)
        {
            List<EmployeeDto> employees = _employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = employeeDto.Name;
            employee.Designation = employeeDto.Designation;
            employee.ContactDetails = employeeDto.ContactDetails;

            return Ok(employee);
        }

        [HttpDelete("{employeeId}")]
        public ActionResult DeleteEmployee(Guid employeeId)
        {
            EmployeeDto? employee = _employeesDataStore.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            _employeesDataStore.Employees.Remove(employee);
            _mailService.Send("Employee Deleted", $"Employee with ID {employeeId} has been deleted successfully.");
            return NoContent();
        }
    }
}
