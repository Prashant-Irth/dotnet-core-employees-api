namespace ContactBook.API.Models
{
    public class ContactDto
    {
        public int ContactId { get; set; } = Random.Shared.Next(1, 1000); // Example ID generation
        public string MobileNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
    }
}
