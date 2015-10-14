using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        public ActionResult Index()
        {
            var users = UserLogic.GetAllUsers();
            var receivers = new SelectList(
            new List<SelectListItem>
            {
               new SelectListItem {Value = "mataxt@kth.se", Text = "mataxt@kth.se" }
            }, "Value" , "Text");
            SendViewModels vm = new SendViewModels { Sender = (string)Session["Email"], Receivers = receivers };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(SendViewModels vm)
        {
            foreach (var r in vm.Receivers)
            {
                Debug.WriteLine(r);
            }

            return Index();
        }
    }
}
