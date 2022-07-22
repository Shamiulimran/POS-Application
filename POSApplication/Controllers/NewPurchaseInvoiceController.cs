using POSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSApplication.Controllers
{
    public class NewPurchaseInvoiceController : Controller
    {
        POSDBContext db = new POSDBContext();
        // GET: NewPurchaseInvoice
        public ActionResult Index()
        {
            var data = (db.NewPurchaseInvoices.ToList());
            return View(data);
        }

        // GET: NewPurchaseInvoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //[HttpGet]
        //public JsonResult GetSupplierInfoById(int id)
        //{
        //    //query
        //    var data = db.NewSuppliers.Where(x => x.Id == id).FirstOrDefault();

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public JsonResult GetSupplierInfoById(int id)
        {
            //query
            var data = db.NewSuppliers.Where(x => x.Id == id).FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetNewProductCatagoryName()
        {
            //query // query method

            var data = db.NewProductCategories.Select(x => new
            {
                id = x.Id,
                text = x.CategoryName

            }).OrderBy(x => x.text).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetProductName()
        {
            var data = db.NewProductInfoes.Distinct().ToList().Select(x => new
            {
                value = x.Id,
                text = x.ProductName


            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

//        var result = new
//        {
//            flag = false,
//            message = "Error occured. !",

//        };


//            if (ModelState.IsValid)
//            {

//                using (var transaction = db.Database.BeginTransaction())
//                //{
//                //    using (TransactionScope transaction = new TransactionScope())
//                //{
//                    try
//                    {
//                        purchaseInvoiceMa.UserId =(int) Session["uid"];

//        db.PurchaseInvoiceMas.Add(purchaseInvoiceMa);
//                        db.SaveChanges();

//                        foreach (var item in PurchaseInvoicedDetails)
//                        {
//                            PurchaseInvoiceDet det = new PurchaseInvoiceDet();
//        det.PurchaseInvoiceMasId = purchaseInvoiceMa.Id;
//                            det.ProductCategoryId = item.ProductCategoryId;
//                            det.Quantity = item.Quantity;
//                            det.SerialNo = item.SerialNo;
//                            det.PurchasePrize = item.PurchasePrize;
//                            det.Amount = item.Amount;
//                            det.ProductId = item.ProductId;
//                            det.ExpireDate = item.ExpireDate;

//                            db.PurchaseInvoiceDets.Add(det);
//                            db.SaveChanges();
//                        }
//    transaction.Commit();
//                        result = new
//                        {
//                            flag = true,
//                            message = "Succes occured. !",

//                        };
//                    }
//                    catch (Exception ex)
//{
//    transaction.Rollback();

//    result = new
//    {
//        flag = false,
//        message = "Fail occured. !",

//    };

//    var message = ex.Message;

//}
//                }
        public JsonResult SavePurchaseInvoice(NewPurchaseInvoice NewpurchaseInvoiceMa,List<NewPurchaseInvoiceDet> NewPurchaseInvoicedDet)
        {
            var result = new
            {
                flag=false,
                message="Error occured!",
            };
            if (ModelState.IsValid)
            {
                using (var transaction = db.Database.BeginTransaction())
                    try
                    {
                        NewpurchaseInvoiceMa.Id = (int)Session["uid"];
                        db.NewPurchaseInvoices.Add(NewpurchaseInvoiceMa);
                        db.SaveChanges();
                        foreach (var item in NewPurchaseInvoicedDet)
                        {
                            NewPurchaseInvoiceDet det = new NewPurchaseInvoiceDet();
                            det.NewPurchaseInvoiceId = NewpurchaseInvoiceMa.Id;
                            det.ProductCategoreyId = item.Id;
                            det.Quantity = item.Quantity;
                            det.PurchasePrice = item.PurchasePrice;
                            det.Amount = item.Amount;
                            det.ExpiryDate = item.ExpiryDate;
                            db.NewPurchaseInvoiceDets.Add(det);
                            db.SaveChanges();

                        }
                        transaction.Commit();
                        result = new
                        {
                            flag = true,
                            message = "Succes occured. !",

                            //};
                        };
                        }

                    catch
                    {

                    }
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult GetProductCategoreyName()
        //{
        //    var data = db.NewProductCategories.Select(x => new
        //    {
        //        id = x.Id,
        //        text = x.CategoryName

        //    }).OrderBy(x => x.text).ToList();



        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult GetProductCategoreyId(int ProductCategoreyId)
        //{
        //    var data = db.NewProductCategories.Where(x => x.Id == ProductCategoreyId).FirstOrDefault();

        //    return Json(data,JsonRequestBehavior.AllowGet);
        //}


        public ActionResult Create()
        {
            ViewBag.NewSupplierId = new SelectList(db.NewSuppliers.ToList().Distinct(),"Id","SupplierName");
            


            return View(ViewBag.NewSupplierId);
        }

        // POST: NewPurchaseInvoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewPurchaseInvoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewPurchaseInvoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewPurchaseInvoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewPurchaseInvoice/Delete/5
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
