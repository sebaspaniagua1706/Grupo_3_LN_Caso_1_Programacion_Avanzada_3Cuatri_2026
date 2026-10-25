using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class PurchaseOrderItemManager : ManagerBase<PurchaseOrderItem>
    {

        public PurchaseOrderItemManager() : base(new PurchaseOrderItemRepository())
        {
        }

    }
}
