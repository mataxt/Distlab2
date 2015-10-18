using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dist_Lab2.ViewModels
{
    public class SendViewModels
    {
        [Required]
        public string Sender { get; set; }

        public IEnumerable<SelectListItem> Receivers { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public ICollection<string> GroupsSelected { get; set; }
        public ICollection<string> ReceiversSelected { get; set; }
    }

    public class SuccessfulViewModels
    {
        public int MessageNumber { get; set; }
        public DateTime TimeSent { get; set; }
        public string ReceiversSent { get; set; }
    }
}