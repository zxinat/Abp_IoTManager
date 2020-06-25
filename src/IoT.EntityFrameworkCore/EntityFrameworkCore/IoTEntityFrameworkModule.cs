using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using IoT.Core;

namespace IoT.EntityFrameworkCore
{
    [DependsOn(typeof(IoTCoreModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class IoTEntityFrameworkModule:AbpModule
    {
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<IoTDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        IoTDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IoTDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTEntityFrameworkModule).GetAssembly());
        }
    }
}
