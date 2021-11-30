using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class ProductSummaryMapper : BaseMapper<ProductSummary, HealthcareProductSummary>
    {
        protected override HealthcareProductSummary Map(ProductSummary source)
        {
            return new HealthcareProductSummary
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Year = source.Jaar,
                TreatingSpecialtyId = source.BehandelendSpecialismeCd,
                TypicalDiagnosisId = source.TyperendeDiagnoseCd,
                HealthcareProductId = source.ZorgproductCd,
                PatientAmountPerProduct = source.AantalPatPerZpd,
                SubProcedureAmountPerProduct = source.AantalSubtrajectPerZpd,
                PatientAmountPerDiagnosis = source.AantalPatPerDiag,
                SubProcedureAmountPerDiagnosis = source.AantalSubtrajectPerDiag,
                PatientAmountPerSpecialty = source.AantalPatPerSpc,
                SubProcedureAmountPerSpecialty = source.AantalSubtrajectPerSpc,
                AverageSalesPrice = source.GemiddeldeVerkoopprijs,
            };
        }
    }
}
