using Abp.Application.Services.Dto;

namespace SprintTek.Bottles.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}