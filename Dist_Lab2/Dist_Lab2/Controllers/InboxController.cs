using System.Web.Mvc;
using Dist_Lab2.ViewModels;
using Microsoft.AspNet.Identity;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class InboxController : Controller
    {
        public ActionResult Index()
        {
            InboxViewModels.InboxSendersViewModels vm = new InboxViewModels.InboxSendersViewModels
            {
                Senders = "Sender",
                SendersList = Models.MessageLogic.GetSenders(User.Identity.GetUserId())
            };

            return View(vm);
        }
    }
}
