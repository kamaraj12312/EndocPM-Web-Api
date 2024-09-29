using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class DrugCode
    {
        public DrugCode()
        {
            PatientMedications = new List<PatientMedication>();
        }

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
        public virtual ICollection<PatientMedication> PatientMedications { get; set; }
        //  public virtual ICollection<EPrescriptionDetail> EPrescriptionDetails { get; set; }
    }
}
