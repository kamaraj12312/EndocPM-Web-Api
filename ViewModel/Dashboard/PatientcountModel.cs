using EndocPM.WebAPI;
using System.Collections.Generic;

namespace EndocPM.WebAPI.ViewModel.Dashboard
{
    public class PatientcountModel
    {
        public int PatientTotalCount { get; set; }

        public int newPatientCount { get; set; }

        public int Patientactive { get; set; }

        public List<Patient> age { get; set; }

    }
}
