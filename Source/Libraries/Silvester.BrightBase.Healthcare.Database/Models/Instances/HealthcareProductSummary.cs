using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models.Instances
{
    public class HealthcareProductSummary : BaseEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int SubProcedureAmountPerProduct { get; set; }
        public int SubProcedureAmountPerDiagnosis { get; set; }
        public int SubProcedureAmountPerSpecialty { get; set; }
        public int PatientAmountPerProduct { get; set; }
        public int PatientAmountPerDiagnosis { get; set; }
        public int PatientAmountPerSpecialty { get; set; }
        public int AverageSalesPrice { get; set; }

        public int TreatingSpecialtyId { get; set; }
        public HealthcareSpecialty TreatingSpecialty { get; set; } = default!;

        public string TypicalDiagnosisId { get; set; } = default!;
        public HealthcareDiagnosis TypicalDiagnosis { get; set; } = default!;

        public int HealthcareProductId { get; set; }
        public HealthcareProduct HealthcareProduct { get; set; } = default!;
    }
}
