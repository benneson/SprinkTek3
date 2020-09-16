using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace SprintTek.Web.Public.Views
{
    public abstract class SprintTekRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SprintTekRazorPage()
        {
            LocalizationSourceName = SprintTekConsts.LocalizationSourceName;
        }
    }
}
