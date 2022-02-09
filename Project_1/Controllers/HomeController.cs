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
        private databaseContext daContext { get; set; }
        public HomeController(databaseContext newOne)
        {
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

        public IActionResult NewTask()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }
    }
}
