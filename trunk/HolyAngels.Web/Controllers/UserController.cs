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
    public partial class UserController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return this.RedirectToAction<HomeController>(a => a.Index());

            var model = BaseModelHelper.GetSignInModel();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Index(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.SignIn(out status))
                    return this.RedirectToAction<HomeController>(a => a.Index());

                ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            // Initialize the meta data information
            model = BaseModelHelper.GetSignInModel(model);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult SignOff()
        {
            UserModelHelper.SignOff();
            return this.RedirectToAction<HomeController>(a => a.Index());
        }

        public virtual ActionResult Register()
        {
            var model = BaseModelHelper.GetRegisterModel();
            return View(model);
        }

        [HttpPost()]
        public virtual ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if(model.Register(out status))
                    return this.RedirectToAction<HomeController>(a => a.Index());
                
                ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            // Initialize the meta data information
            model = BaseModelHelper.GetRegisterModel(model);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult ForgotPassword()
        {
            if (Request.IsAuthenticated)
                return this.RedirectToAction<HomeController>(a => a.Index());

            var model = BaseModelHelper.GetUserModelForForgotPassword();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.GenerateResetToken(out status))
                    ModelState.AddModelError("Error", "Please check your email for password reset token!");
                else
                    ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields!");
            }

            return View(model);
        }        
    }
}
