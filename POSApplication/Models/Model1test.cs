using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace POSApplication.Models
{
    public partial class Model1test : DbContext
    {
        public Model1test()
            : base("name=Model1test")
        {
        }

        public virtual DbSet<Secu_User> Secu_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
