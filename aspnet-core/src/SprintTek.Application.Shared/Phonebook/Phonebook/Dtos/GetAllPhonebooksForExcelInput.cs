using Abp.Application.Services.Dto;
using System;

namespace SprintTek.Phonebook.Phonebook.Dtos
{
    public class GetAllPhonebooksForExcelInput
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public string SurnameFilter { get; set; }

		public string EmailFilter { get; set; }


		 public string PersonNameFilter { get; set; }

		 
    }
}