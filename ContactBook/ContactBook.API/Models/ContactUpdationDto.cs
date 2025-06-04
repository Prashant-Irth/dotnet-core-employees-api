using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class ContactUpdationDto
    {
        [Required(ErrorMessage = "Mobile Number cannot be empty")]
        [Phone]
        public string MobileNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address cannot be empty")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
