using System;
using System.Collections.Generic;

using AegisLibrary.Model;

namespace AegisLibraryDA.DAL {
    public interface IAuthorDAL : IDisposable {
        IList<IAuthor> GetAll();
        IAuthor GetByID(int id);
        IAuthor Add(IAuthor author);
        IAuthor Delete(int id);
        void Update(IAuthor author);
        void Save();
    }
}
