using System;
using System.Collections.Generic;

namespace AegisLibrary.Model {
    public interface IBook {
        int Id { get; set; }

        IList<IAuthor> Authors { get; set; }
        string Title { get; set; }
        DateTime ReleaseDate { get; set; }
        string Description { get; set; }

        string Note { get; set; }
    }
}
