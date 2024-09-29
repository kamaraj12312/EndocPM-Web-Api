using System;

namespace EndocPM.WebAPI
{
    public class InsuranceFeeSchedule
    {
        public int InsuranceFeeScheduleID { get; set; }
        public int InsuranceID { get; set; }
        public string InsuranceCode { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public string ProcedureCode { get; set; }
        public string Modifiers { get; set; }
        public decimal Amount { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
