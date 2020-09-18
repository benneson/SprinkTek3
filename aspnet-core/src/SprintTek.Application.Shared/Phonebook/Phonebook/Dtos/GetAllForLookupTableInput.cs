using Abp.Application.Services.Dto;

namespace SprintTek.Phonebook.Phonebook.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}