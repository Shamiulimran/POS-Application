using POSApplication.Models;
using POSApplication.Models.Helpers;
using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSApplication.Controllers
{
    public class NewProductInfoController : Controller
    {
        POSDBContext db = new POSDBContext();
        // GET: NewProductInfo
        public ActionResult Index()

        {
            // var data = db.NewProductInfoes.OrderBy(p => p.ProductName).ToList();

            var data = (from a in db.NewProductInfoes
                        join b in db.NewSuppliers
                        on a.NewSupplierId equals b.Id
                        join c in db.NewProductCategories
                        on a.NewProductCategoryId equals c.Id
                        select new NewProductHelper()
                        {
                            Id = a.Id,
                            ProductCode = a.ProductCode,
                                ProductName = a.ProductName,
                                ProductCategorey = c.CategoryName,
                                SupplierName = b.SupplierName,
                                SupplierPhone=b.Phone,
                            }).ToList();

            //ViewBag.Data = data;

            return View(data);
        }
        [HttpPost]
        public ActionResult Index(string searchValue1)
        {
            var data = db.NewProductInfoes.Where(x => x.ProductName.Contains(searchValue1));
            return View(data);
        }

        // GET: NewProductInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewProductInfo/Create
        public ActionResult Create()
        {

            //ViewBag.NewSupplierId = new SelectList(db.NewSuppliers.ToList(), "Id", "SupplierName");
            //ViewBag.NewProductCategoryId = new SelectList(db.NewProductCategories.ToList(), "Id", "CategoryName");
            ViewBag.NewSupplierId = new SelectList(db.NewSuppliers.ToList(), "Id", "SupplierName");
            ViewBag.NewProductCategoryId = new SelectList(db.NewProductCategories.ToList(), "Id", "CategoryName");


            return View();
        }

        // POST: NewProductInfo/Create
        [HttpPost]
        public ActionResult CreateNew(NewProductInfo model)
        {
            try
            {
                // TODO: Add insert logic here
                db.NewProductInfoes.Add(model);
                db.SaveChanges();

                return RedirectToAction("Create","NewProductInfo");
            }
            catch( Exception ex)
            {
                return View();
            }
        }

        // GET: NewProductInfo/Edit/5
        public ActionResult Edit(int id)
        {
            //var data = (from p in db.NewProductInfoes
            //            where p.Id == id
            //            select p).FirstOrDefault();
            //return View(data);
            NewProductInfo product = db.NewProductInfoes.Find(id);


            if(product==null)
            {
                return HttpNotFound();
            }

            ViewBag.NewSupplierId = new SelectList(db.NewSuppliers.ToList(), "Id", "SupplierName",product.NewSupplierId);
            ViewBag.NewProductCategoryId = new SelectList(db.NewProductCategories.ToList(), "Id", "CategoryName",product.NewProductCategoryId);

            ViewBag.productid = new SelectList(db.NewProductCategories.ToList(), "Id", "CategoryName", "9");

            return View(product);
        }

        // POST: NewProductInfo/Edit/5
        [HttpPost]
        public ActionResult EditList(int id, NewProductInfo model)
        {
            try
            {
                // TODO: Add update logic here

                NewProductInfo newmodel = new NewProductInfo();

                newmodel.Id = model.Id;
                newmodel.ProductCode = model.ProductCode;
                newmodel.ProductName = model.ProductName;
                newmodel.NewProductCategoryId = model.NewProductCategoryId;
                newmodel.NewSupplierId = model.NewSupplierId;
                db.Entry(newmodel).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewProductInfo/Delete/5
        public ActionResult Delete(int id)
        {
            NewProductInfo DeleteData = db.NewProductInfoes.Find(id);
            db.NewProductInfoes.Remove(DeleteData);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: NewProductInfo/Delete/5
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
