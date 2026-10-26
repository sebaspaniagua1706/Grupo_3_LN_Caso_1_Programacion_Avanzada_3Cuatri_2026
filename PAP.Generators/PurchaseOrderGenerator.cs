using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class PurchaseOrderGenerator :
        GeneratorBase<PurchaseOrder>
    {
        private readonly SupplierRepository _supplierRepository;

        public PurchaseOrderGenerator()
            : base(new PurchaseOrderRepository())
        {
            _supplierRepository = new SupplierRepository();
        }

        public override string EntityName
        {
            get { return "PurchaseOrders"; }
        }

        protected override IEnumerable<PurchaseOrder> CreateData()
        {
            var suppliers = _supplierRepository.GetAll().ToList();

            if (!suppliers.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Suppliers.");
            }

            return suppliers.Select((supplier, index) =>
                new PurchaseOrder
                {
                    SupplierId = supplier.Id,
                    OrderDate = DateTime.Now,
                    ExpectedDate = DateTime.Now.AddDays(7 + index),
                    Status = "Pendiente",
                    TotalCost = 50000m + (index * 10000m)
                }).ToList();
        }
    }
}