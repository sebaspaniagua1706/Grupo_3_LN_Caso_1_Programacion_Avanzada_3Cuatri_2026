using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class PurchaseOrderItemRepository : RepositoryBase<PurchaseOrderItem>
    {
        protected override IQueryable<PurchaseOrderItem> Query()
        {
            return _set.Include(x => x.Book).OrderBy(x => x.Id);
        }
    }
}
