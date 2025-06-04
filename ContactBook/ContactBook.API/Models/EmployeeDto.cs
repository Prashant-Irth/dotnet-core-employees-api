namespace ContactBook.API.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public List<ContactDto> ContactDetails { get; set; } = [];
    }
}
