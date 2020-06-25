using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoTManager.Configuration;

namespace IoTManager.Web.Host.Startup
{
    [DependsOn(
       typeof(IoTManagerWebCoreModule))]
    public class IoTManagerWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IoTManagerWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTManagerWebHostModule).GetAssembly());
        }
    }
}