using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class ActivitySummary
    {
        public string Versie { get; set; } = default!;
        public DateOnly DatumBestand { get; set; }
        public DateOnly PeilDatum { get; set; }
        public int Jaar { get; set; }
        public int BehandelendSpecialismeCd { get; set; } 
        public string TyperendeDiagnoseCd { get; set; } = default!;
        public int ZorgproductCd { get; set; }
        public int ZorgActiviteitCd { get; set; }
        public int ZorgProfielKlasseCd { get; set; }
        public int AantalPat { get; set; }
        public int AantalSubtraject { get; set; }
        public int AantalZat { get; set; }
    }
}
