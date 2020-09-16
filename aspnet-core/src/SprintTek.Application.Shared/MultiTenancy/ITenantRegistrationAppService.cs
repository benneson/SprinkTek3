using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.Editions.Dto;
using SprintTek.MultiTenancy.Dto;

namespace SprintTek.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}