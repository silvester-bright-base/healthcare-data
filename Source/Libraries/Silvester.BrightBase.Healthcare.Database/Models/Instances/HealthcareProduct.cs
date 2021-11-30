using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models.Instances
{
    public class HealthcareProduct : BaseEntity
    {
        public int Id { get; set; }
        public string LatinDescription { get; set; } = default!;
        public string ConsumerDescription { get; set; } = default!;
        public string? InsuredClaimCode { get; set; }
        public string? UninsuredClaimCode { get; set; }
    }
}
