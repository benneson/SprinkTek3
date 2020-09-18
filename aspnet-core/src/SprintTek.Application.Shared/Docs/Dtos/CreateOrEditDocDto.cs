
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SprintTek.Docs.Dtos
{
    public class CreateOrEditDocDto : EntityDto<int?>
    {

		public string name { get; set; }
		
		
		public bool Active { get; set; }
		
		

    }
}