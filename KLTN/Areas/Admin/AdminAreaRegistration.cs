using System.Web.Mvc;

namespace KLTN.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Route chuyển hướng từ /Admin sang /Admin/Login
            context.MapRoute(
                name: "Admin_redirect",
                url: "Admin",
                defaults: new { controller = "Login", action = "Index" }
            );

            context.MapRoute(
                    name: "Admin_default",
                    url: "Admin/{controller}/{action}/{id}",
                    defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}