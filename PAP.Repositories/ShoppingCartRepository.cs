using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>
    {
        protected override IQueryable<ShoppingCart> Query()
        {
            return _set.Include(x => x.Customer).OrderBy(x => x.Id);
        }
    }
}
