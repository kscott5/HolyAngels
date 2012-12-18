using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HolyAngels.Web.Helpers;
using HolyAngels.Web.Areas.Manage.Models;
using System.Web.Routing;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Controllers
{
    [HandleError(View = "Error")]
    public partial class MinistryController : Controller
    {
        public virtual ActionResult Index()
        {
            var model = BaseModelHelper.GetMinistryModel();
            return View(model);
        }

        //[HttpPost]
        public virtual ActionResult DisplayMinistry(string ministryName)
        {
            var model = new MinistryModel();
            return View(model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            var routeDic = new RouteValueDictionary();
            routeDic.Add("ministryName", actionName);

            this.ControllerContext.ServerTransfer(
                controller: MVC.Ministry.Name, 
                action: MVC.Ministry.ActionNames.DisplayMinistry, 
                routes: routeDic
               );
        }        
    }
}
