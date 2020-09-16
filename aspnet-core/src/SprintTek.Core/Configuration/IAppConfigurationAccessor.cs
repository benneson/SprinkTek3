using Microsoft.Extensions.Configuration;

namespace SprintTek.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
