// using CrudApp.Models;
// using Microsoft.EntityFrameworkCore;

// namespace CrudApp.Data
// {
//     public class ApplicationDbContext : DbContext
//     {
//         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//             : base(options)
//         {
//         }

//         public DbSet<Product> Products { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             base.OnModelCreating(modelBuilder);
            
//             modelBuilder.Entity<Product>(entity =>
//             {
//                 entity.HasKey(e => e.Id);
//                 entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
//                 entity.HasIndex(e => e.Name);
//             });
//         }
//     }
// }

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

        // Fluent API to configure models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                entity.HasOne(o => o.Product)  // Define relationship with Product
                      .WithMany()  // A product can have many orders
                      .HasForeignKey(o => o.ProductId);  // Foreign key to Product

                // Adding a default value to the Status column
                entity.Property(o => o.Status).HasDefaultValue("Pending");
            });
        }
    }
}
