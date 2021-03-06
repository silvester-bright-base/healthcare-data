using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.Console.Executors
{
    public interface ICommandExecutorFactory<in TCommand>
    {
        ICommandExecutor<TCommand> Create(CommandLineApplication application);
    }
}
