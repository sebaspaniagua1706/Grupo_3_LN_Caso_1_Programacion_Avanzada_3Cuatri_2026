using PAP.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly GeneratorValidationService
            _validationService;

        public AdminController()
        {
            _validationService =
                new GeneratorValidationService();
        }

        private List<IGenerator> GetGenerators()
        {
            return new List<IGenerator>
            {
                new RoleGenerator(),
                new EmployeeGenerator(),

                new AuthorGenerator(),
                new PublisherGenerator(),
                new CategoryGenerator(),
                new GenreGenerator(),

                new CustomerGenerator(),
                new SupplierGenerator(),

                new BookGenerator(),
                new BookAuthorGenerator(),

                new AddressGenerator(),
                new ShoppingCartGenerator(),
                new InventoryGenerator(),
                new CartItemGenerator(),

                new OrderGenerator(),
                new OrderItemGenerator(),
                new PaymentGenerator(),

                new PurchaseOrderGenerator(),
                new PurchaseOrderItemGenerator(),

                new ReviewGenerator()
            };
        }

        [HttpGet]
        public ActionResult Index()
        {
            var generators = GetGenerators();

            var statuses =
                _validationService.GetStatuses(generators);

            return View(statuses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generate(string entity)
        {
            var generators = GetGenerators();

            var generator = generators.FirstOrDefault(
                item => string.Equals(
                    item.EntityName,
                    entity,
                    StringComparison.OrdinalIgnoreCase));

            if (generator == null)
            {
                TempData["Error"] =
                    "No se encontró el generador solicitado.";

                return RedirectToAction("Index");
            }

            var status = _validationService
                .GetStatuses(generators)
                .FirstOrDefault(item =>
                    string.Equals(
                        item.EntityName,
                        entity,
                        StringComparison.OrdinalIgnoreCase));

            if (status == null)
            {
                TempData["Error"] =
                    "No se pudo determinar el estado del generador.";

                return RedirectToAction("Index");
            }

            if (!status.CanGenerate)
            {
                TempData["Error"] =
                    status.ValidationMessage;

                return RedirectToAction("Index");
            }

            var result = generator.Generate();

            if (result.Success)
            {
                TempData["Success"] = result.Message;
            }
            else
            {
                TempData["Error"] = result.Message;
            }

            return RedirectToAction("Index");
        }
    }
}