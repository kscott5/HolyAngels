using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Filters
{
    /// <summary>
    /// Defines an attribute for authorizing application users using Forms base authentication
    /// </summary>
    public class FormsAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return this.AuthorizeCore();
        }
    }
}