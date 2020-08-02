using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System;
using DataFinding;
using DataFinding.Email;
using System.Linq;

namespace Examples.SmtpExamples.Async
{
    public class SimpleAsynchronousExample
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
        public static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            var now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            if (DateTime.Now == DateTime.UtcNow)
            {
                var list = dataAccess.GetEmailsToSend();
                if (list!=null)
                {
                    foreach (var item in list)
                    {
                        EmailClass.MailSend(item.EmailAddress, "Welcome , please click the <a href='https://localhost:44388/useremail/" + item.EmailAddress + "'>link</a>");
                        dataAccess.SetSentDate(item.EmailAddress);
                    } 
                }
                var remlist = list.Where(p => p.SentDate != DateTime.MinValue && p.SentDate != DateTime.Today && (DateTime.Today - p.SentDate).Days <= 3).ToList();
                if (remlist!=null)
                {
                    foreach (var reminder in remlist)
                    {
                        EmailClass.MailSend(reminder.EmailAddress, "Reminder!, please click the <a href='https://localhost:44388/useremail/" + reminder.EmailAddress + "'>link</a>");

                    }
                }
            }
        }
    }
}