using System;

namespace EndocPM.WebAPI
{
    public class Race
    {
        public int RaceID { get; set; }
        public string RaceCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> RaceOrder { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int ParentRaceID { get; set; }
    }
}
