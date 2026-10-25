using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>
    {
        protected override IQueryable<Review> Query()
        {
            return _set.Include(x => x.Book).Include(x => x.Customer).OrderBy(x => x.Id);
        }
    }
}
