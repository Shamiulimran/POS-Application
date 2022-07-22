namespace POSApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Secu_User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(155)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Salt { get; set; }

        [StringLength(50)]
        public string UserFullName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(1)]
        public string UserStatus { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int? InvalidAttempt { get; set; }

        public int? RoleId { get; set; }
    }
}
