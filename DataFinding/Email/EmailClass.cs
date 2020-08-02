using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DataFinding.Email
{
    public class EmailClass
    {

        public static void MailSend(string to, string body)
        {
            var fromAddress = new MailAddress("sridhargiri1@gmail.com", "From Name");
            var toAddress = new MailAddress(to, "To Name");
            const string fromPassword = "****";//put your password
            const string subject = "email alert";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}
