using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class CartItemGenerator : GeneratorBase<CartItem>
    {
        private readonly ShoppingCartRepository _cartRepository;
        private readonly BookRepository _bookRepository;

        public CartItemGenerator() : base(new CartItemRepository())
        {
            _cartRepository = new ShoppingCartRepository();
            _bookRepository = new BookRepository();
        }

        public override string EntityName
        {
            get { return "CartItems"; }
        }

        protected override IEnumerable<CartItem> CreateData()
        {
            var carts = _cartRepository.GetAll().ToList();
            var books = _bookRepository.GetAll().ToList();

            if (!carts.Any())
                throw new InvalidOperationException(
                    "Primero debe generar ShoppingCarts.");

            if (!books.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Books.");

            return carts.Select((cart, index) => new CartItem
            {
                CartId = cart.Id,
                BookId = books[index % books.Count].Id,
                Quantity = (index % 3) + 1,
                AddedAt = DateTime.Now
            }).ToList();
        }
    }
}