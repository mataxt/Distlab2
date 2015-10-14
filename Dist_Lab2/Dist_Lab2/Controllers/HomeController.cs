﻿using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModels(UserLogLogic.LastLoggedIn("mataxt@kth.se"), UserLogLogic.LoggedLastMonth("mataxt@kth.se"), 0));
        }
    }
}