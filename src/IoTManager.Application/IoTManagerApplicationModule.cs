using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoTManager.Authorization;

namespace IoTManager
{
    [DependsOn(
        typeof(IoTManagerCoreModule),
        typeof(AbpAutoMapperModule))]
    public class IoTManagerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IoTManagerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTManagerApplicationModule).GetAssembly());
        }
    }
}