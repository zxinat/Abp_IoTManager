using Abp.Authorization;
using IoTManager.Authorization.Roles;
using IoTManager.Authorization.Users;

namespace IoTManager.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
