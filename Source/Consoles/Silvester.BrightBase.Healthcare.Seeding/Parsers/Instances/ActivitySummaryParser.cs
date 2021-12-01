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
    public class ActivitySummaryParser : BaseParser<ActivitySummary>
    {
        protected override ActivitySummary Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new ActivitySummary
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                Jaar = int.Parse(row[3]),
                BehandelendSpecialismeCd = int.Parse(row[4]),
                TyperendeDiagnoseCd = row[5],
                ZorgproductCd = int.Parse(row[6]),
                ZorgActiviteitCd = int.Parse(row[7]),
                ZorgProfielKlasseCd = int.Parse(row[8]),
                AantalPat = int.Parse(row[9]),
                AantalSubtraject = int.Parse(row[10]),
                AantalZat = int.Parse(row[11])
            };
        }
    }
}
