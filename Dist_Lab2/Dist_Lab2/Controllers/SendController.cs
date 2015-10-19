using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        public ActionResult Index()
        {
            var users = UserLogic.GetAllUsers();
            var groups = UserGroupsLogic.GetGroups();

            var receiversList = new SelectList(
                users.ToList().Select(u => new SelectListItem {Value = u, Text = u})
                , "Value", "Text");
            var groupList = new SelectList(
                groups.ToList().Select(u => new SelectListItem {Value = u, Text = u})
                , "Value", "Text");

            var vm = new SendViewModels
            {
                Sender = User.Identity.GetUserName(),
                Receivers = receiversList,
                Groups = groupList
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(SendViewModels vm)
        {
            if (ModelState.IsValid)
            {
                var usersSelected = new List<string>();
                usersSelected.AddRange(UserLogic.GetAllUserIds(vm.ReceiversSelected));
                vm.GroupsSelected.ForEach(g => usersSelected.AddRange(UserGroupsLogic.GetMembersId(g)));
                var distinctUsers = usersSelected.Distinct();
                usersSelected = distinctUsers.ToList();

                // User must have selected a Receiver (Users or Groups or Both)
                if (usersSelected.Capacity == 0)
                {
                    return Index();
                }

                var msg = new Message
                {
                    SenderId = User.Identity.GetUserId(),
                    TimeSent = DateTime.Now,
                    Title = vm.Title,
                    Body = vm.Body
                };
                MessageLogic.Send(msg, usersSelected);
                var rc = new StringBuilder();
                vm.ReceiversSelected.ForEach(l => rc.Append(l + ", "));
                vm.GroupsSelected.ForEach(l => rc.Append(l + ", "));
                var receipt = new SuccessfulViewModels
                {
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