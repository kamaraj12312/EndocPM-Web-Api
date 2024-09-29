using System;

namespace EndocPM.WebAPI
{
    public class CommonMasterModel
    {
        public int CommonMasterID { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string HIPAACode { get; set; }
        public int DisplayOrder { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
