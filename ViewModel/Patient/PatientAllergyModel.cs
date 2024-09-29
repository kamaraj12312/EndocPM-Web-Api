using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientAllergyModel
    {
        public PatientAllergyModel()
        {
           // this.RecordedDate = DateTime.UtcNow;
            this.IsActive = true;
        }

        #region Model Properties
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
        public string Notes { get; set; }
        public string AllergyDescription { get; set; }
        public string RxNormConceptID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string DeleteReason { get; set; }
        public string NotesSnomedCT { get; set; }
        public bool IsPrinted { get; set; }

        public Nullable<int> ExternalAllergyID { get; set; }

        #endregion

        #region Reference Properties

        public virtual PatientModel Patient { get; set; }
        //public virtual PatientEncounterModel PatientEncounter { get; set; }
        #endregion

        #region Custom Properties
        public string PatientAllergyTitle { get; set; }
        public string AllergyTypeDescription { get; set; }
        public string AllergySeverityDescription { get; set; }
        public string AllergyOnsetDescription { get; set; }
        public Nullable<int> PatientAllergyCaseSheetBack { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<int> StatusCodeID { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<int> SearchAllergyTypeID { get; set; }
        public string SearchAllergyName { get; set; }
        public string ReconcilationAllergyName { get; set; }
        public string OnSetDateString { get; set; }
        public string AllergyNameID { get; set; }
        public string AllergyRowID { get; set; }
        public string AllergyNameRowID { get; set; }
        public string AllergySubstanceRowID { get; set; }
        public string AllergyReactionRowID { get; set; }
        public string AllergyseverityNameID { get; set; }
        public string AllergyStatusRowID { get; set; }
        public int AllergyNameTableID { get; set; }
        public string AllergySubstanceName { get; set; }
        public string ErrMsg { get; set; }
        public int? SnomedCTID { get; set; }
        public string SnomedCTIDForMultiselect { get; set; }
        public string SnomedDescription { get; set; }

        public string AllergyObjectID { get; set; }
        public string AllergyCode { get; set; }
        public string IsSearch { get; set; }
        public string SearchAllergyStatusID { get; set; }
        public string PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string RxNormAtomID { get; set; }
        public string AtomID { get; set; }
        public string CDSMessage { get; set; }

        #endregion

        #region Paging Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        #endregion

        #region Custom Snomed Code
        public class CustomSnomedCodeModel
        {
            public Nullable<int> NotesArrayID { get; set; }
            public string SNOMEDCode { get; set; }
            public string NotesArrayDescription { get; set; }
        }
        #endregion
    }
}