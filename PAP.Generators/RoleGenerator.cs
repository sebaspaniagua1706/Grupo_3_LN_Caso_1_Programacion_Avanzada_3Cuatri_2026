using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class RoleGenerator : GeneratorBase<Role>
    {
        public RoleGenerator() : base(new RoleRepository())
        {
        }

        public override string EntityName
        {
            get { return "Roles"; }
        }

        protected override IEnumerable<Role> CreateData()
        {
            return new List<Role>
            {
                new Role
                {
                    Name = "Administrador"
                },
                new Role
                {
                    Name = "Vendedor"
                },
                new Role
                {
                    Name = "Bodega"
                }
            };
        }
    }
}