using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models.Instances
{
    public class HealthcareSpecialty : BaseEntity
    {
        public int Id { get; set; } 
        public string Description { get; set; } = default!;
    }
}
