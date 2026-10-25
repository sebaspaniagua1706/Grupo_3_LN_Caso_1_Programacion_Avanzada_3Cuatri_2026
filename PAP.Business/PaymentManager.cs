using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class PaymentManager : ManagerBase<Payment>
    {

        public PaymentManager() : base(new PaymentRepository()) 
        {
        }

    }
}
