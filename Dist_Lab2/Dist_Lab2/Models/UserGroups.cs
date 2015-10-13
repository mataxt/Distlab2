using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.Models
{
    public class UserGroups
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        //Navigation property
        public virtual string GroupMembers { get; set; }
    }
}