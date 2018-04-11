using ArvidDev.Extensions.DependencyInjection.CustomBinding;

namespace NetCoreApiExample.Models
{
    public class MyConfiguration
    {
        [BindToConfiguration("setting-1")]
        public string FromAppSettings1 { get; set; }

        [BindToConfiguration("setting-2")]
        public string FromAppSettings2 { get; set; }

        public string FromAppSettings3 { get; set; }

        [BindToConfiguration("ASPNETCORE_ENVIRONMENT")]
        public string FromEnv1 { get; set; }

        [BindToConfiguration("FROMENV2")]
        public string FromEnv2 { get; set; }

        public string FromEnv3 { get; set; }
    }
}
