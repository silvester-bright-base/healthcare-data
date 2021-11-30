using McMaster.Extensions.CommandLineUtils;
using Silvester.BrightBase.Healthcare.Seeding.Cli.Commands;

namespace Silvester.BrightBase.Healthcare.Seeding.Cli
{
    [Subcommand(typeof(SeedCommand))]
    public class RootCommand
    {

    }
}