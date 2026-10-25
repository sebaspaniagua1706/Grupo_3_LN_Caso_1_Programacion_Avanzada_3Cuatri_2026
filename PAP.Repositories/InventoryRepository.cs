using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>
    {
        protected override IQueryable<Inventory> Query()
        {
            return _set.Include(x => x.Book).OrderBy(x => x.Id);
        }
    }
}
