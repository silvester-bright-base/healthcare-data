using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silvester.Console.Executors;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Silvester.BrightBase.Healthcare.Seeding.Cli;
using Silvester.BrightBase.Healthcare.Seeding.Cli.Commands;
using Silvester.BrightBase.Healthcare.Seeding.DependencyInjection;
using Silvester.BrightBase.Healthcare.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Silvester.BrightBase.Healthcare.Seeding
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureApplication)
                .ConfigureServices(ConfigureServices)
                .RunCommandLineApplicationAsync<RootCommand>(args);
        }

        private static void ConfigureApplication(HostBuilderContext context, IConfigurationBuilder builder)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "ci")
            {
                builder.AddJsonFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "appsettings.ci.json"), optional: false);
            }
            else
            {
                builder.AddJsonFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "appsettings.json"), optional: false);
            }
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            IConfiguration configuration = context.Configuration;

            services.AddTransient<ICommandExecutor<SeedCommand>, SeedCommandExecutor>();
            services.AddHealthcareSeeder();
            services.AddDbContextFactory<HealthcareContext>(options =>
            {
                IConfigurationSection section = configuration.GetSection("databases").GetSection("healthcare");
                string connectionString = $"Server={section["Server"]};Database={section["Database"]};User Id={section["UserId"]};Password={section["Password"]};Port={section["Port"]};Timeout={section["Timeout"]};CommandTimeout={section["CommandTimeout"]};Include Error Detail={section["IncludeErrorDetails"]}";

                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging(true);
                /*options.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder
                        .AddFile("./seed.sql")
                        .AddFilter((category, level) =>
                        {
                            return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
                        });
                }));*/
            });
        }
    }
}
