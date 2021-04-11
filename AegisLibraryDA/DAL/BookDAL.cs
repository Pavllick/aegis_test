using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using AegisLibrary.Model;
using AegisLibraryDA.Context;

namespace AegisLibraryDA.DAL {
    public class BookDAL : IBookDAL {
        private readonly ILibrayContext _context;

        public BookDAL(ILibrayContext context) {
            _context = context;
        }

        public IBook GetByID(int id) {
            return _context.Books.Find(id);
        }

        public IList<IBook> GetAll() {
            return _context.Books.ToList<IBook>();
        }

        public IBook Add(IBook book) {
            return _context.Books.Add(new Book(book));
        }

        public IBook Delete(int id) {
            var book = _context.Books.Find(id);
            return _context.Books.Remove(book);
        }

        public void Update(IBook book) {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Save() {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if(!this.disposed) {
                if(disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
