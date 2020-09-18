
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SprintTek.Phonebook.Phonebook.Dtos
{
    public class CreateOrEditPhonebookDto : EntityDto<int?>
    {

		public string Name { get; set; }
		
		
		public string Surname { get; set; }
		
		
		public string Email { get; set; }
		
		
		 public int? PersonId { get; set; }
		 
		 
    }
}