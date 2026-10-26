using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;

namespace PAP.Business
{
    public class BookManager : ManagerBase<Book>
    {
        public BookManager() : base(new BookRepository())
        {
        }

        public IEnumerable<Book> GetAllBooksFromDataModel()
        {
            return GetAll();
        }
    }
}