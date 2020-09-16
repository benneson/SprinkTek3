using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.Configuration.Tenants.Dto;

namespace SprintTek.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
