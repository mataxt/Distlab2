using System;
using Dist_Lab2.Models;

namespace Dist_Lab2.Logic
{
    public class UserLog
    {
        public static void MarkLog(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var log = new UserLogs() { UserEMail = email, LoggedAt = DateTime.Now };
                db.UserLogs.Add(log);
                db.SaveChanges();
            }
        }
    }
}