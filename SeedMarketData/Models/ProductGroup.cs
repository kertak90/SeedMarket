using System;
using System.ComponentModel.DataAnnotations;

namespace SeedMarketData
{
    public class ProductGroup
    {
        [Key]
        public Guid ProductGroupBaseId { get; set; }
        [Required]
        public String ProductGroupBaseName { get; set; }
    }
}