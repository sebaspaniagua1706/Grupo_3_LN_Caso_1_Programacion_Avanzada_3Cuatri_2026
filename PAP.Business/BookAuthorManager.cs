using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class BookAuthorManager : ManagerBase<Author>
    {
        public BookAuthorManager() : base(new AuthorRepository())
        {
        }

    }
}
