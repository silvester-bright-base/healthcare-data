using Microsoft.EntityFrameworkCore;
using Silvester.BrightBase.Healthcare.Database.Models;
using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using System;
using System.Linq;

namespace Silvester.BrightBase.Healthcare.Database
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options)
            : base(options)
        {

        }

        public DbSet<HealthcareProductSummary> ProductSummaries { get; set; } = default!;
        public DbSet<HealthcareActivitySummary> ActivitySummaries { get; set; } = default!;
        public DbSet<HealthcareDiagnosis> Diagnoses { get; set; } = default!;
        public DbSet<HealthcareActivity> Activities { get; set; } = default!;
        public DbSet<HealthcareSpecialty> Specialties { get; set; } = default!;
        public DbSet<HealthcareProfileClass> ProfileClasses { get; set; } = default!;
        public DbSet<HealthcareProduct> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HealthcareActivity>().HasKey(e => e.Id);
            builder.Entity<HealthcareActivitySummary>().HasKey(e => e.Id);
            builder.Entity<HealthcareDiagnosis>().HasKey(e => new { e.Id, e.HealthcareSpecialtyId });
            builder.Entity<HealthcareProduct>().HasKey(e => e.Id);
            builder.Entity<HealthcareProductSummary>().HasKey(e => e.Id);
            builder.Entity<HealthcareProfileClass>().HasKey(e => e.Id);
            builder.Entity<HealthcareSpecialty>().HasKey(e => e.Id);

            builder.Entity<HealthcareProductSummary>()
                .HasOne(p => p.TypicalDiagnosis)
                .WithMany(e => e.ProductSummaries)
                .HasForeignKey(p => new { p.TypicalDiagnosisId, p.TreatingSpecialtyId });

            builder.Entity<HealthcareActivitySummary>()
                .HasOne(p => p.TypicalDiagnosis)
                .WithMany(e => e.ActivitySummaries)
                .HasForeignKey(p => new { p.TypicalDiagnosisId, p.TreatingSpecialtyId });
        }
    }
}
