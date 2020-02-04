using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ILBLI.Unity
{
    public static class UseAutoMapperExtension
    {

        public static IServiceCollection AddAutoMapperInit(this IServiceCollection services)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => cfg.AddProfile<CustomMappingProfile>());

            services.AddSingleton(provider);
            services.AddSingleton<IMapper, Mapper>();

            return services;
        }
    }
}
