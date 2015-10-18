using System.Web.Mvc;
using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new HomeViewModels
            {
                LoggedInAs = User.Identity.GetUserName(),
                LastLogin = UserLogLogic.LastLoggedIn(User.Identity.GetUserId()),
                LoginAmount = UserLogLogic.LoggedLastMonth(User.Identity.GetUserId()),
                UnreadMessages = MessageLogic.GetMessageStats(User.Identity.GetUserId()).UnreadMessages
            };

            return View(vm);
        }
    }
}