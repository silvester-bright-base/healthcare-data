using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class Activity
    {
        public string Versie { get; set; } = default!;
        public DateOnly DatumBestand { get; set; }
        public DateOnly PeilDatum { get; set; }
        public int ZorgactiviteitCd { get; set; }
        public string Omschrijving { get; set; } = default!;
        public int ZorgprofielKlasseCd { get; set; }
        public string ZorgprofielKlassOms { get; set; } = default!;
    }
}
