using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Int32 Quantity { get; set; }
        public String Description { get; set; }
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public String DeliveryAdress { get; set; }
        public DateTime PurshaseDate { get; set; }
        public Int16 StatusId { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
    }
}