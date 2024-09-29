using System;

namespace EndocPM.WebAPI
{
    public class FeeSchedule
    {
        public int FeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public string CodeQualifier { get; set; }
        public string FeeScheduleStatus { get; set; }
        public string StateCode { get; set; }
        public string Locality { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
