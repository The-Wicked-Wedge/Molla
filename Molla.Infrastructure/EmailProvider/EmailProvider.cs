using Molla.Application.DTOs;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Molla.Infrastructure.EmailProvider
{
    public class EmailProvider : IEmailProvider
    {
        private readonly ApplicationDbContext _context;
        public EmailProvider(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SendEmail(EmailDTO model)
        {
            MailAddress sender = new MailAddress("Molla.Sneakers@gmail.com");
            MailAddress receiver = new MailAddress(model.Reciever, "Receiver");
            string password = "9092301030";
            string sub = model.Subject;
            string body = model.Body + $"\n{DateTime.Now}\n your account activated";
/*            Attachment attachment;
            attachment = new Attachment();*/
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender.Address, password)
            };
            using (var mess = new MailMessage(sender, receiver)
            {
                Subject = sub,
                Body = body
            })
            {
                try
                {
                    smtp.Send(mess);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public Task<bool> SendRegistrationCodeByEmail()
        {
            throw new NotImplementedException();
        }
    }
}
