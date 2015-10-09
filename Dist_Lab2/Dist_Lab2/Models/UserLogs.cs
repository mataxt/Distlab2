using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dist_Lab2.Models
{
    public class UserLogs
    {
        [Key]
        public int LogId { get; set; }
        [Required]
        //Navigation property
        public virtual ApplicationUser User { get; set; }

        [Timestamp] 
        public byte[] LoggedAt { get; set; }
    }
}