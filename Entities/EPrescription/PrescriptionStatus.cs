using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class PrescriptionStatus
    {
        public PrescriptionStatus()
        {
            this.EPrescriptions = new List<EPrescription>();
        }

        public int PrescriptionStatusID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<EPrescription> EPrescriptions { get; set; }
    }
}
