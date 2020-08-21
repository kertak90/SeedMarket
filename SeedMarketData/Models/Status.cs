using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        [Required]
        public String StatusName { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}