
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Dist_Lab2.Models;

namespace Dist_Lab2.ViewModels
{
    public class SendViewModels
    {
        public string Sender { get; set; }
        public IEnumerable<SelectListItem> Receivers { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}