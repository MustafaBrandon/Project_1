using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var lstTasks = daContext.Tasks.Include(x => x.Category).ToList();

            return View(lstTasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = daContext.Categories.ToList();
            var task = daContext.Tasks.Single(x => x.TaskId == taskid);

            return View("NewTask", task);
        }

        [HttpPost]
        public IActionResult Edit(Project_1.Models.Task t)
        {
            daContext.Update(t);
            daContext.SaveChanges();

            return Redirect("Quadrants");
        }


        [HttpGet]
        public IActionResult Delete(int taskid)
        {

            var task = daContext.Tasks.Single(x => x.TaskId == taskid);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Project_1.Models.Task t)
        {
            daContext.Tasks.Remove(t);
            daContext.SaveChanges();

            return Redirect("Quadrants");
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

            return Redirect("Quadrants");
        }
    }
}
