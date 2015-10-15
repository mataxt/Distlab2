using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Diagnostics;
using System.Text;

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
                var msg = new Message
                {
                    SenderId = User.Identity.GetUserName(),
                    ReceiversId = vm.ReceiversSelected,
                    TimeSent = DateTime.Now,
                    Title = vm.Title,
                    Body = vm.Body,
                    Status = "UNREAD"
                };
                MessageLogic.Send(msg);
                var rc = new StringBuilder();
                vm.ReceiversSelected.ToList().ForEach(l => rc.Append(l + ", "));
                var receipt = new SuccessfulViewModels {
                    MessageNumber = msg.MessageId,
                    TimeSent = msg.TimeSent,
                    ReceiversSent = rc.ToString()
                };
                return RedirectToAction("Successful", "Send", receipt);
            }
            return Index();
        }

        public ActionResult Successful(SuccessfulViewModels svm)
        {

            return View(svm);
        }
    }
}
