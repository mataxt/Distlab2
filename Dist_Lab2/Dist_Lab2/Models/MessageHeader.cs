using System;
/// <summary>
/// This model is used to get information about the message
/// </summary>
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