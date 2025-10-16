using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSBusinessDataLogic
{
    public class EmailService
    {
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
                var smtpHost = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHost, smtpPort, tls);

                var userName = "63d24222eb6a32";
                var password = "b8cd7662f3667c";

                client.Authenticate(userName, password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}