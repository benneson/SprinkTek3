
using System;
using Abp.Application.Services.Dto;

namespace SprintTek.Phonebook.Phonebook.Dtos
{
    public class PhonebookDto : EntityDto
    {
		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }


		 public int? PersonId { get; set; }

		 
    }
}