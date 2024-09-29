using System;

namespace EndocPM.WebAPI
{
    public class ClaimAppeal
    {
        public int ClaimAppealID { get; set; }
        public int ClaimID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public string InsuranceCompanyName { get; set; }
        public int PatientID { get; set; }
        public string PatientSSN { get; set; }
        public string PatientNameLast { get; set; }
        public string PatientNameFirst { get; set; }
        public int PatientEncounterID { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string AppealStatus { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
      //  public virtual Claim Claim { get; set; }
      //  public virtual InsuranceCompany InsuranceCompany { get; set; }
       // public virtual PatientEncounter PatientEncounter { get; set; }
       // public virtual Patient Patient { get; set; }
    }
}
