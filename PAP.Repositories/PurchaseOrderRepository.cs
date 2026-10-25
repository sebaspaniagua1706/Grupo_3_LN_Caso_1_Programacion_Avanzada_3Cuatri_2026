using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class PurchaseOrderRepository : RepositoryBase<PurchaseOrder>
    {
        protected override IQueryable<PurchaseOrder> Query()
        {
            return _set.Include(x => x.Supplier).OrderBy(x => x.Id);
        }
    }
}
