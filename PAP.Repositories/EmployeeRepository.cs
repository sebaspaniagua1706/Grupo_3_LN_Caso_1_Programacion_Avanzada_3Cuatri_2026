using PAP.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        protected override IQueryable<Employee> Query()
        {
            return _set.Include(x => x.Role).OrderBy(x => x.Id);
        }
    }
}
