using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

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

        //Action that save the customer data to the database
        public ActionResult create() {
            return View();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.customers.Include(C => C.MembershipType).ToList();
            
            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(C => C.MembershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}