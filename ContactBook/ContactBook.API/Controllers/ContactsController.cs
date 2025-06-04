using ContactBook.API.Models;
using ContactBook.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.API.Controllers
{
    [Route("api/employees/{employeeId}/contacts")]
    [ApiController]
    public class ContactsController(EmployeesDataStore employeesDataStore) : ControllerBase
    {
        [HttpGet]
        public ActionResult<ContactDto> GetAllContactsOfEmployee(Guid employeeId)
        {
            List<EmployeeDto> employees = employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.ContactDetails);
        }

        [HttpGet("{contactId}", Name = "GetContactByContactId")]
        public ActionResult<ContactDto> GetContactByContactId(Guid employeeId, Guid contactId)
        {
            List<EmployeeDto> employees = employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            ContactDto? contact = employee.ContactDetails.FirstOrDefault(x => x.ContactId == contactId);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public ActionResult<ContactDto> AddContact(Guid employeeId, [FromBody] ContactCreationDto contactCreationDto)
        {
            List<EmployeeDto> employees = employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            ContactDto newContact = new()
            {
                MobileNumber = contactCreationDto.MobileNumber,
                EmailAddress = contactCreationDto.EmailAddress,
            };

            employee.ContactDetails.Add(newContact);
            return CreatedAtRoute("GetContactByContactId", new
            {
                employeeId,
                contactId = newContact.ContactId
            }, newContact);
        }

        [HttpPut("{contactId}")]
        public ActionResult<ContactDto> UpdateContact(Guid employeeId, Guid contactId, [FromBody] ContactUpdationDto contactUpdationDto)
        {
            List<EmployeeDto> employees = employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            List<ContactDto> contacts = employee.ContactDetails;
            ContactDto? contact = contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact == null)
            {
                return NotFound();
            }

            //contact.ContactId = contact.ContactId;
            contact.EmailAddress = contactUpdationDto.EmailAddress;
            contact.MobileNumber = contactUpdationDto.MobileNumber;

            return Ok(contact);
        }

        [HttpDelete("{contactId}")]
        public ActionResult DeleteContact(Guid employeeId, Guid contactId)
        {
            List<EmployeeDto> employees = employeesDataStore.Employees;
            EmployeeDto? employee = employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            List<ContactDto> contacts = employee.ContactDetails;
            ContactDto? contact = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact == null)
            {
                return NotFound();
            }
            contacts.Remove(contact);
            return NoContent();
        }
    }
}
