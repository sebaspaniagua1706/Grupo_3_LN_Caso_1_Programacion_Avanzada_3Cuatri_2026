using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class SupplierManager : ManagerBase<Supplier>
    {

        public SupplierManager() : base(new SupplierRepository())
        {
        }

    }
}
