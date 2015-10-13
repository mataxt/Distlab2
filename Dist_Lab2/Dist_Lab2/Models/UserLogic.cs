using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Dist_Lab2.Models
{
    public class UserLogic
    {
        public static List<ApplicationUser> GetAllUsers()
        {
            var users = new List<ApplicationUser>();
            using (var db = new ApplicationDbContext())
            {
                var usernames = db.Users.Select(u => u.UserName).ToList();
                Debug.WriteLine(usernames);
                users.AddRange(usernames.Select(usr => new ApplicationUser {UserName = usr}));
            }
            return users;
        }
    }
}