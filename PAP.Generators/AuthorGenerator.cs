using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class AuthorGenerator : GeneratorBase<Author>
    {
        public AuthorGenerator() : base(new AuthorRepository())
        {
        }

        public override string EntityName
        {
            get { return "Authors"; }
        }

        protected override IEnumerable<Author> CreateData()
        {
            return new List<Author>
            {
                new Author
                {
                    FirstName = "Gabriel",
                    LastName = "García Márquez",
                    Biography = "Escritor y periodista colombiano.",
                    BirthDate = new DateTime(1927, 3, 6),
                    Country = "Colombia",
                    CreatedAt = DateTime.Now
                },
                new Author
                {
                    FirstName = "Isabel",
                    LastName = "Allende",
                    Biography = "Escritora chilena reconocida internacionalmente.",
                    BirthDate = new DateTime(1942, 8, 2),
                    Country = "Chile",
                    CreatedAt = DateTime.Now
                },
                new Author
                {
                    FirstName = "Carlos",
                    LastName = "Ruiz Zafón",
                    Biography = "Novelista español.",
                    BirthDate = new DateTime(1964, 9, 25),
                    Country = "España",
                    CreatedAt = DateTime.Now
                }
            };
        }
    }
}