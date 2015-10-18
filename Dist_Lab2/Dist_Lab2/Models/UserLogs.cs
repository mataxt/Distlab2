using System;
using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.Models
{
    public class UserLogs
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LoggedAt { get; set; }
    }
}