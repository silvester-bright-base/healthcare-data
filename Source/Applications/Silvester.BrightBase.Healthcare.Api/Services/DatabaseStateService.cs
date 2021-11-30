using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Silvester.BrightBase.Healthcare.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Api.Services
{
    public enum DatabaseState
    {
        Unready,
        Ready
    }

    public class DatabaseStateService : BackgroundService
    {
        private IDbContextFactory<HealthcareContext> Factory { get; }

        private ILogger<DatabaseStateService> Logger { get; }

        private IHostApplicationLifetime ApplicationLifetime { get; }

        public DatabaseState DatabaseState { get; set; }

        public DatabaseStateService(IDbContextFactory<HealthcareContext> factory, ILogger<DatabaseStateService> logger, IHostApplicationLifetime applicationLifetime)
        {
            Factory = factory;
            Logger = logger;
            ApplicationLifetime = applicationLifetime;
            DatabaseState = DatabaseState.Unready;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false && DatabaseState != DatabaseState.Ready)
            {
                try
                {
                    using (HealthcareContext context = Factory.CreateDbContext())
                    {
                        if (context.Activities.Any())
                        {
                            DatabaseState = DatabaseState.Ready;
                            Logger.LogInformation("Database state set to ready.");
                        }
                    }
                }
                catch (NpgsqlException exception) when (exception.InnerException != null && exception.InnerException is SocketException)
                {
                    Logger.LogInformation("Socket exception on database connection. Interpreting as 'database not ready'.");
                    DatabaseState = DatabaseState.Unready;
                    Logger.LogInformation("Database state set to unready.");
                }
                catch (Exception exception)
                {
                    Logger.LogCritical(exception, $"Something went wrong in the background service `{nameof(DatabaseStateService)}`.");
                    ApplicationLifetime.StopApplication();
                }

                await Task.Delay(10000);
            }
        }
    }
}