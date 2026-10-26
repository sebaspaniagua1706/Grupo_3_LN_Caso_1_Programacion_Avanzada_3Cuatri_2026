using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Generators
{
    public class BookGenerator : GeneratorBase<Book>
    {
        private readonly PublisherRepository _publisherRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly GenreRepository _genreRepository;

        public BookGenerator() : base(new BookRepository())
        {
            _publisherRepository = new PublisherRepository();
            _categoryRepository = new CategoryRepository();
            _genreRepository = new GenreRepository();
        }

        public override string EntityName
        {
            get { return "Books"; }
        }

        protected override IEnumerable<Book> CreateData()
        {
            var publishers = _publisherRepository.GetAll().ToList();
            var categories = _categoryRepository.GetAll().ToList();
            var genres = _genreRepository.GetAll().ToList();

            if (!publishers.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Publishers.");

            if (!categories.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Categories.");

            if (!genres.Any())
                throw new InvalidOperationException(
                    "Primero debe generar Genres.");

            var books = new List<Book>();

            for (var index = 0; index < 10; index++)
            {
                var publisher = publishers[index % publishers.Count];
                var category = categories[index % categories.Count];
                var genre = genres[index % genres.Count];

                books.Add(new Book
                {
                    Name = "Libro generado " + (index + 1),
                    Title = "Libro generado " + (index + 1),
                    Category = category.Name,
                    Publisher = publisher.Name,
                    Author = "Autor pendiente de asociación",
                    Description = "Libro generado automáticamente.",
                    PublicationDate = DateTime.Today.AddMonths(-index),
                    Height = 23.5m,
                    Width = 16.0m,
                    Price = 15000m + (index * 1250m),
                    IsBestSeller = index % 3 == 0,
                    Genre = genre.Name,
                    IsInStock = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    PublisherId = publisher.Id,
                    CategoryId = category.Id,
                    GenreId = genre.Id,
                    ISBN = "978000000" + (100 + index),
                    Pages = 200 + (index * 20),
                    Language = "Español",
                    CoverImageUrl = null
                });
            }

            return books;
        }
    }
}