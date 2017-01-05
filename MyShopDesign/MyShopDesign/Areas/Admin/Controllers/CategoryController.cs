using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopDesign.Models;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //GET: Admin/Category
       MyShopEntities db = new MyShopEntities();
        int pageSize = 4;

        public ActionResult Index(string searchName, string orderField = "Id desc", int pageIndex = 1)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            IEnumerable<T_Shop_ProductCategory> query = db.T_Shop_ProductCategory;

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
                case "Id desc":
                    query = query.OrderByDescending(m => m.Id);
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

            List<T_Shop_ProductCategory> list = query.ToList();
            ViewBag.list = list;
            ViewBag.search = searchName;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            return View();
        }

        [HttpPost]
        public int Add(T_Shop_ProductCategory category)
        {
            IEnumerable<T_Shop_ProductCategory> p = db.T_Shop_ProductCategory.Where(m => m.Name==category.Name);
            if(p.Count() != 0)
            {
                return 0;
            }

            T_Shop_ProductCategory temp = new T_Shop_ProductCategory();
            temp.Name = category.Name;
            temp.Description = category.Description;
            db.T_Shop_ProductCategory.Add(temp);
            db.SaveChanges();

            return 1;
        }

        [HttpPost]
        public int Delete(int id)
        {
            IEnumerable<T_Shop_Product>  p = db.T_Shop_Product.Where(m => m.CategoryId == id);
            if (p.Count() != 0)
            {
                return 0;
            }

            T_Shop_ProductCategory temp = db.T_Shop_ProductCategory.Find(id);
            db.T_Shop_ProductCategory.Remove(temp);
            db.SaveChanges();
            return 1;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            T_Shop_ProductCategory temp = db.T_Shop_ProductCategory.Find(id);
            ViewBag.item = temp;
            return View();
        }

        [HttpPost]

        public ActionResult EditSave(string Name, string Description, int Id)
        {
            T_Shop_ProductCategory item = db.T_Shop_ProductCategory.Find(Id);
            item.Name = Name;
            item.Description = Description;
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}