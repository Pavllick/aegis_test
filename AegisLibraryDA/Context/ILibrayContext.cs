using System.Data.Entity;
using AegisLibrary.Model;

namespace AegisLibraryDA.Context {
    public interface ILibrayContext : IDbContext {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}
