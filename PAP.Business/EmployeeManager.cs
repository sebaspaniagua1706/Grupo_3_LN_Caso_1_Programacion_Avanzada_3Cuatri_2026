using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class EmployeeManager : ManagerBase<Employee>
    {

        public EmployeeManager() : base(new EmployeeRepository())
        {
        }

    }
}
