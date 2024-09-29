using System;

namespace EndocPM.WebAPI
{
    public partial class PatientAppointmentHistoryModel
    {
        public int PatientAppointmentHistoryID { get; set; }
        public int PatientAppointmentID { get; set; }
        public string AppointmentStatusCode { get; set; }
        public string Comments { get; set; }
        public Nullable<DateTime> ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public virtual AppointmentStatusModel AppointmentStatu { get; set; }
        public virtual PatientAppointmentModel PatientAppointment { get; set; }
    }
}
