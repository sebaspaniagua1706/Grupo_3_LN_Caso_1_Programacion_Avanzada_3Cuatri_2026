using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class InventoryGenerator : GeneratorBase<Inventory>
    {
        private readonly BookRepository _bookRepository;

        public InventoryGenerator() : base(new InventoryRepository())
        {
            _bookRepository = new BookRepository();
        }

        public override string EntityName
        {
            get { return "Inventory"; }
        }

        protected override IEnumerable<Inventory> CreateData()
        {
            var books = _bookRepository.GetAll().ToList();

            if (!books.Any())
            {
                throw new InvalidOperationException(
                    "Primero debe generar Books.");
            }

            return books.Select((book, index) => new Inventory
            {
                BookId = book.Id,
                QuantityInStock = 10 + index,
                ReorderLevel = 5,
                LastRestockedAt = DateTime.Now
            }).ToList();
        }
    }
}