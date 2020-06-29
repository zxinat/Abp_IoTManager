using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoT.Core;

namespace IoT.Application
{
    [DependsOn(typeof(IoTCoreModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class IoTApplicationModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.AddProfile<IoTDtoProfile>();
            });
            //Configuration.Authorization.Providers.Add<IoTManagerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTApplicationModule).GetAssembly());
        }
    }
    
}
