using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.Authorization.Users.Dto;

namespace SprintTek.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
