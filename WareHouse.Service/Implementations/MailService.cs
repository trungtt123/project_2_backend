using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
using WareHouse.Service.Interfaces;

namespace WareHouse.Service.Implementations
{
    public class MailService : IMailService
    {
       
        public async Task<bool> SendMail(EmailFormDto emailForm, EmailAccountDto systemEmail) 
        {
            try
            {
                var message = new MailMessage(emailForm.emailFrom, emailForm.emailTo, emailForm.subject, emailForm.body);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.ReplyToList.Add(new MailAddress(emailForm.emailFrom));
                message.Sender = new MailAddress(emailForm.emailFrom);

                using var smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(systemEmail.emailAddress, systemEmail.password);
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
