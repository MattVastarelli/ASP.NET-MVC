using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using App.ViewModels;

namespace App.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        //database
        private ApplicationDbContext _context;
        //constructor
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //dispose of application db context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {
            //all customers in the database in to a list
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            

            //add the customers to the view model
            var viewModel = new CustomersViewModel
            {
                Customers = customers
            };

            return View("Customers",viewModel);
        }

        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}