using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class CustomerManager : ManagerBase<Customer>
    {

        public CustomerManager() : base(new CustomerRepository())
        {
        }

    }
}
