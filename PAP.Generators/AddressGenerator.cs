using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class AddressGenerator : GeneratorBase<Address>
    {
        private readonly CustomerRepository _customerRepository;

        public AddressGenerator() : base(new AddressRepository())
        {
            _customerRepository = new CustomerRepository();
        }

        public override string EntityName
        {
            get { return "Addresses"; }
        }

        protected override IEnumerable<Address> CreateData()
        {
            var customers = _customerRepository.GetAll().ToList();

            if (!customers.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Customers.");
            }

            return customers.Select((customer, index) => new Address
            {
                CustomerId = customer.Id,
                AddressType = "Casa",
                Street = "Calle principal, casa " + (index + 1),
                City = "San José",
                State = "San José",
                PostalCode = "10101",
                Country = "Costa Rica",
                IsDefault = true
            }).ToList();
        }
    }
}