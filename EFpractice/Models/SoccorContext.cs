using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFpractice.Models
{
    public partial class SoccorContext : DbContext
    {
        public SoccorContext()
            : base("name=SoccorContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
