using System.Collections.Generic;
using SprintTek.Authorization.Permissions.Dto;

namespace SprintTek.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}