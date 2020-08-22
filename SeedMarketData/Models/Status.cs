using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class Status
    {
        [Key]
        public Int16 StatusId { get; set; }
        [Required]
        public String StatusName { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}