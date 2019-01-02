using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using App.DTOS;
using App.Models;
using AutoMapper;

namespace App.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQyery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQyery = customersQyery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQyery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                //add the id to the customer dto
                customerDto.Id = customer.Id;

                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<CustomerDTO, Customer>(customerDto, customerInDb);

                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        }
    }
}
