namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewPurchaseInvoiceDet")]
    public partial class NewPurchaseInvoiceDet
    {
        public int Id { get; set; }

        public int? NewPurchaseInvoiceId { get; set; }

        public int ProductCategoreyId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Amount { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual NewPurchaseInvoice NewPurchaseInvoice { get; set; }
    }
}
