using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeedMarketData;
using SeedMarketData.Repository;

namespace SeedMarket.Services
{
    public class MainControllerService
    {
        private readonly RecordsContext _context;
        public MainControllerService(RecordsContext context)
        {
            _context = context;
        }
        public async Task<string> GetProducts()
        {
            var products = _context.Products.ToList();
            return JsonConvert.SerializeObject(products);
        }
        public async Task<string> GetStatusess()
        {
            var statuses = _context.Statuses.ToList();
            return JsonConvert.SerializeObject(statuses);
        }
        public async Task<IActionResult> AddNewProductGroup(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
            _context.SaveChanges();
            return new OkObjectResult(new {message = "200", curentTime = DateTime.Now});
        }
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return new OkObjectResult(new {message = "200", curentTime = DateTime.Now});
        }
        public async Task<IActionResult> AddNewUser(ApplicationUser applicationUser)
        {
            _context.ApplicationUsers.Add(applicationUser);
            _context.SaveChanges();
            return new OkObjectResult(new {message = "200", curentTime = DateTime.Now});
        }
    }
}