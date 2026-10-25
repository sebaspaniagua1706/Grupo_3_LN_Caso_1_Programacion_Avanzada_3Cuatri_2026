using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class RoleManager : ManagerBase<Role>
    {

        public RoleManager() : base(new RoleRepository())
        {
        }

    }
}
