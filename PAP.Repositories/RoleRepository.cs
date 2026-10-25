using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class RoleRepository : RepositoryBase<Role>
    {
        protected override IQueryable<Role> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
