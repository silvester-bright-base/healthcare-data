﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Silvester.BrightBase.Healthcare.Database;

#nullable disable

namespace Silvester.BrightBase.Healthcare.Database.Migrations
{
    [DbContext(typeof(HealthcareContext))]
    partial class HealthcareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HealthcareProfileClassId")
                        .HasColumnType("integer");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HealthcareProfileClassId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareActivitySummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityAmount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HealthcareActivityId")
                        .HasColumnType("integer");

                    b.Property<int>("HealthcareProductId")
                        .HasColumnType("integer");

                    b.Property<int>("HealthcareProfileClassId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientAmount")
                        .HasColumnType("integer");

                    b.Property<int>("SubProcedureAmount")
                        .HasColumnType("integer");

                    b.Property<int>("TreatingSpecialtyId")
                        .HasColumnType("integer");

                    b.Property<string>("TypicalDiagnosisId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HealthcareActivityId");

                    b.HasIndex("HealthcareProductId");

                    b.HasIndex("HealthcareProfileClassId");

                    b.HasIndex("TreatingSpecialtyId");

                    b.HasIndex("TypicalDiagnosisId", "TreatingSpecialtyId");

                    b.ToTable("ActivitySummaries");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareDiagnosis", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("HealthcareSpecialtyId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id", "HealthcareSpecialtyId");

                    b.HasIndex("HealthcareSpecialtyId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsumerDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsuredClaimCode")
                        .HasColumnType("text");

                    b.Property<string>("LatinDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UninsuredClaimCode")
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProductSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AverageSalesPrice")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HealthcareProductId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientAmountPerDiagnosis")
                        .HasColumnType("integer");

                    b.Property<int>("PatientAmountPerProduct")
                        .HasColumnType("integer");

                    b.Property<int>("PatientAmountPerSpecialty")
                        .HasColumnType("integer");

                    b.Property<int>("SubProcedureAmountPerDiagnosis")
                        .HasColumnType("integer");

                    b.Property<int>("SubProcedureAmountPerProduct")
                        .HasColumnType("integer");

                    b.Property<int>("SubProcedureAmountPerSpecialty")
                        .HasColumnType("integer");

                    b.Property<int>("TreatingSpecialtyId")
                        .HasColumnType("integer");

                    b.Property<string>("TypicalDiagnosisId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HealthcareProductId");

                    b.HasIndex("TreatingSpecialtyId");

                    b.HasIndex("TypicalDiagnosisId", "TreatingSpecialtyId");

                    b.ToTable("ProductSummaries");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProfileClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProfileClasses");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareSpecialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateMeasured")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareActivity", b =>
                {
                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProfileClass", "HealthcareProfileClass")
                        .WithMany()
                        .HasForeignKey("HealthcareProfileClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthcareProfileClass");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareActivitySummary", b =>
                {
                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareActivity", "HealthcareActivity")
                        .WithMany()
                        .HasForeignKey("HealthcareActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProduct", "HealthcareProduct")
                        .WithMany()
                        .HasForeignKey("HealthcareProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProfileClass", "HealthcareProfileClass")
                        .WithMany()
                        .HasForeignKey("HealthcareProfileClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareSpecialty", "TreatingSpecialty")
                        .WithMany()
                        .HasForeignKey("TreatingSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareDiagnosis", "TypicalDiagnosis")
                        .WithMany("ActivitySummaries")
                        .HasForeignKey("TypicalDiagnosisId", "TreatingSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthcareActivity");

                    b.Navigation("HealthcareProduct");

                    b.Navigation("HealthcareProfileClass");

                    b.Navigation("TreatingSpecialty");

                    b.Navigation("TypicalDiagnosis");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareDiagnosis", b =>
                {
                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareSpecialty", "HealthcareSpecialty")
                        .WithMany()
                        .HasForeignKey("HealthcareSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthcareSpecialty");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProductSummary", b =>
                {
                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareProduct", "HealthcareProduct")
                        .WithMany()
                        .HasForeignKey("HealthcareProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareSpecialty", "TreatingSpecialty")
                        .WithMany()
                        .HasForeignKey("TreatingSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareDiagnosis", "TypicalDiagnosis")
                        .WithMany("ProductSummaries")
                        .HasForeignKey("TypicalDiagnosisId", "TreatingSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthcareProduct");

                    b.Navigation("TreatingSpecialty");

                    b.Navigation("TypicalDiagnosis");
                });

            modelBuilder.Entity("Silvester.BrightBase.Healthcare.Database.Models.Instances.HealthcareDiagnosis", b =>
                {
                    b.Navigation("ActivitySummaries");

                    b.Navigation("ProductSummaries");
                });
#pragma warning restore 612, 618
        }
    }
}
