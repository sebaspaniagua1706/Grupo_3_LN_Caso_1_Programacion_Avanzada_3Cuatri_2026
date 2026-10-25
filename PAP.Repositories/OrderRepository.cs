using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class OrderRepository : RepositoryBase<Order>
    {
        protected override IQueryable<Order> Query()
        {
            return _set.Include(x => x.Customer).OrderBy(x => x.Id);
        }
    }
}
