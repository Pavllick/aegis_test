using System.Data.Entity.Infrastructure;

namespace AegisLibraryDA.Context {
    public class LibrayContextFactory: IDbContextFactory<LibrayContext> {
        private readonly string _db_name;

        public LibrayContextFactory() {
            _db_name = Config.DBName;
        }

        public LibrayContextFactory(string db_name) {
            _db_name = db_name;
        }

        public LibrayContext Create() {
            return new LibrayContext(_db_name);
        }
    }
}
