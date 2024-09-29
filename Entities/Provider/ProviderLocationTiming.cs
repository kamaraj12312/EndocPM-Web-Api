using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class ProviderLocationTiming
    {
        public int ProviderLocationTimingID { get; set; }
        public int ProviderLocationID { get; set; }
        public int TimeSlotDuration { get; set; }
        public int BookingPerSlot { get; set; }
        public int BookingPerDay { get; set; }
        public string AppointmentDay { get; set; }
        public bool AppointmentAllowed { get; set; }
        public string RegularWorkHrsFrom { get; set; }
        public string RegularWorkHrsTo { get; set; }

        public string  BreakHrsFrom { get; set; }

        public string BreakHrsTo { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public Nullable<int> NoOfSlots { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
