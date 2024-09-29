using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class ProviderAwardsAndRecognition
    {
        public int ProviderAwardsAndRecognitionID { get; set; }
        public int ProviderID { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> DateFrom { get; set; }
        public string RecognizedBy { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
