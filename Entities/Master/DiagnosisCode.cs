using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class DiagnosisCode
    {
        public int DiagnosisCodeID { get; set; }
        public string ICDCode { get; set; }
        public string CodeStatus { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string CodeType { get; set; }
        public string CodeSystem { get; set; }
    }
}
