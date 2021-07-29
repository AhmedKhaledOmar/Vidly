using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public  CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View(viewModel);
        }
        public async System.Threading.Tasks.Task<ActionResult> SaveAsync(Customer customer)
        {
            if (customer.Id == 0)
            {
                var url = "https://localhost:44331/api/customersapi";
                await API.PostAsync(url, customer);
            }
            else
            {
                var url = "https://localhost:44331/api/customersapi";
                await API.PutAsync(url, customer);
            }
            return RedirectToAction("Index", "Customers");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
               var viewModel = ViewCustomer(customer);
               return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
                EditCustomer(customer);

            _context.SaveChanges();

            return RedirectToAction("Index" , "Customers");
        }
        public ActionResult ViewEdit(int Id)
        {
            var customer =_context.Customers.SingleOrDefault( c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = ViewCustomer(customer);

            return View("CustomerForm", viewModel);
        }
        public ActionResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();
            return View(customers);
        }
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public Customer EditCustomer(Customer customer)
        {
            var customerInDb =  _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

            customerInDb.Name = customer.Name;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            return customerInDb;
        }
        public NewCustomerViewModel ViewCustomer(Customer customer)
        {          
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return viewModel;
        }
    }

}