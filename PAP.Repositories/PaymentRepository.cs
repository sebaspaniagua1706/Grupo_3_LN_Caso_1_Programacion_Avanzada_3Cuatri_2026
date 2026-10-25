using PAP.DataAccess;
using System.Linq;

namespace PAP.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>
    {
        protected override IQueryable<Payment> Query()
        {
            return _set.OrderBy(x => x.Id);
        }
    }
}
