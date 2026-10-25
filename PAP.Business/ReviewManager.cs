using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class ReviewManager : ManagerBase<Review>
    {

        public ReviewManager() : base(new ReviewRepository())
        {
        }

    }
}
