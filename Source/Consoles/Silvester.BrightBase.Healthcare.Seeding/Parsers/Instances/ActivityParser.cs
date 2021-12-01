using Microsoft.VisualBasic.FileIO;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances
{
    public class ActivityParser : BaseParser<Activity>
    {
        protected override Activity Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new Activity
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                ZorgactiviteitCd = int.Parse(row[3]),
                Omschrijving = row[4],
                ZorgprofielKlasseCd = int.Parse(row[5]),
                ZorgprofielKlassOms = row[6]
            };
        }
    }
}
