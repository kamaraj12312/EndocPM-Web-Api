using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class SigCode
    {
        public SigCode()
        {
            this.EPrescriptionDetails = new List<EPrescriptionDetail>();
        }

        public int SigCodeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<EPrescriptionDetail> EPrescriptionDetails { get; set; }
    }
}
