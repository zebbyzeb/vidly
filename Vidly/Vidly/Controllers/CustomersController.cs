using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel();
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "John Smith"},
                new Customer(){ Id = 2, Name = "Mary Williams"}
            };
            viewModel.Customers = customers;

            return View(viewModel);
        }

        public ActionResult View(int Id)
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "John Smith"},
                new Customer(){ Id = 2, Name = "Mary Williams"}
            };
            var query = customers.Where(c => c.Id == Id)
                .First();
            return Content(query.Name);
        }
    }
}