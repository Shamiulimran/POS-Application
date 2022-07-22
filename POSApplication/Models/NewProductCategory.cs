namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewProductCategory")]
   
    public partial class NewProductCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }
    }
   
}
