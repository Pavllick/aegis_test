using System;
using System.Collections.Generic;

using AegisLibrary.Model;

namespace AegisLibraryDA.DAL {
    public interface IBookDAL : IDisposable {
        IList<IBook> GetAll();
        IBook GetByID(int id);
        IBook Add(IBook book);
        IBook Delete(int id);
        void Update(IBook book);
        void Save();
    }
}
