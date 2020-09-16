using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SprintTek.Configuration;
using SprintTek.Web;

namespace SprintTek.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SprintTekDbContextFactory : IDesignTimeDbContextFactory<SprintTekDbContext>
    {
        public SprintTekDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SprintTekDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            SprintTekDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SprintTekConsts.ConnectionStringName));

            return new SprintTekDbContext(builder.Options);
        }
    }
}