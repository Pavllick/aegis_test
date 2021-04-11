using System;
using System.Collections.Generic;
using System.Linq;

namespace AegisLibrary.Model {
    public class Book : IBook {
        public int Id { get; set; }

        public IList<Author> Authors { get; set; }
        IList<IAuthor> IBook.Authors {
            get {
                if(Authors == null) {
                    return null;
                }

                return Authors.ToList<IAuthor>();
            }
            set { Authors = value == null ? null : value.Cast<Author>().ToList(); }
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public string Note { get; set; }

        public Book() { }

        public Book(IBook book) {
            Id = book.Id;
            Authors = book.Authors == null ? null : book.Authors.Select(x => new Author(x)).ToList();
            Title = book.Title;
            ReleaseDate = book.ReleaseDate;
            Description = book.Description;
            Note = book.Note;
        }
    }
}
