using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class OrderItemGenerator : GeneratorBase<OrderItem>
    {
        private readonly OrderRepository _orderRepository;
        private readonly BookRepository _bookRepository;

        public OrderItemGenerator() : base(new OrderItemRepository())
        {
            _orderRepository = new OrderRepository();
            _bookRepository = new BookRepository();
        }

        public override string EntityName
        {
            get { return "OrderItems"; }
        }

        protected override IEnumerable<OrderItem> CreateData()
        {
            var orders = _orderRepository.GetAll().ToList();
            var books = _bookRepository.GetAll().ToList();

            if (!orders.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Orders.");

            if (!books.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Books.");

            return orders.Select((order, index) =>
            {
                var book = books[index % books.Count];

                return new OrderItem
                {
                    OrderId = order.Id,
                    BookId = book.Id,
                    Quantity = 1,
                    UnitPrice = book.Price,
                    Discount = 0m
                };
            }).ToList();
        }
    }
}