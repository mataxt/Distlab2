using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModels vm = new HomeViewModels {
                LoggedInAs = User.Identity.GetUserName(),
                LastLogin = UserLogLogic.LastLoggedIn(User.Identity.GetUserName()),
                LoginAmount = UserLogLogic.LoggedLastMonth(User.Identity.GetUserName()),
                UnreadMessages = MessageLogic.GetMessageStats(User.Identity.GetUserId()).UnreadMessages
                };

            return View(vm);
        }
    }
}