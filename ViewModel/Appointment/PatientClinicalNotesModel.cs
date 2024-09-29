using System;

namespace EndocPM.WebAPI
{
    public partial class PatientClinicalNotesModel
    {
        public int PatientClinicalNotesID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientAppointmentID { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<DateTime> RecordedDate { get; set; }
        public string AssessmentNotes { get; set; }
        public string ProcedureNotes { get; set; }
        public bool IsNoBills { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual PatientModel Patient { get; set; }
        public Nullable<int> CancerRegistrySendStatus { get; set; }
        public bool SendCancerRegistry { get; set; }
        public string SubstanceSnomedCT { get; set; }
        public string SubstanceDescription { get; set; }


        #region Custom Properties
        public string FacilityName { get; set; }
        public string ProviderName { get; set; }
        public string PatientName { get; set; }
        public Nullable<DateTime> AppointmentDate { get; set; }
        public Nullable<DateTime> AssessmentDateFrom { get; set; }
        public Nullable<DateTime> AssessmentDateTo { get; set; }
        public string PatientClinicalNotesTitle { get; set; }
        public string IsSearch { get; set; }
        public string AssessmentSnomedCT { get; set; }
        public string ProcedureSnomedCT { get; set; }
        public bool CancerRegistryStatus { get; set; }
        public bool IsCancerInformationAvailable { get; set; }
        public Nullable<DateTime> VisitDate { get; set; }
        public string VisitDateString { get; set; }
        public string DiagnosisCode { get; set; }

        #endregion


        //#region Search Properities
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
        //public string SortBy { get; set; }
        //public string SortOrder { get; set; }

        //#endregion

        //public string SubjectiveNotes { get; set; }
        //public string ObjectiveNotes { get; set; }
        //public Nullable<int> RecordedDuringId { get; set; }
    
    }
}
