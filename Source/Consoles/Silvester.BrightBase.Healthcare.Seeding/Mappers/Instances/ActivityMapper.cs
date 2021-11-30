using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class ActivityMapper : BaseMapper<Activity, HealthcareActivity>
    {
        protected override HealthcareActivity Map(Activity source)
        {
            return new HealthcareActivity
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Id = source.ZorgactiviteitCd,
                Description = source.Omschrijving,
                HealthcareProfileClassId = source.ZorgprofielKlasseCd
            };
        }
    }
}
