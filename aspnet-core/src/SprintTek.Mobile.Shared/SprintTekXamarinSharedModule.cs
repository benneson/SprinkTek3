using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek
{
    [DependsOn(typeof(SprintTekClientModule), typeof(AbpAutoMapperModule))]
    public class SprintTekXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekXamarinSharedModule).GetAssembly());
        }
    }
}