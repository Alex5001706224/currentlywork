using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Models;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineShoppingWeb.Service;
//using OnlineShoppingWeb.Filters;

namespace OnlineShoppingWeb.Controllers
{
    //[TypeFilter(typeof(SampleExceptionFilter))]
    public class HomeController : Controller
    {
        private IproductRepository productR;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IproductRepository productR)
        {
            _logger = logger;
            this.productR = productR;
        }
        [AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            //productR.GetProducts();
            IndexViewModel model = new IndexViewModel();
            model.Products = productR.GetProducts();
            return View(model);
        }
        //public IActionResult Show()
        //{
        //    return View();
        //}
        
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
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