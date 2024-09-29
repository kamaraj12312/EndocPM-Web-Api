using System;

namespace EndocPM.WebAPI
{
    public class AvailabilityModel
    {
        public int ProviderId { get; set; }
        public int FacilityId { get; set; }
        public DateTime AppointDate { get; set; }
        public string availability { get; set; }
    }
}
