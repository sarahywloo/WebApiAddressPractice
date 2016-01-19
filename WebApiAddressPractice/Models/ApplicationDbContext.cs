using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiAddressPractice.Models {
    public class ApplicationDbContext : DbContext {

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Address> Addresses { get; set; }
    }
}