using Abp.AspNetCore.Mvc.ViewComponents;

namespace SprintTek.Web.Public.Views
{
    public abstract class SprintTekViewComponent : AbpViewComponent
    {
        protected SprintTekViewComponent()
        {
            LocalizationSourceName = SprintTekConsts.LocalizationSourceName;
        }
    }
}