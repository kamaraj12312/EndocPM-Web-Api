using System;

namespace EndocPM.WebAPI
{
    public class PatientFamilyAddress
    {
        public int PatientFamilyAddressID { get; set; }
        public int PatientFamilyID { get; set; }
        public Nullable<int> AddressTypeID { get; set; }
        public bool ForeignAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public int AddressStatusID { get; set; }
        public string Telephone { get; set; }
        public string WorkPhone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
