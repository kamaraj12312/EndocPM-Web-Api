using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class PatientFamily
    {
        public int PatientFamilyID { get; set; }
        public int PatientID { get; set; }
        public string SSN { get; set; }
        public DateTime RecordedDate { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public int PatientRelationID { get; set; }
        public int GenderID { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<int> MaritalStatusID { get; set; }
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
        public bool IsEmergencyContact { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsGuarantor { get; set; }
        public bool IsForeign { get; set; }
    }
}
