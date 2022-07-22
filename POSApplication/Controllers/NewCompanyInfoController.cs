using POSApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSApplication.Controllers
{
    public class NewCompanyInfoController : Controller
    {
        POSDBContext db = new POSDBContext();
        // GET: NewCompanyInfo
        public ActionResult Index()
        {
            var data = db.NewCompanyInformations.OrderBy(c => c.CompanyName).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(string searchValue)
        {
            //  query from  database

            var data = db.NewCompanyInformations.Where(x=>x.CompanyName.Contains(searchValue)).OrderBy(c => c.CompanyName).ToList();

            return View(data);
        }
        // GET: NewCompanyInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewCompanyInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewCompanyInfo/Create
        [HttpPost]
        public ActionResult Save(NewCompanyInformation Information,string name)
        {
            try
            {
                db.NewCompanyInformations.Add(Information);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewCompanyInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var EditData = db.NewCompanyInformations.Where(x => x.Id == id).FirstOrDefault();
            return View(EditData);
        }

        // POST: NewCompanyInfo/Edit/5
        [HttpPost]
        public ActionResult EditList(int id, NewCompanyInformation model)
        {
            try
            {
                NewCompanyInformation newmodel = new NewCompanyInformation();
                newmodel.Id = model.Id;
                newmodel.CompanyName = model.CompanyName;
                newmodel.Address = model.Address;
                newmodel.Phone = model.Phone;
                newmodel.Email = model.Email;
                newmodel.Description = model.Description;
                db.Entry(newmodel).State = EntityState.Modified;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index","NewCompanyInfo");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
     

        // GET: NewCompanyInfo/Delete/5
        public ActionResult Delete(int id)
        {
            var DeleteData = db.NewCompanyInformations.Find(id);
            db.NewCompanyInformations.Remove(DeleteData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: NewCompanyInfo/Delete/5
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
