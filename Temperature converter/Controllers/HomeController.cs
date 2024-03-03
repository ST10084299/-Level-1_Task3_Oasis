using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Temperature_converter.Models;

namespace Temperature_converter.Controllers
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
            var m = new data();
            return View(m);
        }

        [HttpPost]
        public IActionResult Index(data d)
        {
            if (ModelState.IsValid)
            {
                string a = d.Name;
                double t = d.Input;
                double r = 0;
                r = d.Input;
                if (a == "Fahrenheit")
                {
                    r = (t - 32) * 5 / 9;
                }
                else if (a == "Celsius")
                {
                    r = (t * 9 / 5) + 32;
                }

                // Set the converted temperature to the answer property of the model
                d.answer = r;
            }

            // Return the view with the updated model
            return View(d);
        }
    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}