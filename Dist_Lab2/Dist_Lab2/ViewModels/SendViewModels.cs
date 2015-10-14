using Dist_Lab2.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dist_Lab2.ViewModels
{
    public class SendViewModels
    {
        public string SentBy { get; set; }
        public IEnumerable<SelectListItem> Receivers { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string SendTo { get; set; }

        public SendViewModels(string Title, string Body, string SendTo)
        {
            this.Title = Title;
            this.Body = Body;
            this.SendTo = SendTo;
        }
    }
}