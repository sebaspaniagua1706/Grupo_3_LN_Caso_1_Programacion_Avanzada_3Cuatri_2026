using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class ShoppingCartManager : ManagerBase<ShoppingCart>
    {

        public ShoppingCartManager() : base(new ShoppingCartRepository())
        {
        }

    }
}
