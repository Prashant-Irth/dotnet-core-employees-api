namespace ContactBook.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "pgadekar@irthsolutions.com";
        private string _mailFrom = "pg@irthsolutions.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail sent to: {_mailTo}");
            Console.WriteLine($"From: {_mailFrom}, with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
