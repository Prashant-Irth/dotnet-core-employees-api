using ContactBook.API.Entities;

namespace ContactBook.API.Repository
{
    public interface IEmployeeInfoRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee?> GetEmployeeAsync(int employeeId);

        Task<IEnumerable<Contact>> GetAllContactsOfEmployee(string employeeId);

        Task<Contact?> GetContactOfEmployee(int employeeId, int contactId);
    }
}
