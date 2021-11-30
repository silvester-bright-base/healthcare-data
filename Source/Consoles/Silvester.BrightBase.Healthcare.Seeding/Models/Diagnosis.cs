using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Models
{
    public class Diagnosis 
    {
        public string Versie { get; set; } = default!;
        public DateOnly DatumBestand { get; set; }
        public DateOnly PeilDatum { get; set; }
        public string DiagnoseCd { get; set; } = default!;
        public int SpecialismeCd { get; set; } 
        public string DiagnoseOmschrijving { get; set; } = default!;
    }
}
