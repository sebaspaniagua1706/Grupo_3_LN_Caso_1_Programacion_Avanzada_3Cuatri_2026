
using PAP.DataAccess;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Repositories
{
    public class BookRepository : RepositoryBase<Book>
    {
        protected override IQueryable<Book> Query()
        {
            return _set.OrderBy(x => x.Id);
        }

        public IEnumerable<Book> MyBooks()
        {
            // queryable
            var test = from x in _context.Books
                       where !x.IsInStock && x.Name.Contains("a")
                       select x;

            return test.ToList();
        }
    }
}
