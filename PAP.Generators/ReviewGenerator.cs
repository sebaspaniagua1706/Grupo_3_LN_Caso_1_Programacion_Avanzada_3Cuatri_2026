using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class ReviewGenerator : GeneratorBase<Review>
    {
        private readonly BookRepository _bookRepository;
        private readonly CustomerRepository _customerRepository;

        public ReviewGenerator() : base(new ReviewRepository())
        {
            _bookRepository = new BookRepository();
            _customerRepository = new CustomerRepository();
        }

        public override string EntityName
        {
            get { return "Reviews"; }
        }

        protected override IEnumerable<Review> CreateData()
        {
            var books = _bookRepository.GetAll().ToList();
            var customers = _customerRepository.GetAll().ToList();

            if (!books.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Books.");

            if (!customers.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Customers.");

            return customers.Select((customer, index) => new Review
            {
                BookId = books[index % books.Count].Id,
                CustomerId = customer.Id,
                Rating = (byte)((index % 5) + 1),
                Comment = "Reseña generada automáticamente.",
                CreatedAt = DateTime.Now
            }).ToList();
        }
    }
}