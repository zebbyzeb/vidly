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
            var membershipTypes = _context.MembershipTypes
                .ToList();
            //var customer = new Customer();
            var newCustomer = new NewCustomerViewModel()
            {
                //Customer = new Customer(),
                //Id = customer.Id,
                MembershipTypes = membershipTypes
            };
            return View(newCustomer);
        }

        [ActionName("New")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewCustomerViewModel viewModel)
        {
            //validate the customer model
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes
                    .ToList();
                viewModel.MembershipTypes = membershipTypes;
                return View("New", viewModel);
            }

            //If the customer is a new customer
            //if (viewModel.Customer.Id == 0)
            if (viewModel.Id == 0)
            {
                var customer = new Customer()
                {
                    Name = viewModel.Name,
                    Birthdate = viewModel.Birthdate,
                    IsSubscribedToNewsLetter = viewModel.IsSubscribedToNewsLetter,
                    MembershipTypeId = viewModel.MembershipTypeId
                };
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Id);

                //    //Mapper.Map(viewModel.Customer, customerInDb);
                customerInDb.Name = viewModel.Name;
                customerInDb.Birthdate = viewModel.Birthdate;
                customerInDb.MembershipTypeId = viewModel.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = viewModel.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers
                .Where(c => c.Id == Id)
                .ToList()
                .FirstOrDefault();
            
            var viewModel = new NewCustomerViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New",viewModel);
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