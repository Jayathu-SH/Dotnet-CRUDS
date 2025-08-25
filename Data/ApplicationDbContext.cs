

using CrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets represent the tables in the database
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

        // Fluent API to configure models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the Transaction entity
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
                entity.Property(t => t.PaymentMethod).IsRequired();
                entity.HasOne(t => t.Order)
                      .WithMany()
                      .HasForeignKey(t => t.OrderId);
            });

            // Configuring the Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);  // Primary key
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");  // Configure Price column
                entity.HasIndex(e => e.Name);  // Create an index on Name column for better lookup
            });

            // Configuring the Order entity
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);  // Primary key
                entity.Property(o => o.TotalPrice).HasColumnType("decimal(18,2)");  // Configure TotalPrice column
                entity.Property(o => o.Status).HasDefaultValue("Pending");
                entity.HasMany(o => o.OrderDetails)
                      .WithOne(od => od.Order)
                      .HasForeignKey(od => od.OrderId);
            });

            // Configuring the OrderDetail entity
            modelBuilder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.HasKey(x => x.Id);
                orderDetail.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
                orderDetail.HasOne(x => x.Product)
                             .WithMany()
                             .HasForeignKey(x => x.ProductId);
            });

            // Configuring the Customer entity (optional, for completeness)
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.Phone).IsRequired();
                entity.Property(c => c.Address).IsRequired();
            });
        }
    }
}
