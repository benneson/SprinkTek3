using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.Install.Dto;

namespace SprintTek.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}