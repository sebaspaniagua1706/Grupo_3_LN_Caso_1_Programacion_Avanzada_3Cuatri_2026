using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>
    {
        protected override IQueryable<Publisher> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
