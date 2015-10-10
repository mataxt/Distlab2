using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        [Required]
        public string Status { get; set; }

        //Navigation property
        public virtual ApplicationUser Sender { get; set; }
        //Navigation property
        public virtual ICollection<ApplicationUser> Receivers { get; set; }
    }
}