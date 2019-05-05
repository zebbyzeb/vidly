using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.Single(c => c.Id == Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        //add IsAvtive flag in customers and do a soft delete
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
