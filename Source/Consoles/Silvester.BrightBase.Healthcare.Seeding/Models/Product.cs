using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class Product
    {
        public string Versie { get; set; } = default!;
        public DateTimeOffset DatumBestand { get; set; }
        public DateTimeOffset PeilDatum { get; set; }
        public int ZorgproductCd { get; set; }
        public string LatijnOms { get; set; } = default!;
        public string ConsumentOms{ get; set; } = default!;
        public string? DeclaratieVerzekerdCd { get; set; } 
        public string? DeclaratieOnverzekerdCd { get; set; }
    }
}
