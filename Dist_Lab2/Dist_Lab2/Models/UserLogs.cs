using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dist_Lab2.Models
{
    public class UserLogs
    {
        [Required]
        // Navigation property
        public virtual string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LoggedAt { get; set; }
    }
}