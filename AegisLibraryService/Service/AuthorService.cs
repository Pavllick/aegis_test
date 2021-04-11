using System.Collections.Generic;
using System.Linq;

using AegisLibraryService.DALFactory;
using AegisLibraryService.Model;

namespace AegisLibraryService.Service {
    public partial class LibraryService : IAuthorService {
        public AuthorType AddAuthor(AuthorType author) {
            using(var context = new AuthorDALFactory().Data) {
                var res = context.Add(author);
                context.Save();

                return new AuthorType(res);
            }
        }

        public AuthorType GetAuthor(int id) {
            using(var context = new AuthorDALFactory().Data) {
                return new AuthorType(context.GetByID(id));
            }
        }

        public IList<AuthorType> GetAllAuthors() {
            using(var context = new AuthorDALFactory().Data) {
                return context.GetAll().Select(x => new AuthorType(x)).ToList();
            }
        }
    }
}
