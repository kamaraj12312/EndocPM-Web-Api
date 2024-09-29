using System;

namespace EndocPM.WebAPI
{
    public class PharmacyModel
    {
        #region Model Properties
        public int PharmacyID { get; set; }
        public string NPI { get; set; }
        public string PharmacyName { get; set; }
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
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
        #region Custom Property

        public string Address { get; set; }
        #endregion
    }
}
