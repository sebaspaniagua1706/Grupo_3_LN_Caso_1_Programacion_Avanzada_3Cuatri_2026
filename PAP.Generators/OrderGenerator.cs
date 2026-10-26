using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class OrderGenerator : GeneratorBase<Order>
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;

        public OrderGenerator() : base(new OrderRepository())
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new AddressRepository();
        }

        public override string EntityName
        {
            get { return "Orders"; }
        }

        protected override IEnumerable<Order> CreateData()
        {
            var customers = _customerRepository.GetAll().ToList();
            var addresses = _addressRepository.GetAll().ToList();

            if (!customers.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Customers.");

            if (!addresses.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Addresses.");

            var orders = new List<Order>();

            foreach (var customer in customers)
            {
                var address = addresses.FirstOrDefault(
                    item => item.CustomerId == customer.Id);

                if (address == null)
                    continue;

                const decimal subtotal = 25000m;
                const decimal tax = 3250m;
                const decimal shipping = 2000m;

                orders.Add(new Order
                {
                    CustomerId = customer.Id,
                    ShippingAddressId = address.Id,
                    OrderDate = DateTime.Now,
                    Status = "Pendiente",
                    Subtotal = subtotal,
                    TaxAmount = tax,
                    ShippingCost = shipping,
                    Total = subtotal + tax + shipping,
                    Notes = "Orden generada automáticamente.",
                    UpdatedAt = DateTime.Now
                });
            }

            return orders;
        }
    }
}