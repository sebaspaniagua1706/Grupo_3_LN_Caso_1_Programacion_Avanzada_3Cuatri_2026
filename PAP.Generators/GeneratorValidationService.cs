using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAP.Generators
{
    /// <summary>
    /// Controla el orden de generación y verifica las
    /// dependencias entre las diferentes entidades.
    /// </summary>
    public class GeneratorValidationService
    {
        private readonly Dictionary<string, string[]>
            _dependencies;

        public GeneratorValidationService()
        {
            _dependencies =
                new Dictionary<string, string[]>(
                    StringComparer.OrdinalIgnoreCase)
                {
                    {
                        "Roles",
                        new string[0]
                    },
                    {
                        "Employees",
                        new[] { "Roles" }
                    },
                    {
                        "Authors",
                        new string[0]
                    },
                    {
                        "Publishers",
                        new string[0]
                    },
                    {
                        "Categories",
                        new string[0]
                    },
                    {
                        "Genres",
                        new string[0]
                    },
                    {
                        "Customers",
                        new string[0]
                    },
                    {
                        "Suppliers",
                        new string[0]
                    },
                    {
                        "Books",
                        new[]
                        {
                            "Publishers",
                            "Categories",
                            "Genres"
                        }
                    },
                    {
                        "BookAuthors",
                        new[]
                        {
                            "Books",
                            "Authors"
                        }
                    },
                    {
                        "Addresses",
                        new[] { "Customers" }
                    },
                    {
                        "ShoppingCarts",
                        new[] { "Customers" }
                    },
                    {
                        "Inventory",
                        new[] { "Books" }
                    },
                    {
                        "CartItems",
                        new[]
                        {
                            "ShoppingCarts",
                            "Books"
                        }
                    },
                    {
                        "Orders",
                        new[]
                        {
                            "Customers",
                            "Addresses"
                        }
                    },
                    {
                        "OrderItems",
                        new[]
                        {
                            "Orders",
                            "Books"
                        }
                    },
                    {
                        "Payments",
                        new[] { "Orders" }
                    },
                    {
                        "PurchaseOrders",
                        new[] { "Suppliers" }
                    },
                    {
                        "PurchaseOrderItems",
                        new[]
                        {
                            "PurchaseOrders",
                            "Books"
                        }
                    },
                    {
                        "Reviews",
                        new[]
                        {
                            "Books",
                            "Customers"
                        }
                    }
                };
        }

        public IList<GeneratorStatus> GetStatuses(
            IEnumerable<IGenerator> generators)
        {
            if (generators == null)
            {
                throw new ArgumentNullException("generators");
            }

            var generatorList = generators.ToList();

            var currentRecords =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (var generator in generatorList)
            {
                currentRecords[generator.EntityName] =
                    generator.Count();
            }

            var statuses = new List<GeneratorStatus>();

            foreach (var generator in generatorList)
            {
                string[] dependencies;

                if (!_dependencies.TryGetValue(
                    generator.EntityName,
                    out dependencies))
                {
                    dependencies = new string[0];
                }

                var missingDependencies = dependencies
                    .Where(dependency =>
                        !currentRecords.ContainsKey(dependency) ||
                        currentRecords[dependency] == 0)
                    .ToArray();

                var count =
                    currentRecords[generator.EntityName];

                var hasData = count > 0;

                var canGenerate =
                    !hasData &&
                    missingDependencies.Length == 0;

                statuses.Add(new GeneratorStatus
                {
                    EntityName = generator.EntityName,
                    CurrentRecords = count,
                    HasData = hasData,
                    CanGenerate = canGenerate,
                    Dependencies = dependencies,
                    MissingDependencies = missingDependencies
                });
            }

            return statuses;
        }
    }
}