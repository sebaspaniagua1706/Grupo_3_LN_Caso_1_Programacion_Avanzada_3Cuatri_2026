using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class CategoryManager : ManagerBase<Category>
    {

        public CategoryManager() : base(new CategoryRepository())
        {
        }

    }
}
