using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using IoTManager.Authentication.JwtBearer;
using IoTManager.Configuration;
using IoTManager.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Abp.Configuration.Startup;
using IoT.Application;
using IoT.EntityFrameworkCore;

namespace IoTManager
{
    [DependsOn(
         typeof(IoTManagerApplicationModule),
         typeof(IoTManagerEntityFrameworkModule),
         typeof(IoTEntityFrameworkModule),
         typeof(IoTApplicationModule),
         typeof(AbpAspNetCoreModule),
         typeof(AbpAspNetCoreSignalRModule)
    )]
    public class IoTManagerWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IoTManagerWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                IoTManagerConsts.ConnectionStringName
            );

            //在开发环境下发送所有错误信息到前端
            if (_env.IsDevelopment())
            {
                Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
            }

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(IoTManagerApplicationModule).GetAssembly()
                 );
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(IoTApplicationModule).GetAssembly());
            
            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IoTManagerWebCoreModule).GetAssembly());
        }
    }
}