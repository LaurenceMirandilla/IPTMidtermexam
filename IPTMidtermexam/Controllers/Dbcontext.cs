using Microsoft.EntityFrameworkCore;
using IPTMidtermexam.Model.Domain; 

namespace IPTMidtermexam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionItem> TransactionItems { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerID)
                .OnDelete(DeleteBehavior.SetNull);
       
            modelBuilder.Entity<TransactionItem>()
                .HasOne(ti => ti.Transaction)
                .WithMany() 
                .HasForeignKey(ti => ti.TransactionID)
                .OnDelete(DeleteBehavior.Cascade); 

        
            modelBuilder.Entity<TransactionItem>()
                .HasOne(ti => ti.Product)
                .WithMany() 
                .HasForeignKey(ti => ti.ProductID)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}