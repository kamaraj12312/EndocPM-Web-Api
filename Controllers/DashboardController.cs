using EndocPM.WebAPI.ViewModel.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DashboardController : Controller
    {
        public readonly IDashboardService _idashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _idashboardService = dashboardService;
        }


        [HttpGet]
        public PatientcountModel getyearcalledBYpatientcount(int year)
        {
            return this._idashboardService.getyearcalledBYpatientcount(year);
        }

        [HttpGet]
        public CountModel GetCount(SearchModel searchModel)
        {
            return this._idashboardService.GetCount(searchModel);
        }

        [HttpGet]
        public AppointmentDatemodel GetAppointmentfordate(DateTime date)
        {
            return this._idashboardService.GetAppointmentfordate(date);
        }

        [HttpGet]
        public List<PatientAppointmentModel> GetAllAppointment()
        {
            return this._idashboardService.GetAllAppointment();
        }

        [HttpGet]
        public List<Patient> getbypatientadultorchildren()
        {
            return this._idashboardService.getbypatientadultorchildren();
        }

        [HttpGet]
        public List<PatientAppointmentModel> GetAppointmentsForToday()
        {
            return this._idashboardService.GetAppointmentsForToday();
        }





    }
}
