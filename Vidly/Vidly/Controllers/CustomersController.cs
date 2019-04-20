using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private MyDBContext _context;
        public CustomersController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        //public ActionResult Index()
        //{
        //    var viewModel = new CustomersViewModel();//dont need a viewmodel here. viewmodel should be kept for two or more models interacting.
        //    var customers = new List<Customer>()
        //    {
        //        new Customer(){ Id = 1, Name = "John Smith"},
        //        new Customer(){ Id = 2, Name = "Mary Williams"}
        //    };
        //    viewModel.Customers = customers;

        //    return View(viewModel);
        //}

        public ActionResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();
            return View(customers);
        }

        //public ActionResult View(int Id)
        //{
        //    var customer = GetCustomers()
        //        .Where(c => c.Id == Id)
        //        .FirstOrDefault();
        //    if (customer == null)
        //        return HttpNotFound();
        //    return View(customer);
        //}

        public ActionResult View(int Id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Where(c => c.Id == Id)
                .First();
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            return View();
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer{ Id = 1, Name = "John Smith"},
        //        new Customer{ Id = 2, Name = "Mary Williams"}

        //    };
        //    return customers;
        //}
    }
}