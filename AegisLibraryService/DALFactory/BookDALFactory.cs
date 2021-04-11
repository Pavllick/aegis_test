using AegisLibraryDA.Context;
using AegisLibraryDA.DAL;

namespace AegisLibraryService.DALFactory {
    public class BookDALFactory {
        public readonly IBookDAL Data;

        public BookDALFactory() {
            Data = new BookDAL(new LibrayContextFactory().Create());
        }

        public BookDALFactory(ILibrayContext context) {
            Data = new BookDAL(context);
        }
    }
}
