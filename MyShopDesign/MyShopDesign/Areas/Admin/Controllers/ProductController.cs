using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopDesign.Models;
using System.Data.Entity;

namespace MyShopDesign.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        MyShopEntities db = new MyShopEntities();
        int pageSize = 4;
        // GET: Admin/Product
        public ActionResult Index(string searchName, string orderField = "Id desc", int pageIndex = 1)
        {
            if(Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            //饿汉加载
            var query = db.T_Shop_Product.Include(m => m.T_Shop_ProductCategory);
            //ViewBag.lst = query.ToList();
            //IEnumerable<T_Shop_Product> query = db.T_Shop_Product;

            if (!string.IsNullOrEmpty(searchName))
            {
                var temp = query.Where(m => m.Name.Contains(searchName));

                if(temp.Count() == 0)
                {
                    temp = query.Where(m => m.T_Shop_ProductCategory.Name.Contains(searchName));
                }
                query = temp;
            }

            #region 排序逻辑

            switch (orderField)
            {
                case "category":
                    query = query.OrderBy(m => m.CategoryId);
                    break;
                case "title":
                    query = query.OrderBy(m => m.Name);
                    break;
                case "Id":
                    query = query.OrderBy(m => m.Id);
                    break;
                case "Id desc":
                    query = query.OrderByDescending(m => m.Id);
                    break;
                case "Price":
                    query = query.OrderBy(m => m.Price);
                    break;
                case "Price desc":
                    query = query.OrderByDescending(m => m.Price);
                    break;
                case "Store":
                    query = query.OrderBy(m => m.Store);
                    break;
                case "Store desc":
                    query = query.OrderByDescending(m => m.Store);
                    break;
                case "Month":
                    query = query.OrderBy(m => m.Month);
                    break;
                case "Month desc":
                    query = query.OrderByDescending(m => m.Month);
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

            //List<T_Shop_Product> list = query.ToList();
            ViewBag.list = query.ToList();
            ViewBag.search = searchName;
            return View();
        }

        public ActionResult Add()
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            ViewBag.CategoryId = new SelectList(db.T_Shop_ProductCategory, "Id", "Name", 8);
            return View();
        }

        public ActionResult AddSave(T_Shop_Product product)
        {
            db.T_Shop_Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int Id)
        {
            T_Shop_Product product = db.T_Shop_Product.Find(Id);
            db.T_Shop_Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["person"] == null)
            {
                return Redirect("/Admin/AdminLogin/Index");
            }

            T_Shop_Product temp = db.T_Shop_Product.Find(id);
            ViewBag.CategoryId = new SelectList(db.T_Shop_ProductCategory, "Id", "Name", temp.CategoryId);
            ViewBag.item = temp;
            return View();
        }

        [HttpPost]
        public ActionResult EditSave(T_Shop_Product product)
        {
            T_Shop_Product item = db.T_Shop_Product.Find(product.Id);
            item.Name = product.Name;
            item.Price = product.Price;
            item.Store = product.Store;
            item.Month = product.Month;
            item.Description = product.Description;
            item.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}