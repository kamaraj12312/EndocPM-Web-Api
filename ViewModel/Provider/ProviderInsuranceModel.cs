
using System;

namespace EndocPM.WebAPI
{
    public class ProviderInsuranceModel
    {
        #region Model Properties
        public int ProviderInsuranceID { get; set; }
        public int ProviderID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public string InsuranceID { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Nullable<int> InsurancePaymentTypeID { get; set; }
        public virtual Nullable<int> SpecialityID { get; set; }
        public string TaxonomyCode { get; set; }
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

        #endregion
                

        #region Custom Properties
        public string ProviderInsuranceTitle { get; set; }
        public string BillingAddressTitle { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string ProviderName { get; set; }

        public string InsurancePaymentTypeDescription { get; set; }
        public string OrganizationID { get; set; }
        public Nullable<int> InsuranceCategoryID { get; set; }
        public string InsuranceCategoryDescription { get; set; }
        public string TaxonomyDescription { get; set; }
        public string IsSearch { get; set; }

        #endregion

        #region Search Properties
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string SearchInsuranceCompanyName { get; set; }
        #endregion

    }
}
