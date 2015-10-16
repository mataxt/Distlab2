using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dist_Lab2.ViewModels;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        public ActionResult Index()
        {
            GroupsViewModels vm = new GroupsViewModels()
            {
                GroupsName = "Test",
                GroupsMemberAmount = 0
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(GroupsViewModels vm)
        {
            return Index();
        }
    }
}
