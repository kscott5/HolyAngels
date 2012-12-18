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
    public partial class EventsController : Controller
    {
        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Index(GridSortOptions sort, int page = 1)
        {
            var model = ManageEventModelHelper.GetEventModelForEvents(sort, page);
            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add()
        {
            var model = ManageEventModelHelper.GetEventModelForAdd();
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add(EventModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Add(out status))
                    ModelState.AddModelError("Error", "Successfully added new system event");
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
            var model = ManageEventModelHelper.GetEventModelForEdit(idKey);
            if (model == null)
                return this.RedirectToAction<EventsController>(a => a.Index());
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(EventModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Update(out status))
                    ModelState.AddModelError("Error", "Successfully updated system event");
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
