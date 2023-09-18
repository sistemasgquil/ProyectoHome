using System.Web.Mvc;

namespace Listas0.Areas.AreaProyectos
{
    public class AreaProyectosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaProyectos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaProyectos_default",
                "AreaProyectos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}