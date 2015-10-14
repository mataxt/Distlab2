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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public List<string> ReceiversSelected { get; set; }
    }
}