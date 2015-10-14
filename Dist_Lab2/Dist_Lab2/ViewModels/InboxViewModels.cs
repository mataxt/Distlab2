using Dist_Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.ViewModels
{
    public class InboxViewModels
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime TimeSent { get; set; }

        public InboxViewModels(string Title, string Body, string ReceivedBy, DateTime TimeSent)
        {
            this.Title = Title;
            this.Body = Body;
            this.ReceivedBy = ReceivedBy;
            this.TimeSent = TimeSent;
        }
    }
}