using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HolyAngels.Web.Models;
using HolyAngels.Web.Helpers;
using HolyAngels.Web.Filters;

using MvcContrib;
using MvcContrib.ActionResults;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Areas.Manage.Models;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Controllers
{
    [HandleError(View = "Error")]
    [ValidateInput(false)]
    public partial class MinistriesController : Controller
    {
        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Index(GridSortOptions sort, int page = 1)
        {
            var model = ManageMinistryModelHelper.GetMinistryModelForMinistries(sort, page);
            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add()
        {
            var model = ManageMinistryModelHelper.GetMinistryModelForAdd();
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add(MinistryModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Add(out status))
                    ModelState.AddModelError("Error", "Successfully added new ministry");
                else
                    ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(string idKey)
        {
            var model = ManageMinistryModelHelper.GetMinistryModelForEdit(idKey);
            if(model == null)
                return this.RedirectToAction<MinistriesController>(a => a.Index());
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(MinistryModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Update(out status))
                    ModelState.AddModelError("Error", "Successfully updated ministry");
                else
                    ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            return View(model);
        }
    }
}
