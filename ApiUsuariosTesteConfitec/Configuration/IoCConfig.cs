using ApiUsuariosTesteConfitec_Business.Business;
using ApiUsuariosTesteConfitec_Data.DbSessionManagerConfig;
using ApiUsuariosTesteConfitec_Data.Repository;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Business;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Config;
using ApiUsuariosTesteConfitec_Domain.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ApiUsuariosTesteConfitec.Configuration
{
    public static class IoCConfig
    {
        public static IServiceCollection AddIoCServices(this IServiceCollection services)
        {
            services.AddRepositoryServices();
            services.AddBusinessServices();
            services.AddConfigServices();

            return services;
        }
        private static IServiceCollection AddRepositoryServices(this IServiceCollection service)
        {
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return service;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection service)
        {
            service.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            return service;
        }

        private static IServiceCollection AddConfigServices(this IServiceCollection service)
        {
            service.AddScoped<DbSession>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
