using BookCatalog.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null;

        public DbSet<Author> Author { get; set; } = null;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
