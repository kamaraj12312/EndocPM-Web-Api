using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class ImmunizationRegistryStatus
    {
        public int ImmunizationRegistryStatusID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
