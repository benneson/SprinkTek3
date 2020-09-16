using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    [DependsOn(typeof(SprintTekCoreSharedModule))]
    public class SprintTekApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekApplicationSharedModule).GetAssembly());
        }
    }
}