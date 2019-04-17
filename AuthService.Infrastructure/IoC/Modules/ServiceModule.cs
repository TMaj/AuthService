using AuthService.Infrastructure.Services.Interfaces;
using Autofac;
using System.Reflection;

namespace AuthService.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
              .GetTypeInfo()
              .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                       .Where(x => x.IsAssignableTo<IService>())
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
        }
    }
}
