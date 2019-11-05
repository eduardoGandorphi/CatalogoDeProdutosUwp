using System.Web.Mvc;

namespace ProductCatalog.Web.Areas.Admin
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
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional }
                //Define uma rota padrao para dominio/admin
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
            );
        }
    }
}