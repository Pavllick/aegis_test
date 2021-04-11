using System.Collections.Generic;
using System.ServiceModel;

using AegisLibraryService.Model;

namespace AegisLibraryService.Service {
    [ServiceContract]
    public interface IAuthorService {
        [OperationContract]
        AuthorType AddAuthor(AuthorType author);

        [OperationContract]
        AuthorType GetAuthor(int id);

        [OperationContract]
        IList<AuthorType> GetAllAuthors();
    }
}
