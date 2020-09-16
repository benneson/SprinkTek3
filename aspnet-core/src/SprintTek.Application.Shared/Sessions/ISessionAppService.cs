using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.Sessions.Dto;

namespace SprintTek.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
