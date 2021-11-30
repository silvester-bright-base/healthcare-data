using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class Specialty
    {
        public string Versie { get; set; } = default!;
        public DateOnly DatumBestand { get; set; }
        public DateOnly PeilDatum { get; set; }
        public int SpecialismeCd { get; set; } 
        public string Omschrijving { get; set; } = default!;
    }
}
