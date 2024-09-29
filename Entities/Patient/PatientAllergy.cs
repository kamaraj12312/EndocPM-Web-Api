using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientAllergy
    {
        public int PatientAllergyID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public DateTime RecordedDate { get; set; }
        public string AllergyName { get; set; }
        public Nullable<int> AllergyTypeID { get; set; }
        public Nullable<int> AllergySeverityID { get; set; }
        public string Reaction { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> AllergyOnsetID { get; set; }
        public Nullable<DateTime> OnSetDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Notes { get; set; }
        public string AllergyDescription { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string DeleteReason { get; set; }
        public bool IsPrinted { get; set; }
        public string AllergyObjectID { get; set; }
        public string AllergyCode { get; set; }
        public string NotesSnomedCT { get; set; }
        public string RxNormConceptID { get; set; }
        public string AllergyNameID { get; set; }
        public Nullable<int> ExternalAllergyID { get; set; }
    }
}