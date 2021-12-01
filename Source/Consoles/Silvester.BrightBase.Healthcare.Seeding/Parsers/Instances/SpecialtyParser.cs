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
    public class SpecialtyParser : BaseParser<Specialty>
    {
        protected override Specialty Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new Specialty
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                SpecialismeCd = int.Parse(row[3]),
                Omschrijving = row[4]
            };
        }
    }
}
