using System;

namespace EndocPM.WebAPI
{
    public class PatientClinicalNotes
    {
        public int PatientClinicalNotesID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientAppointmentID { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<int> RecordedDuringId { get; set; }
        public Nullable<DateTime> RecordedDate { get; set; }
        public string AssessmentNotes { get; set; }
        public string SubjectiveNotes { get; set; }
        public string ObjectiveNotes { get; set; }
        public string ProcedureNotes { get; set; }
        public bool IsNoBills { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool SendCancerRegistry { get; set; }
        public virtual Patient Patient { get; set; }
        public string AssessmentSnomedCT { get; set; }
        public string ProcedureSnomedCT { get; set; }
        public string SubstanceSnomedCT { get; set; }
        public string SubstanceDescription { get; set; }
    }
}
