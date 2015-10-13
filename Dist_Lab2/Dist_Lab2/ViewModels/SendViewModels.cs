using Dist_Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.ViewModels
{
    public class SendViewModels
    {
        public String Title { get; set; }
        public String Body { get; set; }
        public String SendTo { get; set; }

        public SendViewModels(String Title, String Body, String SendTo)
        {
            this.Title = Title;
            this.Body = Body;
            this.SendTo = SendTo;
        }
    }
}