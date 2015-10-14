using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    [Authorize]
    public class SendController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
