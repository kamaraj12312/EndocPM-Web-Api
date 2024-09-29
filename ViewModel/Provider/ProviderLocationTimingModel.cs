using System;

namespace EndocPM.WebAPI
{
    public class ProviderLocationTimingModel
    {
        public int ProviderLocationTimingID { get; set; }
        public int ProviderLocationID { get; set; }
        public int ProviderID { get; set; }
        public int TimeSlotDuration { get; set; }
        public int BookingPerSlot { get; set; }
        public int BookingPerDay { get; set; }
        public string AppointmentDay { get; set; }

        public bool AppointmentAllowed { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public Nullable<int> NoOfSlots { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string RegularWorkHrsFrom { get; set; }
        public string RegularWorkHrsTo { get; set; }
        public string BreakHrsFrom { get; set; }

        public string BreakHrsTo { get; set; }

        #region Custom Properties
        public int CommonMasterID { get; set; }
        public string Description { get; set; }
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BreakStartTime { get; set; }
        public string BreakEndTime { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool ProviderAvailable { get; set; }
        public bool IsFacilityOnHoliday { get; set; }
        public string ValueTime { get; set; }
        public string DisplayTime { get; set; }
        public bool IsUnscheduleTiming { get; set; }

        
        #endregion

    }

}

