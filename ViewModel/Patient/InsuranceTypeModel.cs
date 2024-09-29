using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{ 
    public class InsuranceTypeModel
    {
        public InsuranceTypeModel()
        {
            // this.EncounterInsurances = new List<EncounterInsuranceModel>();
            this.PatientInsurances = new List<PatientInsuranceModel>();
            this.ProviderInsurances = new List<ProviderInsuranceModel>();
        }
        #region Model Properties
        public int InsuranceTypeID { get; set; }
        public string TypeDescription { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set;}
        #endregion
        #region ICollections
        // public virtual ICollection<EncounterInsuranceModel> EncounterInsurances { get; set; }
        public virtual ICollection<PatientInsuranceModel> PatientInsurances { get; set; }
        public virtual ICollection<ProviderInsuranceModel> ProviderInsurances { get; set; }
        #endregion
    }
}