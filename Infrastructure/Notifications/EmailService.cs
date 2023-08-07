using Application.Interfaces;
using Application.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly Configuration configuration;
        public EmailService(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public bool SendEmail(EmailModel emailModel)
        {        
            bool result = false;
            try
            {
                using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress(emailModel.To));
                    message.From = new MailAddress(emailModel.From, emailModel.FromName);

                    message.Subject = emailModel.Subject;
                    message.Body = emailModel.Body;
                    message.IsBodyHtml = emailModel.IsBodyHtml;
                    //using (var smptClient = new SmtpClient(configuration.Smtp.Client))
                    //{
                    //    smptClient.Port = configuration.Smtp.Port;
                    //    smptClient.Credentials = new NetworkCredential(configuration.Smtp.UserName, configuration.Smtp.Password);
                    //    smptClient.EnableSsl = configuration.Smtp.Ssl;
                    //    smptClient.Send(message);
                    //}
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
