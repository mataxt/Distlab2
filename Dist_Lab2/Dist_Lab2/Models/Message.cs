using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;


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
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        //Navigation property
        public ICollection<string> ReceiversId { get; set; }
        public virtual ICollection<ApplicationUser> Receivers { get; set; }
    }
}