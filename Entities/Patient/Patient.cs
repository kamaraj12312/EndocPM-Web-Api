using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class Patient
    {
        public int PatientID { get; set; }
        public string PatientSSN { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<int> MaritalStatusID { get; set; }
        public int? RaceID { get; set; }
        public Nullable<int> EthnicityID { get; set; }
        public Nullable<int> LanguageID { get; set; }
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
        public string MailAddressLine1 { get; set; }
        public string MailAddressLine2 { get; set; }
        public string MailCity { get; set; }
        public string MailState { get; set; }
        public string MailCounty { get; set; }
        public string MailZIP { get; set; }
        public string MailCountry { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string PatientAccountNumber { get; set; }
        public Nullable<int> SalutationID { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string PassportNo { get; set; }
        public bool IsPhotoAvail { get; set; }
        public bool IsSameAsBillingAddress { get; set; }
        public Nullable<DateTime> DeathDate { get; set; }
        public string CauseOfDeath { get; set; }
        public Nullable<int> PreferredLanguageID { get; set; }        
        public string MothersMaidenNameLast { get; set; }
        public string MothersMaidenNameFirst { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string OtherLanguage { get; set; }
        public string OtherRace { get; set; }
        public string OtherEthnicity { get; set; }
        public string BloodTypeCode { get; set; }
        public Nullable<int> CommunicationPreferenceID { get; set; }
        public int SyndromicRecordSendStatus { get; set; }
        public string ADTType { get; set; }     
        public DateTime? AddressEffectiveDate { get; set; }
        public DateTime? AddressTermDate { get; set; }

        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }
        public bool MailIsForeign { get; set; }
    }
}
