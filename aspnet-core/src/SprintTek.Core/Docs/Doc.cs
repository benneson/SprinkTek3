using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Auditing;

namespace SprintTek.Docs
{
	[Table("docs")]
    [Audited]
    public class Doc : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			

		public virtual string name { get; set; }
		
		public virtual bool Active { get; set; }
		

    }
}