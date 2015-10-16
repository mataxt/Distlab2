using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class InboxController : Controller
    {
        public ActionResult Index()
        {
            var vm = new InboxViewModels
            {
                TotalMessages = MessageLogic.GetMessageStats(User.Identity.GetUserId()).TotalMessages,
                ReadMessages = MessageLogic.GetMessageStats(User.Identity.GetUserId()).ReadMessages,
                RemovedMessages = MessageLogic.GetMessageStats(User.Identity.GetUserId()).RemovedMessages,
                Senders = MessageLogic.GetSenders(User.Identity.GetUserId())

            };

            return View(vm);
        }

        public ActionResult Messages(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var titles = MessageLogic.ListMessageTitles(username);
            var vm = new List<InboxTitles>();
            titles.ToList().ForEach(t => vm.Add(
                new InboxTitles
                {
                    MessageId = t.MessageId,
                    Title = t.Title,
                    Time = t.TimeSent,
                    Status = t.Status,
                    Selected = false
                }));
            return View(vm);

        }

        [HttpPost]
        public ActionResult Messages(IEnumerable<InboxTitles> selected)
        {
            selected?.ToList().ForEach(l => Debug.WriteLineIf(l != null, "HERE: " + l));
            return RedirectToAction("Index", "Home");

        }

        public ActionResult MessageContent(int? messageId)
        {
            if (messageId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new InboxMessageBody { Title = MessageLogic.GetMessageTitle(messageId), Body = MessageLogic.GetMessageBody(messageId) };

            return View(vm);

        }
    }
}
