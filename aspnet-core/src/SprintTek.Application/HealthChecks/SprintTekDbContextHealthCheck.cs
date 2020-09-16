using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SprintTek.EntityFrameworkCore;

namespace SprintTek.HealthChecks
{
    public class SprintTekDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public SprintTekDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("SprintTekDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("SprintTekDbContext could not connect to database"));
        }
    }
}
