using Microsoft.Extensions.DependencyInjection;
using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Mappers;
using Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using Silvester.BrightBase.Healthcare.Seeding.Parsers;
using Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHealthcareSeeder(this IServiceCollection services)
        {
            services
                .AddTransient<IMapper<Activity, HealthcareActivity>, ActivityMapper>()
                .AddTransient<IMapper<Activity, HealthcareProfileClass>, ProfileClassMapper>()
                .AddTransient<IMapper<Product, HealthcareProduct>, ProductMapper>()
                .AddTransient<IMapper<Diagnosis, HealthcareDiagnosis>, DiagnosisMapper>()
                .AddTransient<IMapper<Specialty, HealthcareSpecialty>, SpecialtyMapper>()
                .AddTransient<IMapper<ActivitySummary, HealthcareActivitySummary>, ActivitySummaryMapper>()
                .AddTransient<IMapper<ProductSummary, HealthcareProductSummary>, ProductSummaryMapper>();


            services
                .AddTransient<IParser<Activity>, ActivityParser>()
                .AddTransient<IParser<Product>, ProductParser>()
                .AddTransient<IParser<Diagnosis>, DiagnosisParser>()
                .AddTransient<IParser<Specialty>, SpecialtyParser>()
                .AddTransient<IParser<ActivitySummary>, ActivitySummaryParser>()
                .AddTransient<IParser<ProductSummary>, ProductSummaryParser>();

            services
                .AddTransient<IHealthcareSeeder, HealthcareSeeder>();

            return services;
        }
    }
}
