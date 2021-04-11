using AegisLibrary.Model;
using System.Data.Entity.ModelConfiguration;

namespace AegisLibraryDA.Model {
    internal class AuthorDAConfig : EntityTypeConfiguration<Author> {
        private const string TableName = "author";
        public AuthorDAConfig() {
            this.ToTable(TableName);

            this.HasKey(x => x.Id);
            this.HasIndex(x => x.Id)
                .IsUnique();
            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
