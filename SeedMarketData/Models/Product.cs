using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public String ProductName { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public Int16? StatusId { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        [JsonIgnore]
        public List<String> ProductPhotos { get; set; }
        [JsonIgnore]
        public List<ProductGroup> ProductGrups { get; set; }
    }
}