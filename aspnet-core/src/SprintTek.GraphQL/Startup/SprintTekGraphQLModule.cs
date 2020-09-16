using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SprintTek.Startup
{
    [DependsOn(typeof(SprintTekCoreModule))]
    public class SprintTekGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}