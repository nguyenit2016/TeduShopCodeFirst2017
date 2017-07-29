using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using NUI.Data;
using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Service;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(NUI.Web.App_Start.Startup))]

namespace NUI.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            //Register controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //Register controllerapi
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<NuiShopDbContext>().AsSelf().InstancePerRequest();

            //Repository
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}