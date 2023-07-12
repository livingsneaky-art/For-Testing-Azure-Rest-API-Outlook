using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string recipient, string subject, string body)
        {
            using (var smtpClient = new SmtpClient("smtp-mail.outlook.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("hrautomatesystem@outlook.com", "alliance2023");

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("hrautomatesystem@outlook.com");
                    mailMessage.To.Add(recipient);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}
