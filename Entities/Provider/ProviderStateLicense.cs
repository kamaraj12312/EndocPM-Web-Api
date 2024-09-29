using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ProviderStateLicense
    {
        public int ProviderStateLicenseID { get; set; }
        public int ProviderID { get; set; }
        public string StateCode { get; set; }
        public string LicenseNumber { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}