using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientDiagnosticList
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
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsPrinted { get; set; }
    }
}