using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAP.Business;

namespace PAP.Generators
{
    internal class AddressGenerator
    {
        private readonly AddressManager _repository; //Instanciamos el AddressManager pa manejar el repo y poder usar los metodos

        public AddressGenerator() //Constructor de nuestro AddressGenerator para empezar a utilizar los metodos de este
        {
            _repository = new AddressManager();
        }

        public void GenerateMassData()
        {

            if (true) //Verificacion de si ya tiene datos
            {
                Console.WriteLine("Error, la tabla ya tiene datos");
                return; //Si ya tiene datos, no hace nada
            }



        }

    }
}
