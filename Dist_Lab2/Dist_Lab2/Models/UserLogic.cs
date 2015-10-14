using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.Models
{
    public class UserLogic
    {
        public static List<string> GetAllUsers()
        {
            List<string> usernames;
            using (var db = new ApplicationDbContext())
            {
                usernames =
                    db.Users
                        .OrderByDescending(l => l.UserName)
                        .Select(l => l.UserName).ToList();
            }

            return usernames;
        }
    }
}