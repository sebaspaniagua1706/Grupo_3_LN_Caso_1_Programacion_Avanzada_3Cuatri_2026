using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class EmployeeGenerator : GeneratorBase<Employee>
    {
        private readonly RoleRepository _roleRepository;

        public EmployeeGenerator() : base(new EmployeeRepository())
        {
            _roleRepository = new RoleRepository();
        }

        public override string EntityName
        {
            get { return "Employees"; }
        }

        protected override IEnumerable<Employee> CreateData()
        {
            var roles = _roleRepository.GetAll().ToList();

            if (!roles.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Roles.");
            }

            return roles.Select((role, index) => new Employee
            {
                RoleId = role.Id,
                FirstName = "Empleado" + (index + 1),
                LastName = role.Name,
                Email = "empleado" + (index + 1) + "@pap.example",
                PasswordHash = "HASH_DEMO_" + (index + 1),
                IsActive = true,
                CreatedAt = DateTime.Now
            }).ToList();
        }
    }
}