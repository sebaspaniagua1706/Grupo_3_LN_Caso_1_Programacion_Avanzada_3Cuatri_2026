using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class ShoppingCartGenerator : GeneratorBase<ShoppingCart>
    {
        private readonly CustomerRepository _customerRepository;

        public ShoppingCartGenerator() : base(new ShoppingCartRepository())
        {
            _customerRepository = new CustomerRepository();
        }

        public override string EntityName
        {
            get { return "ShoppingCarts"; }
        }

        protected override IEnumerable<ShoppingCart> CreateData()
        {
            var customers = _customerRepository.GetAll().ToList();

            if (!customers.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Customers.");
            }

            return customers.Select(customer => new ShoppingCart
            {
                CustomerId = customer.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }).ToList();
        }
    }
}