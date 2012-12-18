using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HolyAngels.Web.Helpers
{
    public static class ControllerHelper
    {
        public static void ServerTransfer(this ControllerContext context, string area = "", string controller = "", string action = "", RouteValueDictionary routes = null)
        {
            var urlHelper = new UrlHelper(context.RequestContext);
            var url = urlHelper.Action(actionName: action, controllerName: controller, routeValues: routes);

            HttpContext.Current.Server.TransferRequest(url, false);

        }
    }
}