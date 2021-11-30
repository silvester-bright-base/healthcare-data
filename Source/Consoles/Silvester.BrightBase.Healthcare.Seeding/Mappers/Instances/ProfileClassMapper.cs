using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class ProfileClassMapper : BaseMapper<Activity, HealthcareProfileClass>
    {
        protected override HealthcareProfileClass Map(Activity source)
        {
            return new HealthcareProfileClass
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Id = source.ZorgprofielKlasseCd,
                Description = source.ZorgprofielKlassOms
            };
        }
    }
}
