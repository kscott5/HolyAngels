using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Filters;
using HolyAngels.Web.Areas.Manage.Models;

using MvcContrib;
using MvcContrib.ActionResults;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Controllers
{
    [HandleError(View = "Error")]
    [ValidateInput(false)]
    public partial class QuotesController : Controller
    {
        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Index(GridSortOptions sort, int page = 1)
        {
            var model = ManageQuoteModelHelper.GetQuoteModelForQuotes(sort, page);
            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add()
        {
            var model = ManageQuoteModelHelper.GetQuoteModelForAdd();
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Add(QuoteModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Add(out status))
                    ModelState.AddModelError("Error", "Successfully add new system quote");
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
            var model = ManageQuoteModelHelper.GetQuoteModelForEdit(idKey);
            if (model == null)
            {
                ModelState.AddModelError("Error", "Could not find located quote");
                return this.RedirectToAction<QuotesController>(a => a.Index());
            }

            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(QuoteModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Update(out status))
                    ModelState.AddModelError("Error", "User information updated successfully!");
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
