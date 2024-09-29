
using System;

namespace EndocPM.WebAPI
{
    public class PatientDischargeInstructionAppointmentModel
    {

        public int PatientID { get; set; }
        public int ProviderID { get; set; }
        public int FacilityID { get; set; }
        public int PatientVisitID { get; set; }
        public int PatientAppointmentID { get; set; }
        public string PatientAppointmentDate { get; set; }
        public bool PatientTransactionIsPrinted { get; set; }
        public bool HasSummary { get; set; }
        public string ProviderName { get; set; }
        public string ProviderBillingAddress { get; set; }
        public string ProviderEmail { get; set; }
        public string ProviderBillingPhone { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public string VisitType { get; set; }








    }
    //public partial class PatientDischargeInstructionModel     //:IPager
    //{
    //    public PatientDischargeInstructionModel()
    //    {
    //        this.DischargeInstructionDate = DateTime.UtcNow;
    //    }
    //    #region Model Property
    //    public int PatientDischargeInstructionID { get; set; }
    //    public int PatientVisitID { get; set; }
    //    public int PatientTransaction { get; set; }
    //    public int FacilityID { get; set; }
    //    public Nullable<int> ProviderID { get; set; }
    //    public int PatientID { get; set; }
    //    public Nullable<int> AppointmentID { get; set; }
    //    public Nullable<int> EncounterID { get; set; }
    //    public Nullable<int> ClaimID { get; set; }
    //    public DateTime DischargeInstructionDate { get; set; }
    //    public string DischargeInstruction { get; set; }
    //    public string DietPlans { get; set; }
    //    public string CarePlanGoals { get; set; }
    //    public string CarePlanInstructions { get; set; }
    //    public string FunctionalStatus { get; set; }
    //    public string CognitiveStatus { get; set; }
    //    public int DischargeConditionID { get; set; }
    //    public int DischargeDispositionID { get; set; }
    //    public bool IsPrinted { get; set; }
    //    public Nullable<DateTime> PrintedOn { get; set; }
    //    public string ICDCode1 { get; set; }
    //    public string ICDCode2 { get; set; }
    //    public string ICDCode3 { get; set; }
    //    public string ICDCode4 { get; set; }
    //    public string ICDCode5 { get; set; }
    //    public string ICDCode6 { get; set; }
    //    public string ICDCode7 { get; set; }
    //    public string ICDCode8 { get; set; }
    //    public string ICDCode9 { get; set; }
    //    public string ICDCode10 { get; set; }
    //    public string ICDCode11 { get; set; }
    //    public string ICDCode12 { get; set; }
    //    public string PatientDecisionAids { get; set; }
    //    public bool Deleted { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public Nullable<DateTime> ModifiedDate { get; set; }
    //    public string ModifiedBy { get; set; }
    //    public Nullable<DateTime> AdmissionDate { get; set; }
    //    public Nullable<DateTime> DischargeDate { get; set; }

    //    #endregion

    //    #region Refereance Property

    //    public virtual PatientModel Patient { get; set; }
    //    public virtual ProviderModel Provider { get; set; }
    //    //   public virtual FacilityModel Facility { get; set; }

    //    #endregion

    //    #region Custom Property
    //    public string SelectedPatientVisitIDs { get; set; }
    //    public Nullable<DateTime> RecordedDate { get; set; }
    //    public string ProviderName { get; set; }
    //    public string PatientName { get; set; }
    //    public int SelectPatientID { get; set; }
    //    public int SelectedPatientID { get; set; }
    //    public string FacilityName { get; set; }
    //    public string DischargeInstructionStringDate { get; set; }
    //    public DateTime AppointmentDate { get; set; }
    //    public string PatientAppointmentDate { get; set; }
    //    public string PatientGenderDescription { get; set; }
    //    public string PatientEthnicityDescription { get; set; }
    //    public string PatientPreferredLanguage { get; set; }
    //    public string PatientRaceDescription { get; set; }
    //    public string PatientDateOfBirth { get; set; }
    //    public string ProviderBillingAddress { get; set; }
    //    public string ProviderEmail { get; set; }
    //    public string ProviderBillingPhone { get; set; }
    //    public string FacilityAddress { get; set; }
    //    public string NameLast { get; set; }
    //    public string NameFirst { get; set; }
    //    public string NameMiddle { get; set; }
    //    public string DischargeConditionDescription { get; set; }
    //    public string DischargeDispositionDescription { get; set; }
    //    public string PatientTransactionDateString { get; set; }
    //    public string PatientAllergyIdsString { get; set; }
    //    public string PatientMedicationIdsString { get; set; }
    //    public string PatientVitalSignIdsString { get; set; }
    //    public string PatientMedicalHistoryIdsString { get; set; }
    //    public string PatientImmunizationIdsString { get; set; }
    //    public string PatientSocialHistoryIdsString { get; set; }
    //    public string PatientTreatmentIdsString { get; set; }
    //    public string PatientFutureAppointmentIdsString { get; set; }
    //    public string PatientReferralIdsString { get; set; }
    //    public string PatientLabOrderTestIdsString { get; set; }
    //    public string PatientDiagnosticImagingIdsString { get; set; }
    //    public string PatientDiagnosisIdsString { get; set; }
    //    public string PatientTreatmentCodeFrom { get; set; }
    //    public string PatientDiagnosisCodeFrom { get; set; }
    //    public int IsExistingVisitedDateSelection { get; set; }
    //    public int DischargeInstructionPatientAppointmentID { get; set; }
    //    public string DischargeInstructionPatientVisitIDs { get; set; }
    //    public bool DischargeInstructionTransactionIsPrinted { get; set; }
    //    public bool DischargeSummaryIsPrinted { get; set; }
    //    public int RequestMode { get; set; }
    //    public string AppointmentDateFromTransitionOfCare { get; set; }
    //    public int PatientVisitIDForTransitionOfCare { get; set; }
    //    public int PatientAppointmentIDForTransitionOfCare { get; set; }
    //    public string ReferenceNumber { get; set; }
    //    public string DischargeDiagnosisTitle { get; set; }
    //    public int? SnomedCTIDForCognitiveStatus { get; set; }
    //    public string SnomedCTIDForCognitiveStatusMultiselect { get; set; }
    //    public int? SnomedCTIDForFunctionalStatus { get; set; }
    //    public string SnomedCTIDForFunctionalStatusMultiselect { get; set; }
    //    public int? SnomedCTIDForCarePlanGoals { get; set; }
    //    public string SnomedCTIDForCarePlanGoalsMultiselect { get; set; }
    //    public bool IsPrintReasonInHL7 { get; set; }
    //    public Nullable<int> DischargeSummaryStatusID { get; set; }
    //    public string DischargeSummaryStatus { get; set; }
    //    #endregion

    //    #region Title
    //    public string DischargeInstructionTitle { get; set; }
    //    public string CarePlanTitle { get; set; }
    //    public string PatientAllergyTitle { get; set; }
    //    public string PatientMedicationTitle { get; set; }
    //    public string PatientVitalSignTitle { get; set; }
    //    public string PatientTreatmentTitle { get; set; }
    //    public string PatientMedicalHistoryTitle { get; set; }
    //    public string PatientImmunizationTitle { get; set; }
    //    public string PatientSocialHistoryTitle { get; set; }

    //    #endregion
    //    #region Search Properties
    //    public int PageIndex { get; set; }
    //    public int PageSize { get; set; }
    //    public string SortBy { get; set; }
    //    public string SortOrder { get; set; }

    //    #endregion


    //}


}
