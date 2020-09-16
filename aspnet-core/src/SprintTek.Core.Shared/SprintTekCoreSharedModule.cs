using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    public class SprintTekCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekCoreSharedModule).GetAssembly());
        }
    }
}