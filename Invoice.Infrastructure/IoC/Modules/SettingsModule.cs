using Autofac;
using Microsoft.Extensions.Configuration;
using Invoice.Infrastructure.Settings;
using Invoice.Infrastructure.Extensions;

namespace Invoice.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        
        public SettingsModule (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<CompanySettings>())
                .SingleInstance();
        }
        
    }
}