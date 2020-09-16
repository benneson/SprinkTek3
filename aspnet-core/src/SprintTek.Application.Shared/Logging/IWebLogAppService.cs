using Abp.Application.Services;
using SprintTek.Dto;
using SprintTek.Logging.Dto;

namespace SprintTek.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
