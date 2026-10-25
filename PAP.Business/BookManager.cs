using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace PAP.Business
{
    public class BookManager : ManagerBase<Book>
    {

        public BookManager() : base(new BookRepository())
        {
        }


        
    }
}
