using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silvester.BrightBase.Healthcare.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LatinDescription = table.Column<string>(type: "text", nullable: false),
                    ConsumerDescription = table.Column<string>(type: "text", nullable: false),
                    InsuredClaimCode = table.Column<string>(type: "text", nullable: true),
                    UninsuredClaimCode = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HealthcareProfileClassId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ProfileClasses_HealthcareProfileClassId",
                        column: x => x.HealthcareProfileClassId,
                        principalTable: "ProfileClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HealthcareSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => new { x.Id, x.HealthcareSpecialtyId });
                    table.ForeignKey(
                        name: "FK_Diagnoses_Specialties_HealthcareSpecialtyId",
                        column: x => x.HealthcareSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    PatientAmount = table.Column<int>(type: "integer", nullable: false),
                    SubProcedureAmount = table.Column<int>(type: "integer", nullable: false),
                    ActivityAmount = table.Column<int>(type: "integer", nullable: false),
                    TreatingSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    TypicalDiagnosisId = table.Column<string>(type: "text", nullable: false),
                    HealthcareProductId = table.Column<int>(type: "integer", nullable: false),
                    HealthcareActivityId = table.Column<int>(type: "integer", nullable: false),
                    HealthcareProfileClassId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySummaries_Activities_HealthcareActivityId",
                        column: x => x.HealthcareActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySummaries_Diagnoses_TypicalDiagnosisId_TreatingSpec~",
                        columns: x => new { x.TypicalDiagnosisId, x.TreatingSpecialtyId },
                        principalTable: "Diagnoses",
                        principalColumns: new[] { "Id", "HealthcareSpecialtyId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySummaries_Products_HealthcareProductId",
                        column: x => x.HealthcareProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySummaries_ProfileClasses_HealthcareProfileClassId",
                        column: x => x.HealthcareProfileClassId,
                        principalTable: "ProfileClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySummaries_Specialties_TreatingSpecialtyId",
                        column: x => x.TreatingSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    SubProcedureAmountPerProduct = table.Column<int>(type: "integer", nullable: false),
                    SubProcedureAmountPerDiagnosis = table.Column<int>(type: "integer", nullable: false),
                    SubProcedureAmountPerSpecialty = table.Column<int>(type: "integer", nullable: false),
                    PatientAmountPerProduct = table.Column<int>(type: "integer", nullable: false),
                    PatientAmountPerDiagnosis = table.Column<int>(type: "integer", nullable: false),
                    PatientAmountPerSpecialty = table.Column<int>(type: "integer", nullable: false),
                    AverageSalesPrice = table.Column<int>(type: "integer", nullable: false),
                    TreatingSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    TypicalDiagnosisId = table.Column<string>(type: "text", nullable: false),
                    HealthcareProductId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateMeasured = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSummaries_Diagnoses_TypicalDiagnosisId_TreatingSpeci~",
                        columns: x => new { x.TypicalDiagnosisId, x.TreatingSpecialtyId },
                        principalTable: "Diagnoses",
                        principalColumns: new[] { "Id", "HealthcareSpecialtyId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSummaries_Products_HealthcareProductId",
                        column: x => x.HealthcareProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSummaries_Specialties_TreatingSpecialtyId",
                        column: x => x.TreatingSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_HealthcareProfileClassId",
                table: "Activities",
                column: "HealthcareProfileClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySummaries_HealthcareActivityId",
                table: "ActivitySummaries",
                column: "HealthcareActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySummaries_HealthcareProductId",
                table: "ActivitySummaries",
                column: "HealthcareProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySummaries_HealthcareProfileClassId",
                table: "ActivitySummaries",
                column: "HealthcareProfileClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySummaries_TreatingSpecialtyId",
                table: "ActivitySummaries",
                column: "TreatingSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySummaries_TypicalDiagnosisId_TreatingSpecialtyId",
                table: "ActivitySummaries",
                columns: new[] { "TypicalDiagnosisId", "TreatingSpecialtyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_HealthcareSpecialtyId",
                table: "Diagnoses",
                column: "HealthcareSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSummaries_HealthcareProductId",
                table: "ProductSummaries",
                column: "HealthcareProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSummaries_TreatingSpecialtyId",
                table: "ProductSummaries",
                column: "TreatingSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSummaries_TypicalDiagnosisId_TreatingSpecialtyId",
                table: "ProductSummaries",
                columns: new[] { "TypicalDiagnosisId", "TreatingSpecialtyId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySummaries");

            migrationBuilder.DropTable(
                name: "ProductSummaries");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProfileClasses");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
