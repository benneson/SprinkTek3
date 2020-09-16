using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SprintTek.Configure;
using SprintTek.Startup;
using SprintTek.Test.Base;

namespace SprintTek.GraphQL.Tests
{
    [DependsOn(
        typeof(SprintTekGraphQLModule),
        typeof(SprintTekTestBaseModule))]
    public class SprintTekGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SprintTekGraphQLTestModule).GetAssembly());
        }
    }
}