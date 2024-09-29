using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class InsuranceCompany
    {
        public int InsuranceCompanyID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationID { get; set; }
        public int InsuranceCategoryID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Telephone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTitle { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonWorkPhone { get; set; }
        public string ContactPersonFax { get; set; }
        public string ContactPersonEmail { get; set; }
        public string PrimaryTransmissionMode { get; set; }
        public string SecondaryTransmissionMode { get; set; }
        public string TertiaryTransmissionMode { get; set; }
        public string InsuredSignatureOnFile { get; set; }
        public string PhysicianSignatureOnFile { get; set; }
    }
}
