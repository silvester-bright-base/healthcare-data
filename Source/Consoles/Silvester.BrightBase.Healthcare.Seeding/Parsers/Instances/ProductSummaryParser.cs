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
    public class ProductSummaryParser : BaseParser<ProductSummary>
    {
        protected override ProductSummary Deserialize(string[] row, DateTimeFormatInfo dateTimeFormat)
        {
            return new ProductSummary
            {
                Versie = row[0],
                DatumBestand = DateTimeOffset.Parse(row[1], dateTimeFormat),
                PeilDatum = DateTimeOffset.Parse(row[2], dateTimeFormat),
                Jaar = int.Parse(row[3]),
                BehandelendSpecialismeCd = int.Parse(row[4]),
                TyperendeDiagnoseCd = row[5],
                ZorgproductCd = int.Parse(row[6]),
                AantalPatPerZpd = int.Parse(row[7]),
                AantalSubtrajectPerZpd = int.Parse(row[8]),
                AantalPatPerDiag = int.Parse(row[9]),
                AantalSubtrajectPerDiag = int.Parse(row[10]),
                AantalPatPerSpc = int.Parse(row[11]),
                AantalSubtrajectPerSpc = int.Parse(row[12]),
                GemiddeldeVerkoopprijs = int.Parse(string.IsNullOrWhiteSpace(row[13]) ? "0" : row[13])
            };
        }
    }
}
