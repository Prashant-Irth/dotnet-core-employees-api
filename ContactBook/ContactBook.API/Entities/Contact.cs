using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBook.API.Entities
{
    /// <summary>
    /// DATABASE SETUP:
    /// STEP 2: Creating Employee Entity with required properties.
    /// </summary>
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required]
        public required string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; } = null;
        public int EmployeeId { get; set; }
    }
}
