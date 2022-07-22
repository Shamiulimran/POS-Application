using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSApplication.Models.Helpers
{
    public class NewProductHelper
    {
        public int? Id { get; set; }
        public string ProductCode { get; set;}
        public string ProductName { get; set; }
        public string ProductCategorey { get; set;}
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
    }



}