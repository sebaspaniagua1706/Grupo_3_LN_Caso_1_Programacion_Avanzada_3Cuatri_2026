using PAP.DataAccess;
using PAP.Repositories;

namespace PAP.Business
{
    public class AddressManager : ManagerBase<Address> //Clase manager incluye la base con objetos de tipo Address
    {
        public AddressManager() : base(new AddressRepository()) //Base -> Llama el constructor de la clase padre
        {
            //Constructor que incluye el repositorio de AddressRepository
        }
    }
}
