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
        private PageService PageService {get; set;}
        public HomeController(ILoggerFactory factory, PageService pageService) {
            this.Logger = factory.CreateLogger("HomeController");
            this.PageService = pageService;
        }

        public IActionResult Index([FromServices] QuoteService quoteService)
        {   
            var model = this.PageService.GetPage("hoME");
            model.Quote = quoteService.GetQuoteOfDay();
            
            return View(model);
        }

        public IActionResult About()
        {
            var model = this.PageService.GetPage("About");

            return View(model);
        }

        public IActionResult Contact()
        {
            var model = this.PageService.GetPage("contAct");

            return View(model);
        }

        public IActionResult Mural()
        {
            var model = this.PageService.GetPage("murAl");

            return View(model);
        }

        public IActionResult History()
        {
            var model = this.PageService.GetPage("history");

            return View(model);
        }

        public IActionResult Mission()
        {
            var model = this.PageService.GetPage("mission");

            return View(model);
        }

        public IActionResult Christianity()
        {
            var model = this.PageService.GetPage("christiAnity");

            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = this.PageService.GetPage("privAcy");

            return View(model);
        }

        public IActionResult Terms()
        {
            var model = this.PageService.GetPage("terms");
            return View(model);
        }

        [Route("Ministries/Index")]        
        [Route("Ministries/")]        
        public IActionResult Ministries() {
            var model = this.PageService.GetPageMinistries();
            return View(model);
        }

        [Route("EventCalendar/Events")]
        [Route("EventCalendar/")]
        public IActionResult Events() {
            var model = this.PageService.GetPage("Events");
            return View(model);
        }

        [Route("EventCalendar/Events")]
        [Route("EventCalendar/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Events([FromServices] CalendarService service, DateTime date) {
            var data = service.GetMonthlyEvents(date);
            return new JsonResult(data);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
