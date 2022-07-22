using Microsoft.Reporting.WebForms;
using POSApplication.Models;
using POSApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace POSApplication.Controllers
{
    [Authorize]
    public class SalesReportController : Controller
    {
           private POSDBContext db = new POSDBContext();
       
        // GET: PurchaseReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSalesReport()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories.Distinct().OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult CreateSalesReport(int? ProductCategoryId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                if (DateFrom == null)
                {
                    DateFrom = db.SalesInvoiceDets.Select(x => x.SalesInvoiceMa.Date).Min();
                }
                if (DateTo == null)
                {
                    DateTo = db.SalesInvoiceDets.Select(x => x.SalesInvoiceMa.Date).Max();
                }

                var data = db.SalesInvoiceDets.Where(x => x.SalesInvoiceMa.Date >= DateFrom && x.SalesInvoiceMa.Date <= DateTo && x.ProductCategoryId == ProductCategoryId || ProductCategoryId == null).ToList();

                List<VMSalesInvoice> SalesInvoice = new List<VMSalesInvoice>();

                foreach (var item in data)
                {
                    SalesInvoice.Add(new VMSalesInvoice
                    {
                        ProductCategoryName = item.ProductCategory.CategoryName,
                        ProductName = item.Product.ProductName,
                        PurchasePrice = item.PurchasePrize,
                        SalesPrice=item.SalesPrize,
                        Quantity = item.Quantity??0,
                        Date = item.SalesInvoiceMa.Date,
                        CustomerName =item.SalesInvoiceMa.CustomerId==null?"": item.SalesInvoiceMa.Customer.CustomerName,
                        Discount=item.Discount??0,
                        Value=item.Amount??0.00m

                    });
                }

                //----- Add Company Information To Report--------//
                var companyInfo = db.CompanyInformations.FirstOrDefault();



                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(100);
                reportViewer.Height = Unit.Percentage(100);
                reportViewer.PageCountMode = new PageCountMode();
                reportViewer.LocalReport.ReportPath = Request.MapPath("~/Reports/SalesInvoice.rdlc");

                List<ReportParameter> paraList = new List<ReportParameter>();

                paraList.Add(new ReportParameter("CompanyName", companyInfo.CompanyName));
                paraList.Add(new ReportParameter("Email", companyInfo.Email));
                paraList.Add(new ReportParameter("Phone", companyInfo.Phone));
                paraList.Add(new ReportParameter("Address", companyInfo.Address));
                paraList.Add(new ReportParameter("DateFrom", DateFrom.Value.ToShortDateString()));
                paraList.Add(new ReportParameter("DateTo", DateTo.Value.ToShortDateString()));

                reportViewer.LocalReport.SetParameters(paraList);

                ReportDataSource A = new ReportDataSource("DataSet1", SalesInvoice);
                reportViewer.LocalReport.DataSources.Add(A);
                reportViewer.ShowRefreshButton = false;


                ViewBag.ReportViewer = reportViewer;


                return View("~/Views/SalesReport/SalesInvoiceReport.cshtml");

            }
            catch (Exception ex)
            {
                var message = ex.Message;

            }

            return View();
        }
        [HttpPost]
        public ActionResult SummarySalessReport(int? ProductCategoryId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                if (DateFrom == null)
                {
                    DateFrom = db.SalesInvoiceDets.Select(x => x.SalesInvoiceMa.Date).Min();
                }
                if (DateTo == null)
                {
                    DateTo = db.SalesInvoiceDets.Select(x => x.SalesInvoiceMa.Date).Max();
                }

                var data = db.SalesInvoiceDets.Where(x => x.SalesInvoiceMa.Date >= DateFrom && x.SalesInvoiceMa.Date <= DateTo && x.ProductCategoryId == ProductCategoryId || ProductCategoryId == null).ToList();

                List<VMSalesInvoice> SalesInvoice = new List<VMSalesInvoice>();

                foreach (var item in data)
                {
                    SalesInvoice.Add(new VMSalesInvoice
                    {
                        ProductCategoryName = item.ProductCategory.CategoryName,
                        ProductName = item.Product.ProductName,
                        PurchasePrice = item.PurchasePrize,
                        SalesPrice = item.SalesPrize,
                        Quantity = item.Quantity ?? 0,
                        Date = item.SalesInvoiceMa.Date,
                        CustomerName = item.SalesInvoiceMa.CustomerId == null ? "" : item.SalesInvoiceMa.Customer.CustomerName,
                        Discount = item.Discount ?? 0,
                        Value = item.Amount ?? 0.00m

                    });
                }

                //----- Add Company Information To Report--------//
                var companyInfo = db.CompanyInformations.FirstOrDefault();

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(100);
                reportViewer.Height = Unit.Percentage(100);
                reportViewer.PageCountMode = new PageCountMode();
                reportViewer.LocalReport.ReportPath = Request.MapPath("~/Reports/SummarySalesInvoice.rdlc");

                List<ReportParameter> paraList = new List<ReportParameter>();

                paraList.Add(new ReportParameter("CompanyName", companyInfo.CompanyName));
                paraList.Add(new ReportParameter("Email", companyInfo.Email));
                paraList.Add(new ReportParameter("Phone", companyInfo.Phone));
                paraList.Add(new ReportParameter("Address", companyInfo.Address));
                paraList.Add(new ReportParameter("DateFrom", DateFrom.Value.ToShortDateString()));
                paraList.Add(new ReportParameter("DateTo", DateTo.Value.ToShortDateString()));

                reportViewer.LocalReport.SetParameters(paraList);

                ReportDataSource A = new ReportDataSource("DataSet1", SalesInvoice);
                reportViewer.LocalReport.DataSources.Add(A);
                reportViewer.ShowRefreshButton = false;


                ViewBag.ReportViewer = reportViewer;


                return View("~/Views/SalesReport/SalesInvoiceReport.cshtml");

            }
            catch (Exception ex)
            {
                var message = ex.Message;

            }

            return View();
        }

        
    }
}
