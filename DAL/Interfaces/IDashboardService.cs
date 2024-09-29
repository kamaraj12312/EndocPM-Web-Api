using System;
using System.Collections.Generic;
using EndocPM.WebAPI.ViewModel.Dashboard;

namespace EndocPM.WebAPI
{
    public interface IDashboardService
    {
        PatientcountModel getyearcalledBYpatientcount(int year);

        CountModel GetCount(SearchModel searchModel);

        AppointmentDatemodel GetAppointmentfordate(DateTime date);

        List<PatientAppointmentModel> GetAllAppointment();

        List<Patient> getbypatientadultorchildren();

        List<PatientAppointmentModel> GetAppointmentsForToday();

    }
}
