using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using HolyAngels.Models;
using HolyAngels.Services;

namespace HolyAngels.Controllers
{    
    public class HomeController : Controller
    {
        private ILogger Logger {get; set;}        
        private DataService DataService {get; set;}
        public HomeController(ILoggerFactory factory, DataService dataService) {
            this.Logger = factory.CreateLogger("HomeController");
            this.DataService = dataService;
        }

        public IActionResult Index()
        {   
            var model = this.DataService.GetPage("hoME");
            return View(model);
        }

        public IActionResult About()
        {
            var model = this.DataService.GetPage("About");

            return View(model);
        }

        public IActionResult Contact()
        {
            var model = this.DataService.GetPage("contAct");

            return View(model);
        }

        public IActionResult Mural()
        {
            var model = this.DataService.GetPage("murAl");

            return View(model);
        }

        public IActionResult History()
        {
            var model = this.DataService.GetPage("history");

            return View(model);
        }

        public IActionResult Mission()
        {
            var model = this.DataService.GetPage("mission");

            return View(model);
        }

        public IActionResult Christianity()
        {
            var model = this.DataService.GetPage("christiAnity");

            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = this.DataService.GetPage("privAcy");

            return View(model);
        }

        public IActionResult Terms()
        {
            var model = this.DataService.GetPage("terms");
            return View(model);
        }

        [Route("Ministries/Index")]        
        [Route("Ministries/")]        
        public IActionResult Ministries() {
            var model = this.DataService.GetPageMinistries();
            return View(model);
        }

        [Route("Articles/Index")]
        [Route("Articles/")]        
        public IActionResult Articles() {
            var model = this.DataService.GetPage("Articles");
            return View(model);
        }

        [Route("EventCalendar/Events")]
        [Route("EventCalendar/")]        
        public IActionResult Events() {
            var model = this.DataService.GetPage("Articles");
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
