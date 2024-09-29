using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class FacilityTreatmentCode
    {
        public int FacilityTreatmentCodeID { get; set; }
        public int FacilityID { get; set; }
        public int TreatmentCodeID { get; set; }
        public string CPTCode { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
