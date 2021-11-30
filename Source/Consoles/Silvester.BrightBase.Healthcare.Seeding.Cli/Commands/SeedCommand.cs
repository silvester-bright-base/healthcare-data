using McMaster.Extensions.CommandLineUtils;
using Silvester.Console;
using Silvester.Console.Executors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Cli.Commands
{
    [Command("seed", "Start seeding the healthcare data into the given database context.")]
    public class SeedCommand : Command<SeedCommand>
    {
        [Required]
        [Option("--product-summaries", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the product summaries (file 1).")]
        public string ProductSummariesPath { get; set; } = default!;

        [Required]
        [Option("--activity-summaries", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the activity summaries (file 2).")]
        public string ActivitySummariesPath { get; set; } = default!;

        [Required]
        [Option("--products", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the products (file 3).")]
        public string ProductsPath { get; set; } = default!;

        [Required]
        [Option("--activities", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the activities summaries (file 4).")]
        public string ActivitiesPath { get; set; } = default!;

        [Required]
        [Option("--specialties", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the specialties (file 5).")]
        public string SpecialtiesPath { get; set; } = default!;

        [Required]
        [Option("--diagnoses", CommandOptionType.SingleValue, Description = "Path to the .csv file containing the diagnoses (file 6).")]
        public string DiagnosesPath { get; set; } = default!;

        public SeedCommand(ICommandExecutor<SeedCommand> executor)
            : base(executor)
        {

        }
    }
}
