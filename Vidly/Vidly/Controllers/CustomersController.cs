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
            var customer = GetCustomers()
                .Where(c => c.Id == Id)
                .FirstOrDefault();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{ Id = 1, Name = "John Smith"},
                new Customer{ Id = 2, Name = "Mary Williams"}

            };
            return customers;
        }
    }
}