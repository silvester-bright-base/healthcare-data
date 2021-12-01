using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Extensions;
using Silvester.BrightBase.Healthcare.Seeding.Mappers;
using Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using Silvester.BrightBase.Healthcare.Seeding.Parsers;
using Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding
{
    public interface IHealthcareSeeder
    {
        Task SeedAsync(Stream productSummariesStream, Stream activitySummariesStream, Stream productsStream, Stream activitiesStream, Stream specialtiesStream, Stream diagnosesStream);
    }

    public class HealthcareSeeder : IHealthcareSeeder
    {
        private IServiceProvider Services { get; }

        public HealthcareSeeder(IServiceProvider services)
        {
            Services = services;
        }

        public async Task SeedAsync(Stream productSummaries, Stream activitySummaries, Stream products, Stream activities, Stream specialties, Stream diagnoses)
        {
            await SeedProfileClassesAsync(activities);
            activities.Seek(0, SeekOrigin.Begin);

            await SeedActivitiesAsync(activities);
            await SeedSpecialtiesAsync(specialties);
            await SeedProductsAsync(products);
            await SeedDiagnosesAsync(diagnoses);
            await SeedProductSummariesAsync(productSummaries);
            await SeedActivitySummaryAsync(activitySummaries);
        }

        private async Task SeedProfileClassesAsync(Stream activities)
        {
            await SeedAsync<Activity, HealthcareProfileClass>(Parse<Activity>(activities).DistinctBy(e => e.ZorgprofielKlasseCd));
        }

        private async Task SeedActivitiesAsync(Stream activities)
        {
            await SeedAsync<Activity, HealthcareActivity>(Parse<Activity>(activities));
        }

        private async Task SeedSpecialtiesAsync(Stream specialties)
        {
            await SeedAsync<Specialty, HealthcareSpecialty>(Parse<Specialty>(specialties));
        }

        private async Task SeedProductsAsync(Stream products)
        {
            await SeedAsync<Product, HealthcareProduct>(Parse<Product>(products));
        }

        private async Task SeedDiagnosesAsync(Stream diagnoses)
        {
            await SeedAsync<Diagnosis, HealthcareDiagnosis>(Parse<Diagnosis>(diagnoses));
        }

        private async Task SeedProductSummariesAsync(Stream productSummaries)
        {
            await SeedAsync<ProductSummary, HealthcareProductSummary>(Parse<ProductSummary>(productSummaries));
        }

        private async Task SeedActivitySummaryAsync(Stream activitySummaries)
        {
            await SeedAsync<ActivitySummary, HealthcareActivitySummary>(Parse<ActivitySummary>(activitySummaries));
        }

        private IEnumerable<TModel> Parse<TModel>(Stream csv)
        {
            return Services
                .GetRequiredService<IParser<TModel>>()
                .Parse(csv);
        }

        private async Task SeedAsync<TModel, TEntity>(IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class
        {
            await ActivatorUtilities
               .CreateInstance<BatchSeeder<TModel, TEntity>>(Services)
               .SeedAsync(models);
        }
    }

    public class BatchSeeder<TModel, TEntity>
        where TEntity : class
        where TModel : class
    {
        private ILogger<BatchSeeder<TModel, TEntity>> Logger { get; }
        private IDbContextFactory<HealthcareContext> ContextFactory { get; }
        private IMapper<TModel, TEntity> Mapper { get; }
        private IOptions<Options> BatchOptions { get; }

        private int Count { get; set; }
        private System.Diagnostics.Stopwatch Stopwatch { get; }

        public BatchSeeder(ILogger<BatchSeeder<TModel, TEntity>> logger, IDbContextFactory<HealthcareContext> contextFactory, IMapper<TModel, TEntity> mapper, IOptions<BatchSeeder<TModel, TEntity>.Options> batchOptions)
        {
            Stopwatch = new System.Diagnostics.Stopwatch();
            Count = 0;
            Logger = logger;
            ContextFactory = contextFactory;
            Mapper = mapper;
            BatchOptions = batchOptions;
        }

        public async Task SeedAsync(IEnumerable<TModel> models)
        {
            Stopwatch.Reset();
            Stopwatch.Start();

            Logger.LogInformation("Available processors: " + Environment.ProcessorCount);

            ParallelOptions parallelOptions = new ParallelOptions 
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            await Parallel.ForEachAsync(models.Batch(BatchOptions.Value.BatchSize), parallelOptions, async (batch, cancellationToken) => 
            {
                HealthcareContext context = ContextFactory.CreateDbContext();
                context.ChangeTracker.AutoDetectChangesEnabled = false;

                context
                    .Set<TEntity>()
                    .AddRange(Mapper.Map(batch));

                await context.SaveChangesAsync();

                Logger.LogInformation($"Processed {typeof(TEntity).Name} batch {Count} after '{Stopwatch.ElapsedMilliseconds}'.");
                Count += 1;
            });
        }

        public class Options
        {
            public int BatchSize { get; set; }

            public Options()
            {
                BatchSize = 1000;
            }
        }
    }
}
