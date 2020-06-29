using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoT.Core.MongoDb;

namespace IoT.Core
{
    public class IoTCoreModule:AbpModule
    {
        public override void PreInitialize()
        {
            //IocManager.Register<IDeviceDataManager,DeviceDataManager>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTCoreModule).GetAssembly());
        }
    }
}
