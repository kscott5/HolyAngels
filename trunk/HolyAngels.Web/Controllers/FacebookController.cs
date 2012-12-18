using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Helpers;

using MvcContrib;
using MvcContrib.ActionResults;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Controllers
{
    [HandleError(View = "Error")]
    public partial class FacebookController : Controller
    {
        [HttpPost]
        public virtual ActionResult Authorize()
        {
            string code = this.Request.QueryString[FacebookHelper.OAUTH_CODE];
            Status status;

            var model = FacebookHelper.GetUserModel(code, out status);            
            if (status == Status.Success && model.Authorize(code, out status))
            {
                return this.RedirectToAction<HomeController>(a => a.Index());
            }
            else
            {
                ModelState.AddModelError("Error", status.Message());
                return View(model);
            }
        }

        [HttpPost]
        public virtual ActionResult Deauthorize()
        {
            FacebookHelper.Deauthorize();
            return this.RedirectToAction<HomeController>(a => a.Index());
        }
    }
}
