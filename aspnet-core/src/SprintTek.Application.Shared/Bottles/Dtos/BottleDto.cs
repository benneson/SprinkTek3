
using System;
using Abp.Application.Services.Dto;

namespace SprintTek.Bottles.Dtos
{
    public class BottleDto : EntityDto
    {
		public string Name { get; set; }

		public bool Active { get; set; }



    }
}