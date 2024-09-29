using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public partial class Ethnicity
    {
        public int EthnicityID { get; set; }
        public string EthnicityCode { get; set; }
        public string Description { get; set; }
        public int? EthnicityOrder { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int ParentEthnicityID { get; set; }
    }
}
