using System;
using System.Collections.Generic;

namespace SeedMarketData
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}