namespace ContactBook.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _mailTo = "pgadekar@irthsolutions.com";
        private readonly string _mailFrom = "pg@irthsolutions.com";

        public LocalMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailTo = _configuration["MailSettings:MailTo"] ?? _mailTo;
            _mailFrom = _configuration["MailSettings:MailFrom"] ?? _mailFrom;
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail sent to: {_mailTo}");
            Console.WriteLine($"From: {_mailFrom}, with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
