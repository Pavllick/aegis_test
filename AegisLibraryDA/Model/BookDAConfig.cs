using AegisLibrary.Model;
using System.Data.Entity.ModelConfiguration;

namespace AegisLibraryDA.Model {
    internal class BookDAConfig : EntityTypeConfiguration<Book> {
        private const string TableName = "book";
        public BookDAConfig() {
            this.ToTable(TableName);

            this.HasKey(x => x.Id);
            this.HasIndex(x => x.Id)
                .IsUnique();
            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.ReleaseDate)
                .IsRequired();

            this.Property(x => x.Description)
                .IsOptional();

            this.Property(x => x.Note)
                .IsOptional();

            this.HasMany(x => x.Authors)
                .WithOptional()
                .HasForeignKey(x => x.BookId);
        }
    }
}
