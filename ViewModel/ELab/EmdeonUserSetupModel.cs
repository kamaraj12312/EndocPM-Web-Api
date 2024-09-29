using System;

namespace EndocPM.WebAPI
{
    public class EmdeonUserSetupModel
    {
        public int EmdeonUserSetupID { get; set; }
        public string EmdeonUserName { get; set; }
        public string EmdeonPassword { get; set; }
        public string BmsUserID { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
