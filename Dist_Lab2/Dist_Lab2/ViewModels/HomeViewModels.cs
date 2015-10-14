using System;

namespace Dist_Lab2.ViewModels
{
    public class HomeViewModels
    {
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