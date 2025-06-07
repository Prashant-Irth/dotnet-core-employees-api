using AutoMapper;
using ContactBook.API.Entities;
using ContactBook.API.Models;
using ContactBook.API.Repository;
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
        private readonly IEmployeeInfoRepository _employeeInfoRepository;
        private readonly IMapper _mapper;

        public EmployeesController(ILogger<EmployeesController> logger,
            IMailService mailService, EmployeesDataStore employeesDataStore,
            IEmployeeInfoRepository employeeInfoRepository,
            IMapper mapper)
        {
            _logger = logger;
            _mailService = mailService;
            _employeesDataStore = employeesDataStore;
            _employeeInfoRepository = employeeInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeInfoRepository.GetAllEmployeesAsync();
                IEnumerable<EmployeeDto> employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeeDtos);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "An error occurred while getting all employees.");
                return StatusCode(500, "A error ocurred while handling your request.");
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployeeById(int employeeId)
        {
            IEnumerable<Employee> employees = await _employeeInfoRepository.GetAllEmployeesAsync();
            Employee? employee = employees.FirstOrDefault(x => x.Id == employeeId);

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
        public ActionResult<EmployeeDto> UpdateEmployee(int employeeId, [FromBody] EmployeeDto employeeDto)
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
        public ActionResult DeleteEmployee(int employeeId)
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
