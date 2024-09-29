﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class PatientProblemListModel
    {
        #region entity properties

        public int PatientProblemListID { get; set; }
        public int PatientID { get; set; }
        public DateTime RecordedDate { get; set; }
        public int StatusID { get; set; }
        public bool IsAdvancedDirective { get; set; }

        public string DiagnosisCode { get; set; }   
        public string SourceName { get; set; }
        public Nullable<DateTime> DiagnosedDate { get; set; }
        public Nullable<int> DocumentTypeID { get; set; }
        public string Description { get; set; }
        public string ClinicalNotes { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<clsViewFile> ProblemListFile { get; set; }

        #endregion

        #region custom properties
        
        public string DocumentTypeDescription { get; set; }
        public string StatusDescription { get; set; }

        #endregion
    }
}
