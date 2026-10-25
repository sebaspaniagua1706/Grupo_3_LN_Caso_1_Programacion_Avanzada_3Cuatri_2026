using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class AddressRepository : RepositoryBase<Address>
    {
        protected override IQueryable<Address> Query()
        {
            return _set.Include(x => x.Customer).OrderBy(x => x.Id);
        }
    }
}
