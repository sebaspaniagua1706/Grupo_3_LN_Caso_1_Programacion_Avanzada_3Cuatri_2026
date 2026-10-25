using PAP.DataAccess;
using PAP.Models;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Repositories
{
    /// <summary>
    /// BookAuthors es una relacion muchos-a-muchos: EF la expone como
    /// Book.Authors y Author.Books, no como entidad, por eso este repositorio
    /// no hereda de RepositoryBase.
    /// </summary>
    public class BookAuthorRepository
    {
        private readonly BookStoreDBEntities _context;

        public BookAuthorRepository()
        {
            _context = new BookStoreDBEntities();
        }

        public IEnumerable<BookAuthorRow> GetTop(int count)
        {
            return _context.Books
                .SelectMany(b => b.Authors.Select(a => new BookAuthorRow
                {
                    BookId = b.Id,
                    BookTitle = b.Title,
                    AuthorId = a.Id,
                    AuthorName = a.FirstName + " " + a.LastName
                }))
                .OrderBy(r => r.BookId)
                .ThenBy(r => r.AuthorId)
                .Take(count)
                .ToList();
        }

        public bool Any()
        {
            return _context.Books.Any(b => b.Authors.Any());
        }

        public int Count()
        {
            return _context.Books.SelectMany(b => b.Authors).Count();
        }

        public void Add(int bookId, int authorId)
        {
            var book = _context.Books.Find(bookId);
            var author = _context.Authors.Find(authorId);
            if (book == null || author == null) return;

            if (!book.Authors.Any(a => a.Id == authorId))
            {
                book.Authors.Add(author);
                _context.SaveChanges();
            }
        }

        public void Delete(int bookId, int authorId)
        {
            var book = _context.Books.Find(bookId);
            var author = _context.Authors.Find(authorId);
            if (book == null || author == null) return;

            book.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
