
using System;
using Abp.Application.Services.Dto;

namespace SprintTek.Docs.Dtos
{
    public class DocDto : EntityDto
    {
		public string name { get; set; }

		public bool Active { get; set; }



    }
}