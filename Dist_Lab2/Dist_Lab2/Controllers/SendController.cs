
using System.Collections;
using System.Diagnostics;
using System.Web.Mvc;
using Dist_Lab2.Models;
using Dist_Lab2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            List<ApplicationUser> userList = UserLogic.GetAllUsers();
            List<SelectListItem> selectListItems = userList.Select(usr => new SelectListItem
            {
                Text = usr.UserName, Value = usr.UserName
            }).ToList();

            return View(new SendViewModels { Sender = (string)Session["Username"], Receivers = selectListItems});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SendViewModels model)
        {
            ApplicationUser sender = new ApplicationUser { UserName = (string)Session["Username"] };
            List<ApplicationUser> receivers = model.Receivers.Select(rcv => new ApplicationUser { UserName = rcv.Value }).ToList();
            Message msg = new Message { Sender = sender, Receivers = receivers, Title = model.Title, Body = model.Body };
            MessageLogic.Send(msg);
            return View(new SendViewModels());
        }



    }
}
