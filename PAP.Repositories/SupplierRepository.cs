using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>
    {
        protected override IQueryable<Supplier> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
