﻿using System.Collections.Generic;
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
            titles.ToList().ForEach(t => vm.Add(new InboxTitles {Title = t.Title, Time = t.TimeSent}));
            return View(vm);

        }
    }
}
