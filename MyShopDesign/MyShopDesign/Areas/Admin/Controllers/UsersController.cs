using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int Id)
        {
            return RedirectToAction("index");
        }

        public ActionResult ResetPassword(int Id)
        {
            return RedirectToAction("index");
        }
    }
}