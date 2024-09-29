namespace EndocPM.WebAPI
{
    public class PatientVisitsModel
    {
        public int PatientAppointmentID { get; set; }
        public string Description { get; set; }

        public string PatientVisitNotes { get; set; }

        public string PatientAppointmentNotes { get; set; }

        public string ChiefCompliantNotes { get; set; }
    }
}
