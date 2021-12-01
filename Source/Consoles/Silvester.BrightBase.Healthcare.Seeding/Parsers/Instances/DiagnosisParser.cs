using Microsoft.VisualBasic.FileIO;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using Silvester.BrightBase.Healthcare.Seeding.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances
{
    public class DiagnosisParser : BaseParser<Diagnosis>
    {
        protected override Diagnosis Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new Diagnosis
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                DiagnoseCd = row[3],
                SpecialismeCd = int.Parse(row[4]),
                DiagnoseOmschrijving = row[5]
            };
        }
    }
}
