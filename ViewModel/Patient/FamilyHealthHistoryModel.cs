using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class FamilyHealthHistoryModel
    {
        #region Model Properties
        public int FamilyHealthHistoryID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Nullable<int> AgeatDiagnosis { get; set; }
        public Nullable<int> AgeatDeath { get; set; }
        public string Disease { get; set; }
        public string Living { get; set; }
        public Nullable<int> PatientRelationID { get; set; }
        public string PatientRelation { get; set; }
        public string PersonName { get; set; }
        public string ClinicalNotes { get; set; }
        public Nullable<DateTime> RecordedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<int> StatusCodeID { get; set; }
        #endregion

        #region Custom Properties
        public string PatientHealthHistoryTitle { get; set; }
        public string PatientRelationShipDescription { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<int> FamilyHealthHistoryCaseSheetBack { get; set; }
        public string SearchPersonName { get; set; }
        public Nullable<int> SearchPatientRelationID { get; set; }
        public string IsSearch { get; set; }
        public string Notes { get; set; }
        public string SearchNotes { get; set; }
        public int? SnomedCTID { get; set; }
        public string SnomedCTIDForMultiselect { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<int> SearchStatusCodeID { get; set; }

        public string GenderDescription { get; set; }


        #endregion
    }
}