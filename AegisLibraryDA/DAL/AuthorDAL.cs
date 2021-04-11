using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using AegisLibrary.Model;
using AegisLibraryDA.Context;

namespace AegisLibraryDA.DAL {
    public class AuthorDAL : IAuthorDAL {
        private readonly ILibrayContext _context;

        public AuthorDAL(ILibrayContext context) {
            _context = context;
        }

        public IAuthor GetByID(int id) {
            return _context.Authors.Find(id);
        }

        public IList<IAuthor> GetAll() {
            return _context.Authors.ToList<IAuthor>();
        }

        public IAuthor Add(IAuthor author) {
            return _context.Authors.Add(new Author(author));
        }

        public IAuthor Delete(int id) {
            var author = _context.Authors.Find(id);
            return _context.Authors.Remove(author);
        }

        public void Update(IAuthor author) {
            _context.Entry(author).State = EntityState.Modified;
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
