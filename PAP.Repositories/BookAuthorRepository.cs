using PAP.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookAuthorRow = PAP.Models.BookAuthorRow;

namespace PAP.Repositories
{
    /// <summary>
    /// Repositorio para administrar la relación muchos a muchos
    /// entre libros y autores.
    ///
    /// Entity Framework representa la tabla BookAuthors mediante
    /// las propiedades Book.Authors y Author.Books.
    /// </summary>
    public class BookAuthorRepository
    {
        private readonly BookStoreDBEntities _context;

        public BookAuthorRepository()
        {
            _context = new BookStoreDBEntities();
        }

        /// <summary>
        /// Obtiene una cantidad determinada de relaciones
        /// entre libros y autores.
        /// </summary>
        public IEnumerable<BookAuthorRow> GetTop(int count)
        {
            return _context.Books
                .SelectMany(book =>
                    book.Authors.Select(author => new BookAuthorRow
                    {
                        BookId = book.Id,
                        BookTitle = book.Title,
                        AuthorId = author.Id,
                        AuthorName =
                            author.FirstName + " " + author.LastName
                    }))
                .OrderBy(row => row.BookId)
                .ThenBy(row => row.AuthorId)
                .Take(count)
                .ToList();
        }

        /// <summary>
        /// Indica si ya existe al menos una relación
        /// entre un libro y un autor.
        /// </summary>
        public bool Any()
        {
            return _context.Books.Any(
                book => book.Authors.Any());
        }

        /// <summary>
        /// Obtiene la cantidad total de relaciones
        /// entre libros y autores.
        /// </summary>
        public int Count()
        {
            return _context.Books
                .SelectMany(book => book.Authors)
                .Count();
        }

        /// <summary>
        /// Agrega una relación entre un libro y un autor.
        /// </summary>
        public void Add(int bookId, int authorId)
        {
            var book = _context.Books
                .Include(item => item.Authors)
                .FirstOrDefault(item => item.Id == bookId);

            var author = _context.Authors
                .FirstOrDefault(item => item.Id == authorId);

            if (book == null || author == null)
            {
                return;
            }

            var relationshipExists = book.Authors.Any(
                item => item.Id == authorId);

            if (relationshipExists)
            {
                return;
            }

            book.Authors.Add(author);
            _context.SaveChanges();
        }

        /// <summary>
        /// Agrega múltiples relaciones entre libros y autores
        /// utilizando una sola llamada a SaveChanges.
        /// </summary>
        public void AddRange(IEnumerable<BookAuthorRow> rows)
        {
            if (rows == null)
            {
                return;
            }

            var relationships = rows.ToList();

            if (!relationships.Any())
            {
                return;
            }

            var bookIds = relationships
                .Select(row => row.BookId)
                .Distinct()
                .ToList();

            var authorIds = relationships
                .Select(row => row.AuthorId)
                .Distinct()
                .ToList();

            var books = _context.Books
                .Include(book => book.Authors)
                .Where(book => bookIds.Contains(book.Id))
                .ToDictionary(book => book.Id);

            var authors = _context.Authors
                .Where(author => authorIds.Contains(author.Id))
                .ToDictionary(author => author.Id);

            foreach (var relationship in relationships)
            {
                if (!books.ContainsKey(relationship.BookId) ||
                    !authors.ContainsKey(relationship.AuthorId))
                {
                    continue;
                }

                var book = books[relationship.BookId];
                var author = authors[relationship.AuthorId];

                var relationshipExists = book.Authors.Any(
                    item => item.Id == author.Id);

                if (!relationshipExists)
                {
                    book.Authors.Add(author);
                }
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Elimina una relación existente entre un libro
        /// y un autor.
        /// </summary>
        public void Delete(int bookId, int authorId)
        {
            var book = _context.Books
                .Include(item => item.Authors)
                .FirstOrDefault(item => item.Id == bookId);

            if (book == null)
            {
                return;
            }

            var author = book.Authors
                .FirstOrDefault(item => item.Id == authorId);

            if (author == null)
            {
                return;
            }

            book.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}