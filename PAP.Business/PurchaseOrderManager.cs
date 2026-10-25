using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class PurchaseOrderManager : ManagerBase<PurchaseOrder>
    {

        public PurchaseOrderManager() : base(new PurchaseOrderRepository())
        {
        }

    }
}
