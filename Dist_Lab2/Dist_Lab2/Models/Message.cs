using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeSent { get; set; }

        //Navigation property
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        //Navigation property
        public virtual ICollection<MessageUser> MessageUser { get; set; }
    }
}