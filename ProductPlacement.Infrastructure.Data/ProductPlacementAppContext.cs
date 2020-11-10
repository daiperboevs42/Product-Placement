using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdductPlacement.Core.Entity;

namespace ProductPlacement.Infrastructure.Data
{
    public class ProductPlacementAppContext : DbContext
    {
        public ProductPlacementAppContext(DbContextOptions<ProductPlacementAppContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasOne(o => o.Owner).WithMany(c => c.Pets).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Pet>().HasOne(t => t.PetType);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

