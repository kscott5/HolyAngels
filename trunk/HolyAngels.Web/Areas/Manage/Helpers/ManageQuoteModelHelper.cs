using System;
using System.Linq;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Domains;
using HolyAngels.Web.Helpers;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class ManageQuoteModelHelper
    {
        /// <summary>
        /// Creates a paginated quote model used for the QuoteController.Index view
        /// </summary>
        /// <param name="model">Paginated model for quotes</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static void GetPaginatedQuotes(this PaginationModel<QuoteModel> model, int pageNumber = 1)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var data = (from q in db.Quotes
                                  select new QuoteModel
                                  {
                                      Id = q.Id,
                                      IdKey = q.IdKey,
                                      Description = q.Description,
                                      Source = q.Source,
                                      Approved = q.Approved,
                                  })
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction)
                                .ToList();

                    model.Data = new CustomPagination<QuoteModel>(data, pageNumber, 20, data.Count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageQuoteModelHelper.GetPaginatedQuotes", ex);
                throw ex;
            }
        }
        
        public static QuoteModel GetQuoteModel(this Quote quote)
        {
            var model = new QuoteModel
            {
                Id = quote.Id,
                IdKey = quote.IdKey,
                Description = quote.Description,
                Source = quote.Source,
                Approved = quote.Approved,
            };

            return model;
        }

        public static bool Add(this QuoteModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = db.Quotes.Create();
                    entity.IdKey = Guid.NewGuid();
                    entity.Description = model.Description.Sanitize();
                    entity.Source = model.Source;
                    entity.Created = DateTime.Now;
                    entity.Approved = model.Approved;

                    entity = db.Quotes.Add(entity);                    
                    db.SaveChanges();

                    model.Id = entity.Id;
                    model.IdKey = entity.IdKey;

                    model = GetQuoteModelForAdd();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageQuoteModelHelper.Add", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Update(this QuoteModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from q in db.Quotes
                                  where q.Id == model.Id || q.IdKey == model.IdKey
                                  select q).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity.Description = model.Description.Sanitize();
                    entity.Source = model.Source;
                    entity.Modified = DateTime.Now;
                    entity.Approved = model.Approved;

                    db.SaveChanges();

                    model = GetQuoteModelForEdit(entity.IdKey.ToString());
                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageQuoteModelHelper.Add", ex);
                status = Status.SystemException;
            }

            return false;
        }

        /// <summary>
        /// Creates a paginated quote model used by the QuotesController.Index method
        /// </summary>
        /// <param name="sort">Sort options</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static PaginationModel<QuoteModel> GetQuoteModelForQuotes(GridSortOptions sort, int pageNumber = 1)
        {
            var column = (sort.Column == null) ? Constants.Sort_Column_Source : sort.Column;
            var direction = sort.Direction;

            var model = CommonModelHelper.GetPaginatedModel<QuoteModel>(column, direction);
            model.GetPaginatedQuotes(pageNumber);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Quotes";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a quote model used by the QuotesController.Add method
        /// </summary>
        /// <returns></returns>
        public static QuoteModel GetQuoteModelForAdd()
        {
            var model = new QuoteModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Quote";
            model.SubTitle = "Add New Quote";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a quote model used by the QuotesController.Edit method
        /// </summary>
        /// <returns></returns>
        public static QuoteModel GetQuoteModelForEdit(string idKey)
        {
            Guid id = (Guid.TryParse(idKey, out id)) ? id : Guid.Empty;

            var quote = GetQuote(id);
            if (quote == null)
                return null;

            var model = quote.GetQuoteModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Quote";
            model.SubTitle = "Edit Quote";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static Quote GetQuote(Guid idKey)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var quote = (from q in db.Quotes
                                 where q.IdKey == idKey
                                 select q).FirstOrDefault();

                    return quote;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageQuoteModelHelper.GetQuote", ex);
                throw ex;
            }
        }
    }
}