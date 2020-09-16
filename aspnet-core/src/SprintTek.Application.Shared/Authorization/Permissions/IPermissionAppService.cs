using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.Authorization.Permissions.Dto;

namespace SprintTek.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
