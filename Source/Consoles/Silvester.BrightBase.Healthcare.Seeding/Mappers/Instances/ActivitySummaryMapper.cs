using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class ActivitySummaryMapper : BaseMapper<ActivitySummary, HealthcareActivitySummary>
    {
        protected override HealthcareActivitySummary Map(ActivitySummary source)
        {
            return new HealthcareActivitySummary
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Year = source.Jaar,
                TreatingSpecialtyId = source.BehandelendSpecialismeCd,
                TypicalDiagnosisId = source.TyperendeDiagnoseCd,
                HealthcareProductId = source.ZorgproductCd,
                HealthcareActivityId = source.ZorgActiviteitCd,
                HealthcareProfileClassId = source.ZorgProfielKlasseCd,
                PatientAmount = source.AantalPat,
                SubProcedureAmount = source.AantalSubtraject,
                ActivityAmount = source.AantalZat
            };
        }
    }
}
