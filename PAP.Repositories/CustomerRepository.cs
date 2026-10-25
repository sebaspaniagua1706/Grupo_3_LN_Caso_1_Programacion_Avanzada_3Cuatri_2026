using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        protected override IQueryable<Customer> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
