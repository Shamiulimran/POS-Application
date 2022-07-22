using POSApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSApplication.Controllers
{
    public class NewProductCategoriesController : Controller
    {
        POSDBContext db = new POSDBContext();
        // GET: NewProductCateories
        public ActionResult Index()
        {
            var newproductCategory=db.NewProductCategories.OrderBy(x => x.CategoryName).ToList();
            return View(newproductCategory);
        }
        [HttpPost]
        public ActionResult Index( string SearchValue)
        {
            var data = db.NewProductCategories.Where(x => x.CategoryName.Contains(SearchValue));
            return View(data);
        }

        // GET: NewProductCateories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewProductCateories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewProductCateories/Create
        [HttpPost]
        public ActionResult save(NewProductCategory category)
        {
            try
            {
                db.NewProductCategories.Add(category);
                db.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Create", "NewProductCategories");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewProductCateories/Edit/5
        public ActionResult Edit(int id)
        {
            //query to get data

            var EidtData = (db.NewProductCategories.Where(x => x.Id == id)).FirstOrDefault();
            return View(EidtData);
        }

        // POST: NewProductCateories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NewProductCategory model)
        {
            try
            {
                NewProductCategory newmodel = new NewProductCategory();
                newmodel.Id = model.Id;
                newmodel.CategoryName = model.CategoryName;
                newmodel.ImageUrl = model.ImageUrl;




                // TODO: Add update logic here
                //db.Entry(newmodel).State = EntityState.Modified;
                db.Entry(newmodel).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewProductCateories/Delete/5
        public ActionResult Delete(int id)
        {
            NewProductCategory DeleteData = db.NewProductCategories.Find(id);
            db.NewProductCategories.Remove(DeleteData);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: NewProductCateories/Delete/5
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
