namespace AegisLibrary.Model {
    public class Author : IAuthor {
        public int Id { get; set; }
        public int? BookId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author() {
        }

        public Author(IAuthor author) {
            Id = author.Id;
            BookId = author.BookId;

            FirstName = author.FirstName;
            LastName = author.LastName;
    }
    }
}
