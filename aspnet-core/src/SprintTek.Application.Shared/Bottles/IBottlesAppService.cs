using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.Bottles.Dtos;
using SprintTek.Dto;


namespace SprintTek.Bottles
{
    public interface IBottlesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetBottleForViewDto>> GetAll(GetAllBottlesInput input);

        Task<GetBottleForViewDto> GetBottleForView(int id);

		Task<GetBottleForEditOutput> GetBottleForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditBottleDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetBottlesToExcel(GetAllBottlesForExcelInput input);

		
    }
}