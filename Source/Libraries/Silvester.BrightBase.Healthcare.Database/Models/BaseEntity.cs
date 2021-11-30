using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models
{
    public class BaseEntity
    {
        public string Version { get; set; } = default!;
        public DateTime DateCreated { get; set; }
        public DateTime DateMeasured { get; set; }
    }
}
