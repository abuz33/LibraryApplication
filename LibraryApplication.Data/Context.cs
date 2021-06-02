using System.Data.Entity;
using LibraryApplication.Data.Migrations;
using LibraryApplication.Data.Model;

namespace LibraryApplication.Data
{
    public class Context:DbContext
    {
        public Context() : base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("Context"));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}