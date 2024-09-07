using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerMVC.Controllers
{
    public class UrlController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
