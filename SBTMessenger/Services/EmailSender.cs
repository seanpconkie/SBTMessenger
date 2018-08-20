using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using SBTMessenger.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace SBTMessenger.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(Message message)
        {
            return Execute(Options.SendGridKey, message);
        }

        public Task Execute(string apiKey, Message message)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(message.FromEmail),
                Subject = message.Subject,
                PlainTextContent = message.MessageContent,
                HtmlContent = message.MessageContent
            };
            msg.AddTo(new EmailAddress(message.Email));
            return client.SendEmailAsync(msg);
        }
    }
}
