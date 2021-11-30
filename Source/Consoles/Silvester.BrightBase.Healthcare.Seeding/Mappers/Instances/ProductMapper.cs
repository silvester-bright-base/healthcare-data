using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using Silvester.BrightBase.Healthcare.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Mappers.Instances
{
    public class ProductMapper : BaseMapper<Product, HealthcareProduct>
    {
        protected override HealthcareProduct Map(Product source)
        {
            return new HealthcareProduct
            {
                Version = source.Versie,
                DateCreated = source.DatumBestand,
                DateMeasured = source.PeilDatum,
                Id = source.ZorgproductCd,
                LatinDescription = source.LatijnOms,
                ConsumerDescription = source.ConsumentOms,
                InsuredClaimCode = source.DeclaratieVerzekerdCd,
                UninsuredClaimCode = source.DeclaratieOnverzekerdCd
            };
        }
    }
}
