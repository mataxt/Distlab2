using System.Collections.Generic;
using System.Linq;
/// <summary>
/// This class is responsible for methods concerning usergroups which requires 
/// a database connection
/// </summary>
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

        public static List<string> GetMembersId(string groupName)
        {
            List<string> users;
            using (var db = new ApplicationDbContext())
            {
                users = db.UserGroups.Where(g => g.GroupName.Equals(groupName)).Select(l => l.UserId).ToList();
            }
            return users;
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

        public static bool GroupExists(string groupName)
        {
            bool exists;
            using (var db = new ApplicationDbContext())
            {
                exists = db.UserGroups.Any(l => l.GroupName == groupName);
            }
            return exists;
        }

        public static bool IsMember(string userId, string groupName)
        {
            bool isMember;
            using (var db = new ApplicationDbContext())
            {
                isMember = db.UserGroups.Any(l => l.UserId.Equals(userId) && l.GroupName.Equals(groupName));
            }
            return isMember;
        }

        public static void JoinGroup(string userId, string groupName)
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

        public static void LeaveGroup(string userId, string groupName)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserGroups.Remove(db.UserGroups.Single(g => g.GroupName.Equals(groupName) && g.UserId.Equals(userId)));
                db.SaveChanges();
            }
        }
    }
}