using System;
using System.Collections.Generic;
using System.Linq;
using DataFinding.SurveyModel;
using Microsoft.Extensions.FileProviders;

namespace DataFinding
{
    public class DataAccess
    {
        public void SetStatus(string email)
        {
            using (var context = new SurveyDataContext())
            {
                var found = context.EmailData.Where(x => x.EmailAddress == email).FirstOrDefault();
                if (found != null)
                {
                    found.IsViewed = true;
                    context.SaveChanges();
                }
            }

        }
        public void SetSentDate(string email)
        {
            using (var context = new SurveyDataContext())
            {
                var found = context.EmailData.Where(x => x.EmailAddress == email).FirstOrDefault();
                if (found != null)
                {
                    found.SentDate = DateTime.Today;
                    context.SaveChanges();
                }
            }

        }
        public IEnumerable<EmailData> GetEmailsToSend()
        {
            using (var context = new SurveyDataContext())
            {
                var found = context.EmailData.Where(x => !x.IsViewed).ToList();
                return found;
            }
        }
        public IEnumerable<EmailData> GetReminderEmails()
        {
            using (var context = new SurveyDataContext())
            {
                var found = context.EmailData.Where(x => !x.IsViewed && (x.SentDate !=DateTime.MinValue) && (x.SentDate <= DateTime.Today.AddDays(3))).ToList();
                return found;
            }
        }
    }
}
