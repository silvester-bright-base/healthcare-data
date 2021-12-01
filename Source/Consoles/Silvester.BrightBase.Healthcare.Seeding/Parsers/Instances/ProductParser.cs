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
    public class ProductParser : BaseParser<Product>
    {
        protected override Product Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new Product
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                ZorgproductCd = int.Parse(row[3]),
                LatijnOms = row[4],
                ConsumentOms = row[5],
                DeclaratieVerzekerdCd = row[6],
                DeclaratieOnverzekerdCd = row[7]
            };
        }
    }
}
