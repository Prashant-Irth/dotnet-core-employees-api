using ContactBook.API.DbContexts;
using ContactBook.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.API.Repository
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        private readonly EmployeeInfoContext _context;
        public EmployeeInfoRepository(EmployeeInfoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.OrderBy(x => x.Name).ToListAsync();
        }
        public async Task<Employee?> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }
        public async Task<IEnumerable<Contact>> GetAllContactsOfEmployee(string employeeId)
        {
            return await _context.Contacts.Where(c => c.EmployeeId.ToString() == employeeId).ToListAsync();
        }
        public async Task<Contact?> GetContactOfEmployee(int employeeId, int contactId)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.EmployeeId == employeeId && c.ContactId == contactId);
        }
    }
}
