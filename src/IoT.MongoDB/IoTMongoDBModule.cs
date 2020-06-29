using System;
using System.Collections.Generic;
using System.Text;
using Abp.Modules;
using Microsoft.Extensions.DependencyInjection;
using Abp.MongoDb;
using Castle.DynamicProxy;
using Abp.Configuration.Startup;
using Abp.MongoDb.Configuration;
using Abp.Reflection.Extensions;

namespace IoT.MongoDB
{
    [DependsOn(typeof(AbpMongoDbModule))]
    public class IoTMongoDBModule:AbpModule
    {
        public override void PreInitialize()
        {
            //IocManager.Register<IAbpMongoDbModuleConfiguration, AbpMongoDbModuleConfiguration>();
            Configuration.Modules.AbpMongoDb().ConnectionString = "mongodb://iotmanager:iotmanager-pwd@118.31.2.239:27017/?authSource=iotmanager";
            Configuration.Modules.AbpMongoDb().DatabaseName = "iotmanager";
            
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTMongoDBModule).GetAssembly());
            //IocManager.Register<DeviceDataRepository>();
        }
    }
}
