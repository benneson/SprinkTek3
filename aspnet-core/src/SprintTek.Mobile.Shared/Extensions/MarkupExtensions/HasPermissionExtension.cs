using System;
using SprintTek.Core;
using SprintTek.Core.Dependency;
using SprintTek.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SprintTek.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}