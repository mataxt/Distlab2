
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            var vm = new List<GroupsViewModels>();
            groups.ToList().ForEach(l => vm.Add(new GroupsViewModels {GroupName = l, GroupMemberAmount = UserGroupsLogic.GetMembersAmount(l)}));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(GroupsViewModels vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserGroupsLogic.JoinGroup(User.Identity.GetUserId(), vm.GroupName);
                }
                catch (DbUpdateException)
                {
                    return Index();
                }
                
            }
            return Index();
        }
    }
}
