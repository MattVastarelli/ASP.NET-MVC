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

        //a given customers info
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            //all customers in the database in to a list
            var customer =  _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                var viewModel = new CustomerDetails
                {
                    Customer = customer
                };

                return View("Details", viewModel);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }
    }
}