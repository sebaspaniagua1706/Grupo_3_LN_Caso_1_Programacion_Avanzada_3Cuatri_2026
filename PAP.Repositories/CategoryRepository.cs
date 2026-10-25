using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        protected override IQueryable<Category> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
