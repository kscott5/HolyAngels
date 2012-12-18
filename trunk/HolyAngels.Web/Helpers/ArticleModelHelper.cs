using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Helpers
{
    public static class ArticleModelHelper
    {
        public static ArticleModel GetArticleModelForViewer(string idKey)
        {
            Guid id = (Guid.TryParse(idKey, out id))? id: Guid.Empty;           
            var article = ManageArticleModelHelper.GetArticle(id);

            if (article == null) return null;

            return article.GetArticleModel();
        }
    }
}