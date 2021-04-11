using AegisLibrary.Model;
using AegisLibraryDA.Context;
using AegisLibraryDA.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AegisLibraryDATest {
    [TestClass]
    public class BookUnitTest {
        private readonly LibrayContext _context;
        private readonly AuthorDAL _author_dal;
        private readonly BookDAL _book_dal;

        public BookUnitTest() {
            _context = new LibrayContextFactory("AegisDBTest").Create();
            _author_dal = new AuthorDAL(_context);
            _book_dal = new BookDAL(_context);

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

        private void MockAuthors() {
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
        }

        [TestMethod]
        public void CreateNewBookAndAddToDB() {
            MockAuthors();

            Book book = new Book() {
                Title = "title",
                ReleaseDate = DateTime.Now,
                Description = "desc",
                Note = "note",
                Authors = _author_dal.GetAll().Select(x => new Author(x)).ToList()
            };

            _book_dal.Add(book);
            _book_dal.Save();

            Assert.AreEqual(1, _book_dal.GetAll().Count);
        }

        [TestMethod]
        public void GetBookById() {
            MockAuthors();

            Book book = new Book() {
                Title = "title",
                ReleaseDate = DateTime.Now,
                Description = "desc",
                Note = "note",
                Authors = _author_dal.GetAll().Select(x => new Author(x)).ToList()
            };

            _book_dal.Add(book);
            _book_dal.Save();

            var res = _book_dal.GetByID(1);

            Assert.AreEqual(book.Title, res.Title);
        }

        [TestMethod]
        public void CheckBookHasAuthors() {
            MockAuthors();

            Book book = new Book() {
                Title = "title",
                ReleaseDate = DateTime.Now,
                Description = "desc",
                Note = "note",
                Authors = _author_dal.GetAll().Select(x => new Author(x)).ToList()
            };

            _book_dal.Add(book);
            _book_dal.Save();

            var res = _book_dal.GetByID(1);

            Assert.AreEqual(2, res.Authors.Count);
        }
    }
}
