using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HolyAngels.Models;

namespace HolyAngels.Controllers
{
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {   
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Church";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult About()
        {
            var model = new HomeModel();
            model.PageTitle = "About Holy Angels Church";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Contact()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Contact Information";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Mural()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Church Mural";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult History()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Church History";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Mission()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Church Mission";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Christianity()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels African-American Christianity";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Privacy()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Privacy Statement";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public virtual ActionResult Terms()
        {
            var model = new HomeModel();
            model.PageTitle = "Holy Angels Church Terms of site use";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
