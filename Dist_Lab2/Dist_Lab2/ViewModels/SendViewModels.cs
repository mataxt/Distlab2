using Dist_Lab2.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dist_Lab2.ViewModels
{
    public class SendViewModels
    {
        public string Sender { get; set; }
        public IEnumerable<SelectListItem> Receivers { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> ReceiversSelected { get; set; }
    }
}