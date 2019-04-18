using AuthService.Infrastructure.Security;
using Autofac;
using System.Reflection;

namespace AuthService.Infrastructure.IoC.Modules
{
    public class SecurityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SecurityModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                       .Where(x => x.IsAssignableTo<IJwtTokenFactory>())
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                      .Where(x => x.IsAssignableTo<ITokenFactory>())
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IJwtTokenHandler>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IJwtTokenValidator>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
