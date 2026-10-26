using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using BookAuthorRow = PAP.Models.BookAuthorRow;

namespace PAP.Generators
{
    public class BookAuthorGenerator : IGenerator
    {
        private readonly BookAuthorRepository _repository;
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;

        public BookAuthorGenerator()
        {
            _repository = new BookAuthorRepository();
            _bookRepository = new BookRepository();
            _authorRepository = new AuthorRepository();
        }

        public string EntityName
        {
            get { return "BookAuthors"; }
        }

        public int Count()
        {
            return _repository.Count();
        }

        public GeneratorResult Generate()
        {
            try
            {
                if (_repository.Any())
                {
                    return new GeneratorResult
                    {
                        Success = false,
                        Message =
                            "La tabla BookAuthors ya contiene datos."
                    };
                }

                var books = _bookRepository.GetAll().ToList();
                var authors = _authorRepository.GetAll().ToList();

                if (!books.Any())
                {
                    return new GeneratorResult
                    {
                        Success = false,
                        Message = "Primero debe generar Books."
                    };
                }

                if (!authors.Any())
                {
                    return new GeneratorResult
                    {
                        Success = false,
                        Message = "Primero debe generar Authors."
                    };
                }

                var relationships = books.Select((book, index) =>
                    new BookAuthorRow
                    {
                        BookId = book.Id,
                        BookTitle = book.Title,
                        AuthorId = authors[index % authors.Count].Id,
                        AuthorName =
                            authors[index % authors.Count].FirstName +
                            " " +
                            authors[index % authors.Count].LastName
                    }).ToList();

                _repository.AddRange(relationships);

                return new GeneratorResult
                {
                    Success = true,
                    GeneratedRecords = relationships.Count,
                    Message = "Se generaron " +
                              relationships.Count +
                              " relaciones BookAuthors."
                };
            }
            catch (Exception ex)
            {
                return new GeneratorResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}