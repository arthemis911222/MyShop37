using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class WorkersController : Controller
    {
        // GET: Admin/Workers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddSave()
        {
            return RedirectToAction("index");
        }

        public ActionResult Delete(int Id)
        {
            return RedirectToAction("index");
        }

        public ActionResult Edit(int Id)
        {
            return View();
        }

        public ActionResult EditSave()
        {
            return RedirectToAction("index");
        }

    }
}