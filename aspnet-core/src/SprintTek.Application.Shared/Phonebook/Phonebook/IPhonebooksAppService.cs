using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.Phonebook.Phonebook.Dtos;
using SprintTek.Dto;


namespace SprintTek.Phonebook.Phonebook
{
    public interface IPhonebooksAppService : IApplicationService 
    {
        Task<PagedResultDto<GetPhonebookForViewDto>> GetAll(GetAllPhonebooksInput input);

        Task<GetPhonebookForViewDto> GetPhonebookForView(int id);

		Task<GetPhonebookForEditOutput> GetPhonebookForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditPhonebookDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetPhonebooksToExcel(GetAllPhonebooksForExcelInput input);

		
		Task<PagedResultDto<PhonebookPersonLookupTableDto>> GetAllPersonForLookupTable(GetAllForLookupTableInput input);
		
    }
}