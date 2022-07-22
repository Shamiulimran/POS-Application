namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewPurchaseInvoice")]
    public partial class NewPurchaseInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewPurchaseInvoice()
        {
            NewPurchaseInvoiceDets = new HashSet<NewPurchaseInvoiceDet>();
        }

        public int Id { get; set; }

        public int? NewSupplierId { get; set; }

        public DateTime? Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewPurchaseInvoiceDet> NewPurchaseInvoiceDets { get; set; }
    }
}
