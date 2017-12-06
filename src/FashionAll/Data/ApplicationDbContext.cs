using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FashionAll.Models;

namespace FashionAll.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bag> Bags { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //public DbSet<ViewModel> ViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Bag>().ToTable("Bag");

            builder.Entity<Supplier>().ToTable("Supplier");

            builder.Entity<CartItem>().ToTable("CartItem");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<OrderDetail>().ToTable("OrderDetail");

            builder.Entity<OrderDetail>().HasOne(p => p.Order).WithMany(o => o.OrderDetails).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);


        }

        //public DbSet<ViewModel> ViewModels { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        

    }
}
