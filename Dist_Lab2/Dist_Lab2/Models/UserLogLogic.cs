using System;
using System.Linq;

namespace Dist_Lab2.Models
{
    public class UserLogLogic
    {
        public static void MarkLog(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var log = new UserLogs
                {
                    UserId = db.Users.Where(u => u.Email.Equals(email)).Select(i => i.Id).First(),
                    LoggedAt = DateTime.Now
                };
                db.UserLogs.Add(log);
                db.SaveChanges();
            }
        }

        public static DateTime LastLoggedIn(string userId)
        {
            var lastlog = DateTime.Now;
            using (var db = new ApplicationDbContext())
            {
                var lastLogged =
                    db.UserLogs.Where(l => l.UserId.Equals(userId))
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

        public static int LoggedLastMonth(string userId)
        {
            int amount;
            var lastMonth = DateTime.Now.AddMonths(-1);
            using (var db = new ApplicationDbContext())
            {
                var amountLogged =
                    db.UserLogs.Where(l => l.UserId.Equals(userId) &&
                                           l.LoggedAt >= lastMonth)
                        .OrderByDescending(l => l.LoggedAt)
                        .Select(l => l.LoggedAt).Count();
                amount = amountLogged;
            }
            return amount;
        }
    }
}