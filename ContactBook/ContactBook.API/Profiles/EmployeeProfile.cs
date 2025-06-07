using AutoMapper;
using ContactBook.API.Entities;
using ContactBook.API.Models;

namespace ContactBook.API.Profiles
{
    /// <summary>
    /// Configures mapping between <see cref="Employee"/> and <see cref="EmployeeDto"/> types.
    /// </summary>
    /// <remarks>This profile is used by AutoMapper to define how properties of the <see cref="Employee"/> 
    /// class are mapped to the <see cref="EmployeeDto"/> class. </remarks>
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>(); 
        }
    }
}
