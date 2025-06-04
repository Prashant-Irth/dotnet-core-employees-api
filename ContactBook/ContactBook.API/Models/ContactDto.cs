namespace ContactBook.API.Models
{
    public class ContactDto
    {
        public Guid ContactId { get; set; } = Guid.NewGuid();
        public string MobileNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
    }
}
