using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class ProductSummary
    {
        public string Versie { get; set; } = default!;
        public DateOnly DatumBestand { get; set; }
        public DateOnly PeilDatum { get; set; }
        public int Jaar { get; set; }
        public int BehandelendSpecialismeCd { get; set; } 
        public string TyperendeDiagnoseCd { get; set; } = default!;
        public int ZorgproductCd { get; set; }
        public int AantalPatPerZpd { get; set; }
        public int AantalSubtrajectPerZpd { get; set; }
        public int AantalPatPerDiag { get; set; }
        public int AantalSubtrajectPerDiag { get; set; }
        public int AantalPatPerSpc { get; set; }
        public int AantalSubtrajectPerSpc{ get; set; }
        public int GemiddeldeVerkoopprijs { get; set; }
    }
}
