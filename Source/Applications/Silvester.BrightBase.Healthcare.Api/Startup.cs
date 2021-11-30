using HotChocolate.Data.Filters;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silvester.BrightBase.Healthcare.Api.Graphql;
using Silvester.BrightBase.Healthcare.Api.Graphql.Extensions;
using Silvester.BrightBase.Healthcare.Api.Graphql.Interceptors;
using Silvester.BrightBase.Healthcare.Api.Probes;
using Silvester.BrightBase.Healthcare.Api.Services;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.Hosting.Middleware;
using Silvester.Hosting.Probes.Liveness;
using Silvester.Hosting.Probes.Readiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Silvester.BrightBase.Healthcare.Api
{
    public class Startup
    {
        private const string LOCALHOST_CORS_POLICY_NAME = "CORS_POLICY_LOCALHOST";

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddForwardedPathBaseHeader(options => 
                {
                    options.ForwardedPathHeaderName = "x-forwarded-path";
                });

            services
                .AddCors(options =>
                {
                    options.AddPolicy(name: LOCALHOST_CORS_POLICY_NAME, builder =>
                    {
                        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowCredentials();
                    });
                });

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            if (bool.Parse(Configuration.GetSection("databases").GetSection("healthcare")["enabled"]))
            {
                services.AddSingleton<IHostedService, DatabaseStateService>();
            }

            services
                .AddSingleton<IReadinessProbe, DatabaseReadinessProbe>();

            services
                .AddPooledDbContextFactory<HealthcareContext>(options =>
                {
                    IConfigurationSection section = Configuration.GetSection("databases").GetSection("healthcare");
                    string connectionString = $"Server={section["Server"]};Database={section["Database"]};User Id={section["UserId"]};Password={section["Password"]};Port={section["Port"]};Timeout={section["Timeout"]};CommandTimeout={section["CommandTimeout"]};Include Error Detail={section["IncludeErrorDetails"]}";

                    options.EnableSensitiveDataLogging(false);// Environment.IsDevelopment());
                    options.UseNpgsql(connectionString);
                });

            IRequestExecutorBuilder graphql = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddEntityTypes()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddType<QueryType>()
                .AddType<DateOnlyType>()
                .SetPagingOptions(new PagingOptions { MaxPageSize = 100, DefaultPageSize = 25, IncludeTotalCount = true })
                .TryAddTypeInterceptor<DateOnlyInterceptor>();

            services
                .Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();
            app.UseMiddleware<ForwardedPathBaseHeaderMiddleware>();
            app.UseLivenessProbe();
            app.UseReadinessProbe();

            app.UseRouting();
            app.UseCors(LOCALHOST_CORS_POLICY_NAME);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
