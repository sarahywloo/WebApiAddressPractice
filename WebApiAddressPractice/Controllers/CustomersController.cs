using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAddressPractice.Models;

namespace WebApiAddressPractice.Controllers
{
    public class CustomersController : ApiController {

        public static IList<Customer> _customers = new List<Customer>() {
            new Customer() {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe",
                ShippingAddress = new Address() {
                    Id = 1,
                    Street = "Richmond Avenue",
                    City = "Houston"
                },
                BillingAddress = new Address() {
                    Id = 2,
                    Street = "Gray Street",
                    City = "Houston"
                }
            }
        };

        public IHttpActionResult Post(Customer newCustomer) {
            _customers.Add(newCustomer);
            return Ok();
        }
    }
}
