using Microsoft.VisualBasic.FileIO;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Parsers.Instances
{
    public class ActivityParser : BaseParser<Activity>
    {
        protected override Activity Deserialize(string[] row)
        {
            return new Activity
            {
                Versie = row[0],
                DatumBestand = DateOnly.Parse(row[1]),
                PeilDatum = DateOnly.Parse(row[2]),
                ZorgactiviteitCd = int.Parse(row[3]),
                Omschrijving = row[4],
                ZorgprofielKlasseCd = int.Parse(row[5]),
                ZorgprofielKlassOms = row[6]
            };
        }
    }
}
