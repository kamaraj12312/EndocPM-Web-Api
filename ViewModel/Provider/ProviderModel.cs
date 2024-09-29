using EndocPM.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ProviderModel
    {
        public int ProviderID { get; set; }
        public string NPI { get; set; }
        public string TaxID { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string Credential { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<int> GenderID { get; set; }
        public string MedicareID { get; set; }
        public string UPIN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCounty { get; set; }
        public string BillingZIP { get; set; }
        public string BillingCountry { get; set; }
        public bool IsActive { get; set; }
        public bool SubscriptionFlag { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsSameAsMailingAddress { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> PreferredLanguageID { get; set; }
        public string MothersMaidenName { get; set; }
        public string MedicaidID { get; set; }
        public string WebsiteName { get; set; }
        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }
        public bool IsBillingForeign { get; set; }
        public int FeeScheduleToUse { get; set; }
        public Nullable<int> UserID { get; set; }
        public string FeeScheduleDescription { get; set; }
        public string ProviderSSN { get; set; }

     
        public Nullable<int> PrimaryFacilityID { get; set; }
        public string Biography { get; set; }
        public string DoximityURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedinURL { get; set; }

        //Foreign Address Implementation Properties
        public List<clsViewFile> ProviderPhoto { get; set; }
        public List<clsViewFile> ProviderSignature { get; set; }

        public List<ProviderInsuranceModel> providerInsuranceModels { get; set; }
        public List<ProviderLocationsModel> providerLocationsModels { get; set; }
        public List<ProviderStateLicenseModel> providerStateLicenseModels { get; set; }
        public List<ProviderVacationModel> providerVacationModels { get; set; }
        public List<ProviderAwardsAndRecognitionModel> providerAwardsandRecognitionModels { get; set; }
        public List<SchedulerSetupModel> schedulerSetupModels { get; set; }

        // Custom Properties

        public string Sex { get; set; }
        public string GenderDescription { get; set; }
        public string PrimaryFacilityName { get; set; }
        public string PrimaryFacilityDescription { get; set; }
        public string PreferredLanguageDescription { get; set; }
        public string PrimaryFacilityAddress { get; set; }
        public string LanguageDescription { get; set; }

    }
}