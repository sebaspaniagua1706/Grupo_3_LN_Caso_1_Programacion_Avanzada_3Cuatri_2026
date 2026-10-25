using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>
    {
        protected override IQueryable<OrderItem> Query()
        {
            return _set.Include(x => x.Order).Include(x => x.Book).OrderBy(x => x.Id);
        }
    }
}
