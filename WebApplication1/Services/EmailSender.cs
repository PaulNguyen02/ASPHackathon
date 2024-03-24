using System.Net.Mail;
using System.Net;

namespace WebEnvironment_Hackathon_GaMo.Services
{
    public class EmailSender
    {
        public IConfiguration _configuration { get; }
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string email, string subject, string HtmlMessage)
        {
            using (MailMessage mm = new MailMessage(_configuration["NetMail:sender"], email))
            {
                mm.Subject = subject;
                string body = HtmlMessage;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _configuration["NetMail:smtpHost"];
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(_configuration["NetMail:sender"], _configuration["NetMail:senderpassword"]);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }
    }
}
