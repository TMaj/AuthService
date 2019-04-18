using AuthService.Infrastructure.Logging;
using Autofac;
using System.Reflection;

namespace AuthService.Infrastructure.IoC.Modules
{
    public class LoggingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(LoggingModule)
              .GetTypeInfo()
              .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                       .Where(x => x.IsAssignableTo<ILogger>())
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
        }
    }
}
