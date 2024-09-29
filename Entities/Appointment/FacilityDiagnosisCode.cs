using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class FacilityDiagnosisCode
    {
        public int FacilityDiagnosisCodeID { get; set; }
        public int FacilityID { get; set; }
        public int DiagnosisCodeID { get; set; }
        public string ICDCode { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
