using ContactBook.API.Models;

namespace ContactBook.API.Utils
{
    public class EmployeesDataStore
    {
        public List<EmployeeDto> Employees { get; set; }

        public EmployeesDataStore()
        {
            Employees = new()
            {
                new EmployeeDto
                {
                    Name = "Prashant Gadekar",
                    Designation = "Software Engineer",
                    ContactDetails = new List<ContactDto>
                    {
                        new ContactDto
                        {
                            MobileNumber = "8320644000",
                            EmailAddress = "prashant.gadekar@example.com"
                        },
                        new ContactDto
                        {
                            MobileNumber = "8300000000",
                            EmailAddress = "pgadekar@irth.com"
                        }
                    }
                },
                new EmployeeDto
                {
                    Name = "Vinayak Sawant",
                    Designation = "Product Manager",
                    ContactDetails = new List<ContactDto>
                    {
                        new ContactDto
                        {
                            MobileNumber = "9819177889",
                            EmailAddress = "vsawant@irth.com"
                        }
                    }
                }
            };
        }
    }
}
