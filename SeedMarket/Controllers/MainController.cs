using Microsoft.AspNetCore.Mvc;
using SeedMarketData.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace SeedMarketData
{
    public class MainController : Controller
    {
        private readonly RecordsContext _context;
        public MainController(RecordsContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task PrepareDB()
        {
            System.Console.WriteLine($"PrepareDB Method runned");
            System.Console.WriteLine($"done");
        }
    }
}