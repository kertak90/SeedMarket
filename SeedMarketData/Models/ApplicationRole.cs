using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class ApplicationRole
    {
        [Key]
        public Guid ApplicationRoleId { get; set; }
        [Required]
        public String RoleName { get; set; }
        [JsonIgnore]
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}