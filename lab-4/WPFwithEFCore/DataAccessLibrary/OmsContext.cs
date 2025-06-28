using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;
using System.Configuration;




namespace DataAccessLibrary
{
    public class OmsContext : DbContext
    {
        // Constructor accepting DbContextOptions and passing it to the base DbContext constructor
        public OmsContext(DbContextOptions<OmsContext> options) : base(options)
        {
        }

        public DbSet<Shopper> Shopper { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>()
                .HasKey(s => s.IdShopper); // Defines IdShopper as the primary key for the Shopper entity

            modelBuilder.Entity<Basket>()
                .HasKey(b => b.IdBasket);

            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => bi.IdBasketItem);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Shopper)
                .WithMany(s => s.Baskets)
                .HasForeignKey(b => b.IdShopper);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.IdProduct);

            // Adjusting precision for decimal properties to match your database schema
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(6, 2)"); // Matching the precision and scale to the database

            modelBuilder.Entity<Basket>()
                .Property(b => b.SubTotal)
                .HasColumnType("decimal(7, 2)"); // Matching the precision and scale to the database

            // If you have any additional configuration for your entities, add them here
        }
    }
}
