using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.ViewModels
{
    public class GroupsViewModels
    {
        [Required]
        public string GroupName { get; set; }
        public int GroupMemberAmount { get; set; }
        public bool IsMember { get; set; }
    }
}