
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SprintTek.Bottles.Dtos
{
    public class CreateOrEditBottleDto : EntityDto<int?>
    {

		public string Name { get; set; }
		
		
		public bool Active { get; set; }
		
		

    }
}