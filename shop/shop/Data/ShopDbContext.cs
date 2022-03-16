using Microsoft.EntityFrameworkCore;
using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=softShopdb; Integrated Security=yes");
        //}

        public ShopDbContext(DbContextOptions<ShopDbContext> options): base(options) 
        {

        }

        //Hiç yazmasanız da eğer modeliniz doğru ise EF Core >= 5 tabloları doğru bir biçimde oluşturabilir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired()
                                                                .HasMaxLength(100);


                                                                
        }
    }
}
