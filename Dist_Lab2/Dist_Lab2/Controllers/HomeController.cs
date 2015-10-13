using Dist_Lab2.ViewModels;
using System.Web.Mvc;
using Dist_Lab2.Models;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModels(UserLogLogic.LastLoggedIn((string)Session["Username"]), UserLogLogic.LoggedLastMonth((string)Session["Username"]), 0));
        }
    }
}