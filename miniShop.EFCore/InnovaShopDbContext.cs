using Microsoft.EntityFrameworkCore;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.EFCore
{
   public class InnovaShopDbContext : DbContext
    {
        public InnovaShopDbContext(DbContextOptions<InnovaShopDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(modelBuilder);
        }
    }
}
