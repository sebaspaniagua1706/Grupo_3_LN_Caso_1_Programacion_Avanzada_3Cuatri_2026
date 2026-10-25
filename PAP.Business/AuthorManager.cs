using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class AuthorManager : ManagerBase<Author>
    {
        public AuthorManager() : base(new AuthorRepository())
        {
        }

    }
}
