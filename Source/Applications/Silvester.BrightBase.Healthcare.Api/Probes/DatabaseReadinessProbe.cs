using Microsoft.Extensions.Hosting;
using Silvester.BrightBase.Healthcare.Api.Services;
using Silvester.Hosting.Probes.Readiness;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Api.Probes
{
    public class DatabaseReadinessProbe : IReadinessProbe
    {
        private DatabaseStateService DatabaseStateService { get; }

        public DatabaseReadinessProbe(IEnumerable<IHostedService> hostedServices)
        {
            DatabaseStateService = hostedServices.OfType<DatabaseStateService>().First();
        }

        public ValueTask<bool> IsReadyToAcceptTrafficAsync()
        {
            return new ValueTask<bool>(DatabaseStateService.DatabaseState == DatabaseState.Ready);
        }
    }
}