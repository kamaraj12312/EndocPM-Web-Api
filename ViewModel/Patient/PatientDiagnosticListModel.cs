using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientDiagnosticListModel
    {
        public int PatientDiagnosticListID { get; set; }
        public int PatientID { get; set; }

        public DateTime RecordedDate { get; set; }
        public string ICDCode1 { get; set; }
        public string ICDCode2 { get; set; }
        public string ICDCode3 { get; set; }
        public string ICDCode4 { get; set; }
        public string ICDCode5 { get; set; }
        public string ICDCode6 { get; set; }
        public string ICDCode7 { get; set; }
        public string ICDCode8 { get; set; }
        public string ICDCode9 { get; set; }
        public string ICDCode10 { get; set; }
        public string ICDCode11 { get; set; }
        public string ICDCode12 { get; set; }
        public Nullable<DateTime> ServiceDate { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #region Custom Properties
        public string PatientDiagnosticListTitle { get; set; }
        public string ICDCode1Description { get; set; }
        public string ICDCode2Description { get; set; }
        public string ICDCode3Description { get; set; }
        public string ICDCode4Description { get; set; }
        public string ICDCode5Description { get; set; }
        public string ICDCode6Description { get; set; }
        public string ICDCode7Description { get; set; }
        public string ICDCode8Description { get; set; }
        public string ICDCode9Description { get; set; }
        public string ICDCode10Description { get; set; }
        public string ICDCode11Description { get; set; }
        public string ICDCode12Description { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string ICDCodes { get; set; }
        public string ICDCodeTitle { get; set; }
        public string CPTCodes { get; set; }

        #endregion
        #region Page Properties

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
        public bool IsPrinted { get; set; }
    }
}