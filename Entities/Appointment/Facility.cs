using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class Facility
    {
        public int FacilityID { get; set; } 
        public Nullable<int> GroupFacilityID { get; set; }
        public string NPI { get; set; }
        public string TaxID { get; set; }
        public string FacilityName { get; set; }
        public string OtherName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int BillingLocation { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsForeign { get; set; }

    }
}
