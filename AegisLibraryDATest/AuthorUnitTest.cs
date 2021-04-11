using AegisLibrary.Model;
using AegisLibraryDA.Context;
using AegisLibraryDA.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AegisLibraryDATest {
    [TestClass]
    public class AuthorUnitTest {
        private readonly LibrayContext _context;
        private readonly AuthorDAL _author_dal;

        public AuthorUnitTest() {
            _context = new LibrayContextFactory("AegisDBTest").Create();
            _author_dal = new AuthorDAL(_context);

            Cleanup();
        }

        [TestInitialize()]
        public void Startup() {
            _context.Database.Create();
        }

        [TestCleanup()]
        public void Cleanup() {
            _context.Database.Delete();
        }

        [TestMethod]
        public void CreateNewAuthorAndAddToDB() {
            Author author = new Author() {
                FirstName = "Fn",
                LastName = "Ln"
            };
            _author_dal.Add(author);

            Author author2 = new Author() {
                FirstName = "Fn2",
                LastName = "Ln2"
            };
            _author_dal.Add(author2);

            _author_dal.Save();

            Assert.AreEqual(2, _author_dal.GetAll().Count);
        }

        [TestMethod]
        public void GetAuthorById() {
            Author author = new Author() {
                FirstName = "Fn",
                LastName = "Ln"
            };
            _author_dal.Add(author);
            _author_dal.Save();

            var res = _author_dal.GetByID(1);

            Assert.AreEqual(author.FirstName, res.FirstName);
        }
    }
}
