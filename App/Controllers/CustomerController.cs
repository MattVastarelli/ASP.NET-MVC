using System;
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
        // GET: Customer
        public ActionResult Index()
        {
            //make the customer list
            var customers = new List<Customer>
            {
                //make and add the customers to the list
                new Customer{Name = "John Smith", Id = 1},
                new Customer{Name = "Mary Williams", Id = 2}
            };

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
            //make the customer list
            var customers = new List<Customer>
            {
                //make and add the customers to the list
                new Customer{Name = "John Smith", Id = 1},
                new Customer{Name = "Mary Williams", Id = 2}
            };

            if (customers.Count >= id)
            {
                var viewModel = new CustomerDetails
                {
                    Customer = customers[id - 1]
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