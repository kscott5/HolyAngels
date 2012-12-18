using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using HolyAngels.Web.Models;
using HolyAngels.Web.Helpers;
using System.Web.Security;

namespace HolyAngels.Web.Controllers
{
    [HandleError(View = "Error")]
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var model = BaseModelHelper.GetHomeModel();            
            return View(model);
        }

        public virtual ActionResult About()
        {
            var model = BaseModelHelper.GetAboutModel();
            return View(model);
        }

        public virtual ActionResult Contact()
        {
            var model = BaseModelHelper.GetContactModel();
            return View(model);
        }

        public virtual ActionResult Mural()
        {
            var model = BaseModelHelper.GetMuralModel();
            return View(model);
        }

        public virtual ActionResult History()
        {
            var model = BaseModelHelper.GetHistoryModel();
            return View(model);
        }

        public virtual ActionResult Mission()
        {
            var model = BaseModelHelper.GetMissionModel();
            return View(model);
        }

        public virtual ActionResult Christianity()
        {
            var model = BaseModelHelper.GetChristianityModel();
            return View(model);
        }

        public virtual ActionResult Privacy()
        {
            var model = BaseModelHelper.GetPrivacyModel();
            return View(model);
        }

        public virtual ActionResult Terms()
        {
            var model = BaseModelHelper.GetTermsModel();
            return View(model);
        }
    }
}
