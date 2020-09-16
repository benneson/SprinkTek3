using Abp.Domain.Services;

namespace SprintTek
{
    public abstract class SprintTekDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected SprintTekDomainServiceBase()
        {
            LocalizationSourceName = SprintTekConsts.LocalizationSourceName;
        }
    }
}
