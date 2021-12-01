using McMaster.Extensions.CommandLineUtils;
using Microsoft.EntityFrameworkCore;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.Console.Executors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Cli.Commands
{
    public class SeedCommandExecutor : ICommandExecutor<SeedCommand>
    {
        private IHealthcareSeeder Seeder { get; }
        private IDbContextFactory<HealthcareContext> ContextFactory { get; }

        public SeedCommandExecutor(IHealthcareSeeder seeder, IDbContextFactory<HealthcareContext> contextFactory)
        {
            Seeder = seeder;
            ContextFactory = contextFactory;
        }

        public async Task<int> ExecuteAsync(CommandLineApplication application, CancellationToken cancellationToken, SeedCommand command)
        {
            //Make sure the schema is applied to the database.
            await MigrateAsync();

            //Seed the healthcare data into the database.
            using Stream productSummaries = GetStream(command.ProductSummariesPath);
            using Stream activitySummaries = GetStream(command.ActivitySummariesPath);
            using Stream products = GetStream(command.ProductsPath);
            using Stream activities = GetStream(command.ActivitiesPath);
            using Stream specialties = GetStream(command.SpecialtiesPath);
            using Stream diagnoses = GetStream(command.DiagnosesPath);

            await Seeder.SeedAsync(productSummaries, activitySummaries, products, activities, specialties, diagnoses);

            //Return success exit code.
            return 0;
        }

        private async Task MigrateAsync()
        {
            HealthcareContext context = ContextFactory.CreateDbContext();
            IEnumerable<string> appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
            System.Console.WriteLine("Detected migrations: " + appliedMigrations.Count());

            if (appliedMigrations.Any() == false)
            {
                System.Console.WriteLine("Migrating ...");
                await context.Database.MigrateAsync();
            }
        }

        private Stream GetStream(string path)
        {
            return File.OpenRead(path);
        }
    }
}
