using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeedMarketData
{
    public class ApplicationUser
    {
        [Key]
        public Guid ApplicationUserId { get; set; }
        [Required]
        public String ApplicationUserName { get; set; }
        public String ApplicationUserEmail { get; set; }
        [Required]
        public Int16 StatusId { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public Guid ApplicationRoleId { get; set; }
        [JsonIgnore]
        public ApplicationRole ApplicationRole { get; set; }
    }
}