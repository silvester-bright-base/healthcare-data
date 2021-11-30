using System.Threading.Tasks;

namespace Silvester.Hosting.Probes.Liveness
{
    public interface ILivenessProbe
    {
        ValueTask<bool> ShouldRestartAsync();
    }

    public class DefaultLivenessProbe : ILivenessProbe
    {
        public ValueTask<bool> ShouldRestartAsync()
        {
            return new ValueTask<bool>(false);
        }
    }
}
