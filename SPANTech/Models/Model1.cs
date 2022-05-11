using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SPANTech.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Dataset")
        {
        }
        public virtual DbSet<Inputs> tbl_input { get; set; }
        public virtual DbSet<States> tbl_States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
