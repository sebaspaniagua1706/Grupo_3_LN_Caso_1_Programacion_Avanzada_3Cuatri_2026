using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class CartItemManager : ManagerBase<CartItem>
    {

        public CartItemManager() : base(new CartItemRepository())
        {
        }

    }
}
