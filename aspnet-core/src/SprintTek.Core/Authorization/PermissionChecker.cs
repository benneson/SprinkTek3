using Abp.Authorization;
using SprintTek.Authorization.Roles;
using SprintTek.Authorization.Users;

namespace SprintTek.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
