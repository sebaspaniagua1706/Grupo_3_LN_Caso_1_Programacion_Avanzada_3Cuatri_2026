using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class GenreGenerator : GeneratorBase<Genre>
    {
        public GenreGenerator() : base(new GenreRepository())
        {
        }

        public override string EntityName
        {
            get { return "Genres"; }
        }

        protected override IEnumerable<Genre> CreateData()
        {
            return new List<Genre>
            {
                new Genre
                {
                    Name = "Novela",
                    Description = "Narraciones literarias extensas."
                },
                new Genre
                {
                    Name = "Programación",
                    Description = "Desarrollo de software y programación."
                },
                new Genre
                {
                    Name = "Biografía",
                    Description = "Historia de la vida de una persona."
                },
                new Genre
                {
                    Name = "Ciencia ficción",
                    Description = "Historias basadas en ciencia y tecnología."
                }
            };
        }
    }
}