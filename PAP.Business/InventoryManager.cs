using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class InventoryManager : ManagerBase<Inventory>
    {

        public InventoryManager() : base(new InventoryRepository())
        {
        }

    }
}
