using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using HolyAngels.Web.Helpers;
using System.Web.Security;
using System.Security.Principal;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Modules
{
	public class FormsAuthenticationModule : IHttpModule
	{
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            if (AuthenticationMode.Forms == CommonHelper.AuthenticiationMode)
            {
                context.AuthenticateRequest += new EventHandler(AuthenticateRequest);
            }
        }

        void AuthenticateRequest(object sender, EventArgs e)
        {
            var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
            if (ticket != null)
            {
                HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), ticket.Roles().ToArray());
            }            
        }
    }
}