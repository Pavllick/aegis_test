using AegisLibraryDA.Context;
using AegisLibraryDA.DAL;

namespace AegisLibraryService.DALFactory {
    public class AuthorDALFactory {
        public readonly IAuthorDAL Data;

        public AuthorDALFactory() {
            Data = new AuthorDAL(new LibrayContextFactory().Create());
        }

        public AuthorDALFactory(ILibrayContext context) {
            Data = new AuthorDAL(context);
        }
    }
}
