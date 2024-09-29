using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class EPrescription
    {
        public EPrescription()
        {
            this.EPrescriptionDetails = new List<EPrescriptionDetail>();
        }

        public int EPrescriptionID { get; set; }
        public string EPrescriptionNumber { get; set; }
        public Nullable<DateTime> EPrescriptionDate { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PrescriberID { get; set; }
        public string PrescriberType { get; set; }
        public Nullable<int> PrescriptionStatusID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PrescriptionStatus PrescriptionStatus { get; set; }
        public virtual ICollection<EPrescriptionDetail> EPrescriptionDetails { get; set; }
        public Nullable<int> PharmacyID { get; set; }
    }
}
