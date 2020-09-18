using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.Docs.Dtos;
using SprintTek.Dto;


namespace SprintTek.Docs
{
    public interface IDocsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetDocForViewDto>> GetAll(GetAllDocsInput input);

        Task<GetDocForViewDto> GetDocForView(int id);

		Task<GetDocForEditOutput> GetDocForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditDocDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetDocsToExcel(GetAllDocsForExcelInput input);

		
    }
}