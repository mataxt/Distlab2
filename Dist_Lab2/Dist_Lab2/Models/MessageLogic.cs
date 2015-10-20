using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace Dist_Lab2.Models
{
    public class MessageLogic
    {
        public static void Send(Message message,List<string> receivers)
        {
            using (var db = new ApplicationDbContext())
            {
                receivers.ForEach(uId => db.MessagesSent.Add(new MessageUser { Message = message, User = db.Users.First(d=> d.Id == uId), Status = "UNREAD"}));
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
                var sendersId =
                    db.Messages.Where(m => db.MessagesSent.Any(usr => usr.UserId.Equals(userId) && !usr.Status.Equals("REMOVED") && m.MessageId.Equals(usr.MessageId)))
                        .Select(msg => msg.SenderId)
                        .ToList();
                senders =
                    sendersId.Select(usr => db.Users.Where(u => u.Id == usr).Select(u => u.UserName).First())
                        .Distinct()
                        .ToList();
            }
            return senders;
        }

        public static string GetMessageTitle(int? messageId)
        {
            string msgTitle;
            using (var db = new ApplicationDbContext())
            {
                msgTitle = db.Messages.Find(messageId).Title;
            }
            return msgTitle;
        }

        public static List<MessageHeader> ListMessageTitles(string userId, string sender)
        {
            var msgTitles = new List<MessageHeader>();
            using (var db = new ApplicationDbContext())
            {
                var sendersId = db.Users.Where(usr => usr.UserName == sender).Select(u => u.Id).First();
                msgTitles.AddRange(
                    db.Messages.Where(m => m.SenderId == sendersId &&
                            db.MessagesSent.Any(d => d.MessageId.Equals(m.MessageId)&& d.UserId.Equals(userId) && !d.Status.Equals("REMOVED")))
                        .OrderByDescending(a => a.TimeSent)
                        .Select(
                            n =>
                                new MessageHeader
                                {
                                    MessageId = n.MessageId,
                                    Title = n.Title,
                                    TimeSent = n.TimeSent,
                                })
                        .ToList());
                msgTitles.ForEach(t => t.Status = db.MessagesSent.First(d => d.MessageId.Equals(t.MessageId) && d.UserId.Equals(userId)).Status);
            }
          
            return msgTitles;
        }


        public static string GetMessageBody(string userId, int? messageId)
        {
            string msgBody;
            using (var db = new ApplicationDbContext())
            {
                msgBody = db.Messages.Find(messageId).Body;
                db.MessagesSent.First(u => u.MessageId == messageId && u.UserId == userId).Status = "READ";
                db.SaveChanges();
            }
            return msgBody;
        }

        public static MessageStatistics GetMessageStats(string userId)
        {
            var msgStats = new MessageStatistics();
            using (var db = new ApplicationDbContext())
            {
                msgStats.TotalMessages = db.MessagesSent.Count(usr => usr.UserId.Equals(userId));
                msgStats.UnreadMessages =
                    db.MessagesSent.Count(msg => msg.Status.Equals("UNREAD") && msg.UserId.Equals(userId));
                msgStats.ReadMessages =
                    db.MessagesSent.Count(msg => msg.Status.Equals("READ") && msg.UserId.Equals(userId));
                msgStats.RemovedMessages =
                    db.MessagesSent.Count(msg => msg.Status.Equals("REMOVED") && msg.UserId.Equals(userId));
            }
            return msgStats;
        }

        public static void MarkedAsRead(string userId, IEnumerable<int> messageIds)
        {
            using (var db = new ApplicationDbContext())
            {
                messageIds.ForEach(m => db.MessagesSent.First(u => u.MessageId.Equals(m) && u.UserId.Equals(userId)).Status = "READ");
                db.SaveChanges();
            }
        }

        public static void RemoveMessage(string userId, IEnumerable<int> messageIds)
        {
            using (var db = new ApplicationDbContext())
            {
                messageIds.ForEach(m => db.MessagesSent.First(u => u.MessageId.Equals(m) && u.UserId.Equals(userId)).Status = "REMOVED");
                db.SaveChanges();
            }
        }
    }
}