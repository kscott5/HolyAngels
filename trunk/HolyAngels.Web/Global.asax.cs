using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HolyAngels.Web.Binders;
using HolyAngels.Web.Areas.Manage.Models;

namespace HolyAngels.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{idKey}", // URL with parameters
                new { controller = "Home", action = "Index", idKey = UrlParameter.Optional }, // Parameter defaults
                new[] { "HolyAngels.Web.Controllers" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
            // Add List of Roles to ModelBinders
            Type roleModelType = typeof(List<RoleModel>);
            GenericModelBinder modelBinder1 = new GenericModelBinder();
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(roleModelType, modelBinder1));

            // Add List of Ministries to ModelBinders
            Type ministryModelType = typeof(List<MinistryModel>);
            GenericModelBinder modelBinder2 = new GenericModelBinder();
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(ministryModelType, modelBinder2));
        }
    }
}