using PAP.DataAccess;
using PAP.Repositories;


namespace PAP.Business
{
    public class PublisherManager : ManagerBase<Publisher>
    {

        public PublisherManager() : base(new PublisherRepository())
        {
        }

    }
}
