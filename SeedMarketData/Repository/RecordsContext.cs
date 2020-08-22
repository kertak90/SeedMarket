using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SeedMarketData.Repository
{   
    public class RecordsContext : IdentityDbContext
    {
        private readonly string _connectionString;
        public RecordsContext() : base()
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Port=5432;Database=seed_market_db;User Id=test_user;Password=test_password
            // optionsBuilder.UseNpgsql(_connectionString);
        }
        public RecordsContext(DbContextOptions<RecordsContext> options) : base(options)
        {
            
        }
    }
}