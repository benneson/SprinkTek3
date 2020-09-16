using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    public class SprintTekClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekClientModule).GetAssembly());
        }
    }
}
