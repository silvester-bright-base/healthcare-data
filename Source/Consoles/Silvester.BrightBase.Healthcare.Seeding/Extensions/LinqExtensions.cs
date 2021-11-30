using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<List<TSource>> Batch<TSource>(this IEnumerable<TSource> sources, int batchSize)
        {
            IEnumerator<TSource> enumerator = sources.GetEnumerator();
            
            List<TSource> batch = new List<TSource>();
            while(enumerator.MoveNext())
            {
                batch.Add(enumerator.Current);

                if(batch.Count == batchSize)
                {
                    yield return batch;
                    batch = new List<TSource>();
                }
            }

            if(batch.Any())
            {
                yield return batch;
            }
        }
    }
}
