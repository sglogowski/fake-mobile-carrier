using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FakeMobileCarrier.CallCenter.WebApp
{
    public class MvcApplication : HttpApplication
    {
        private IContainer Container
        {
            get
            {
                var builder = new ContainerBuilder();

                builder.RegisterControllers(typeof(MvcApplication).Assembly);
                builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

                var container = builder.Build();

                return container;
            }
        }

        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
