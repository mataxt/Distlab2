using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace Dist_Lab2.Models
{
    public class MessageLogic
    {
        public static void Send(Message message)
        {
            using (var db = new ApplicationDbContext())
            {
                //// Get Senders ID from their Username
                //message.SenderId = db.Users.Where(usr => usr.UserName == message.SenderId).Select(u => u.Id).First();

                //// Get Receivers ID from their Usernames
                //var userIds = message.ReceiversId.Select(usr => db.Users.Where(u => u.UserName == usr).Select(u => u.Id).First()).ToList();
                //message.ReceiversId = userIds;

                message.Receivers = new List<ApplicationUser>();
                message.ReceiversId.ForEach(uId => message.Receivers.Add(db.Users.First(u => u.Id == uId)));
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
                    db.Messages.Where(msg => msg.Receivers.Any(usr => usr.Id == userId))
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

        public static List<MessageHeader> ListMessageTitles(string username)
        {
            var msgTitles = new List<MessageHeader>();
            using (var db = new ApplicationDbContext())
            {
                var sendersId = db.Users.Where(usr => usr.UserName == username).Select(u => u.Id).First();
                msgTitles.AddRange(
                    db.Messages.Where(m => m.SenderId == sendersId && !m.Status.Equals("REMOVED"))
                        .OrderByDescending(a => a.TimeSent)
                        .Select(
                            n =>
                                new MessageHeader
                                {
                                    MessageId = n.MessageId,
                                    Title = n.Title,
                                    TimeSent = n.TimeSent,
                                    Status = n.Status
                                })
                        .ToList());
            }
            return msgTitles;
        }


        public static string GetMessageBody(int? messageId)
        {
            string msgBody;
            using (var db = new ApplicationDbContext())
            {
                msgBody = db.Messages.Find(messageId).Body;
                db.Messages.Find(messageId).Status = "READ";
                db.SaveChanges();
            }
            return msgBody;
        }

        public static MessageStatistics GetMessageStats(string userId)
        {
            var msgStats = new MessageStatistics();
            using (var db = new ApplicationDbContext())
            {
                msgStats.TotalMessages = db.Messages.Count(msg => msg.Receivers.Any(usr => usr.Id == userId));
                msgStats.UnreadMessages =
                    db.Messages.Count(msg => msg.Status.Equals("UNREAD") && msg.Receivers.Any(usr => usr.Id == userId));
                msgStats.ReadMessages =
                    db.Messages.Count(msg => msg.Status.Equals("READ") && msg.Receivers.Any(usr => usr.Id == userId));
                msgStats.RemovedMessages =
                    db.Messages.Count(msg => msg.Status.Equals("REMOVED") && msg.Receivers.Any(usr => usr.Id == userId));
            }
            return msgStats;
        }

        public static void MarkedAsRead(IEnumerable<int> messageIds)
        {
            using (var db = new ApplicationDbContext())
            {
                messageIds.ToList().ForEach(m => db.Messages.Find(m).Status = "READ");
                db.SaveChanges();
            }
        }

        public static void RemoveMessage(IEnumerable<int> messageIds)
        {
            using (var db = new ApplicationDbContext())
            {
                messageIds.ToList().ForEach(m => db.Messages.Find(m).Status = "REMOVED");
                db.SaveChanges();
            }
        }
    }
}