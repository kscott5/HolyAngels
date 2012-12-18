using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyAngels.Web.Helpers;
using HolyAngels.Web.Areas.Manage.Helpers;
using MvcContrib;
using MvcContrib.ActionResults;

namespace HolyAngels.Web.Controllers
{
    public partial class ArticlesController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index(int pageNumber = 1)
        {
            var model = BaseModelHelper.GetPaginatedArticle(pageNumber: pageNumber);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Viewer(string idKey)
        {
            var model = ArticleModelHelper.GetArticleModelForViewer(idKey);
            
            if (model == null)
                return this.RedirectToAction<ArticlesController>(a => a.Index(1));

            return View(model);
        }
    }
}
