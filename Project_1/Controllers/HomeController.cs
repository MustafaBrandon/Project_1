using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private databaseContext daContext { get; set; }
        public HomeController(ILogger<HomeController> logger, databaseContext newOne)
        {
            _logger = logger;
            daContext = newOne;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewTask()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewTask(Project_1.Models.Task t)
        {
            daContext.Add(t);
            daContext.SaveChanges();

            return View("Quadrants");
        }
    }
}
