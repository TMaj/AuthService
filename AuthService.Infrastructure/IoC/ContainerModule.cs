using AuthService.Infrastructure.IoC.Modules;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace AuthService.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        public ContainerModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
