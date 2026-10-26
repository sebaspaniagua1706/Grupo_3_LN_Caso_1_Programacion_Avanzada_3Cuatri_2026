using PAP.DataAccess;
using PAP.Repositories;
using System;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class PublisherGenerator : GeneratorBase<Publisher>
    {
        public PublisherGenerator() : base(new PublisherRepository())
        {
        }

        public override string EntityName
        {
            get { return "Publishers"; }
        }

        protected override IEnumerable<Publisher> CreateData()
        {
            return new List<Publisher>
            {
                new Publisher
                {
                    Name = "Editorial Costa Rica",
                    Country = "Costa Rica",
                    Website = "https://www.editorialcr.example",
                    Email = "contacto@editorialcr.example",
                    CreatedAt = DateTime.Now
                },
                new Publisher
                {
                    Name = "Editorial Latinoamericana",
                    Country = "México",
                    Website = "https://www.editoriallatina.example",
                    Email = "contacto@editoriallatina.example",
                    CreatedAt = DateTime.Now
                },
                new Publisher
                {
                    Name = "Tecnología Press",
                    Country = "Estados Unidos",
                    Website = "https://www.tecnologiapress.example",
                    Email = "contacto@tecnologiapress.example",
                    CreatedAt = DateTime.Now
                }
            };
        }
    }
}