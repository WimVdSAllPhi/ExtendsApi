using ExtendsApi.BusinessLayer.Services;
using ExtendsApi.BusinessLayer.Services.Interfaces;
using ExtendsApi.DataLayer.Repository;
using ExtendsApi.DataLayer.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExtendsApi.BusinessLayer.StartupExtention
{
    public static class StartupExtentions
    {
        public static void ConfigureServicesExtention(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            if (configuration is null)
            {
                throw new System.ArgumentNullException(nameof(configuration));
            }

            services.AddScoped(typeof(IBaseViewRepository<>), typeof(BaseViewRepository<>));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

            services.AddScoped(typeof(IBaseService<,,,,>), typeof(BaseService<,,,,>));
        }
    }
}
