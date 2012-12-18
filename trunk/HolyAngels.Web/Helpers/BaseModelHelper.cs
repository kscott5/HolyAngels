using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyAngels.Web.Models;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Domains;
using MvcContrib.Sorting;

namespace HolyAngels.Web.Helpers
{
    public static class BaseModelHelper
    {        
        public static PaginationModel<ArticleModel> GetPaginatedArticle(PaginationModel<ArticleModel> model = null, int pageNumber = 1)
        {
            if (model == null)
                model = new PaginationModel<ArticleModel>(Constants.Sort_Column_Start, SortDirection.Descending);

            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime end = DateTime.Now;

            model.GetPaginatedArticles(pageNumber, start, end);

            model.SubTitle = "Current News";
            model.PageTitle = "Holy Angels Current News";

            return model;
        }

        public static HomeModel GetHomeModel()
        {
            var model = new HomeModel();
            var quotes = QuoteModelHelper.GetAll();
            model.Quote = quotes.GetRandom();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            return model;
        }

        public static HomeModel GetAboutModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "About Holy Angels Church";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static HomeModel GetMuralModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church Mural";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static HomeModel GetChristianityModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels African-American Christianity";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }
        public static HomeModel GetHistoryModel()
        {
            var model = GetHomeModel();
            
            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church History";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static HomeModel GetMissionModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church Mission";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static PaginationModel<MinistryModel> GetMinistryModel()
        {
            var model = CommonModelHelper.GetPaginatedModel<MinistryModel>(Constants.Sort_Column_Name, MvcContrib.Sorting.SortDirection.Ascending);
            model.GetPaginatedMinistries();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();

            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church Ministries";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static QuoteModel GetQuoteModel()
        {
            var model = new QuoteModel();
            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();

            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angel Quote";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static EventModel GetEventCalendarModel()
        {
            var model = new EventModel();
            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();

            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Event Calendar";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }



        /// <summary>
        /// Gets the model for UserController.ForgotPassword
        /// </summary>
        /// <returns></returns>
        public static UserModel GetUserModelForForgotPassword()
        {
            var model = new UserModel();

            model.PageTitle = "Holy Angels Forgot Password";
            model.SubTitle = "Forgot Password";

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Gets the model for the contact view
        /// </summary>
        /// <returns></returns>
        public static object GetContactModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Contact Holy Angels Church";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        internal static object GetTermsModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church Terms of Service";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        internal static object GetPrivacyModel()
        {
            var model = GetHomeModel();

            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
                model.UserIdKey = ticket.IdKey();

            model.PageTitle = "Holy Angels Church Privacy Policy";
            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }
    }
}