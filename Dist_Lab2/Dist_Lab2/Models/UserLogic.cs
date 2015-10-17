
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

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

        public static List<string> GetAllUserIds(ICollection<string> users)
        {
            List<string> userIds = new List<string>();
            using (var db = new ApplicationDbContext())
            {
                users.ForEach(u => userIds.Add(db.Users.Where(l => l.UserName.Equals(u)).Select(a => a.Id).First()));
            }

            return userIds;
        }
    }
}