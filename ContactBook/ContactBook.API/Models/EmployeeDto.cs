namespace ContactBook.API.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; } = Random.Shared.Next(1, 1000); // Example ID generation
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public List<ContactDto> ContactDetails { get; set; } = [];
    }
}
