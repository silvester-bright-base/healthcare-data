using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class DiagnosisMapper : BaseMapper<Diagnosis, HealthcareDiagnosis>
    {
        protected override HealthcareDiagnosis Map(Diagnosis source)
        {
            return new HealthcareDiagnosis
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand.ToOffset(TimeSpan.Zero),
                DateMeasured = source.PeilDatum.ToOffset(TimeSpan.Zero),
                Id = source.DiagnoseCd,
                HealthcareSpecialtyId = source.SpecialismeCd,
                Description = source.DiagnoseOmschrijving
            };
        }
    }
}
