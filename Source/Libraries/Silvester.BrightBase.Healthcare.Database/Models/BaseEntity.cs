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
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateMeasured { get; set; }
    }
}
