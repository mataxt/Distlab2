using Dist_Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.ViewModels
{
    public class InboxViewModels
    {
        public String Title { get; set; }
        public String Body { get; set; }
        public String ReceivedBy { get; set; }
        public DateTime TimeSent { get; set; }

        public InboxViewModels(String Title, String Body, String ReceivedBy, DateTime TimeSent)
        {
            this.Title = Title;
            this.Body = Body;
            this.ReceivedBy = ReceivedBy;
            this.TimeSent = TimeSent;
        }
    }
}