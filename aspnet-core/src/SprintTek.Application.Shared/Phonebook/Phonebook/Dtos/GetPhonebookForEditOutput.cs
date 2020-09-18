using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SprintTek.Phonebook.Phonebook.Dtos
{
    public class GetPhonebookForEditOutput
    {
		public CreateOrEditPhonebookDto Phonebook { get; set; }

		public string PersonName { get; set;}


    }
}