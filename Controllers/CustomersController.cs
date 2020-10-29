using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Action that create the new customer form. It take view model that include
        //the customer model and membership type model
        public ActionResult NewCustomerForm() {
            var membershipTypes = _context.membershipTypes.ToList();

            var membershipTypeViewModel = new NewCustomerFormViewModels
            {
                MembershipTypes = membershipTypes
            };
            return View(membershipTypeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Action that save the customer data to the database
        public ActionResult create(Customer customer) {
            if (!ModelState.IsValid) {
                var viewModel = new NewCustomerFormViewModels
                {
                    customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("NewCustomerForm", viewModel);
            }
            if (customer.id == 0) {
                
                Customer newCust = new Customer();
                newCust.id = customer.id;
                newCust.name = customer.name;
                newCust.BirthDate = customer.BirthDate;
                newCust.MembershipTypeId = customer.MembershipTypeId;
                newCust.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                
                _context.customers.Add(newCust);
            }
            else {
                var customerinDb = _context.customers.Single(c => c.id == customer.id);
                customerinDb.name = customer.name;
                customerinDb.BirthDate = Convert.ToDateTime(customer.BirthDate);
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e) {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Customers");
        }

        //Edit customer
        public ActionResult Edit(int id) {
            var customer = _context.customers.SingleOrDefault(c => c.id==id);
            if (customer == null)
                HttpNotFound();
            var customerMemBershipViewModel = new NewCustomerFormViewModels
            {
                customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("NewCustomerForm", customerMemBershipViewModel);
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.customers.Include(C => C.MembershipType).ToList();
            Console.WriteLine(customers);
            return View(customers);
        }

        //[Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(C => C.MembershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}