using Microsoft.AspNetCore.Mvc;
using SeedMarketData.Repository;
using System.Threading;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using Newtonsoft.Json;
using SeedMarket.Services;
using SeedMarket.Middleware;

namespace SeedMarketData
{
    [ControllerExceptionFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private readonly RecordsContext _context;
        private readonly MainControllerService _mainControllerService;
        public MainController(RecordsContext context,
            MainControllerService mainControllerService)
        {
            _context = context;
            _mainControllerService = mainControllerService;
        }

        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "Get all products", Description = "Get all products")]
        public async Task<string> GetProducts() => 
            await _mainControllerService.GetProducts();

        [HttpGet("Statuses")]
        public async Task<string> GetStatusess() => 
            await _mainControllerService.GetStatusess();

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Post new product group")]
        public async Task<IActionResult> AddNewProductGroup(ProductGroup newProductGroup) => 
            await _mainControllerService.AddNewProductGroup(newProductGroup);

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Add new products")]
        public async Task AddNewProduct(Product product) =>
            await _mainControllerService.AddNewProduct(product);

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Add new user")]
        public async Task AddNewUser(ApplicationUser applicationUser) =>
            await _mainControllerService.AddNewUser(applicationUser);
    }
}