using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersApiController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersApiController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        // Post /api/customers
        [HttpPost]
        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
