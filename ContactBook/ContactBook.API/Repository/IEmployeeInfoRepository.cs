using ContactBook.API.Entities;

namespace ContactBook.API.Repository
{
    public interface IEmployeeInfoRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
