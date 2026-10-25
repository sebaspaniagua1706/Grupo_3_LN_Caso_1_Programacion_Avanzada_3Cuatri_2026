using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>
    {
        protected override IQueryable<Genre> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
