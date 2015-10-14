using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        public ActionResult Index()
        {
            var users = UserLogic.GetAllUsers();
            var receivers = new SelectList(

               users.ToList().Select(u => new SelectListItem{ Value = u, Text = u })
            , "Value" , "Text");
            SendViewModels vm = new SendViewModels { Sender = (string)Session["Email"], Receivers = receivers };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(SendViewModels vm)
        {

                foreach (var r in vm.ReceiversSelected)
                {
                    Debug.WriteLine(r);
                }

                
            return Index();
        }

        public ActionResult Successfull()
        {
            return View();
        }
    }
}
