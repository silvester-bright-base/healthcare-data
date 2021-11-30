using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class SpecialtyMapper : BaseMapper<Specialty, HealthcareSpecialty>
    {
        protected override HealthcareSpecialty Map(Specialty source)
        {
            return new HealthcareSpecialty
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Id = source.SpecialismeCd,
                Description = source.Omschrijving
            };
        }
    }
}
