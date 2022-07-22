namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewProductInfo")]
    public partial class NewProductInfo
    {   [Key]
        public int Id { get; set; }

        public string ProductCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        public int? NewSupplierId { get; set; }

        public int? NewProductCategoryId { get; set; }
    }
}
