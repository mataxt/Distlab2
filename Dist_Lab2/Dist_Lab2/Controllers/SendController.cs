using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        public ActionResult Index()
        {
            var users = UserLogic.GetAllUsers();
            var receivers = new SelectList(
               users.ToList().Select(u => new SelectListItem { Value = u, Text = u })
            , "Value", "Text");
            SendViewModels vm = new SendViewModels { Sender = User.Identity.GetUserName(), Receivers = receivers };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(SendViewModels vm)
        {
            if (ModelState.IsValid)
            {
                
                var msg = new Message {
                    SenderId = User.Identity.GetUserName(),
                    ReceiversId = vm.ReceiversSelected,
                    Title = vm.Title,
                    Body = vm.Body };
                MessageLogic.Send(msg);
            }
            return Index();
        }

        public ActionResult Successfull()
        {
            return View();
        }
    }
}
