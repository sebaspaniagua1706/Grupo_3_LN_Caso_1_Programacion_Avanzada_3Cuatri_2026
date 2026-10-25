using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class GenreManager : ManagerBase<Genre>
    {

        public GenreManager() : base(new GenreRepository())
        {
        }

    }
}
