using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBook.API.Entities
{
    /// <summary>
    /// DATABASE SETUP:
    /// STEP 1: Creating Employee Entity with required properties.
    /// </summary>
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public string Designation { get; set; } = string.Empty;

        public List<Contact> ContactDetails { get; set; } = [];
    }
}
