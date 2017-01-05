using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopDesign.Models;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        MyShopEntities db = new MyShopEntities();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoginCheck(string Name, string password)
        {
            IEnumerable<T_Shop_Workers> workers = db.T_Shop_Workers.Where(m => m.Name.Equals(Name));
            if (workers.Count() == 0)
            {
                return Json(new { code = 2, message = "用户不存在" }, JsonRequestBehavior.AllowGet);
            }
            else if (workers.First().Password == password)
            {
                Session["person"] = workers.First();
                return Json(new { code = 1, message = "登录成功" }, JsonRequestBehavior.AllowGet );
        }
            else
            {
                return Json(new { code = 3, message = "密码错误"}, JsonRequestBehavior.AllowGet );
            }
        }

        public ActionResult Login()
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            return View();
        }
    }
}