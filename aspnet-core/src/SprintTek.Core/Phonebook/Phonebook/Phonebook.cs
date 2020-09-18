using SprintTek.Phonebook;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Auditing;

namespace SprintTek.Phonebook.Phonebook
{
	[Table("Phonebooks")]
    [Audited]
    public class Phonebook : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			

		public virtual string Name { get; set; }
		
		public virtual string Surname { get; set; }
		
		public virtual string Email { get; set; }
		

		public virtual int? PersonId { get; set; }
		
        [ForeignKey("PersonId")]
		public Person PersonFk { get; set; }
		
    }
}