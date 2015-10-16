
using System;

namespace Dist_Lab2.Models
{
    public class MessageHeader
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public DateTime TimeSent { get; set; }
        public string Status { get; set; }
    }
}