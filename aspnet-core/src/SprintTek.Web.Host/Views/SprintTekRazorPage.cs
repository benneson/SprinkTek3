using Abp.AspNetCore.Mvc.Views;

namespace SprintTek.Web.Views
{
    public abstract class SprintTekRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SprintTekRazorPage()
        {
            LocalizationSourceName = SprintTekConsts.LocalizationSourceName;
        }
    }
}
