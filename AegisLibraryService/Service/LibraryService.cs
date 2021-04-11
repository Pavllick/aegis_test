using System.ServiceModel;

namespace AegisLibraryService.Service {
    [ServiceContract]
    public interface ILibraryService : IBookService, IAuthorService {
    }

    public partial class LibraryService : ILibraryService {
    }
}
