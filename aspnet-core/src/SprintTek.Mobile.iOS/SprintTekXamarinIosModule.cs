using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    [DependsOn(typeof(SprintTekXamarinSharedModule))]
    public class SprintTekXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekXamarinIosModule).GetAssembly());
        }
    }
}