using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.Models
{
    public class MessageLogic
    {
        public static void Send(Message message)
        {
            message.TimeSent = DateTime.Now;
            message.Status = "UNREAD";
            using (var db = new ApplicationDbContext())
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
        }
    }
}