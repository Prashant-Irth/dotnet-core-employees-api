using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class EmployeeUpdationDto
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Designation cannot be empty")]
        public string Designation { get; set; } = string.Empty;

        public List<ContactDto> ContactDetails { get; set; } = [];
    }
}
