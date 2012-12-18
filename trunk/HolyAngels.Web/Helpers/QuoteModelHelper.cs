using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Helpers
{
    public static class QuoteModelHelper
    {
        public static List<QuoteModel> GetAll()
        {
            List<QuoteModel> quotes = new List<QuoteModel>();

            try
            {
                using (var db = new DbContextHelper())
                {
                    quotes = (from q in db.Quotes
                              where q.Approved == true
                              select new QuoteModel { 
                                  Id = q.Id, 
                                  Description = q.Description, 
                                  Source = q.Source 
                              }).ToList();

                    return quotes;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("QuoteModelHelper.GetRandom", ex);
                throw ex;
            }
        }

        public static QuoteModel GetRandom(this List<QuoteModel> models)
        {
            if (models.Count == 0) return new QuoteModel();

            Random rand = new Random();
            int index = rand.Next(models.Count-1);
            return models[index];
        }
    }
}