using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class PurchaseOrderItemGenerator :
        GeneratorBase<PurchaseOrderItem>
    {
        private readonly PurchaseOrderRepository
            _purchaseOrderRepository;

        private readonly BookRepository _bookRepository;

        public PurchaseOrderItemGenerator()
            : base(new PurchaseOrderItemRepository())
        {
            _purchaseOrderRepository =
                new PurchaseOrderRepository();

            _bookRepository = new BookRepository();
        }

        public override string EntityName
        {
            get { return "PurchaseOrderItems"; }
        }

        protected override IEnumerable<PurchaseOrderItem> CreateData()
        {
            var purchaseOrders =
                _purchaseOrderRepository.GetAll().ToList();

            var books = _bookRepository.GetAll().ToList();

            if (!purchaseOrders.Any())
                throw new InvalidOperationException(
                    "Primero debe generar PurchaseOrders.");

            if (!books.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Books.");

            return purchaseOrders.Select((purchaseOrder, index) =>
            {
                var book = books[index % books.Count];

                return new PurchaseOrderItem
                {
                    PurchaseOrderId = purchaseOrder.Id,
                    BookId = book.Id,
                    Quantity = 10,
                    UnitCost = book.Price * 0.60m
                };
            }).ToList();
        }
    }
}