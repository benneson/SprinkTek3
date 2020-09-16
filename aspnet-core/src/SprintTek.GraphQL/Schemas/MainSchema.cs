using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using SprintTek.Queries.Container;

namespace SprintTek.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}