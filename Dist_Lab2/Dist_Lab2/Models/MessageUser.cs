
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dist_Lab2.Models
{
    public class MessageUser
    {
        [Key, Column(Order = 0)]
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Status { get; set; }
    }
}