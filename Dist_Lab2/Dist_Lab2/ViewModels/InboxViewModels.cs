using System;
using System.Collections.Generic;

namespace Dist_Lab2.ViewModels
{
    public class InboxViewModels
    {
        public int TotalMessages { get; set; }
        public int ReadMessages { get; set; }
        public int RemovedMessages { get; set; }
        public List<string> Senders { get; set; }
    }

    public class InboxTitles
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
    }

    public class InboxMessageBody
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}