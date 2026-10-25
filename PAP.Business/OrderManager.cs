using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class OrderManager : ManagerBase<Order>
    {

        public OrderManager() : base(new OrderRepository())
        {
        }

    }
}
