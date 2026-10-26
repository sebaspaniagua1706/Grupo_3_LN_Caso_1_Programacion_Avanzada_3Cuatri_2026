using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class CustomerGenerator : GeneratorBase<Customer>
    {
        public CustomerGenerator() : base(new CustomerRepository())
        {
        }

        public override string EntityName
        {
            get { return "Customers"; }
        }

        protected override IEnumerable<Customer> CreateData()
        {
            var now = DateTime.Now;

            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Ana",
                    LastName = "Rodríguez",
                    Email = "ana.rodriguez@example.com",
                    PasswordHash = "HASH_DEMO_ANA",
                    Phone = "8888-1001",
                    BirthDate = new DateTime(1995, 4, 12),
                    IsActive = true,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Customer
                {
                    FirstName = "Luis",
                    LastName = "Mora",
                    Email = "luis.mora@example.com",
                    PasswordHash = "HASH_DEMO_LUIS",
                    Phone = "8888-1002",
                    BirthDate = new DateTime(1992, 8, 23),
                    IsActive = true,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Customer
                {
                    FirstName = "María",
                    LastName = "Fernández",
                    Email = "maria.fernandez@example.com",
                    PasswordHash = "HASH_DEMO_MARIA",
                    Phone = "8888-1003",
                    BirthDate = new DateTime(1998, 2, 15),
                    IsActive = true,
                    CreatedAt = now,
                    UpdatedAt = now
                }
            };
        }
    }
}