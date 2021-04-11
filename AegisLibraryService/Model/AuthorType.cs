using System.Runtime.Serialization;

using AegisLibrary.Model;

namespace AegisLibraryService.Model {
    [KnownType(typeof(BookType))]
    [DataContract]
    public class AuthorType : IAuthor {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? BookId { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public AuthorType() { }

        public AuthorType(IAuthor author) {
            Id = author.Id;
            BookId = author.BookId;

            FirstName = author.FirstName;
            LastName = author.LastName;
        }
    }
}
