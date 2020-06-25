using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using IoTManager.Authorization.Roles;
using IoTManager.Authorization.Users;
using IoTManager.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace IoTManager.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
         IOptions<SecurityStampValidatorOptions> options,
         SignInManager signInManager,
         ISystemClock systemClock,
         ILoggerFactory loggerFactory)
         : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}