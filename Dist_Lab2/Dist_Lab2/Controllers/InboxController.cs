using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dist_Lab2.Controllers
{
    public class InboxController : Controller
    {
        // GET: Inbox
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inbox/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inbox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inbox/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inbox/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inbox/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inbox/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inbox/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
