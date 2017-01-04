using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopDesign.Controllers
{
    public class ProductViewController : Controller
    {
        // GET: ProductView
        public ActionResult Index(int pageIndex = 1)
        {    
            return View();
        }
        public ActionResult ProductAll() {
            return View();

        }
        public ActionResult Productkind()
        {
            return View();
        }
         public ActionResult Detail()
        {
            return View();
        }
    }
}