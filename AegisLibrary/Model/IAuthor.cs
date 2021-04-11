namespace AegisLibrary.Model {
    public interface IAuthor {
        int Id { get; set; }
        int? BookId { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
