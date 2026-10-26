using PAP.DataAccess;
using PAP.Repositories;
using System.Collections.Generic;

namespace PAP.Generators
{
    public class CategoryGenerator : GeneratorBase<Category>
    {
        public CategoryGenerator() : base(new CategoryRepository())
        {
        }

        public override string EntityName
        {
            get { return "Categories"; }
        }

        protected override IEnumerable<Category> CreateData()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Ficción",
                    Description = "Novelas y obras de ficción."
                },
                new Category
                {
                    Name = "Tecnología",
                    Description = "Libros de informática y tecnología."
                },
                new Category
                {
                    Name = "Historia",
                    Description = "Libros históricos y biográficos."
                },
                new Category
                {
                    Name = "Educación",
                    Description = "Libros educativos y académicos."
                }
            };
        }
    }
}