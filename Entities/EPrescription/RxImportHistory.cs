using System;

namespace EndocPM.WebAPI
{ 
    public class RxImportHistory
    {
        public RxImportHistory()
        {

        }
        public int RxImportHistoryID { get; set; }
        public string TransmissionStatus { get; set; }
        public Nullable<System.DateTime> IssuedDate { get; set; }
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        public string IssueType { get; set; }
        public string Prescriber { get; set; }
        public string DrugName { get; set; }
        public string SIG { get; set; }
        public string Quantity { get; set; }
        public string Refills { get; set; }
        public string RxStatusAuthorized { get; set; }
        public string DaysLeft { get; set; }
        public string RxType { get; set; }
        public string Person { get; set; }
        public string RxStatus { get; set; }
        public string RxObjid { get; set; }
        public string CreatedBy { get; set; }
        public string PatientAccount { get; set; }
        public string SupervisingPhysiciansDEA { get; set; }
        public string SupervisingPhysiciansNPI { get; set; }
        public string DrugID { get; set; }
        public string PharmacyID { get; set; }
        public string Diagnosis { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddressLine1 { get; set; }
        public string PharmacyAddressLine2 { get; set; }
        public string PharmacyCity { get; set; }
        public string PharmacyState { get; set; }
        public string PharmacyZip { get; set; }
        public string GenericCode { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> SupervisingProviderID { get; set; }
        public Nullable<int> RxNormConceptID { get; set; }
        public string RxNormCode { get; set; }
        public Nullable<int> NationalDrugCodeID { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool IsFormularyCheck { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        //  public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


    }
}
