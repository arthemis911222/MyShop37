using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopDesign.Models;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class WorkersController : Controller
    {
        MyShopEntities db = new MyShopEntities();
        int pageSize = 4;
        // GET: Admin/Workers
        public ActionResult Index(string searchName, string orderField = "Id desc", int pageIndex = 1)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            IEnumerable<T_Shop_Workers> query = db.T_Shop_Workers;

            if (string.IsNullOrEmpty(searchName))
            {

            }
            else
            {
                query = query.Where(m => m.Name.Contains(searchName));
            }

            #region 排序逻辑
            // orderField

            switch (orderField)
            {
                case "title":
                    query = query.OrderBy(m => m.Name);
                    break;
                case "Time desc":
                    query = query.OrderByDescending(m => m.Time);
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

            List<T_Shop_Workers> list = query.ToList();
            ViewBag.list = list;
            ViewBag.search = searchName;

            return View();
        }

        public ActionResult Add()
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            return View();
        }

        public ActionResult AddSave(T_Shop_Workers worker)
        {
            worker.Time = DateTime.Now;
            db.T_Shop_Workers.Add(worker);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int Id)
        {
            T_Shop_Workers product = db.T_Shop_Workers.Find(Id);
            db.T_Shop_Workers.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int Id)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            T_Shop_Workers temp = db.T_Shop_Workers.Find(Id);
            ViewBag.item = temp;
            return View();
        }

        public ActionResult EditSave(T_Shop_Workers worker)
        {
            T_Shop_Workers item = db.T_Shop_Workers.Find(worker.Id);
            item.Name = worker.Name;
            item.Password = worker.Password;
            item.Phone = worker.Phone;
            item.State = worker.State;
            item.TrueName = worker.TrueName;
            db.SaveChanges();

            return RedirectToAction("index");
        }

    }
}