namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewCompanyInformation")]
    public partial class NewCompanyInformation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        public int Phone { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Description { get; set; }
        
    }
}
