using System.Web.Mvc;

namespace HolyAngels.Web.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{idKey}",
                new { action = "Index", idKey = UrlParameter.Optional },
                new []{ "HolyAngels.Web.Areas.Manage.Controllers" }
            );
        }
    }
}
