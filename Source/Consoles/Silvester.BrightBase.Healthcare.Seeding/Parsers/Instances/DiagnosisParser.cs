using Microsoft.VisualBasic.FileIO;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using Silvester.BrightBase.Healthcare.Seeding.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances
{
    public class DiagnosisParser : BaseParser<Diagnosis>
    {
        protected override Diagnosis Deserialize(string[] row)
        {
            return new Diagnosis
            {
                Versie = row[0],
                DatumBestand = DateOnly.Parse(row[1]),
                PeilDatum = DateOnly.Parse(row[2]),
                DiagnoseCd = row[3],
                SpecialismeCd = int.Parse(row[4]),
                DiagnoseOmschrijving = row[5]
            };
        }
    }
}
