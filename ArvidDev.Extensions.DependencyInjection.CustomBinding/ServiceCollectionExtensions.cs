using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ArvidDev.Extensions.DependencyInjection.CustomBinding
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCustom<TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class, new()
        {
            // Set all properties
            var objectToBind = BindingHelpers.Bind<TOptions>(config.AsEnumerable());

            services.AddOptions();
            return services.AddSingleton(Options.Create(objectToBind));
        }
    }
}
