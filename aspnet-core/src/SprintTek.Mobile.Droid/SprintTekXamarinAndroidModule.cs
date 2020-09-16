using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    [DependsOn(typeof(SprintTekXamarinSharedModule))]
    public class SprintTekXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekXamarinAndroidModule).GetAssembly());
        }
    }
}