using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Database.Models.Instances
{
    public class HealthcareActivitySummary : BaseEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int PatientAmount { get; set; }
        public int SubProcedureAmount { get; set; }
        public int ActivityAmount { get; set; }

        public int TreatingSpecialtyId { get; set; }
        public HealthcareSpecialty TreatingSpecialty { get; set; } = default!;

        public string TypicalDiagnosisId { get; set; } = default!;
        public HealthcareDiagnosis TypicalDiagnosis { get; set; } = default!;

        public int HealthcareProductId { get; set; }
        public HealthcareProduct HealthcareProduct { get; set; } = default!;

        public int HealthcareActivityId { get; set; }
        public HealthcareActivity HealthcareActivity { get; set; } = default!;

        public int HealthcareProfileClassId { get; set; }
        public HealthcareProfileClass HealthcareProfileClass { get; set; } = default!;
    }
}
