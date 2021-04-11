using System.Collections.Generic;
using System.ServiceModel;

using AegisLibraryService.Model;

namespace AegisLibraryService.Service {
    [ServiceContract]
    public interface IBookService {
        [OperationContract]
        BookType AddBook(BookType book);

        [OperationContract]
        BookType GetBook(int id);

        [OperationContract]
        IList<BookType> GetAllBooks();
    }
}
