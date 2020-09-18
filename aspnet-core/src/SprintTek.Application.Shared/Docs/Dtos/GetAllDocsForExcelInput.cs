using Abp.Application.Services.Dto;
using System;

namespace SprintTek.Docs.Dtos
{
    public class GetAllDocsForExcelInput
    {
		public string Filter { get; set; }

		public string nameFilter { get; set; }

		public int? ActiveFilter { get; set; }



    }
}