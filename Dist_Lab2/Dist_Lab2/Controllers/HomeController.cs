using Dist_Lab2.Logic;
using Dist_Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModels(UserLog.LastLoggedIn("mataxt@kth.se"),UserLog.LoggedLastMonth("mataxt@kth.se"),0));
        }
    }
}