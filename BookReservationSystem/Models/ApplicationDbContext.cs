using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookReservationSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookDefinition> BookDefinitions { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(t => t.Books)
                .WithMany(t => t.Orders);

            modelBuilder.Entity<Book>()
                .HasOptional(t => t.Lender)
                .WithMany(t => t.BorrowedBooks);

            base.OnModelCreating(modelBuilder);
        }
    }
}