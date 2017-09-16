using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using HolyAngels.Models;
using HolyAngels.Services;

namespace HolyAngels.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        private ILogger Logger {get; set;}
        private PageService PageService {get; set;}

        public DashboardController(ILoggerFactory factory, PageService pageService) {
            this.Logger = factory.CreateLogger("DashboardController");
            this.PageService = pageService;
        }
        public IActionResult App()
        {
            var model = this.PageService.GetPage("Admin-Dashboard");
            return View(model);
        }
    }
}