using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;
using AutoMapper;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.Single(c => c.Id == Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDTO, Customer>(customerDto,customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        //add IsActive flag in customers and do a soft delete
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
