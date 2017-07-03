using Autofac;
using Invoice.Infrastructure.IoC.Modules;
using Invoice.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace Invoice.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<HandlerModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}