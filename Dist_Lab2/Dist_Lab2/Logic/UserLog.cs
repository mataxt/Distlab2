using System;
using System.Diagnostics;
using System.Linq;
using Dist_Lab2.Models;

namespace Dist_Lab2.Logic
{
    public class UserLog
    {
        public static void MarkLog(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var log = new UserLogs() { UserEmail = email, LoggedAt = DateTime.Now};
                db.UserLogs.Add(log);
                db.SaveChanges();
            }
        }

        public static DateTime LastLoggedIn(string email)
        {
            DateTime lastlog = DateTime.Now;
            using (var db = new ApplicationDbContext())
            {
                var lastLogged =
                    db.UserLogs.Where(l => l.UserEmail.Equals(email))
                        .OrderByDescending(l => l.LoggedAt)
                        .Select(l => l.LoggedAt).ToList().Skip(1).FirstOrDefault();

                // Record ONLY If it's NOT the users first time, and has no previous logs
                if (!lastLogged.ToString().Equals("0001-01-01 00:00:00"))
                {
                    lastlog = lastLogged;    
                }
            }
                return lastlog;
        }

        public static int LoggedLastMonth(string email)
        {
            int amount = 1;
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            using (var db = new ApplicationDbContext())
            {
                var amountLogged =
                    db.UserLogs.Where(l => l.UserEmail.Equals(email)&& 
                        l.LoggedAt >= lastMonth)
                        .OrderByDescending(l => l.LoggedAt)
                        .Select(l => l.LoggedAt).Count();
                amount = amountLogged;
            }
            Debug.WriteLine(amount);
            return amount;
        }
    }
}