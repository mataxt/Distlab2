using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.Models
{
    public class UserGroups
    {
        [Required]
        public string GroupName { get; set; }

        //Navigation property
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}