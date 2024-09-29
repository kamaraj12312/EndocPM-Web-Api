﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class DocumentType
    {

        public DocumentType()
        {
            //   this.PatientDocuments = new List<PatientDocument>();
        }


        #region Model Properities
        public int DocumentTypeID { get; set; }
        public string DocumentTypeCode { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


        #endregion


        #region Reference Properities
        //  public virtual ICollection<PatientDocument> PatientDocuments { get; set; }


        #endregion
    }
}
