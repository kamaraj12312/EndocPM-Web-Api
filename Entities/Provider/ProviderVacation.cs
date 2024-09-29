using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ProviderVacation
    {
        public int ProviderVacationID { get; set; }
        public int ProviderID { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public string Reason { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}