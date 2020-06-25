using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IoTManager.Controllers
{
    public abstract class IoTManagerControllerBase: AbpController
    {
        protected IoTManagerControllerBase()
        {
            LocalizationSourceName = IoTManagerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
