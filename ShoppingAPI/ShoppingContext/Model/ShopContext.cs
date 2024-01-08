using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
               : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSize{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);
                entity.Property(e => e.NameRole).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Description).IsRequired(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.NameEmployee).HasMaxLength(150);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired(false);
                entity.Property(e => e.Image).IsRequired(false);
                entity.Property(e => e.Password).IsRequired(false);
                entity.Property(e => e.NameEmployee).IsRequired(false);
                entity.Property(e => e.Otp).IsRequired(false);
                entity.HasOne(r => r.Role)
            .WithMany(u => u.Employees)
            .HasForeignKey(r => r.RoleId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);
                entity.Property(e => e.Email).IsRequired(false); 
                entity.Property(e => e.Image).IsRequired(false); 
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview);
                entity.Property(e => e.Comment).IsRequired(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPaymentMethod);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);
                entity.Property(e => e.SubCategory).IsRequired(false);

            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.IdProductImage);
                entity.HasOne(r => r.Product)
            .WithMany(u => u.ProductImages)
            .HasForeignKey(r => r.ProductId);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.IdSize);
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => e.IdProductSize);
                entity.HasOne(r => r.Size);
                entity.HasOne(r => r.Product)
            .WithMany(u => u.ProductSizes)
            .HasForeignKey(r => r.SizeId)
            .HasForeignKey(r => r.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);
                entity.Property(e => e.Title).HasMaxLength(500);
                entity.Property(e => e.Description).HasMaxLength(5000);
                entity.Property(e => e.Description).IsRequired(false);
                entity.HasOne(r => r.Category)
            .WithMany(u => u.Products)
            .HasForeignKey(r => r.CategoryId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.HasOne(r => r.Customer)
             .WithMany(u => u.Orders)
            .HasForeignKey(r => r.CustomerId);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.CartItemId);
            });

        }
    }
}
