using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacocatWCustomModel.Models;

namespace TacocatWCustomModel.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Solution()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solution(string input)
        {
            var pm = new PalindromeModel
            {
                Input = input,
                Reverse = string.Join("", input.Reverse().ToArray()),
                Result = ""
            };
            if (pm.Input == pm.Reverse)
            { 
                pm.Result = "Palindrome!"; 
            }
            else 
            { 
                pm.Result = "Not a palindrome..."; 
            }
            return RedirectToAction("Result", pm);
        }

        public IActionResult Result(PalindromeModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
