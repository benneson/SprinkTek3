using Abp.Application.Services.Dto;
using System;

namespace SprintTek.Docs.Dtos
{
    public class GetAllDocsInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string nameFilter { get; set; }

		public int? ActiveFilter { get; set; }



    }
}