using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using UrlShortenerMVC.Models;

namespace UrlShortenerMVC.Controllers
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
            if(User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Account");
            }

            return RedirectToAction("Create", "Url");
        }

        
    }
}
