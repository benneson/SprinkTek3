using Abp.Application.Services.Dto;
using System;

namespace SprintTek.Bottles.Dtos
{
    public class GetAllBottlesInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public int? ActiveFilter { get; set; }



    }
}