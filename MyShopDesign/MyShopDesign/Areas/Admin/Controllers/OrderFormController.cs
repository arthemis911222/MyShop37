using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopDesign.Models;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class OrderFormController : Controller
    {
        MyShopEntities db = new MyShopEntities();
        int pageSize = 4;
        // GET: Admin/OrderForm
        public ActionResult Index(string searchName, string orderField = "State", int pageIndex = 1)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            IEnumerable<T_Shop_OrderForm> query = db.T_Shop_OrderForm;

            if (string.IsNullOrEmpty(searchName))
            {

            }
            else
            {
                int temp;
                if(int.TryParse(searchName,out temp))
                    query = query.Where(m => m.Id==temp);
            }

            #region 排序逻辑
            // orderField

            switch (orderField)
            {
                case "State":
                    query = query.OrderBy(m => m.State);
                    break;
                case "Id":
                    query = query.OrderBy(m => m.Id);
                    break;
                case "Time":
                    query = query.OrderBy(m => m.Date);
                    break;
                default:
                    break;
            }
            #endregion

            #region 分页实现
            int recordCount = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.recordCount = recordCount;
            #endregion

            List<T_Shop_OrderForm> list = query.ToList();
            ViewBag.list = list;
            ViewBag.search = searchName;

            return View();
        }

        public ActionResult PassProduct(int id,string WuliuId)
        {
            T_Shop_OrderForm item = db.T_Shop_OrderForm.Find(id);
            item.FahuoId = WuliuId;
            item.State = 2;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        //public ActionResult Detail(int Id)
        //{
        //    //ViewBag.p_list = db.T_Shop_OFProduct.Where(m => m.Id == Id).ToList();
        //    ////Response.Write("<scrip>$('#detail').modal({show: true}); </scrip>");

        //    //Response.Redirect("index");
        //    ////Response.Write("<script>location.href='/admin/orderform/index';</script>");//在ascx中跳到指定页，需要用JS方法
        //    //return PartialView("_DetailPartialView");
        //    return View();
        //}
    }
}