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
        //[Display(Name = "Message Number")]
        public int MessageId { get; set; }
        [Required]
        [MaxLength(128)]
        //[StringLength(128, ErrorMessage = "Maximum length is 128 characters")]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Timestamp]
        //[Display(Name = "Date Sent")]
        //[DisplayFormat(DataFormatString = "{HH:mm 0:yyyy-MM-dd}")]
        public byte[] TimeSent { get; set; }
        [Required]
        public string Status { get; set; }

        //Navigation property
        public virtual ApplicationUser Sender { get; set; }
        //Navigation property
        public virtual ICollection<ApplicationUser> Receivers { get; set; }
    }
}