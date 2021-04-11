using System.Data.Entity;
using AegisLibrary.Model;
using AegisLibraryDA.Model;

namespace AegisLibraryDA.Context {
    public class LibrayContext : DbContext, ILibrayContext {
        public LibrayContext(string con_str) : base(con_str) {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new AuthorDAConfig());
            modelBuilder.Configurations.Add(new BookDAConfig());
        }
    }
}