using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public class AppointmentDatemodel
    {
        public List<PatientAppointmentModel> Newrequest { get; set; }

        public List<PatientAppointmentModel> Cancelled { get; set; }

        public List<PatientAppointmentModel> Reschedule { get; set; }

        public List<PatientAppointmentModel> Arrived { get; set; }
        public List<PatientAppointmentModel> Confirmed { get; set; }
        public List<PatientAppointmentModel> Deleted { get; set; }
        public List<PatientAppointmentModel> NotArrived { get; set; }
        public List<PatientAppointmentModel> WaitingList { get; set; }
    }
}
