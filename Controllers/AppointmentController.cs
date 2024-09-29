using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        public readonly IAppointmentService _iAppointmentService;
        public AppointmentController(IAppointmentService iAppointmentService)
        {
            _iAppointmentService = iAppointmentService;
        }

        [HttpGet]
        public PatientAppointmentModel GetAppointmentByID(int patientAppointmentID)
        {
            return this._iAppointmentService.GetAppointmentByID(patientAppointmentID);
        }

        [HttpGet]
        public List<PatientAppointmentModel> GetAllAppointment()
        {
            return this._iAppointmentService.GetAllAppointment();
        }
        [HttpGet]
        public List<AppointmentStatusModel> GetAppointmentStatus()
        {
            return this._iAppointmentService.GetAppointmentStatus();
        }
        [HttpGet]
        public PatientVisitsModel GetPatientAppointmentByVisitID(int patientVisitID)
        {
            return this._iAppointmentService.GetPatientAppointmentByVisitID(patientVisitID);
        }

        [HttpGet]
        public PatientAppointmentHistoryModel GetPatientAppointmentHistoryByID(int patientAppointmentID)
        {
            return this._iAppointmentService.GetPatientAppointmentHistoryByID(patientAppointmentID);
        }
        [HttpGet]
        public List<PatientAppointmentModel> GetAppointmentsForToday()
        {
            return this._iAppointmentService.GetAppointmentsForToday();
        }
        [HttpGet]
        public List<CommonMasterModel> GetPatientAppointmentReason()
        {
            return this._iAppointmentService.GetPatientAppointmentReason();
        }
        [HttpGet]
        public List<CommonMasterModel> GetPatientAppointmentDuration()
        {
            return this._iAppointmentService.GetPatientAppointmentDuration();
        }
        [HttpGet]
        public PatientClinicalNotesModel GetPatientClinicalNotesByAppointmentID(int patientAppointmentID)
        {
            return this._iAppointmentService.GetPatientClinicalNotesByAppointmentID(patientAppointmentID);
        }

        [HttpGet]
        public List<CommonMasterModel> GetAppointmentMonthsRecurrence()
        {
            return this._iAppointmentService.GetAppointmentMonthsRecurrence();

        }
        [HttpGet]
        public List<CommonMasterModel> GetAppointmentWeekDaysRecurrence()
        {
            return this._iAppointmentService.GetAppointmentWeekDaysRecurrence();
        }

        public List<CommonMasterModel> GetAppointmentWeekRecurrence()
        {
            return this._iAppointmentService.GetAppointmentWeekRecurrence();
        }
        [HttpGet]
        public string GetAppointmentStatusDescriptionByCode(string appointmentStatusCode)
        {
            return this._iAppointmentService.GetAppointmentStatusDescriptionByCode(appointmentStatusCode);

        }
        [HttpGet]
        public PatientAppointmentModel GetLatestAppointmentDetailByPatientID(int patientID)
        {
            return this._iAppointmentService.GetLatestAppointmentDetailByPatientID(patientID);

        }

        [HttpGet]
        public IList<PatientDischargeInstructionAppointmentModel> GetPatientAppointmentDateByPatientID(int patientID)
        {
            return this._iAppointmentService.GetPatientAppointmentDateByPatientID(patientID);
        }

        [HttpGet]
        public List<AppointmentStatusModel> GetAppointmentStatusByStatusCodes(string appointmentStatusCode)
        {
            return this._iAppointmentService.GetAppointmentStatusByStatusCodes(appointmentStatusCode);
        }


        [HttpPost]
        public PatientAppointmentModel AddUpdatePatientAppointment(PatientAppointmentModel appointModel)
        {
            return this._iAppointmentService.AddUpdatePatientAppointment(appointModel);
        }

        [HttpGet]
        public List<ProviderModel> GetbyProviderName()
        {
            return this._iAppointmentService.GetbyProvidername();
        }

        [HttpGet]
        public List<PatientModel> GetPatientbySearchKey(String Searchkey)
        {
            return this._iAppointmentService.GetPatientbySearchKey(Searchkey);
        }

        [HttpPost]
        public List<PatientAppointmentModel> GetPatientAppointmentbySearchModel(SearchModel searchModel)
        {
            return this._iAppointmentService.GetPatientAppointmentbySearchModel(searchModel);
        }

        [HttpPost]
        public AvailabilityModel AvailabilityStatus(AvailabilityModel availModel)
        {
            return this._iAppointmentService.AvailabilityStatus(availModel);
        }

        [HttpGet]
        public List<PatientAppointmentModel> GetAppointmentsForCalendar(string viewMode, string date)
        {
            return this._iAppointmentService.GetAppointmentsForCalendar(viewMode, date);
        }

        [HttpGet]
        public List<DateTime> GetDatesForProvider(int ProviderId)
        {
            return this._iAppointmentService.GetDatesForProvider(ProviderId);
        }

        [HttpGet]
        public List<TimingModel> GetTimingsforAppointment(string AppointDate, int ProviderID, int facilityID)
        {
            return this._iAppointmentService.GetTimingsforAppointment(AppointDate, ProviderID, facilityID);
        }

        //[HttpGet]
        //public AppointmentStatus ConfirmAppointment(int AppointmentStatusID)
        //{
        //    return this._iAppointmentService.ConfirmAppointment(AppointmentStatusID);
        //}

        [HttpGet]
        public List<string> ConfirmAppointment(int PatientAppointmentID)
        {
            List<string> status = new List<string>();
            status.Add(this._iAppointmentService.ConfirmAppointment(PatientAppointmentID));
            return status;
        }

        [HttpGet]
        public List<string> CancelAppointment(int PatientAppointmentID)
        {
            List<string> status = new List<string>();
            status.Add(this._iAppointmentService.CancelAppointment(PatientAppointmentID));
            return status;
        }

      



    }
}
