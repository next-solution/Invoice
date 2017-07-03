using System.Reflection;
using Autofac;
using Invoice.Infrastructure.Handlers.Jwt;

namespace Invoice.Infrastructure.IoC.Modules
{
    public class HandlerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(HandlerModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                   .SingleInstance();
        }
    }
}