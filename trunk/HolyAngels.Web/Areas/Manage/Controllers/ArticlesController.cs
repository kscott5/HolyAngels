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
    public partial class ArticlesController : Controller
    {
        [HttpGet]
        [FormsAuthorize(Roles = "Content Publisher, Content Approver")]
        public virtual ActionResult Index(GridSortOptions sort, int page = 1)
        {
           var model = ManageArticleModelHelper.GetArticleModelForArticles(sort, page, checkIfApproved : true);
            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Content Publisher, Content Approver")]
        public virtual ActionResult Add()
        {
            var model = ManageArticleModelHelper.GetArticleModelForAdd();
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Content Publisher, Content Approver")]
        public virtual ActionResult Add(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Add(out status))
                {
                    ModelState.AddModelError("Error", "Successfully added new system article");
                }
                else
                {
                    ModelState.AddModelError("Error", status.Message());
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Content Publisher, Content Approver")]
        public virtual ActionResult Edit(string idKey)
        {
            var model = ManageArticleModelHelper.GetArticleModelForEdit(idKey);
            if (model == null)
                return this.RedirectToAction<ArticlesController>(a => a.Index());
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Content Publisher, Content Approver")]
        public virtual ActionResult Edit(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Update(out status))
                {
                    ModelState.AddModelError("Error", "Successfully updated system article");
                }
                else
                {
                    ModelState.AddModelError("Error", status.Message());
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields");
            }

            return View(model);
        }
    }
}
