using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReservationDataLogic;

namespace STSBusinessDataLogic
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Reservation", "reservation@test.com"));
            message.To.Add(new MailboxAddress("Reservation testing", "user@example.com"));
            message.Subject = "Seoul House";
            message.Body = new TextPart("plain")
            {

                Text = $"Reservation made successfully!"
            };
            using (var client = new SmtpClient())
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHost, smtpPort, tls);

                var userName = _configuration["EmailSettings:SmtpUsername"];
                var password = _configuration["EmailSettings:SmtpPassword"];

                client.Authenticate(userName, password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}