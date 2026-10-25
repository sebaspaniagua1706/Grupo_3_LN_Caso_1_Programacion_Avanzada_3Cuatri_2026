using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>
    {
        protected override IQueryable<Author> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
