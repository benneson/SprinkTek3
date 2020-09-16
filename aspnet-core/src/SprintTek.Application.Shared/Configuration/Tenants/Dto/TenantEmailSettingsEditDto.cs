using Abp.Auditing;
using SprintTek.Configuration.Dto;

namespace SprintTek.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}