/// <summary>
/// This model is used to list statistics about the users messages.
/// </summary>
namespace Dist_Lab2.Models
{
    public class MessageStatistics
    {
        public int TotalMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int ReadMessages { get; set; }
        public int RemovedMessages { get; set; }
    }
}