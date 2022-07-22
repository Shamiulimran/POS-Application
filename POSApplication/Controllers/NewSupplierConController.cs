using POSApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSApplication.Controllers
{
    public class NewSupplierConController : Controller
    {
        POSDBContext db = new POSDBContext();

        // GET: NewSupplierCon
        public ActionResult Index()
        { // write query
          //var data = (db.NewSuppliers.ToList);
            var NewSupplierData = db.NewSuppliers.OrderBy(x => x.SupplierName).ThenByDescending(x => x.Email).ToList();

            return View(NewSupplierData);


        }

            //return View(db.NewSuppliers.ToList());
            [HttpPost]
        public ActionResult Index(string searchvalue)
        {

            var data = db.NewSuppliers.Where(s => s.SupplierName.Contains(searchvalue)).ToList();

            ViewBag.searchvalue = searchvalue;

            if (data.Count == 0)
            {
                string msg = "data is not found for "+ searchvalue;
                ViewBag.Message =msg ;
            }


            return View(data);
        }

        // GET: NewSupplierCon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewSupplierCon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewSupplierCon/Create
        [HttpPost]
        public ActionResult savesu(NewSupplier model)
        {
            try
            {
                //
                //db.Suppliers.Add(supplier);
                //db.SaveChanges();
                db.NewSuppliers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Create", "NewSupplierCon");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewSupplierCon/Edit/5
        public ActionResult Edit(int id)
        {

            var data = (from a in db.NewSuppliers
                        where a.Id == id
                        select a).FirstOrDefault();


            return View(data);
        }

        // POST: NewSupplierCon/Edit/5
        [HttpPost]
        public ActionResult EditList(int id, NewSupplier model)
        {
            try
            {
               // tolist 1 data list
               //first
                //query
             
                NewSupplier newmodel =  new NewSupplier();
                
                newmodel.Id = model.Id;
                newmodel.SupplierName = model.SupplierName;
                newmodel.Phone = model.Phone;
                newmodel.CompanyName = model.CompanyName;
                newmodel.Address = model.Address;
                newmodel.Email = model.Email;
                //
                db.Entry(newmodel).State = EntityState.Modified;
                
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return RedirectToAction("Index");
              //  return View();
            }
        }

        // GET: NewSupplierCon/Delete/5
        public ActionResult Delete(int id)
        {
            NewSupplier DeleteData = db.NewSuppliers.Find(id);
            db.NewSuppliers.Remove(DeleteData);
            db.SaveChanges();
           return RedirectToAction("Index");

        }

        // POST: NewSupplierCon/Delete/5
        [HttpPost, ]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                // tolist 1 data list
                //first
                //query

                //NewSupplier newmodel = new NewSupplier();

                //newmodel.Id = model.Id;
                //newmodel.SupplierName = model.SupplierName;
                //newmodel.Phone = model.Phone;
                //newmodel.CompanyName = model.CompanyName;
                //newmodel.Address = model.Address;
                //newmodel.Email = model.Email;
                ////
                //db.Entry(newmodel).State = EntityState.Modified;

                //db.SaveChanges();


                //return RedirectToAction("Index");
                //NewSupplier s = db.NewSuppliers.Find(id);
                
                //db.NewSuppliers.Remove(s);
                //db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            
            catch
            {
                return View();
            }
        }
    }
}
