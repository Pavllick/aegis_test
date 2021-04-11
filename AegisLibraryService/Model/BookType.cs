using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using AegisLibrary.Model;

namespace AegisLibraryService.Model {
    [KnownType(typeof(AuthorType))]
    [DataContract]
    public class BookType : IBook {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public IList<AuthorType> Authors { get; set; }

        IList<IAuthor> IBook.Authors {
            get {
                if(Authors == null) {
                    return null;
                }

                return Authors.Cast<IAuthor>().ToList();
            }
            set { Authors = value == null ? null : value.Cast<AuthorType>().ToList(); }
        }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Note { get; set; }

        public BookType() { }

        public BookType(IBook book) {
            Id = book.Id;
            Authors = book.Authors == null ? null : book.Authors.Select(x => new AuthorType(x)).ToList();
            Title = book.Title;
            ReleaseDate = book.ReleaseDate;
            Description = book.Description;
            Note = book.Note;
        }
    }
}
