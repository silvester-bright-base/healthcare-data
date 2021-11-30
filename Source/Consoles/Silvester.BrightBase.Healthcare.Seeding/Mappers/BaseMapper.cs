using Silvester.BrightBase.Healthcare.Seeding.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers
{
    public interface IMapper<TSource, TTarget>
    {
        IEnumerable<TTarget> Map(IEnumerable<TSource> sources);
    }

    public abstract class BaseMapper<TSource, TTarget> : IMapper<TSource, TTarget>
    {
        public IEnumerable<TTarget> Map(IEnumerable<TSource> sources)
        {
            foreach (TSource source in sources)
            {
                yield return Map(source);
            }
        }

        protected abstract TTarget Map(TSource source);
    }
}
