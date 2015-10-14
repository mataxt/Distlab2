using System;
using System.ComponentModel.DataAnnotations;

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