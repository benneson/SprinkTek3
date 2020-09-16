using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.Configuration.Host.Dto;

namespace SprintTek.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
