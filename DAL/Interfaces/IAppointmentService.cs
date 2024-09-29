using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{    
    public interface IAppointmentService
    {

        PatientAppointmentModel AddUpdatePatientAppointment(PatientAppointmentModel appointModel);

        PatientAppointmentModel GetAppointmentByID(int patientAppointmentID);

        List<PatientAppointmentModel> GetAllAppointment();

        List<AppointmentStatusModel> GetAppointmentStatus();

        PatientVisitsModel GetPatientAppointmentByVisitID(int patientVisitID);

        PatientAppointmentHistoryModel GetPatientAppointmentHistoryByID(int patientAppointmentID);

        List<PatientAppointmentModel> GetAppointmentsForToday();
        List<CommonMasterModel> GetPatientAppointmentReason();
        List<CommonMasterModel> GetPatientAppointmentDuration();
        PatientClinicalNotesModel GetPatientClinicalNotesByAppointmentID(int patientAppointmentID);

        List<CommonMasterModel> GetAppointmentMonthsRecurrence();

        List<CommonMasterModel> GetAppointmentWeekDaysRecurrence();
        List<CommonMasterModel> GetAppointmentWeekRecurrence();
        string GetAppointmentStatusDescriptionByCode(string appointmentStatusCode);
        PatientAppointmentModel GetLatestAppointmentDetailByPatientID(int patientID);

        List<PatientDischargeInstructionAppointmentModel> GetPatientAppointmentDateByPatientID(int patientID);

        List<AppointmentStatusModel> GetAppointmentStatusByStatusCodes(string appointmentStatusCode);

        List<ProviderModel> GetbyProvidername();
        List<PatientModel> GetPatientbySearchKey(String Searchkey);
        List<PatientAppointmentModel> GetPatientAppointmentbySearchModel(SearchModel searchModel);
        AvailabilityModel AvailabilityStatus(AvailabilityModel availModel);
        List<PatientAppointmentModel> GetAppointmentsForCalendar(string viewMode, string date);
        List<DateTime> GetDatesForProvider(int ProviderId);
        List<TimingModel> GetTimingsforAppointment(string AppointDate, int ProviderID, int facilityID);
        // AppointmentStatus ConfirmAppointment(int AppointmentStatusID);
        string ConfirmAppointment(int PatientAppointmentID);
        string CancelAppointment(int PatientAppointmentID);

       







    }
}
