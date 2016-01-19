using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAddressPractice.Models;

namespace WebApiAddressPractice.Controllers
{
    public class CustomersController : ApiController {

        //creating a field to make this a member of the class, we use private because we will only access it in this class
        private ApplicationDbContext _db = new ApplicationDbContext();

        public Customer Get(int id) {

            //using LINQ here
            return (from c in _db.Customers
                                .Include(c => c.BillingAddress)
                                .Include(c => c.ShippingAddress)
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        //public static IList<Customer> _customers = new List<Customer>() {
        //    new Customer() {
        //        Id = 1,
        //        FirstName = "Jane",
        //        LastName = "Doe",
        //        ShippingAddress = new Address() {
        //            Id = 1,
        //            Street = "Richmond Avenue",
        //            City = "Houston"
        //        },
        //        BillingAddress = new Address() {
        //            Id = 2,
        //            Street = "Gray Street",
        //            City = "Houston"
        //        }
        //    }
        //};

        //access modifier, return method, name: Post, parameter is customer type named customer
        public IHttpActionResult Post(Customer customer) {
            //_customers.Add(newCustomer);

            //To interact with the database, set db to a new context of the database, one operation per context
            //var db = new ApplicationDbContext();
            //to access the db set table to add customer
            _db.Customers.Add(customer);
            //so everytime we click submit, it will be added into the database
            _db.SaveChanges();
            //to return ok if it worked
            return Ok();
        }

        public IHttpActionResult Delete(int id) {
            //var db = new ApplicationDbContext();

            var customer = _db.Customers.Find(id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return Ok();
        }
    }
}
