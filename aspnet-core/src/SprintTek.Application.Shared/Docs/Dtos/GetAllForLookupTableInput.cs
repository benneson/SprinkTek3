using Abp.Application.Services.Dto;

namespace SprintTek.Docs.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}