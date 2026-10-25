using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class OrderItemManager : ManagerBase<OrderItem>
    {

        public OrderItemManager() : base(new OrderItemRepository())
        {
        }

    }
}
