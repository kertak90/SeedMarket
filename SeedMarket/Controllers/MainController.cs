using Microsoft.AspNetCore.Mvc;
using SeedMarketData.Repository;
using System.Threading;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using Newtonsoft.Json;

namespace SeedMarketData
{
    [ApiController]
    [Route("main/[controller]")]
    public class MainController : Controller
    {
        private readonly RecordsContext _context;
        public MainController(RecordsContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "Get all products", Description = "Get all products")]
        public async Task GetProducts()
        {
            System.Console.WriteLine($"PrepareDB Method runned");
            System.Console.WriteLine($"done");
        }

        [HttpGet("Statuses")]
        public async Task<string> GetStatusess()
        {
            var statuses = _context.Statuses.ToList();
            return JsonConvert.SerializeObject(statuses);
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Post new product group")]
        public async Task AddNewProductGroup()
        {
            System.Console.WriteLine($"PrepareDB Method runned");
            System.Console.WriteLine($"done");
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Add new products")]
        public async Task AddNewProduct()
        {

        }
        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Add new user")]
        public async Task AddNewUser()
        {

        }
    }
}