using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        public ActionResult Index()
        {
            var groups = UserGroupsLogic.GetGroups();
            var vm = new List<GroupsViewModels> {new GroupsViewModels {GroupName = "", GroupMemberAmount = 0}};
            groups.ToList().ForEach(l => vm.Add(
                new GroupsViewModels
                {
                    GroupName = l,
                    GroupMemberAmount = UserGroupsLogic.GetMembersAmount(l),
                    IsMember = UserGroupsLogic.IsMember(User.Identity.GetUserId(), l)
                }));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(GroupsViewModels vm, string submit)
        {
            if (submit != null)
            {
                if (!UserGroupsLogic.GroupExists(vm.GroupName))
                {
                    UserGroupsLogic.JoinGroup(User.Identity.GetUserId(), vm.GroupName);
                }
            }

            return Index();
        }

        public ActionResult Join(string grp)
        {
            if (grp == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                UserGroupsLogic.JoinGroup(User.Identity.GetUserId(), grp);
            }
            catch (DbUpdateException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult Leave(string grp)
        {
            if (grp == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                UserGroupsLogic.LeaveGroup(User.Identity.GetUserId(), grp);
            }
            catch (InvalidOperationException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}