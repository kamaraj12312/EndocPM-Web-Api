using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientImmunization
    {
        public int PatientImmunizationID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> VaccinationID { get; set; }
        public Nullable<int> ImmunizationID { get; set; }
        public Nullable<int> VaccinationManufacturerID { get; set; }
        public string ImmunizedAge { get; set; }
        public decimal Dose { get; set; }
        public string LotNumber { get; set; }
        public string Route { get; set; }
        public string HumanBodySite { get; set; }
        public Nullable<DateTime> InjectedOn { get; set; }
        public Nullable<DateTime> InjectedTime { get; set; }
        public string InjectedBy { get; set; }
        public string DoseUnits { get; set; }
        public Nullable<int> RemindBeforeDays { get; set; }
        public Nullable<int> RemindBeforeHours { get; set; }
        public string Notes { get; set; }
        public Nullable<DateTime> ExpirationDate { get; set; }
        public Nullable<int> ImmunizationRouteID { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public Nullable<int> HumanBodySiteID { get; set; }
        public string ImmunizationNotes { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<int> ImmunizationRegistryStatusID { get; set; }
        public Nullable<DateTime> RecordedDate { get; set; }
        public Nullable<int> ReviewedByID { get; set; }
        public string DiseasePresumedImmunity { get; set; }
        public Nullable<DateTime> RegistryStatusEffectiveDate { get; set; }
        public Nullable<int> PublicityCodeID { get; set; }
        public Nullable<DateTime> RegistryPublicityEffectiveDate { get; set; }
        public string NotesSnomedCT { get; set; }
        public Nullable<int> ImmunizationRegistrySentStatusID { get; set; }
        public Nullable<int> VFCFinancialClassID { get; set; }
        public Nullable<int> RefusalReasonCodeID { get; set; }
        public Nullable<int> ImmunizationInformationSourceID { get; set; }
        public bool ProtectionIndicator { get; set; }
        public Nullable<DateTime> ProtectionIndicatorEffective { get; set; }
        public Nullable<int> InjectedByID { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public Nullable<int> NumberOfMessagesToSendPerPatient { get; set; }
        public Nullable<int> IntervalPerMessage { get; set; }
        public Nullable<int> IntervalBetweenMessagesTypeId { get; set; }
        public Nullable<DateTime> ImmunizationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}