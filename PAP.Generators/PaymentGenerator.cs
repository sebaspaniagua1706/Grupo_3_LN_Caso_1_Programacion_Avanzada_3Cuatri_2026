using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class PaymentGenerator : GeneratorBase<Payment>
    {
        private readonly OrderRepository _orderRepository;

        public PaymentGenerator() : base(new PaymentRepository())
        {
            _orderRepository = new OrderRepository();
        }

        public override string EntityName
        {
            get { return "Payments"; }
        }

        protected override IEnumerable<Payment> CreateData()
        {
            var orders = _orderRepository.GetAll().ToList();

            if (!orders.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Orders.");
            }

            return orders.Select((order, index) => new Payment
            {
                OrderId = order.Id,
                PaymentMethod = index % 2 == 0
                    ? "Tarjeta"
                    : "Transferencia",
                Amount = order.Total,
                PaymentDate = DateTime.Now,
                Status = "Aprobado",
                TransactionRef = "TRX-" +
                                 DateTime.Now.ToString("yyyyMMdd") +
                                 "-" + order.Id
            }).ToList();
        }
    }
}