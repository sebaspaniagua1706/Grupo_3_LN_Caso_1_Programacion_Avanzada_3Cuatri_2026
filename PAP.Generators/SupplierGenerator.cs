using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class SupplierGenerator : GeneratorBase<Supplier>
    {
        public SupplierGenerator() : base(new SupplierRepository())
        {
        }

        public override string EntityName
        {
            get { return "Suppliers"; }
        }

        protected override IEnumerable<Supplier> CreateData()
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Name = "Distribuidora Central",
                    ContactName = "Laura Gómez",
                    Email = "ventas@distribuidoracentral.example",
                    Phone = "2222-1001",
                    Address = "San José, Costa Rica",
                    IsActive = true
                },
                new Supplier
                {
                    Name = "Libros del Valle",
                    ContactName = "José Ramírez",
                    Email = "ventas@librosdelvalle.example",
                    Phone = "2222-1002",
                    Address = "Heredia, Costa Rica",
                    IsActive = true
                },
                new Supplier
                {
                    Name = "Importadora Educativa",
                    ContactName = "Andrea Castro",
                    Email = "ventas@importadoraeducativa.example",
                    Phone = "2222-1003",
                    Address = "Alajuela, Costa Rica",
                    IsActive = true
                }
            };
        }
    }
}