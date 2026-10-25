using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class CartItemRepository : RepositoryBase<CartItem>
    {
        protected override IQueryable<CartItem> Query()
        {
            return _set.Include(x => x.Book).OrderBy(x => x.Id);
        }
    }
}
