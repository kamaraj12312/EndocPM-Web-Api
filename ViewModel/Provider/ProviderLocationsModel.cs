using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ProviderLocationsModel
    {
        public int ProviderLocationID { get; set; }
        public int ProviderID { get; set; }
        public int FacilityID { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string name { get; set; }
        public string namefile { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string TimeavailabilityStatus { get; set; }
        public int BookingPerDay { get; set; }
        public int BookingPerSlot { get; set; }
        public int TimeSlotDuration { get; set; }
        public string FacilityName { get; set; }
        public string RegularWorkHrsFrom { get; set; }
        public string RegularWorkHrsTo { get; set; }
        public List<ProviderLocationTimingModel> locationTimings { get; set; }
    }
}