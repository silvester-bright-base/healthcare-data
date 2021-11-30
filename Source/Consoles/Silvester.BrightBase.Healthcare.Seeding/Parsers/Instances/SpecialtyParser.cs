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
    public class SpecialtyParser : BaseParser<Specialty>
    {
        protected override Specialty Deserialize(string[] row)
        {
            return new Specialty
            {
                Versie = row[0],
                DatumBestand = DateOnly.Parse(row[1]),
                PeilDatum = DateOnly.Parse(row[2]),
                SpecialismeCd = int.Parse(row[3]),
                Omschrijving = row[4]
            };
        }
    }
}
