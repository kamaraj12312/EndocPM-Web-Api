using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data.Entity.Core.Mapping;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class AppointmentService : IAppointmentService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _MasterService;

        //public string ConnectionString = ConfigurationManager.ConnectionStrings["EndocDataContext"].ConnectionString;
        public AppointmentService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService masterService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _MasterService = masterService;
        }


        public PatientAppointmentModel AddUpdatePatientAppointment(PatientAppointmentModel appointModel)
        {
            var patient = (from pa in this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.PatientAppointmentID == appointModel.PatientAppointmentID)

                           select pa).FirstOrDefault();

            if (patient == null)
            {
                patient = new PatientAppointment();

                patient.PatientID = appointModel.PatientID;
                patient.FacilityID = appointModel.FacilityID;
                patient.ProviderID = appointModel.ProviderID;
                patient.AppointmentDate = this._MasterService.GetLocalTime(appointModel.AppointmentDate);
                patient.AppointmentStatusCode = appointModel.AppointmentStatusCode;
                patient.OtherAppointmentType = appointModel.OtherAppointmentType;
                patient.IsRecurrence = appointModel.IsRecurrence;
                patient.IsReminder = appointModel.IsReminder;
                patient.IsWaiting = appointModel.IsWaiting;
                patient.IntervalBetweenMessagesTypeId = appointModel.IntervalBetweenMessagesTypeId;
                patient.VisitTypeID = appointModel.VisitTypeID;
                patient.StartTime = this._MasterService.GetLocalTime(appointModel.StartTime);
                patient.EndTime = this._MasterService.GetLocalTime(appointModel.EndTime);
                patient.Duration = appointModel.Duration;
                patient.SlotNumber = appointModel.SlotNumber;
                patient.Description = appointModel.Description;
                patient.ParentAppointID = appointModel.ParentAppointID;
                patient.RecurrenceRule = appointModel.RecurrenceRule;
                patient.RecurrenceException = appointModel.RecurrenceException;
                patient.StartTimezone = appointModel.StartTimezone;
                patient.EndTimezone = appointModel.EndTimezone;
                patient.IsWaiting = appointModel.IsWaiting;
                patient.PatientVisitID = appointModel.PatientVisitID;
                patient.RemindBeforeDays = appointModel.RemindBeforeDays;
                patient.RemindBeforeHours = appointModel.RemindBeforeHours;
                patient.NumberOfMessagesToSendPerPatient = appointModel.NumberOfMessagesToSendPerPatient;
                patient.IntervalPerMessage = appointModel.IntervalPerMessage;
                patient.IntervalBetweenMessagesTypeId = appointModel.IntervalBetweenMessagesTypeId;
                patient.IsSuperBillGenerated = appointModel.IsSuperBillGenerated;
                patient.ShowInGrid = appointModel.ShowInGrid;
                patient.OtherAppointmentType = appointModel.OtherAppointmentType;
                patient.IsPrinted = appointModel.IsPrinted;
                patient.IsMobileRequest = appointModel.IsMobileRequest;
                patient.IsUnScheduledAppointment = appointModel.IsUnScheduledAppointment;
                patient.AppointmentTypeId = appointModel.AppointmentTypeId;
                patient.ConsultationTypeID = appointModel.ConsultationTypeID;
                patient.EndAfter = appointModel.EndAfter;
                patient.EndOnDate = appointModel.EndOnDate != null ? this._MasterService.GetLocalTime(appointModel.EndOnDate.Value): appointModel.EndOnDate;
                patient.RepeatID = appointModel.RepeatID;
                patient.RepeatDaysInterval = appointModel.RepeatDaysInterval;
                patient.Notes = appointModel.Notes;
                patient.Deleted = false;
                patient.CreatedDate = DateTime.Now;
                patient.CreatedBy = "User";

                this._uow.GenericRepository<PatientAppointment>().Insert(patient);
            }
            else
            {

                patient.PatientID = appointModel.PatientID;
                patient.FacilityID = appointModel.FacilityID;
                patient.AppointmentDate = this._MasterService.GetLocalTime(appointModel.AppointmentDate);
                patient.AppointmentStatusCode = appointModel.AppointmentStatusCode;
                patient.OtherAppointmentType = appointModel.OtherAppointmentType;
                patient.IsRecurrence = appointModel.IsRecurrence;
                patient.IsReminder = appointModel.IsReminder;
                patient.IsWaiting = appointModel.IsWaiting;
                patient.IntervalBetweenMessagesTypeId = appointModel.IntervalBetweenMessagesTypeId;
                patient.VisitTypeID = appointModel.VisitTypeID;
                patient.StartTime = this._MasterService.GetLocalTime(appointModel.StartTime);
                patient.EndTime = this._MasterService.GetLocalTime(appointModel.EndTime);
                patient.Duration = appointModel.Duration;
                patient.SlotNumber = appointModel.SlotNumber;
                patient.Description = appointModel.Description;
                patient.ParentAppointID = appointModel.ParentAppointID;
                patient.RecurrenceRule = appointModel.RecurrenceRule;
                patient.RecurrenceException = appointModel.RecurrenceException;
                patient.StartTimezone = appointModel.StartTimezone;
                patient.EndTimezone = appointModel.EndTimezone;
                patient.IsWaiting = appointModel.IsWaiting;
                patient.PatientVisitID = appointModel.PatientVisitID;
                patient.RemindBeforeDays = appointModel.RemindBeforeDays;
                patient.RemindBeforeHours = appointModel.RemindBeforeHours;
                patient.NumberOfMessagesToSendPerPatient = appointModel.NumberOfMessagesToSendPerPatient;
                patient.IntervalPerMessage = appointModel.IntervalPerMessage;
                patient.IntervalBetweenMessagesTypeId = appointModel.IntervalBetweenMessagesTypeId;
                patient.IsSuperBillGenerated = appointModel.IsSuperBillGenerated;
                patient.ShowInGrid = appointModel.ShowInGrid;
                patient.OtherAppointmentType = appointModel.OtherAppointmentType;
                patient.IsPrinted = appointModel.IsPrinted;
                patient.IsMobileRequest = appointModel.IsMobileRequest;
                patient.IsUnScheduledAppointment = appointModel.IsUnScheduledAppointment;
                patient.AppointmentTypeId = appointModel.AppointmentTypeId;
                patient.ConsultationTypeID = appointModel.ConsultationTypeID;
                patient.EndAfter = appointModel.EndAfter;
                patient.EndOnDate = appointModel.EndOnDate != null ? this._MasterService.GetLocalTime(appointModel.EndOnDate.Value) : appointModel.EndOnDate;
                patient.RepeatID = appointModel.RepeatID;
                patient.RepeatDaysInterval = appointModel.RepeatDaysInterval;
                patient.Notes = appointModel.Notes;
                patient.Deleted = false;
                patient.ModifiedDate = DateTime.Now;
                patient.ModifiedBy = "Hari";

                this._uow.GenericRepository<PatientAppointment>().Update(patient);
            }
            this._uow.Save();
            appointModel.PatientID = patient.PatientID;
            return appointModel;

        }

        public int GetIntervaltime(int repeatID)
        {
            int intervalTime = 0;

            var time = this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Category.ToLower().Trim() == "repeat" & x.CommonMasterID == repeatID).FirstOrDefault();
            

            if (time != null)
            {
                if(time.Description.ToLower().Trim() == "never")
                {
                    intervalTime = 0;
                } 
                if(time.Description.ToLower().Trim() == "daily")
                {
                    intervalTime = 1;
                } 
                if(time.Description.ToLower().Trim() == "weekly")
                {
                    intervalTime = 7;
                } 
                if(time.Description.ToLower().Trim() == "monthly")
                {
                    intervalTime = 30;
                } 
                if(time.Description.ToLower().Trim() == "yearly")
                {
                    intervalTime = 365;
                } 
                if(time.Description.ToLower().Trim() == "after 6 months")
                {
                    intervalTime = 180;
                } 
                if(time.Description.ToLower().Trim() == "after 2 weeks")
                {
                    intervalTime = 14;
                } 
                if(time.Description.ToLower().Trim() == "after 2 months")
                {
                    intervalTime = 60;
                } 
                if(time.Description.ToLower().Trim() == "after 3 months")
                {
                    intervalTime = 90;
                }
            }
            
            return intervalTime;
        }

        #region GetAppointment
        public PatientAppointmentModel GetAppointmentByID(int patientAppointmentID)
        {
            PatientAppointmentModel patientAppointmentModel = new PatientAppointmentModel();

            if (patientAppointmentID == 0)
                return null;

            var query = (from pa in this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.PatientAppointmentID == patientAppointmentID)

                         join ast in this._uow.GenericRepository<AppointmentStatus>().Table() on pa.AppointmentStatusCode equals ast.Code

                         join p in this._uow.GenericRepository<Patient>().Table() on pa.PatientID equals p.PatientID

                         join f in this._uow.GenericRepository<Facility>().Table() on pa.FacilityID equals f.FacilityID
                         join pr in this._uow.GenericRepository<Provider>().Table() on pa.ProviderID equals pr.ProviderID

                         join vt in this._uow.GenericRepository<VisitType>().Table() on pa.VisitTypeID equals vt.VisitTypeID into g
                         from a in g.DefaultIfEmpty()

                         join pv in this._uow.GenericRepository<PatientVisit>().Table() on pa.PatientVisitID equals pv.PatientVisitID into encounterVisitJoin
                         from pv in encounterVisitJoin.DefaultIfEmpty()

                         join cm in this._uow.GenericRepository<CommonMaster>().Table() on pa.IntervalBetweenMessagesTypeId equals cm.CommonMasterID into commonGroup
                         from cg in commonGroup.DefaultIfEmpty()


                         join com in this._uow.GenericRepository<CommonMaster>().Table() on p.GenderID equals com.CommonMasterID into commonJoin
                         from com in commonJoin.DefaultIfEmpty()

                         select new
                         {
                             PatientAppointmentID = pa.PatientAppointmentID,
                             PatientID = pa.PatientID,
                             PatientName = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             AlternatePhonePanelDisplay = p.AlternatePhone,
                             PhonePanelDisplay = p.Phone,
                             Phone = p.Phone,
                             AlternatePhone = p.AlternatePhone,
                             PatientPanelDisplay = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             Email = p.Email,
                             GenderID = p.GenderID.Value,
                             AddressLine1 = p.AddressLine1,
                             AddressLine2 = p.AddressLine2,
                             LastName = p.NameLast,
                             FirstName = p.NameFirst,
                             ZIP = p.ZIP,
                             DateOfBirth = p.BirthDate.Value,
                             PatientAccountNumber = p.PatientAccountNumber,
                             MedicalRecordNumber = p.MedicalRecordNumber,
                             FacilityID = pa.FacilityID,
                             FacilityName = f.FacilityName,
                             ProviderID = pa.ProviderID,
                             ProviderName = pr.NameFirst + " " + pr.NameLast,
                             AppointmentDate = pa.AppointmentDate,
                             VisitTypeID = pa.VisitTypeID,
                             VisitTypeDescription = a.Description,
                             StartTime = pa.StartTime,
                             EndTime = pa.EndTime,
                             Duration = pa.Duration,
                             SlotNumber = pa.SlotNumber,
                             AppointmentStatusCode = pa.AppointmentStatusCode,
                             AppointmentStatus = ast.Description,
                             Description = pa.Description,
                             OtherAppointmentType = pa.OtherAppointmentType,
                             IsWaiting = pa.IsWaiting,
                             Deleted = pa.Deleted,
                             CreatedDate = pa.CreatedDate,
                             CreatedBy = pa.CreatedBy,
                             ModifiedDate = pa.ModifiedDate,
                             ModifiedBy = pa.ModifiedBy,
                             IsRecurrence = pa.IsRecurrence,
                             RecurrenceRule = pa.RecurrenceRule,
                             IsReminder = pa.IsReminder,
                             pa.RemindBeforeDays,
                             pa.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = pa.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = pa.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = pa.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = cg.Description,
                             IsSuperBillGenerated = pa.IsSuperBillGenerated,
                             PatientVisitID = pa.PatientVisitID,
                             PatientTransactionDate = pv.VisitDate,
                             VisitTime = pv.VisitTime,
                             AppointmentTypeId = pa.AppointmentTypeId,
                             EndAfter = pa.EndAfter,
                             EndOnDate = pa.EndOnDate,
                             RepeatID = pa.RepeatID,
                             RepeatDaysInterval = pa.RepeatDaysInterval,
                             Notes = pa.Notes,
                             ConsultationTypeID = pa.ConsultationTypeID


                         }).AsEnumerable().Select(PAM => new PatientAppointmentModel
                         {
                             PatientAppointmentID = PAM.PatientAppointmentID,
                             PatientID = PAM.PatientID,
                             PatientName = PAM.LastName + ", " + PAM.FirstName,
                             AlternatePhonePanelDisplay = PAM.AlternatePhone,
                             PhonePanelDisplay = PAM.Phone,
                             Phone = PAM.Phone,
                             AlternatePhone = PAM.AlternatePhone,
                             PatientPanelDisplay = PAM.LastName + ", " + PAM.FirstName,
                             Email = PAM.Email,
                             GenderID = PAM.GenderID,
                             GenderDescription = PAM.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.GenderID).FirstOrDefault().Description : "",
                             AddressLine1 = PAM.AddressLine1,
                             AddressLine2 = PAM.AddressLine2,
                             LastName = PAM.LastName,
                             FirstName = PAM.FirstName,
                             ZIP = PAM.ZIP,
                             DateOfBirth = PAM.DateOfBirth,
                             PatientAccountNumber = PAM.PatientAccountNumber,
                             MedicalRecordNumber = PAM.MedicalRecordNumber,
                             FacilityID = PAM.FacilityID,
                             FacilityName = PAM.FacilityName,
                             ProviderID = PAM.ProviderID,
                             ProviderName = PAM.LastName + " " + PAM.FirstName,
                             AppointmentDate = PAM.AppointmentDate,
                             VisitTypeID = PAM.VisitTypeID,
                             VisitTypeDescription = PAM.Description,
                             StartTime = PAM.AppointmentDate,
                             EndTime = (PAM.Duration != 0 && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
                             Duration = PAM.Duration,
                             SlotNumber = PAM.SlotNumber,
                             AppointmentStatusCode = PAM.AppointmentStatusCode,
                             AppointmentStatus = PAM.AppointmentStatus,
                             Description = PAM.Description,
                             OtherAppointmentType = PAM.OtherAppointmentType,
                             IsWaiting = PAM.IsWaiting,
                             Deleted = PAM.Deleted,
                             CreatedDate = PAM.CreatedDate,
                             CreatedBy = PAM.CreatedBy,
                             ModifiedDate = PAM.ModifiedDate,
                             ModifiedBy = PAM.ModifiedBy,
                             IsRecurrence = PAM.IsRecurrence,
                             RecurrenceRule = PAM.RecurrenceRule,
                             IsReminder = PAM.IsReminder,
                             RemindBeforeDays = PAM.RemindBeforeDays,
                             RemindBeforeHours = PAM.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = PAM.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = PAM.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = PAM.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = PAM.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                             IsSuperBillGenerated = PAM.IsSuperBillGenerated,
                             AppointmentTypeId = PAM.AppointmentTypeId,
                             AppointmentTypeDescription = PAM.AppointmentTypeId > 0 ? this._uow.GenericRepository<AppointmentType>().Table().Where(x => x.AppointmentTypeId == PAM.AppointmentTypeId).FirstOrDefault().AppointmentTypeDescription : "",
                             EndAfter = PAM.EndAfter,
                             EndOnDate = PAM.EndOnDate,
                             RepeatID = PAM.RepeatID,
                             RepeatDescription = PAM.RepeatID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.RepeatID).FirstOrDefault().Description : "",
                             RepeatDaysInterval = PAM.RepeatDaysInterval,
                             Notes = PAM.Notes,
                             ConsultationTypeID = PAM.ConsultationTypeID,
                             ConsultationTypeDescription = PAM.ConsultationTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.ConsultationTypeID).FirstOrDefault().Description : ""

                         }).ToList();


            if (query != null)
            {
                patientAppointmentModel = query.FirstOrDefault();
                ////  PatientAppointmentModel.PatientTransactionDateString = String.Format("{0:MM/dd/yyyy}", patientAppointmentModel.PatientTransactionDate) + " " + String.Format("{0:HH:mm }", patientAppointmentModel.VisitTime);
                return patientAppointmentModel;
            }
            return null;
        }
        #endregion

        #region GetPatientAppointments
        public List<PatientAppointmentModel> GetAllAppointment()
        {
            PatientAppointmentModel patientAppointmentModel = new PatientAppointmentModel();


            var query = (from pa in this._uow.GenericRepository<PatientAppointment>().Table()

                         join ast in this._uow.GenericRepository<AppointmentStatus>().Table() on pa.AppointmentStatusCode equals ast.Code

                         join p in this._uow.GenericRepository<Patient>().Table() on pa.PatientID equals p.PatientID

                         join f in this._uow.GenericRepository<Facility>().Table() on pa.FacilityID equals f.FacilityID
                         join pr in this._uow.GenericRepository<Provider>().Table() on pa.ProviderID equals pr.ProviderID

                         join vt in this._uow.GenericRepository<VisitType>().Table() on pa.VisitTypeID equals vt.VisitTypeID into g
                         from a in g.DefaultIfEmpty()

                         join pv in this._uow.GenericRepository<PatientVisit>().Table() on pa.PatientVisitID equals pv.PatientVisitID into encounterVisitJoin
                         from pv in encounterVisitJoin.DefaultIfEmpty()

                         join cm in this._uow.GenericRepository<CommonMaster>().Table() on pa.IntervalBetweenMessagesTypeId equals cm.CommonMasterID into commonGroup
                         from cg in commonGroup.DefaultIfEmpty()


                         join com in this._uow.GenericRepository<CommonMaster>().Table() on p.GenderID equals com.CommonMasterID into commonJoin
                         from com in commonJoin.DefaultIfEmpty()

                         select new
                         {
                             PatientAppointmentID = pa.PatientAppointmentID,
                             PatientID = pa.PatientID,
                             PatientName = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             AlternatePhonePanelDisplay = p.AlternatePhone,
                             PhonePanelDisplay = p.Phone,
                             Phone = p.Phone,
                             AlternatePhone = p.AlternatePhone,
                             PatientPanelDisplay = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             Email = p.Email,
                             GenderID = p.GenderID.Value,
                             //GenderDescription = com.Description,
                             AddressLine1 = p.AddressLine1,
                             AddressLine2 = p.AddressLine2,
                             LastName = p.NameLast,
                             FirstName = p.NameFirst,
                             ZIP = p.ZIP,
                             DateOfBirth = p.BirthDate.Value,
                             PatientAccountNumber = p.PatientAccountNumber,
                             MedicalRecordNumber = p.MedicalRecordNumber,
                             FacilityID = pa.FacilityID,
                             FacilityName = f.FacilityName,
                             ProviderID = pa.ProviderID,
                             ProviderName = pr.NameFirst + " " + pr.NameLast,
                             AppointmentDate = pa.AppointmentDate,
                             VisitTypeID = pa.VisitTypeID,
                             VisitTypeDescription = a.Description,
                             StartTime = pa.StartTime,
                             EndTime = pa.EndTime,
                             Duration = pa.Duration,
                             SlotNumber = pa.SlotNumber,
                             AppointmentStatusCode = pa.AppointmentStatusCode,
                             AppointmentStatus = ast.Description,
                             Description = pa.Description,
                             OtherAppointmentType = pa.OtherAppointmentType,
                             IsWaiting = pa.IsWaiting,
                             Deleted = pa.Deleted,
                             CreatedDate = pa.CreatedDate,
                             CreatedBy = pa.CreatedBy,
                             ModifiedDate = pa.ModifiedDate,
                             ModifiedBy = pa.ModifiedBy,
                             IsRecurrence = pa.IsRecurrence,
                             RecurrenceRule = pa.RecurrenceRule,
                             IsReminder = pa.IsReminder,
                             pa.RemindBeforeDays,
                             pa.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = pa.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = pa.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = pa.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = cg.Description,
                             IsSuperBillGenerated = pa.IsSuperBillGenerated,
                             PatientVisitID = pa.PatientVisitID,
                             PatientTransactionDate = pv.VisitDate,
                             VisitTime = pv.VisitTime,
                             AppointmentTypeId = pa.AppointmentTypeId,
                             EndAfter = pa.EndAfter,
                             EndOnDate = pa.EndOnDate,
                             RepeatID = pa.RepeatID,
                             RepeatDaysInterval = pa.RepeatDaysInterval,
                             Notes = pa.Notes,
                             ConsultationTypeID = pa.ConsultationTypeID


                         }).AsEnumerable().Select(PAM => new PatientAppointmentModel
                         {
                             PatientAppointmentID = PAM.PatientAppointmentID,
                             PatientID = PAM.PatientID,
                             PatientName = PAM.LastName + ", " + PAM.FirstName,
                             AlternatePhonePanelDisplay = PAM.AlternatePhone,
                             PhonePanelDisplay = PAM.Phone,
                             Phone = PAM.Phone,
                             AlternatePhone = PAM.AlternatePhone,
                             PatientPanelDisplay = PAM.LastName + ", " + PAM.FirstName,
                             Email = PAM.Email,
                             GenderID = PAM.GenderID,
                             GenderDescription = PAM.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.GenderID).FirstOrDefault().Description : "",
                             AddressLine1 = PAM.AddressLine1,
                             AddressLine2 = PAM.AddressLine2,
                             LastName = PAM.LastName,
                             FirstName = PAM.FirstName,
                             ZIP = PAM.ZIP,
                             DateOfBirth = PAM.DateOfBirth,
                             PatientAccountNumber = PAM.PatientAccountNumber,
                             MedicalRecordNumber = PAM.MedicalRecordNumber,
                             FacilityID = PAM.FacilityID,
                             FacilityName = PAM.FacilityName,
                             ProviderID = PAM.ProviderID,
                             ProviderName = PAM.LastName + " " + PAM.FirstName,
                             AppointmentDate = PAM.AppointmentDate,
                             VisitTypeID = PAM.VisitTypeID,
                             VisitTypeDescription = PAM.Description,
                             StartTime = PAM.AppointmentDate,
                             EndTime = (PAM.Duration != 0 && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
                             Duration = PAM.Duration,
                             SlotNumber = PAM.SlotNumber,
                             AppointmentStatusCode = PAM.AppointmentStatusCode,
                             AppointmentStatus = PAM.AppointmentStatus,
                             Description = PAM.Description,
                             IsWaiting = PAM.IsWaiting,
                             OtherAppointmentType = PAM.OtherAppointmentType,
                             Deleted = PAM.Deleted,
                             CreatedDate = PAM.CreatedDate,
                             CreatedBy = PAM.CreatedBy,
                             ModifiedDate = PAM.ModifiedDate,
                             ModifiedBy = PAM.ModifiedBy,
                             IsRecurrence = PAM.IsRecurrence,
                             RecurrenceRule = PAM.RecurrenceRule,
                             IsReminder = PAM.IsReminder,
                             RemindBeforeDays = PAM.RemindBeforeDays,
                             RemindBeforeHours = PAM.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = PAM.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = PAM.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = PAM.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = PAM.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                             IsSuperBillGenerated = PAM.IsSuperBillGenerated,
                             AppointmentTypeId = PAM.AppointmentTypeId,
                             AppointmentTypeDescription = PAM.AppointmentTypeId > 0 ? this._uow.GenericRepository<AppointmentType>().Table().Where(x => x.AppointmentTypeId == PAM.AppointmentTypeId).FirstOrDefault().AppointmentTypeDescription : "",
                             EndAfter = PAM.EndAfter,
                             EndOnDate = PAM.EndOnDate,
                             RepeatID = PAM.RepeatID,
                             RepeatDescription = PAM.RepeatID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.RepeatID).FirstOrDefault().Description : "",
                             RepeatDaysInterval = PAM.RepeatDaysInterval,
                             Notes = PAM.Notes,
                             ConsultationTypeID = PAM.ConsultationTypeID,
                             ConsultationTypeDescription = PAM.ConsultationTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.ConsultationTypeID).FirstOrDefault().Description : ""

                         }).ToList();


            return query;
        }
        #endregion


        #region GetAppointment Status
        public List<AppointmentStatusModel> GetAppointmentStatus()
        {
            var query = (from a in this._uow.GenericRepository<AppointmentStatus>().Table()
                         where a.Deleted == false
                         orderby a.Code
                         select new
                         {
                             AppointmentStatusID = a.AppointmentStatusID,
                             Code = a.Code,
                             Description = a.Description,
                             Deleted = a.Deleted,
                             CreatedDate = a.CreatedDate,
                             CreatedBy = a.CreatedBy,
                             ModifiedDate = a.ModifiedDate,
                             ModifiedBy = a.ModifiedBy

                         }).AsEnumerable().Select(PAM => new AppointmentStatusModel
                         {

                             AppointmentStatusID = PAM.AppointmentStatusID,
                             Code = PAM.Code,
                             Description = PAM.Description,
                             Deleted = PAM.Deleted,
                             CreatedDate = PAM.CreatedDate,
                             CreatedBy = PAM.CreatedBy,
                             ModifiedDate = PAM.ModifiedDate,
                             ModifiedBy = PAM.ModifiedBy

                         }).ToList();
            var AppointmentStatuss = query.ToList();
            return AppointmentStatuss;
        }
        #endregion

        #region GetPatientAppointmentByVisitID
        public PatientVisitsModel GetPatientAppointmentByVisitID(int patientVisitID)
        {
            PatientVisitsModel patientVisitsModel = new PatientVisitsModel();


            if (patientVisitID > 0)
            {
                var appointmentDetail = (from pa in this._uow.GenericRepository<PatientAppointment>().Table().Where(x => !x.Deleted && x.PatientVisitID == patientVisitID && x.Description != null)
                                         select new PatientVisitsModel
                                         {
                                             PatientAppointmentID = pa.PatientAppointmentID,
                                             PatientAppointmentNotes = pa.Description,
                                         }).FirstOrDefault();

                var visitDetail = (from pv in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted && x.PatientVisitID == patientVisitID)
                                   select new PatientVisitsModel
                                   {
                                       PatientVisitNotes = pv.Notes,
                                       ChiefCompliantNotes = pv.ChiefComplaint
                                   }).FirstOrDefault();

                if (visitDetail != null)
                {
                    if (appointmentDetail != null)
                    {
                        patientVisitsModel.PatientAppointmentID = appointmentDetail.PatientAppointmentID;
                        patientVisitsModel.PatientAppointmentNotes = appointmentDetail.PatientAppointmentNotes;
                    }
                    patientVisitsModel.PatientVisitNotes = visitDetail.PatientVisitNotes;
                    patientVisitsModel.ChiefCompliantNotes = visitDetail.ChiefCompliantNotes;
                }
                return patientVisitsModel;
            }
            return patientVisitsModel;
        }
        #endregion

        #region Get PatientAppointmentHistory by ID
        public PatientAppointmentHistoryModel GetPatientAppointmentHistoryByID(int patientAppointmentID)
        {


            if (patientAppointmentID == 0)
                return null;
            var query = (from pah in this._uow.GenericRepository<PatientAppointmentHistory>().Table()
                         join pa in this._uow.GenericRepository<PatientAppointment>().Table() on pah.PatientAppointmentID equals pa.PatientAppointmentID
                             into patientAppointmentJoin
                         from pa in patientAppointmentJoin.DefaultIfEmpty()
                         join a in this._uow.GenericRepository<AppointmentStatus>().Table() on pah.AppointmentStatusCode equals a.Code
                             into appointmentStatusJoin
                         from a in appointmentStatusJoin.DefaultIfEmpty()
                         where (pah.PatientAppointmentID == patientAppointmentID)
                         select new
                         {
                             PatientAppointmentHistoryID = pah.PatientAppointmentHistoryID,
                             PatientAppointmentID = pah.PatientAppointmentID,
                             AppointmentStatusCode = pah.AppointmentStatusCode,
                             Comments = pah.Comments,
                             ChangedDate = pah.ChangedDate,
                             ChangedBy = pah.ChangedBy


                         }).AsEnumerable().Select(PAM => new PatientAppointmentHistoryModel
                         {

                             PatientAppointmentHistoryID = PAM.PatientAppointmentHistoryID,
                             PatientAppointmentID = PAM.PatientAppointmentID,
                             AppointmentStatusCode = PAM.AppointmentStatusCode,
                             Comments = PAM.Comments,
                             ChangedDate = PAM.ChangedDate,
                             ChangedBy = PAM.ChangedBy

                         }).ToList();
            var resultAppoinmentHistory = query.FirstOrDefault();
            return resultAppoinmentHistory;
        }
        #endregion

        #region GetAppointmentsForToday
        public List<PatientAppointmentModel> GetAppointmentsForToday()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var pattoday = (from pa in this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.AppointmentDate.Date == DateTime.Now.Date)
                            join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on pa.PatientID equals p.PatientID
                            join f in this._uow.GenericRepository<Facility>().Table().Where(x => !x.Deleted) on pa.FacilityID equals f.FacilityID
                            join pr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on pa.ProviderID equals pr.ProviderID
                            join vt in this._uow.GenericRepository<VisitType>().Table().Where(x => !x.Deleted) on pa.VisitTypeID equals vt.VisitTypeID
                            join pv in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted) on pa.PatientVisitID equals pv.PatientVisitID into encounterVisitJoin
                            from pv in encounterVisitJoin.DefaultIfEmpty()
                            join ast in this._uow.GenericRepository<AppointmentStatus>().Table().Where(x => !x.Deleted) on pa.AppointmentStatusCode equals ast.Code
                            join com in this._uow.GenericRepository<CommonMaster>().Table() on p.GenderID equals com.CommonMasterID into commonJoin
                            from com in commonJoin.DefaultIfEmpty()
                            where (!pa.ShowInGrid)
                            //  && System.Data.Entity.DbFunctions.TruncateTime(pa.AppointmentDate) == System.Data.Entity.DbFunctions.TruncateTime(DateTime.Now)

                            orderby pa.StartTime
                            select new
                            {
                                PatientAppointmentID = pa.PatientAppointmentID,
                                PatientID = pa.PatientID,
                                PatientName = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                                AlternatePhonePanelDisplay = p.AlternatePhone,
                                PhonePanelDisplay = p.Phone,
                                Phone = p.Phone,
                                AlternatePhone = p.AlternatePhone,
                                PatientPanelDisplay = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                                Email = p.Email,
                                GenderID = p.GenderID.Value,
                                AddressLine1 = p.AddressLine1,
                                AddressLine2 = p.AddressLine2,
                                LastName = p.NameLast,
                                FirstName = p.NameFirst,
                                ZIP = p.ZIP,
                                DateOfBirth = p.BirthDate.Value,
                                PatientAccountNumber = p.PatientAccountNumber,
                                MedicalRecordNumber = p.MedicalRecordNumber,
                                FacilityID = pa.FacilityID,
                                FacilityName = f.FacilityName,
                                ProviderID = pa.ProviderID,
                                ProviderName = pr.NameFirst + " " + pr.NameLast,
                                AppointmentDate = pa.AppointmentDate,
                                VisitTypeID = pa.VisitTypeID,
                                StartTime = pa.StartTime,
                                EndTime = pa.EndTime,
                                Duration = pa.Duration,
                                SlotNumber = pa.SlotNumber,
                                AppointmentStatusCode = pa.AppointmentStatusCode,
                                AppointmentStatus = ast.Description,
                                Description = pa.Description,
                                OtherAppointmentType = pa.OtherAppointmentType,
                                IsWaiting = pa.IsWaiting,
                                Deleted = pa.Deleted,
                                CreatedDate = pa.CreatedDate,
                                CreatedBy = pa.CreatedBy,
                                ModifiedDate = pa.ModifiedDate,
                                ModifiedBy = pa.ModifiedBy,
                                IsRecurrence = pa.IsRecurrence,
                                RecurrenceRule = pa.RecurrenceRule,
                                IsReminder = pa.IsReminder,
                                pa.RemindBeforeDays,
                                pa.RemindBeforeHours,
                                NumberOfMessagesToSendPerPatient = pa.NumberOfMessagesToSendPerPatient,
                                IntervalPerMessage = pa.IntervalPerMessage,
                                IntervalBetweenMessagesTypeId = pa.IntervalBetweenMessagesTypeId,
                                IsSuperBillGenerated = pa.IsSuperBillGenerated,
                                PatientVisitID = pa.PatientVisitID,
                                PatientTransactionDate = pv.VisitDate,
                                VisitTime = pv.VisitTime,
                                AppointmentTypeId = pa.AppointmentTypeId,
                                EndAfter = pa.EndAfter,
                                EndOnDate = pa.EndOnDate,
                                RepeatID = pa.RepeatID,
                                RepeatDaysInterval = pa.RepeatDaysInterval,
                                Notes = pa.Notes,
                                ConsultationTypeID = pa.ConsultationTypeID


                            }).AsEnumerable().Select(PAM => new PatientAppointmentModel
                            {
                                PatientAppointmentID = PAM.PatientAppointmentID,
                                PatientID = PAM.PatientID,
                                PatientName = PAM.LastName + ", " + PAM.FirstName,
                                AlternatePhonePanelDisplay = PAM.AlternatePhone,
                                PhonePanelDisplay = PAM.Phone,
                                Phone = PAM.Phone,
                                AlternatePhone = PAM.AlternatePhone,
                                PatientPanelDisplay = PAM.LastName + ", " + PAM.FirstName,
                                Email = PAM.Email,
                                GenderID = PAM.GenderID,
                                GenderDescription = PAM.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.GenderID).FirstOrDefault().Description : "",
                                AddressLine1 = PAM.AddressLine1,
                                AddressLine2 = PAM.AddressLine2,
                                LastName = PAM.LastName,
                                FirstName = PAM.FirstName,
                                ZIP = PAM.ZIP,
                                DateOfBirth = PAM.DateOfBirth,
                                PatientAccountNumber = PAM.PatientAccountNumber,
                                MedicalRecordNumber = PAM.MedicalRecordNumber,
                                FacilityID = PAM.FacilityID,
                                FacilityName = PAM.FacilityName,
                                ProviderID = PAM.ProviderID,
                                ProviderName = PAM.LastName + " " + PAM.FirstName,
                                AppointmentDate = PAM.AppointmentDate,
                                VisitTypeID = PAM.VisitTypeID,
                                VisitTypeDescription = PAM.Description,
                                StartTime = PAM.AppointmentDate,
                                EndTime = (PAM.Duration != 0 && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
                                Duration = PAM.Duration,
                                SlotNumber = PAM.SlotNumber,
                                AppointmentStatusCode = PAM.AppointmentStatusCode,
                                AppointmentStatus = PAM.AppointmentStatus,
                                Description = PAM.Description,
                                OtherAppointmentType = PAM.OtherAppointmentType,
                                IsWaiting = PAM.IsWaiting,
                                Deleted = PAM.Deleted,
                                CreatedDate = PAM.CreatedDate,
                                CreatedBy = PAM.CreatedBy,
                                ModifiedDate = PAM.ModifiedDate,
                                ModifiedBy = PAM.ModifiedBy,
                                IsRecurrence = PAM.IsRecurrence,
                                RecurrenceRule = PAM.RecurrenceRule,
                                IsReminder = PAM.IsReminder,
                                RemindBeforeDays = PAM.RemindBeforeDays,
                                RemindBeforeHours = PAM.RemindBeforeHours,
                                NumberOfMessagesToSendPerPatient = PAM.NumberOfMessagesToSendPerPatient,
                                IntervalPerMessage = PAM.IntervalPerMessage,
                                IntervalBetweenMessagesTypeId = PAM.IntervalBetweenMessagesTypeId,
                                IntervalBetweenMessagesTypeDescription = PAM.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                                IsSuperBillGenerated = PAM.IsSuperBillGenerated,
                                AppointmentTypeId = PAM.AppointmentTypeId,
                                AppointmentTypeDescription = PAM.AppointmentTypeId > 0 ? this._uow.GenericRepository<AppointmentType>().Table().Where(x => x.AppointmentTypeId == PAM.AppointmentTypeId).FirstOrDefault().AppointmentTypeDescription : "",
                                EndAfter = PAM.EndAfter,
                                EndOnDate = PAM.EndOnDate,
                                RepeatID = PAM.RepeatID,
                                RepeatDescription = PAM.RepeatID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.RepeatID).FirstOrDefault().Description : "",
                                RepeatDaysInterval = PAM.RepeatDaysInterval,
                                Notes = PAM.Notes,
                                ConsultationTypeID = PAM.ConsultationTypeID,
                                ConsultationTypeDescription = PAM.ConsultationTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.ConsultationTypeID).FirstOrDefault().Description : ""

                            }).ToList();
            return pattoday.ToList();
        }
        #endregion

        #region GetPatientAppointmentReasons
        public List<CommonMasterModel> GetPatientAppointmentReason()
        {
            var patientAppointmentReason = (from cm in this._uow.GenericRepository<CommonMaster>().Table().Where(cm => (!cm.Deleted)
                        && (cm.Category.Equals("AppointmentReason")))
                                            select new CommonMasterModel
                                            {
                                                CommonMasterID = cm.CommonMasterID,
                                                Category = cm.Category,
                                                Description = cm.Description
                                            }).ToList();
            return patientAppointmentReason;
        }
        #endregion

        #region GetPatientAppointmentDuration
        public List<CommonMasterModel> GetPatientAppointmentDuration()
        {
            var patientAppointmentDuration = (from cm in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted && x.Category.Trim().ToUpper() == "DURATION")
                                              select new CommonMasterModel
                                              {
                                                  CommonMasterID = cm.CommonMasterID,
                                                  Category = cm.Category,
                                                  Code = cm.Code,
                                                  Description = cm.Description
                                              }).ToList();
            return patientAppointmentDuration;
        }
        #endregion

        #region GetPatientClinicalNotesByAppointmentID
        public PatientClinicalNotesModel GetPatientClinicalNotesByAppointmentID(int patientAppointmentID)
        {


            PatientClinicalNotesModel patientClinicalNotesModel = null;
            if (patientAppointmentID == 0)
                return null;
            var query = from pc in this._uow.GenericRepository<PatientClinicalNotes>().Table().Where(x => !x.Deleted && x.PatientAppointmentID == patientAppointmentID)
                        select new PatientClinicalNotesModel
                        {
                            PatientAppointmentID = pc.PatientAppointmentID,
                            AssessmentNotes = pc.AssessmentNotes,
                            ProcedureNotes = pc.ProcedureNotes
                        };
            if (query != null)
            {
                patientClinicalNotesModel = query.FirstOrDefault();
                return patientClinicalNotesModel;
            }
            return null;
        }
        #endregion

        #region GetAppointmentMonthsRecurrence
        public List<CommonMasterModel> GetAppointmentMonthsRecurrence()
        {
            var query = from cm in this._uow.GenericRepository<CommonMaster>().Table()
                        where ((!cm.Deleted)
                        && (cm.Category.Equals("Months")))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cm.CommonMasterID,
                            Category = cm.Category,
                            Description = cm.Description
                        };
            var patientAppointmentrecurrence = query.ToList();
            return patientAppointmentrecurrence;
        }
        #endregion

        #region GetAppointmentWeekDaysRecurrence
        public List<CommonMasterModel> GetAppointmentWeekDaysRecurrence()
        {
            var query = from cm in this._uow.GenericRepository<CommonMaster>().Table()
                        where ((!cm.Deleted)
                        && (cm.Category.Equals("WeekDays")))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cm.CommonMasterID,
                            Category = cm.Category,
                            Description = cm.Description
                        };
            var patientAppointmentWeekDaysrecurrence = query.ToList();
            return patientAppointmentWeekDaysrecurrence;
        }
        #endregion

        #region GetAppointmentWeekRecurrence
        public List<CommonMasterModel> GetAppointmentWeekRecurrence()
        {
            var query = from cm in this._uow.GenericRepository<CommonMaster>().Table()
                        where ((!cm.Deleted)
                        && (cm.Category.Equals("DaysLevel")))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cm.CommonMasterID,
                            Category = cm.Category,
                            Description = cm.Description
                        };
            var patientAppointmentDaysLevelrecurrence = query.ToList();
            return patientAppointmentDaysLevelrecurrence;
        }
        #endregion

        #region GetAppointmentStatusDescriptionByCode
        public string GetAppointmentStatusDescriptionByCode(string appointmentStatusCode)
        {
            if (string.IsNullOrEmpty(appointmentStatusCode))
                return "";
            var query = from ast in this._uow.GenericRepository<AppointmentStatus>().Table()
                        where (!ast.Deleted) && (ast.Code.Trim() == appointmentStatusCode.Trim())
                        orderby ast.Description ascending
                        select ast.Description;
            var result = query.FirstOrDefault();
            return result;
        }
        #endregion

        #region GetLatestAppointmentDetailByPatientID
        public PatientAppointmentModel GetLatestAppointmentDetailByPatientID(int patientID)
        {
            PatientAppointmentModel patientAppointmentModel = new PatientAppointmentModel();

            if (patientID == 0)
                return null;
            var query = (from pa in this._uow.GenericRepository<PatientAppointment>().Table()

                         join ast in this._uow.GenericRepository<AppointmentStatus>().Table() on pa.AppointmentStatusCode equals ast.Code

                         join p in this._uow.GenericRepository<Patient>().Table() on pa.PatientID equals p.PatientID

                         join f in this._uow.GenericRepository<Facility>().Table() on pa.FacilityID equals f.FacilityID
                         join pr in this._uow.GenericRepository<Provider>().Table() on pa.ProviderID equals pr.ProviderID

                         join vt in this._uow.GenericRepository<VisitType>().Table() on pa.VisitTypeID equals vt.VisitTypeID into g
                         from a in g.DefaultIfEmpty()

                         join pv in this._uow.GenericRepository<PatientVisit>().Table() on pa.PatientVisitID equals pv.PatientVisitID into encounterVisitJoin
                         from pv in encounterVisitJoin.DefaultIfEmpty()

                         join cm in this._uow.GenericRepository<CommonMaster>().Table() on pa.IntervalBetweenMessagesTypeId equals cm.CommonMasterID into commonGroup
                         from cg in commonGroup.DefaultIfEmpty()


                         join com in this._uow.GenericRepository<CommonMaster>().Table() on p.GenderID equals com.CommonMasterID into commonJoin
                         from com in commonJoin.DefaultIfEmpty()

                         select new
                         {
                             PatientAppointmentID = pa.PatientAppointmentID,
                             PatientID = pa.PatientID,
                             PatientName = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             AlternatePhonePanelDisplay = p.AlternatePhone,
                             PhonePanelDisplay = p.Phone,
                             Phone = p.Phone,
                             AlternatePhone = p.AlternatePhone,
                             PatientPanelDisplay = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                             Email = p.Email,
                             GenderID = p.GenderID.Value,
                             GenderDescription = com.Description,
                             AddressLine1 = p.AddressLine1,
                             AddressLine2 = p.AddressLine2,
                             LastName = p.NameLast,
                             FirstName = p.NameFirst,
                             ZIP = p.ZIP,
                             DateOfBirth = p.BirthDate.Value,
                             PatientAccountNumber = p.PatientAccountNumber,
                             MedicalRecordNumber = p.MedicalRecordNumber,
                             FacilityID = pa.FacilityID,
                             FacilityName = f.FacilityName,
                             ProviderID = pa.ProviderID,
                             ProviderName = pr.NameFirst + " " + pr.NameLast,
                             AppointmentDate = pa.AppointmentDate,
                             VisitTypeID = pa.VisitTypeID,
                             VisitTypeDescription = a.Description,
                             StartTime = pa.StartTime,
                             EndTime = pa.EndTime,
                             Duration = pa.Duration,
                             SlotNumber = pa.SlotNumber,
                             AppointmentStatusCode = pa.AppointmentStatusCode,
                             AppointmentStatus = ast.Description,
                             Description = pa.Description,
                             OtherAppointmentType = pa.OtherAppointmentType,
                             IsWaiting = pa.IsWaiting,
                             Deleted = pa.Deleted,
                             CreatedDate = pa.CreatedDate,
                             CreatedBy = pa.CreatedBy,
                             ModifiedDate = pa.ModifiedDate,
                             ModifiedBy = pa.ModifiedBy,
                             IsRecurrence = pa.IsRecurrence,
                             RecurrenceRule = pa.RecurrenceRule,
                             IsReminder = pa.IsReminder,
                             pa.RemindBeforeDays,
                             pa.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = pa.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = pa.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = pa.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = cg.Description,
                             IsSuperBillGenerated = pa.IsSuperBillGenerated,
                             PatientVisitID = pa.PatientVisitID,
                             PatientTransactionDate = pv.VisitDate,
                             VisitTime = pv.VisitTime,
                             AppointmentTypeId = pa.AppointmentTypeId,
                             EndAfter = pa.EndAfter,
                             EndOnDate = pa.EndOnDate,
                             RepeatID = pa.RepeatID,
                             RepeatDaysInterval = pa.RepeatDaysInterval,
                             Notes = pa.Notes,
                             ConsultationTypeID = pa.ConsultationTypeID


                         }).AsEnumerable().Select(PAM => new PatientAppointmentModel
                         {
                             PatientAppointmentID = PAM.PatientAppointmentID,
                             PatientID = PAM.PatientID,
                             PatientName = PAM.LastName + ", " + PAM.FirstName,
                             AlternatePhonePanelDisplay = PAM.AlternatePhone,
                             PhonePanelDisplay = PAM.Phone,
                             Phone = PAM.Phone,
                             AlternatePhone = PAM.AlternatePhone,
                             PatientPanelDisplay = PAM.LastName + ", " + PAM.FirstName,
                             Email = PAM.Email,
                             GenderID = PAM.GenderID,
                             GenderDescription = PAM.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.GenderID).FirstOrDefault().Description : "",
                             AddressLine1 = PAM.AddressLine1,
                             AddressLine2 = PAM.AddressLine2,
                             LastName = PAM.LastName,
                             FirstName = PAM.FirstName,
                             ZIP = PAM.ZIP,
                             DateOfBirth = PAM.DateOfBirth,
                             PatientAccountNumber = PAM.PatientAccountNumber,
                             MedicalRecordNumber = PAM.MedicalRecordNumber,
                             FacilityID = PAM.FacilityID,
                             FacilityName = PAM.FacilityName,
                             ProviderID = PAM.ProviderID,
                             ProviderName = PAM.LastName + " " + PAM.FirstName,
                             AppointmentDate = PAM.AppointmentDate,
                             VisitTypeID = PAM.VisitTypeID,
                             OtherAppointmentType = PAM.OtherAppointmentType,
                             VisitTypeDescription = PAM.Description,
                             StartTime = PAM.AppointmentDate,
                             EndTime = (PAM.Duration != 0 && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
                             Duration = PAM.Duration,
                             SlotNumber = PAM.SlotNumber,
                             AppointmentStatusCode = PAM.AppointmentStatusCode,
                             AppointmentStatus = PAM.AppointmentStatus,
                             Description = PAM.Description,
                             IsWaiting = PAM.IsWaiting,
                             Deleted = PAM.Deleted,
                             CreatedDate = PAM.CreatedDate,
                             CreatedBy = PAM.CreatedBy,
                             ModifiedDate = PAM.ModifiedDate,
                             ModifiedBy = PAM.ModifiedBy,
                             IsRecurrence = PAM.IsRecurrence,
                             RecurrenceRule = PAM.RecurrenceRule,
                             IsReminder = PAM.IsReminder,
                             RemindBeforeDays = PAM.RemindBeforeDays,
                             RemindBeforeHours = PAM.RemindBeforeHours,
                             NumberOfMessagesToSendPerPatient = PAM.NumberOfMessagesToSendPerPatient,
                             IntervalPerMessage = PAM.IntervalPerMessage,
                             IntervalBetweenMessagesTypeId = PAM.IntervalBetweenMessagesTypeId,
                             IntervalBetweenMessagesTypeDescription = PAM.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                             IsSuperBillGenerated = PAM.IsSuperBillGenerated,
                             AppointmentTypeId = PAM.AppointmentTypeId,
                             AppointmentTypeDescription = PAM.AppointmentTypeId > 0 ? this._uow.GenericRepository<AppointmentType>().Table().Where(x => x.AppointmentTypeId == PAM.AppointmentTypeId).FirstOrDefault().AppointmentTypeDescription : "",
                             EndAfter = PAM.EndAfter,
                             EndOnDate = PAM.EndOnDate,
                             RepeatID = PAM.RepeatID,
                             RepeatDescription = PAM.RepeatID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.RepeatID).FirstOrDefault().Description : "",
                             RepeatDaysInterval = PAM.RepeatDaysInterval,
                             Notes = PAM.Notes,
                             ConsultationTypeID = PAM.ConsultationTypeID,
                             ConsultationTypeDescription = PAM.ConsultationTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PAM.ConsultationTypeID).FirstOrDefault().Description : ""

                         }).ToList();



            if (query != null)
            {
                if (patientAppointmentModel != null)
                {
                    patientAppointmentModel = query.FirstOrDefault();
                    //patientAppointmentModel.PhonePanelDisplay = (patientAppointmentModel.Phone.Length) > 0 ? ("☎ " + BmsCommonUtility.FormatStrings(patientAppointmentModel.Phone, BmsCommonUtility.FormatStringTypes.Phone)) : string.Empty;
                    //patientAppointmentModel.AlternatePhonePanelDisplay = BmsCommonUtility.FormatStrings(patientAppointmentModel.AlternatePhone, BmsCommonUtility.FormatStringTypes.Phone);
                    // patientAppointmentModel.BirthDateDisPlay = (patientAppointmentModel.DateOfBirth == DateTime.MinValue) ? "" : String.Format("{0:MM/dd/yyyy}", patientAppointmentModel.DateOfBirth);// + " [ " + GetAgeByDateOfBirth(patientAppointmentModel.DateOfBirth) + " ]";
                    return patientAppointmentModel;
                }
            }
            return null;
        }
        #endregion

        #region GetPatientAppointmentDateByPatientID
        public List<PatientDischargeInstructionAppointmentModel> GetPatientAppointmentDateByPatientID(int patientID)
        {

            if (patientID < 0)
                return null;
            var patientDischargeInstructionResult = (from pa in this._uow.GenericRepository<PatientAppointment>().Table().Where(x => (!x.Deleted) && (x.PatientID == patientID) && x.AppointmentDate <= DateTime.UtcNow && !x.ShowInGrid)
                                                     join pt in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted) on pa.PatientVisitID equals pt.PatientVisitID
                                                     orderby pa.AppointmentDate descending
                                                     select new
                                                     {
                                                         PatientAppointmentID = pa.PatientAppointmentID,
                                                         PatientAppointmentDate = pa.AppointmentDate,
                                                         PatientVisitID = pa.PatientVisitID,
                                                         IsPrinted = pt.IsPrinted,
                                                     }).AsEnumerable().Select(x => new PatientDischargeInstructionAppointmentModel
                                                     {
                                                         PatientAppointmentID = x.PatientAppointmentID,
                                                         PatientVisitID = x.PatientVisitID.HasValue ? x.PatientVisitID.Value : 0,
                                                         PatientAppointmentDate = String.Format("{0:MM/dd/yyyy}", x.PatientAppointmentDate),
                                                         PatientTransactionIsPrinted = x.IsPrinted,
                                                     }).Take(30).ToList();

            return patientDischargeInstructionResult;
        }
        #endregion

        #region GetAppointmentStatusByStatusCode
        public List<AppointmentStatusModel> GetAppointmentStatusByStatusCodes(string appointmentStatusCode)
        {
            List<string> _selectedAppointmentStatus = new List<string>();
            string[] _appointmentStatusCodes = new string[] { "AR", "CL", "CN", "DL", "NA", "RQ" };
            if (!string.IsNullOrEmpty(appointmentStatusCode))
            {
                _appointmentStatusCodes = appointmentStatusCode.Trim().Split(',');
                foreach (string _code in _appointmentStatusCodes)
                {
                    _selectedAppointmentStatus.Add(_code);
                }
            }
            var appointmentStatus = (from a in this._uow.GenericRepository<AppointmentStatus>().Table().Where(a => !a.Deleted
                                     && (_selectedAppointmentStatus.Count == 0 || _selectedAppointmentStatus.Contains(a.Code)))
                       .OrderBy(x => x.Code)
                                     select new
                                     {
                                         appointmentStatusID = a.AppointmentStatusID,
                                         code = a.Code,
                                         description = a.Description,
                                         deleted = a.Deleted,
                                         createdDate = a.CreatedDate,
                                         createdBy = a.CreatedBy,
                                         modifiedDate = a.ModifiedDate,
                                         modifiedBy = a.ModifiedBy
                                     }).AsEnumerable().Select(x => new AppointmentStatusModel
                                     {
                                         AppointmentStatusID = x.appointmentStatusID,
                                         Code = x.code,
                                         Description = x.description,
                                         Deleted = x.deleted,
                                         CreatedDate = x.createdDate,
                                         CreatedBy = x.createdBy,
                                         ModifiedDate = x.modifiedDate,
                                         ModifiedBy = x.modifiedBy
                                     }).ToList();
            return appointmentStatus;
        }
        #endregion

        #region
        public List<ProviderModel> GetbyProvidername()
        {
            var provider = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true)
                            join u in this._uow.GenericRepository<UserData>().Table()
                             on a.UserID equals u.UserID
                            select
                            new
                            {
                                a.ProviderID,
                                a.UserID,
                                u.SSNID,
                                a.NPI,
                                a.AddressLine1,
                                a.AddressLine2,
                                a.Country,
                                a.BillingState,
                                a.BillingZIP,
                                a.City,
                                a.CreatedBy,
                                a.CreatedDate,
                                a.Deleted,
                                a.County,
                                a.BirthDate,
                                a.BillingCity,
                                a.AlternatePhone,
                                a.Credential,
                                a.Email,
                                a.IsBillingForeign,
                                a.IsForeign,
                                a.IsSameAsMailingAddress,
                                a.LanguageID,
                                a.MedicaidID,
                                a.MedicareID,
                                a.ModifiedBy,
                                a.ModifiedDate,
                                a.MothersMaidenName,
                                a.NameFirst,
                                a.NameLast,
                                a.NamePrefix,
                                a.NameSuffix,
                                a.BillingAddressLine1,
                                a.BillingAddressLine2,
                                a.BillingCountry

                            }).AsEnumerable().Select(ss => new ProviderModel
                            {
                                ProviderID = ss.ProviderID,
                                UserID = ss.UserID,
                                NPI = ss.NPI,
                                ProviderSSN = ss.SSNID.ToString(),
                                AddressLine1 = ss.AddressLine1,
                                AddressLine2 = ss.AddressLine2,
                                Country = ss.Country,
                                BillingState = ss.BillingState,
                                BillingZIP = ss.BillingZIP,
                                City = ss.City,
                                CreatedBy = ss.CreatedBy,
                                CreatedDate = ss.CreatedDate,
                                Deleted = ss.Deleted,
                                County = ss.County,
                                BirthDate = ss.BirthDate,
                                BillingCity = ss.BillingCity,
                                AlternatePhone = ss.AlternatePhone,
                                Credential = ss.Credential,
                                Email = ss.Email,
                                IsBillingForeign = ss.IsBillingForeign,
                                IsForeign = ss.IsForeign,
                                IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                LanguageID = ss.LanguageID,
                                MedicaidID = ss.MedicaidID,
                                MedicareID = ss.MedicareID,
                                ModifiedBy = ss.ModifiedBy,
                                ModifiedDate = ss.ModifiedDate,
                                MothersMaidenName = ss.MothersMaidenName,
                                NameFirst = ss.NameFirst != null ? ss.NameFirst : this._uow.GenericRepository<UserData>().Table().
                                           Where(x => x.UserID == ss.UserID).FirstOrDefault().NameFirst,
                                NameLast = ss.NameLast != null ? ss.NameLast : this._uow.GenericRepository<UserData>().Table().
                                           Where(x => x.UserID == ss.UserID).FirstOrDefault().NameLast,
                                NamePrefix = ss.NamePrefix,
                                NameSuffix = ss.NameSuffix,
                                BillingAddressLine1 = ss.BillingAddressLine1,
                                BillingAddressLine2 = ss.BillingAddressLine1,
                                BillingCountry = ss.BillingCountry,

                            }).ToList();
            return provider;
        }
        #endregion

        #region GetPatientbySearchKey
        public List<PatientModel> GetPatientbySearchKey(string Searchkey)
        {
            List<PatientModel> patientModels = (from a in this._uow.GenericRepository<Patient>().Table()

                                                select new
                                                {
                                                    a.PatientID,
                                                    a.PatientSSN,
                                                    a.MedicalRecordNumber,
                                                    PatientName = a.NameFirst + " " + a.NameMiddle + " " + a.NameLast,
                                                    GenderDescription = a.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == a.GenderID).FirstOrDefault().Description : "",



                                                }).AsEnumerable().Select(pam => new PatientModel
                                                {
                                                    PatientID = pam.PatientID,
                                                    PatientSSN = pam.PatientSSN,
                                                    MedicalRecordNumber = pam.MedicalRecordNumber,
                                                    PatientName = pam.PatientName,
                                                    GenderDescription = pam.GenderDescription,


                                                }).ToList();

            patientModels = (from p in patientModels
                             where (Searchkey == null || (p.PatientName.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) ||
                                           p.GenderDescription.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) ||
                                         p.PatientSSN != null && p.PatientSSN.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) ||
                                         p.MedicalRecordNumber != null && p.MedicalRecordNumber.ToLower().Trim().Contains(Searchkey.ToLower().Trim())

                                           ))

                             select p).ToList();
            return patientModels;
        }
        #endregion

        #region GetPatientAppointmentbySearchModel
        public List<PatientAppointmentModel> GetPatientAppointmentbySearchModel(SearchModel searchModel)
        {

            //   DateTime Currentdate = searchModel.Currentdate == null ? DateTime.Now : this._MasterService.GetLocalTime(searchModel.Currentdate.Value);
            List<PatientAppointmentModel> patientAppointments = (from pa in this._uow.GenericRepository<PatientAppointment>().Table()
                                                                 join p in this._uow.GenericRepository<Patient>().Table() on pa.PatientID equals p.PatientID
                                                                 join pr in this._uow.GenericRepository<Provider>().Table() on pa.ProviderID equals pr.ProviderID
                                                                 join f in this._uow.GenericRepository<Facility>().Table() on pa.PatientID equals f.FacilityID

                                                                 select new
                                                                 {
                                                                     pa.PatientAppointmentID,
                                                                     pa.PatientID,
                                                                     PatientName = p.NameLast + ", " + p.NameMiddle + ", " + p.NameFirst,
                                                                     GenderID = p.GenderID.Value,
                                                                     PatientAccountNumber = p.PatientAccountNumber,
                                                                     MedicalRecordNumber = p.MedicalRecordNumber,
                                                                     FacilityID = pa.FacilityID,
                                                                     FacilityName = f.FacilityName,
                                                                     ProviderID = pa.ProviderID,
                                                                     ProviderName = pr.NameFirst + " " + pr.NameLast,
                                                                     AppointmentDate = pa.AppointmentDate,
                                                                     AppointmentStatusCode = pa.AppointmentStatusCode,
                                                                     Description = pa.Description,
                                                                     OtherAppointmentType = pa.OtherAppointmentType,

                                                                 }).AsEnumerable().Select(PAM => new PatientAppointmentModel
                                                                 {
                                                                     PatientAppointmentID = PAM.PatientAppointmentID,
                                                                     PatientID = PAM.PatientID,
                                                                     PatientName = PAM.PatientName,
                                                                     GenderID = PAM.GenderID,
                                                                     GenderDescription = PAM.Description,
                                                                     PatientAccountNumber = PAM.PatientAccountNumber,
                                                                     MedicalRecordNumber = PAM.MedicalRecordNumber,
                                                                     FacilityID = PAM.FacilityID,
                                                                     FacilityName = PAM.FacilityName,
                                                                     ProviderID = PAM.ProviderID,
                                                                     ProviderName = PAM.ProviderName,
                                                                     AppointmentDate = PAM.AppointmentDate,
                                                                     AppointmentStatusCode = PAM.AppointmentStatusCode,


                                                                 }).ToList();
            patientAppointments = (from a in patientAppointments
                                   where ((searchModel.Currentdate == null || a.AppointmentDate == this._MasterService.GetLocalTime(searchModel.Currentdate.Value)) &&
                                          //Currentdate.Date <= pa.AppointmentDate &&
                                          (searchModel.PatientId == 0 || a.PatientID == searchModel.PatientId) &&
                                          (searchModel.ProviderId == 0 || a.ProviderID == searchModel.ProviderId) &&
                                          (searchModel.FacilityId == 0 || a.FacilityID == searchModel.FacilityId) &&
                                          ((searchModel.PatientName == null || searchModel.PatientName == "") || a.PatientName.ToLower().Trim().Contains(searchModel.PatientName.ToLower().Trim()) &&
                                          ((searchModel.AppointmentStatusCode == null || searchModel.AppointmentStatusCode == "") || a.AppointmentStatusCode.ToLower().Trim() == searchModel.AppointmentStatusCode.ToLower().Trim())))
                                   select a).ToList();


            return patientAppointments;



        }
        #endregion

        ////Calendar for Setup Appointments 
        public AvailabilityModel AvailabilityStatus(AvailabilityModel availModel)
        {
            var schedule = (from pl in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.FacilityID == availModel.FacilityId & x.ProviderID == availModel.ProviderId & x.TerminationDate.Value.Date > DateTime.Now.Date).ToList()
                            join pt in this._uow.GenericRepository<ProviderLocationTiming>().Table()
                            on pl.ProviderLocationID equals pt.ProviderLocationID
                            select pt).ToList();

            var Date = this._MasterService.GetLocalTime(availModel.AppointDate);
            string Message = "";
            if (schedule.Count() == 0)
            {
                Message = "No Schedules for this Provider";
            }
            else if (schedule.Count() > 0)
            {
                var Data = schedule.FirstOrDefault(x => x.AppointmentDay == Date.DayOfWeek.ToString() && x.EffectiveDate <= Date
                                                    && x.TerminationDate >= Date);
                var vacation = this._uow.GenericRepository<ProviderVacation>().Table().FirstOrDefault(x => x.ProviderID == availModel.ProviderId
                                                                            && x.StartDate <= Date && x.EndDate >= Date);

                if (Data == null)
                    Message = "No Schedule available on this Day for this Provider";
                else if (vacation != null)
                    Message = "Provider is on Vacation, Not Available";
                else
                    Message = "Yes, Available";

            }
            availModel.AppointDate = Date;
            availModel.ProviderId = availModel.ProviderId;
            availModel.FacilityId = availModel.FacilityId;
            availModel.availability = Message;

            return availModel;
        }

        public TimeSpan GetRailwayTimeForSchedule(string scheduledTime)
        {
            int Hours = 0;
            int Mins = 0;
            TimeSpan time = new TimeSpan(0, 0, 0);

            string timeSet = scheduledTime.Split(' ')[0];

            if (scheduledTime.ToLower().Trim().Contains("pm") && timeSet.Split(':')[0] != "12")
            {
                Hours = Int32.Parse(timeSet.Split(':')[0]) + 12;
                Mins = Int32.Parse(timeSet.Split(':')[1]);
            }
            else
            {
                Hours = Int32.Parse(timeSet.Split(':')[0]);
                Mins = Int32.Parse(timeSet.Split(':')[1]);
            }
            time = new TimeSpan(Hours, Mins, 0);

            return time;
        }

        ///// <summary>
        ///// Get Time returns with AM or PM
        ///// </summary>
        ///// <param>(string Daytime)</param>
        ///// <returns>TimeSpan. if time with AM or PM for given value = success. else = failure</returns>
        public string GetTimewithTiming(string Daytime)
        {
            TimeSpan midTime = new TimeSpan(12, 00, 00);
            TimeSpan timeData = new TimeSpan(Int32.Parse(Daytime.Split(':')[0]), Int32.Parse(Daytime.Split(':')[1]), Int32.Parse(Daytime.Split(':')[2]));
            TimeSpan timeResult = new TimeSpan();
            string Timing = "";
            if (midTime <= timeData)
            {
                timeResult = timeData - midTime;
                if (timeResult.Hours == 0)
                {
                    var span = new TimeSpan(12, timeResult.Minutes, timeResult.Seconds);
                    Timing = span + " " + "PM";
                }
                else
                {
                    Timing = timeResult + " " + "PM";
                }
            }
            else
            {
                Timing = timeData + " " + "AM";
            }
            return Timing;
        }

        public List<PatientAppointmentModel> GetAppointmentsForCalendar(string viewMode, string date) // ,int PatientAppointmentID)//, int providerId)
        {
            DateTime selectedDate = this._MasterService.GetLocalTime(Convert.ToDateTime(date));
            //DateTime selectedDate = Convert.ToDateTime(date);
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (viewMode.ToLower().Trim() == "day")
            {
                startDate = Convert.ToDateTime(selectedDate.ToShortDateString());
                endDate = startDate.AddDays(1);
            }
            else if (viewMode.ToLower().Trim() == "week")
            {
                startDate = selectedDate.AddDays(selectedDate.DayOfWeek.GetHashCode() * -1);
                endDate = startDate.AddDays(7);
            }
            else if (viewMode.ToLower().Trim() == "month")
            {
                startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                endDate = startDate.AddMonths(1);
            }

            List<PatientAppointmentModel> appointments = new List<PatientAppointmentModel>();

            appointments = (from app in this._uow.GenericRepository<PatientAppointment>().Table()//.Where(x => x.ProviderID == providerId)

                            join prov in this._uow.GenericRepository<Provider>().Table()
                            on app.ProviderID equals prov.ProviderID

                            join pat in this._uow.GenericRepository<Patient>().Table()
                            on app.PatientID equals pat.PatientID


                            select new
                            {
                                pat.NameFirst,
                                pat.NameMiddle,
                                pat.NameLast,
                                pat.Phone,
                                pat.MedicalRecordNumber,
                                ProviderFirstName = prov.NameFirst,
                                ProivderMiddleName = prov.NameMiddle,
                                ProivderLastName = prov.NameLast,
                                app.PatientAppointmentID,
                                app.AppointmentDate,
                                app.PatientID,
                                app.Duration,
                                app.Notes,
                                app.ProviderID,
                                app.FacilityID,
                                app.AppointmentStatusCode,
                                app.AppointmentTypeId,
                                app.IsRecurrence,
                                app.IsWaiting,


                            }).AsEnumerable().OrderByDescending(x => x.AppointmentDate).Select(PAM => new PatientAppointmentModel
                            {
                                PatientAppointmentID = PAM.PatientAppointmentID,
                                AppointmentDate = PAM.AppointmentDate,
                                // AppointmentTime = PAM.AppointmentDate.ToString("hh:mm:ss tt"),
                                StartTime = PAM.AppointmentDate,
                                EndTime = (PAM.Duration != 0 && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
                                //  AppointmentNo = PAM.AppointmentNo,
                                PatientID = PAM.PatientID,
                                PatientName = PAM.NameFirst + " " + PAM.NameMiddle + " " + PAM.NameLast,
                                Phone = PAM.Phone,
                                MedicalRecordNumber = PAM.MedicalRecordNumber,
                                Notes = PAM.Notes,
                                Duration = PAM.Duration,
                                ProviderID = PAM.ProviderID,
                                ProviderName = PAM.ProviderFirstName + " " + PAM.ProivderMiddleName + " " + PAM.ProivderLastName,
                                FacilityID = PAM.FacilityID,
                                FacilityName = PAM.FacilityID > 0 ? this._uow.GenericRepository<Facility>().Table().FirstOrDefault(x => x.FacilityID == PAM.FacilityID).FacilityName : "",
                                AppointmentTypeDescription = PAM.AppointmentTypeId > 0 ? this._uow.GenericRepository<AppointmentType>().Table().Where(x => x.AppointmentTypeId == PAM.AppointmentTypeId).FirstOrDefault().AppointmentTypeDescription : "",
                                AppointmentTypeId = PAM.AppointmentTypeId,
                                AppointmentStatusDescription = PAM.AppointmentStatusCode.ToLower().Trim() != null ? this._uow.GenericRepository<AppointmentStatus>().Table().Where(x => x.Code == PAM.AppointmentStatusCode.ToLower().Trim()).FirstOrDefault().Description : "",
                                IsRecurrence = PAM.IsRecurrence,
                                IsWaiting = PAM.IsWaiting,


                            }).ToList();

            var appointmentList = (from data in appointments.Where(x => x.AppointmentStatusDescription.ToLower().Trim() != "cancelled")

                                       //join schedule in this.uow.GenericRepository<ProviderSchedule>().Table()
                                       //on data.ProviderID equals schedule.ProviderID

                                   where (//schedule.EffectiveDate.Value.Date <= data.AppointmentDate.Date && schedule.TerminationDate.Value.Date >= data.AppointmentDate.Date && 
                                   (startDate.Date > new DateTime().Date && data.AppointmentDate.Date >= startDate.Date) &&
                                   (endDate.Date > new DateTime().Date && endDate >= startDate && data.AppointmentDate.Date < endDate))

                                   select data).GroupBy(obj => new { obj.ProviderID, obj.AppointmentDate }).Select(data => data.OrderByDescending(set => set.AppointmentDate).FirstOrDefault()).ToList();



            return appointmentList;
        }

        public List<DateTime> GetDatesForProvider(int ProviderID)
        {
            List<DateTime> Dates = new List<DateTime>();
            List<DateTime> vacationDates = new List<DateTime>();
            List<DateTime> availableDates = new List<DateTime>();

            //   var schedule = this._uow.GenericRepository<ProviderSchedule>().Table().Where(x => x.ProviderID == ProviderId & x.TerminationDate.Value.Date > DateTime.Now.Date).ToList();

            var schedule = (from pl in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == ProviderID & x.TerminationDate.Value.Date > DateTime.Now.Date).ToList()
                            join pt in this._uow.GenericRepository<ProviderLocationTiming>().Table()
                            on pl.ProviderLocationID equals pt.ProviderLocationID
                            select pt).ToList();

            if (schedule.Count() > 0)
            {
                var startDate = schedule.FirstOrDefault().EffectiveDate;

                var endDate = schedule.FirstOrDefault().TerminationDate;

                var vacation = this._uow.GenericRepository<ProviderVacation>().Table().
                                Where(x => x.ProviderID == ProviderID & x.StartDate >= startDate & x.EndDate <= endDate).FirstOrDefault();

                if (vacation != null)
                {
                    for (var date = vacation.StartDate; date <= vacation.EndDate; date.Value.AddDays(1))
                    {
                        vacationDates.Add(date.Value);
                        date = date.Value.AddDays(1);
                    }
                }

                foreach (var day in schedule)
                {
                    for (var Scheduleddate = startDate; Scheduleddate <= endDate; Scheduleddate.AddDays(1))
                    {
                        if (day.AppointmentDay == Scheduleddate.DayOfWeek.ToString())
                        {
                            Dates.Add(Scheduleddate);
                        }
                        Scheduleddate = Scheduleddate.AddDays(1);
                    }
                }
            }

            if (vacationDates.Count() > 0)
            {
                var dateRecords = (from dat in Dates join vac in vacationDates on dat.Date equals vac.Date select dat).ToList();

                availableDates = Dates.Except(dateRecords).ToList();
            }
            else
            {
                availableDates = Dates;
            }
            return availableDates;
        }

        public List<TimingModel> GetTimingsforAppointment(string AppointDate, int ProviderID, int facilityID)
        {
            var appointDate = Convert.ToDateTime(AppointDate);
            List<TimingModel> AvailableTimings = new List<TimingModel>();
            List<string> Timings = new List<string>();
            List<string> times = new List<string>();

            //   var Schedule = this._uow.GenericRepository<ProviderSchedule>().Table().FirstOrDefault(x => x.ProviderID == ProviderID & x.FacilityID == facilityID & x.TerminationDate.Value.Date > DateTime.Now.Date & x.AppointmentDay == appointDate.DayOfWeek.ToString());

            var Schedule = (from pl in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == ProviderID & x.FacilityID == facilityID & x.TerminationDate.Value.Date > DateTime.Now.Date).ToList()
                            join pt in this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(x => x.TerminationDate.Value > DateTime.Now.Date & x.AppointmentDay == appointDate.DayOfWeek.ToString())
                            on pl.ProviderLocationID equals pt.ProviderLocationID
                            select pt).FirstOrDefault();

            TimeSpan time = new TimeSpan();
            TimeSpan timeSet = new TimeSpan();
            TimeSpan duration = new TimeSpan(0, Schedule.TimeSlotDuration, 0);

            time = (Schedule.RegularWorkHrsFrom == "12:00:00 am" || Schedule.RegularWorkHrsFrom == "12:00 am") ? this.GetRailwayTimeForSchedule("00:00 am") : this.GetRailwayTimeForSchedule(Schedule.RegularWorkHrsFrom);

            if ((Schedule.BreakHrsFrom != null && Schedule.BreakHrsFrom != "")
                && (Schedule.BreakHrsTo != null && Schedule.BreakHrsTo != ""))
            {
                timeSet = (Schedule.BreakHrsFrom == "12:00:00 am" || Schedule.BreakHrsFrom == "12:00 am") ? this.GetRailwayTimeForSchedule("00:00 am") : this.GetRailwayTimeForSchedule(Schedule.BreakHrsFrom);

                while (time < timeSet)
                {
                    if (time + duration <= timeSet)
                    {
                        if (!Timings.Contains(time.ToString()))
                        {
                            Timings.Add(time.ToString());
                        }
                    }
                    time = time + duration;
                }

                timeSet = (Schedule.BreakHrsTo == "12:00:00 am" || Schedule.BreakHrsTo == "12:00 am") ? this.GetRailwayTimeForSchedule("00:00 am") : this.GetRailwayTimeForSchedule(Schedule.BreakHrsTo);

                time = timeSet;
            }

            timeSet = (Schedule.RegularWorkHrsTo == "12:00:00 am" || Schedule.RegularWorkHrsTo == "12:00 am") ? this.GetRailwayTimeForSchedule("00:00 am") : this.GetRailwayTimeForSchedule(Schedule.RegularWorkHrsTo);

            while (time < timeSet)
            {
                if (time + duration <= timeSet)
                {
                    if (!Timings.Contains(time.ToString()))
                    {
                        Timings.Add(time.ToString());
                    }
                }
                time = time + duration;
            }

            var appStatus = this._uow.GenericRepository<AppointmentStatus>().Table().Where(x => x.Description.ToLower().Trim() == "cancelled").FirstOrDefault();

            var takentime = (from appnt in this._uow.GenericRepository<PatientAppointment>().Table().
                            Where(x => x.ProviderID == ProviderID & x.AppointmentDate.Date == appointDate.Date & x.AppointmentStatusCode.ToLower().Trim() != appStatus.Code.ToLower().Trim())
                             select (appnt.AppointmentDate.TimeOfDay.Hours + ":" + appnt.AppointmentDate.TimeOfDay.Minutes + ":00")).ToList();

            if (takentime.Count() > 0)
            {
                if (Schedule.BookingPerSlot <= takentime.Count())
                {
                    times = Timings.Except(takentime).ToList();
                }
                else
                {
                    times = Timings;
                }
            }
            else
            {
                times = Timings;
            }

            foreach (var set in times)
            {
                TimingModel model = new TimingModel();

                var AppointedTime = this._uow.GenericRepository<PatientAppointment>().Table().FirstOrDefault(x => x.AppointmentDate.Date == appointDate.Date
                                        & x.AppointmentDate.TimeOfDay.ToString() == set & x.AppointmentStatusCode.ToLower().Trim() != appStatus.Code.ToLower().Trim() & x.ProviderID == ProviderID);

                if (AppointedTime == null || (AppointedTime != null && AppointedTime.AppointmentStatusCode == appStatus.Code))
                {
                    model.IsAvailable = true;
                }
                else
                {
                    var appRecord = this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.AppointmentDate.Date == appointDate.Date & x.AppointmentStatusCode.ToLower().Trim() != appStatus.Code.ToLower().Trim()
                    & x.AppointmentDate.TimeOfDay.ToString() == set & x.ProviderID == ProviderID).ToList();

                    if (appRecord.Count() < Schedule.BookingPerSlot)
                        model.IsAvailable = true;
                    else
                        model.IsAvailable = false;
                }
                model.ScheduleTime = this.GetTimewithTiming(set);
                model.duration = duration.Minutes.ToString();

                if (!AvailableTimings.Contains(model))
                {
                    AvailableTimings.Add(model);
                }
            }

            return AvailableTimings;
        }


        //public PatientAppointment ConfirmAppointment(int PatientAppointmentID)
        //{
        //    var confirmstatus = this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.PatientAppointmentID == PatientAppointmentID).SingleOrDefault();

        //    if (confirmstatus != null)
        //    {
        //        confirmstatus.AppointmentStatusID = 5;

        //        this._uow.GenericRepository<AppointmentStatus>().Update(confirmstatus);

        //        this._uow.Save();
        //    }

        //    return confirmstatus;
        //}

        public string ConfirmAppointment(int PatientAppointmentID)
        {
            string status = "";

            var appointRecord = this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.PatientAppointmentID == PatientAppointmentID).FirstOrDefault();

            if (appointRecord != null)
            {
                var appStatus = this._uow.GenericRepository<AppointmentStatus>().Table().Where(x => x.Description.ToLower().Trim() == "confirmed").FirstOrDefault();

                appointRecord.AppointmentStatusCode = appStatus.Code;
                appointRecord.ModifiedDate = DateTime.Now;
                appointRecord.ModifiedBy = "User";

                this._uow.GenericRepository<PatientAppointment>().Update(appointRecord);
                this._uow.Save();

                status = "Confirmed Successfully";
            }
            else
            {
                status = "No record found";
            }

            return status;
        }


        public string CancelAppointment(int PatientAppointmentID)
        {
            string status = "";

            var appointRecord = this._uow.GenericRepository<PatientAppointment>().Table().Where(x => x.PatientAppointmentID == PatientAppointmentID).FirstOrDefault();

            if (appointRecord != null)
            {
                var appStatus = this._uow.GenericRepository<AppointmentStatus>().Table().Where(x => x.Description.ToLower().Trim() == "cancelled").FirstOrDefault();

                appointRecord.AppointmentStatusCode = appStatus.Code;
                appointRecord.ModifiedDate = DateTime.Now;
                appointRecord.ModifiedBy = "User";

                this._uow.GenericRepository<PatientAppointment>().Update(appointRecord);
                this._uow.Save();

                status = "Cancelled Successfully";
            }
            else
            {
                status = "No record found";
            }

            return status;
        }


      



    }






}
