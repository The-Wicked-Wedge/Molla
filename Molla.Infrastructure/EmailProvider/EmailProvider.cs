using Molla.Application.DTOs;
using Molla.Infrastructure.persistence.Common;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Molla.Application.Interfaces.IPoviders;

namespace Molla.Infrastructure.EmailProvider
{
    public class EmailProvider(ApplicationDbContext context, UserManager<IdentityUser> userManager) : IEmailProvider
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly ApplicationDbContext _context = context;
        public async Task<bool> SendEmail(EmailDTO model)
        {
            MailAddress sender = new MailAddress("Molla.Sneakers@gmail.com");
            MailAddress receiver = new MailAddress(model.Reciever, "Receiver");
            string password = "dksw dvol zval hrls";
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
                    await smtp.SendMailAsync(mess);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> SendRegistrationCodeByEmail(string Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            Random rnd = new Random();
            int x = rnd.Next(999, 9999);
/*            user.RCode = x;*/
            await _context.SaveChangesAsync();
            var email = new EmailDTO()
            {
                Reciever = user.Email,
                Subject = "Verification Code",
                Body = "The Verification Code Is  : " + x.ToString()
            };
            try
            {
                await SendEmail(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
