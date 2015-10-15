using System;
using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.ViewModels
{
    public class HomeViewModels
    {
        [Required]
        public string LoggedInAs { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LastLogin { get; set; }
        public int LoginAmount { get; set; }
        public int UnreadMessages { get; set; }
   }
}