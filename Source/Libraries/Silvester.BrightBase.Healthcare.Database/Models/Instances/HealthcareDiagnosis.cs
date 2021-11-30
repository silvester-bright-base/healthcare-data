using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models.Instances
{
    public class HealthcareDiagnosis : BaseEntity
    {
        public string Id { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int HealthcareSpecialtyId { get; set; } = default!;
        public HealthcareSpecialty HealthcareSpecialty { get; set; } = default!;

        public ICollection<HealthcareProductSummary> ProductSummaries { get; set; } = new List<HealthcareProductSummary>();
        public ICollection<HealthcareActivitySummary> ActivitySummaries { get; set; } = new List<HealthcareActivitySummary>();
    }
}
