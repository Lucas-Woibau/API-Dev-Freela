using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DevFreela.Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _client;

        private readonly string _fromEmail;
        private readonly string _fromName;
        public EmailService(ISendGridClient client, IConfiguration configuration)
        {
            _client = client;
            _fromEmail = configuration.GetValue<string>("SendGrid:FromEmail") ?? "";
            _fromName = configuration.GetValue<string>("SendGrid:FromName") ?? "";
        }

        public async Task SendAsync(string email, string subject, string message)
        {
            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
            };

            sendGridMessage.AddContent(MimeType.Text, message);
            sendGridMessage.AddTo(new EmailAddress(email));

            var response = await _client.SendEmailAsync(sendGridMessage);
        }
    }
}
