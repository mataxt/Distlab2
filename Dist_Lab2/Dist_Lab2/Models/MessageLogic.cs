using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dist_Lab2.Models
{
    public class MessageLogic
    {
        public static void Send(Message message)
        {
            using (var db = new ApplicationDbContext())
            {
                // Get Senders ID from their Username
                message.SenderId = db.Users.Where(usr => usr.UserName == message.SenderId).Select(u => u.Id).First();

                // Get Receivers ID from their Usernames
                var userIds = message.ReceiversId.Select(usr => db.Users.Where(u => u.UserName == usr).Select(u => u.Id).First()).ToList();
                message.ReceiversId = userIds;

                message.Receivers = new List<ApplicationUser>();
                foreach (var uId in message.ReceiversId)
                {
                    message.Receivers.Add(db.Users.First(u => u.Id == uId));
                }

                db.Messages.Add(message);
                db.SaveChanges();
            }
        }

        public static List<string> GetSenders(string userId)
        {
            List<string> senders;
            using (var db = new ApplicationDbContext())
            {
                // Get messages according to their User IDs
                senders = db.Messages.Where(msg => msg.Receivers.Any(usr => usr.Id == userId)).Select(msg => msg.SenderId).ToList();
            }
            
            return senders;
        }
    }
}