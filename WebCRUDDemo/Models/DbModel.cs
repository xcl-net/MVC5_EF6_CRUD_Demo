using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebCRUDDemo.Models
{
    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
