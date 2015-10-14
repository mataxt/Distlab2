using System;
using System.ComponentModel.DataAnnotations;

namespace Dist_Lab2.ViewModels
{
    public class HomeViewModels
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LastLogin { get; set; }
        public int LoginAmount { get; set; }
        public int UnreadMessages { get; set; }

        public HomeViewModels(DateTime LastLogin, int LoginAmount, int UnreadMessages)
        {
            this.LastLogin = LastLogin;
            this.LoginAmount = LoginAmount;
            this.UnreadMessages = UnreadMessages;
        }
   }
}