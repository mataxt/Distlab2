using System;
using System.Collections.Generic;

namespace Dist_Lab2.ViewModels
{
    public class InboxViewModels
    {
        public List<string> Senders { get; set; }
    }

    public class InboxTitles
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
    }
}