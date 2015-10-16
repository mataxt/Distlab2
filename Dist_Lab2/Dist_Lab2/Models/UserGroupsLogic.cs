using System.Collections.Generic;
using System.Linq;

namespace Dist_Lab2.Models
{
    public class UserGroupsLogic
    {
        public static List<string> GetGroups()
        {
            List<string> grpName;
            using (var db = new ApplicationDbContext())
            {
                grpName = db.UserGroups.Select(l => l.GroupName).Distinct().ToList();
            }
            return grpName;
        }

        public static int GetMembersAmount(string groupName)
        {
            int members;
            using (var db = new ApplicationDbContext())
            {
                members = db.UserGroups.Count(l => l.GroupName.Equals(groupName));
            }
            return members;
        }

        public static void JoinGroup(string userId,string groupName)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserGroups.Add(new UserGroups
                {
                    GroupName = groupName,
                    UserId = userId
                });
                db.SaveChanges();
            }
        }
    }
}