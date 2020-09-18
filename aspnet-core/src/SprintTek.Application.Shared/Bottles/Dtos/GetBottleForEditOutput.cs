using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SprintTek.Bottles.Dtos
{
    public class GetBottleForEditOutput
    {
		public CreateOrEditBottleDto Bottle { get; set; }


    }
}