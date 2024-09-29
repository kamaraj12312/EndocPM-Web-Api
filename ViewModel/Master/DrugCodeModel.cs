using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class DrugCodeModel
    {
        public DrugCodeModel()
        {
            PatientMedications = new List<PatientMedicationModel>();
        }
        #region Model Properties
        public int DrugCodeID { get; set; }
        public string NDCCode { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientMedicationModel> PatientMedications { get; set; }
        #endregion 

        #region Custom Properties
        public string DrugCodeTitle { get; set; }

        public string IsSearch { get; set; }
        public string CodeType { get; set; }
        public long AtomID { get; set; }

        #endregion

        #region Paging Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
    }
}
