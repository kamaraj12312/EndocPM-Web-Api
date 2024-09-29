using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{ 
    public class FamilyHealthHistory
    {
        public int FamilyHealthHistoryID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Nullable<int> AgeatDiagnosis { get; set; }
        public Nullable<int> AgeatDeath { get; set; }
        public string Disease { get; set; }
        public string Living { get; set; }
        public Nullable<int> PatientRelationID { get; set; }
        public string PersonName { get; set; }
        public string ClinicalNotes { get; set; }
        public Nullable<DateTime> RecordedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string Notes { get; set; }
        public Nullable<int> StatusCodeID { get; set; }
    }
}