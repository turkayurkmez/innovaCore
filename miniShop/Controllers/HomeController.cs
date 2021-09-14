using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product{ Id=1, Name ="Product A", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc."},
                new Product{ Id=2, Name ="Product B", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc."},
                new Product{ Id=3, Name ="Product C", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc."},
                new Product{ Id=4, Name ="Product D", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc."},


            };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
