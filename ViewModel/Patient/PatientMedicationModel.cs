using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientMedicationModel
    {
        public PatientMedicationModel()
        {
            StartedDate = DateTime.UtcNow;
          //  PrescribedDate = DateTime.UtcNow;
            RecordedTimeString = string.Format("{0:HH:mm}", DateTime.Now);
            ReconcilDate = DateTime.UtcNow;
          //  MedicatedDate = DateTime.UtcNow;
            MedicatedTimeString = string.Format("{0:HH:mm}", DateTime.Now);
            //CurrentStatus = 218;
        }

        #region Model Properties
        public int PatientMedicationID { get; set; }
        public int PatientID { get; set; }

        public DateTime RecordedDate { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public DateTime StartedDate { get; set; }
        public Nullable<int> DrugCodeID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> DispenseFormID { get; set; }
        public Nullable<decimal> Refill { get; set; }
        public Nullable<bool> AllowSubstitution { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string PatientInstructions { get; set; }
        public string DrugName { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public Nullable<DateTime> PrescribedDate { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string SubstitutionDrug { get; set; }
        public string SideEffects { get; set; }
        public string NotesToPharmacist { get; set; }
        public bool DispenseAsWritten { get; set; }
        public string Prescriber { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> CurrentStatus { get; set; }
        public string Sig { get; set; }
        public string RxObjectID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string DeleteReason { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<int> RxNormConceptID { get; set; }
        public string RxNormCode { get; set; }
        public Nullable<DateTime> RecordedTime { get; set; }
        public string RecordedTimeString { get; set; }
        public string MedicatedTimeString { get; set; }

        public string Units { get; set; }
        public Nullable<int> ScheduledTestStatusID { get; set; }
        public string ScheduledTestStatusDescription { get; set; }
        public string MedicationBarcode { get; set; }
        public Byte[] BarcodeImage { get; set; }
        public Nullable<int> MedicationRefusalReasonID { get; set; }
        public string MedicationRefusalReason { get; set; }
        public Nullable<int> MedicationOrderNotPerformedID { get; set; }
        public bool IsScheduled { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThan { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThanHrs { get; set; }
        public Nullable<int> NumberOfMessagesToSendPerPatient { get; set; }
        public Nullable<int> IntervalPerMessage { get; set; }
        public Nullable<int> IntervalBetweenMessagesTypeId { get; set; }
        public Nullable<int> ImmunizationRouteID { get; set; }
        //public virtual ImmunizationRouteModel ImmunizationRoute { get; set; }
        //public virtual MedicationOrderNotPerformedModel MedicationOrderNotPerformed { get; set; }
        //public virtual MedicationRefusalReasonModel MedicationRefusalReasonModel { get; set; }
        public Nullable<DateTime> MedicatedDate { get; set; }
        public Nullable<DateTime> MedicatedTime { get; set; }
        public string BarCodeImageUrl { get; set; }
        public string BarCodeDate { get; set; }
        public string DrugCodeForCDS { get; set; }

        public Nullable<int> ExternalMedicationID { get; set; }
      //  public string StatusDescription { get; set; }


        #region NewFields

        public Nullable<int> PrescribedDuringID { get; set; }
        public string PrescribedDuringName { get; set; }
        public string DiagnosisCode { get; set; }
        public string PrescriptionFor { get; set; }
        public Nullable<int> PrescriptionOrderTypeID { get; set; }
        public string PrescriptionOrderTypeName { get; set; }
        //public string DosageFormDescription
        //{ get; set; }


        #endregion
        #endregion

        #region Reference Property

        //public virtual DispenseFormModel DispenseForm { get; set; }
        //public virtual DrugCodeModel DrugCode { get; set; }
        public virtual PatientModel Patient { get; set; }
        //public virtual PatientEncounterModel PatientEncounter { get; set; }

        #endregion

        #region Customised Property
        public string EnteredThrough { get; set; }
        public string List { get; set; }
        public string CPOE { get; set; }
        public string ImmunizationRouteDescription { get; set; }
        public string PatientMedicationTitle { get; set; }
        public string DrugCodeDescription { get; set; }
        public string DispenseFormDescription { get; set; }
        public string DosageFormDescription { get; set; }
        public string CurrentStatusDescription { get; set; }
        public string MedicationOrderNotPerformedDescription { get; set; }
        public string MedicationRefusalReasonDescription { get; set; }
        public string MedicationOrderNotPerformedCode { get; set; }
        public string MedicationRefusalReasonCode { get; set; }
        public string MedicationRefusalReasonCodeAndDescription { get; set; }
        public Nullable<int> PatientMedicationCaseSheetBack { get; set; }
        public string ImmunizationRouteAbbriviation { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<int> StatusCodeID { get; set; }
        public string StatusDescription { get; set; }
        public int DrugCodeIDReconcilation { get; set; }
        public Nullable<int> NationalDrugCodeID { get; set; }
        public string NDCPackageCode { get; set; }
        public string IsSearch { get; set; }
        public string DispenseAsWrittenDescription { get; set; }
        public string RXNormSatNDCCode { get; set; }
        public string RXNormSatPackageDescription { get; set; }
        public int RxNormAtomID { get; set; }
        public string RxNormDescription { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string PatientMedicationBarCodeTitle { get; set; }
        public Nullable<DateTime> ReconcilDate { get; set; }
        public string ReminderInformationTitle { get; set; }
        public string IntervalBetweenMessagesTypeDescription { get; set; }
        public string Email { get; set; }
        public string PatientName { get; set; }
        public bool IsFormularyCheck { get; set; }

        public string ImportedBy { get; set; }
        public string CDSMessage { get; set; }

        #region PQRS Report properties
        public int MedicationListCount { get; set; }
        public int CPOEOrdersCount { get; set; }
        public int CPOEOrderedCount { get; set; }
        #endregion

        #endregion

        #region Search Property
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public Nullable<int> SearchDrugCodeID { get; set; }
        public string SearchDrugCodeDescription { get; set; }

        public string Frequency { get; set; }

        public string PackageDescription { get; set; }
        #endregion
    }
}