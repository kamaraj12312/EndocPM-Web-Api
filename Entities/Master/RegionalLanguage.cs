using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public partial class RegionalLanguage
    {
        public int RegionalLanguageID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
