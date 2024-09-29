using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientInsurance
    {
        public int PatientInsuranceID { get; set; }
        public int PatientID { get; set; }
        public bool SelfInsured { get; set; }
        public Nullable<int> InsuranceTypeID { get; set; }
        public string BillingMethodID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public Nullable<int> PatientRelationID { get; set; }
        public string SSN { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Copay { get; set; }
        public string SubscriberInsuredID { get; set; }
        public string PatientInsuredID { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public Nullable<DateTime> EligibilityRequestedDate { get; set; }
        public string EligibilityStatus { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsForeign { get; set; }
    }
}