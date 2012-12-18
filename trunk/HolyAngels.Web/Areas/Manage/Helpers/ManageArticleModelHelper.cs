using System;
using System.Collections.Generic;
using System.Linq;
using HolyAngels.Web.Domains;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Helpers;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class ManageArticleModelHelper
    {
        /// <summary>
        /// Creates a paginated entity model used for the ArticlesController.Index view
        /// </summary>
        /// <param name="model">Paginated model of acticles</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <param name="start">The start date for querying the articles</param>
        /// <param name="end">The end date for querying the articles</param>
        /// <param name="checkIfApproved">Flag to check if articles approved for viewing</param>
        /// <returns></returns>
        public static void GetPaginatedArticles(this PaginationModel<ArticleModel> model, int pageNumber = 1, DateTime? start = null, DateTime? end = null, bool checkIfApproved = true)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var query = (from a in db.Articles select a)
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction);

                    if (checkIfApproved)
                        query = query.Where(a => a.Approved == true);

                    if(start.HasValue)
                    {
                        var sDate = start.Value.StartOfDay();
                        query = query.Where(a => a.Start >= sDate);
                    }

                    if (end.HasValue)
                    {
                        var eDate = end.Value.EndOfDay();
                        query = query.Where(a => a.End <= eDate);
                    }

                    var articles = query.ToList();
                    var data = new List<ArticleModel>();
                    foreach (var a in articles)
                    {
                        data.Add(new ArticleModel
                                 {
                                     Id = a.Id,
                                     IdKey = a.IdKey,
                                     Title = a.Title,
                                     Description = a.Description,
                                     StartDate = a.Start.ToShortDateString(),
                                     EndDate = a.End.ToShortDateString(),
                                     Keywords = a.Keywords,
                                     Author = a.Author,
                                     Summary = a.Summary,
                                     Approved = a.Approved,
                                     CategoryId = a.CategoryId,
                                 });
                    }

                    model.Data = new CustomPagination<ArticleModel>(data, pageNumber, 20, data.Count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageArticleModelHelper.GetPaginatedArticles", ex);
                throw ex;
            }
        }


        public static bool Add(this ArticleModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = db.Articles.Create();
                    entity.Title = model.Title;
                    entity.Description = model.Description.Sanitize();
                    entity.Start = Convert.ToDateTime(model.StartDate);
                    entity.End = Convert.ToDateTime(model.EndDate);
                    entity.Summary =  model.Summary.Sanitize();
                    entity.CategoryId = model.CategoryId;
                    entity.Author = model.Author;
                    entity.Approved = model.Approved;
                    entity.Keywords = model.Keywords;
                    entity.Created = DateTime.Now;

                    var ministries = model.Ministries.GetMinistriesFromModel(db);
                    if (ministries.Count > 0)
                    {
                        entity.Ministries = new List<Ministry>();
                        foreach (var ministry in ministries)
                            entity.Ministries.Add(ministry);
                    }

                    entity = db.Articles.Add(entity);
                    db.SaveChanges();

                    model.Id = entity.Id;
                    model.IdKey = entity.IdKey;

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageArticleModelHelper.Add", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Update(this ArticleModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Articles
                                  where m.Id == model.Id && m.IdKey == model.IdKey
                                  select m).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity.Title = model.Title;
                    entity.Description = model.Description.Sanitize();
                    entity.Start = Convert.ToDateTime(model.StartDate);
                    entity.End = Convert.ToDateTime(model.EndDate);
                    entity.Summary = model.Summary.Sanitize();
                    entity.CategoryId = model.CategoryId;
                    entity.Author = model.Author;
                    entity.Approved = model.Approved;
                    entity.Modified = DateTime.Now;
                    entity.Keywords = model.Keywords;

                    if (entity.Ministries == null) entity.Ministries = new List<Ministry>();
                    var ministries = model.Ministries.GetMinistriesFromModel(db);
                    if (ministries.Count > 0)
                    {
                        entity.Ministries.Clear();
                        foreach (var ministry in ministries)
                            entity.Ministries.Add(ministry);
                    }

                    db.SaveChanges();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageArticleModelHelper.Update", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Delete(Guid idKey, out Status status)
        {
            try
            {
                
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Articles
                                  where m.IdKey == idKey
                                  select m).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity = db.Articles.Remove(entity);
                    db.SaveChanges();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageArticleModelHelper.Delete", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static Article GetArticle(Guid idKey)
        {

            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Articles
                                  where m.IdKey == idKey
                                  select m).FirstOrDefault();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageArticleModelHelper.Get", ex);
                throw ex;
            }
        }
        
        /// <summary>
        /// Creates a paginated entity model used by the ArticlesController.Index method
        /// </summary>
        /// <param name="sort">Sort options</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <param name="start">The start date for querying the articles</param>
        /// <param name="end">The end date for querying the articles</param>
        /// <param name="checkIfApproved">Flag to check if articles approved for viewing</param>
        /// <returns></returns>
        public static PaginationModel<ArticleModel> GetArticleModelForArticles(GridSortOptions sort, int pageNumber = 1, DateTime? start = null, DateTime? end = null, bool checkIfApproved = true)
        {
            var column = (sort.Column == null) ? Constants.Sort_Column_Title : sort.Column;
            var direction = sort.Direction;

            var model = CommonModelHelper.GetPaginatedModel<ArticleModel>(column, direction);
            model.GetPaginatedArticles(pageNumber, start, end, checkIfApproved);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();
            
            model.PageTitle = "Holy Angels System Articles";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the ArticlesController.Add method
        /// </summary>
        /// <returns></returns>
        public static ArticleModel GetArticleModelForAdd()
        {
            var model = new ArticleModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();
            
            model.PageTitle = "Holy Angels System Article";
            model.SubTitle = "Add New Article";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the ArticlesController.Edit method
        /// </summary>
        /// <returns></returns>
        public static ArticleModel GetArticleModelForEdit(string id)
        {
            Guid idKey = (Guid.TryParse(id, out idKey)) ? idKey : Guid.Empty;

            var entity = GetArticle(idKey);
            if (entity == null)
                return null;

            var model = entity.GetArticleModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();
            
            model.PageTitle = "Holy Angels System Article";
            model.SubTitle = "Edit Article";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static ArticleModel GetArticleModel(this Article entity)
        {
            var model = new ArticleModel
            {
                Id = entity.Id,
                IdKey = entity.IdKey,
                Title = entity.Title,
                Description = entity.Description,
                StartDate = entity.Start.ToShortDateString(),
                EndDate = entity.End.ToShortDateString(),
                Author = entity.Author,
                Summary = entity.Summary,
                CategoryId = entity.CategoryId,
                Approved = entity.Approved,
            };

            return model;
        }
    }
}