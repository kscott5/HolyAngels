using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyAngels.Web.Models;
using HolyAngels.Web.Helpers;

namespace HolyAngels.Web.Controllers
{
    [HandleError(View = "Error")]
    public partial class EventCalendarController : Controller
    {
        public virtual ActionResult Index()
        {
            var model = BaseModelHelper.GetEventCalendarModel();
            return View(model);
        }
        
        [HttpPost]
        public virtual JsonResult Events(string start, string end)
        {
            
            var json = new JsonResult();
            json.Data = EventCalendarModelHelper.GetEvents(Convert.ToDateTime(start), Convert.ToDateTime(end));
            
            return json;
        }
    }
}
