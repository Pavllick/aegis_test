using System.Collections.Generic;
using System.Linq;
using AegisLibraryService.DALFactory;
using AegisLibraryService.Model;

namespace AegisLibraryService.Service {
    public partial class LibraryService : IBookService {
        public BookType AddBook(BookType book) {
            using(var context = new BookDALFactory().Data) {
                var res = context.Add(book);
                context.Save();

                return new BookType(res);
            }
        }

        public BookType GetBook(int id) {
            using(var context = new BookDALFactory().Data) {
                return new BookType(context.GetByID(id));
            }
        }

        public IList<BookType> GetAllBooks() {
            using(var context = new BookDALFactory().Data) {
                return context.GetAll().Select(x => new BookType(x)).ToList();
            }
        }
    }
}
