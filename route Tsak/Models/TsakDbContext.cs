using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using route_Tsak.Enum;

namespace route_Tsak.Models
{
    public class TsakDbContext : DbContext
    {
        public TsakDbContext(DbContextOptions<TsakDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore enum types
            modelBuilder.Ignore<Statusenum>();
            modelBuilder.Ignore<paymentenum>();

            // Customer constraints
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Orders constraints
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.OrderDate)
                    .IsRequired();
                entity.Property(o => o.TotalAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired(); // Assuming TotalAmount is decimal(18,2)

                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId);
            });

            // OrderItem constraints
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.OrderItemId);
                entity.Property(oi => oi.Quantity)
                    .IsRequired();
                entity.Property(oi => oi.UnitPrice)
                    .HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.Discount)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(oi => oi.Orders)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId);

                entity.HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId);
            });

            // Product constraints
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock)
                    .IsRequired();
            });

            // Invoice constraints
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(i => i.InvoiceId);
                entity.Property(i => i.InvoiceDate)
                    .IsRequired();
                entity.Property(i => i.TotalAmount)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(i => i.Orders)
                    .WithMany(o => o.Invoices)
                    .HasForeignKey(i => i.OrderId);
            });

            // User constraints
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.PasswordHash)
                    .IsRequired();
                entity.Property(u => u.Role)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
