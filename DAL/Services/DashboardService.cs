using EndocPM.WebAPI.ViewModel.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace EndocPM.WebAPI
{
    public class DashboardService : IDashboardService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _MasterService;
        public readonly IAppointmentService _appointmentService;

        public DashboardService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService masterService, IAppointmentService appointmentService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _MasterService = masterService;
            _appointmentService = appointmentService;
        }



        public PatientcountModel getyearcalledBYpatientcount(int year)
        {

            List<PatientModel> queryPatients = (from p in this._uow.GenericRepository<Patient>().Table()
                                                select new
                                                {
                                                    PatientID = p.PatientID,
                                                    PatientSSN = p.PatientSSN,
                                                    NameLast = p.NameLast,
                                                    NameFirst = p.NameFirst,
                                                    NameMiddle = p.NameMiddle,
                                                    NamePrefix = p.NamePrefix,
                                                    NameSuffix = p.NameSuffix,
                                                    GenderID = p.GenderID,
                                                    BirthDate = p.BirthDate,
                                                    MaritalStatusID = p.MaritalStatusID,
                                                    RaceID = p.RaceID,
                                                    EthnicityID = p.EthnicityID,
                                                    LanguageID = p.LanguageID,
                                                    AddressLine1 = p.AddressLine1,
                                                    AddressLine2 = p.AddressLine2,
                                                    City = p.City,
                                                    State = p.State,
                                                    County = p.County,
                                                    ZIP = p.ZIP,
                                                    AddressEffectiveDate = p.AddressEffectiveDate,
                                                    AddressTermDate = p.AddressTermDate,
                                                    Country = p.County,
                                                    Phone = p.Phone,
                                                    AlternatePhone = p.AlternatePhone,
                                                    Email = p.Email,
                                                    MailAddressLine1 = p.MailAddressLine1,
                                                    MailAddressLine2 = p.MailAddressLine2,
                                                    MailCity = p.MailCity,
                                                    MailState = p.MailState,
                                                    MailCounty = p.MailCounty,
                                                    MailZIP = p.MailZIP,
                                                    MailCountry = p.MailCountry,
                                                    IsActive = p.IsActive,
                                                    PassportNo = p.PassportNo,
                                                    DrivingLicenseNo = p.DrivingLicenseNo,
                                                    Deleted = p.Deleted,
                                                    CreatedDate = p.CreatedDate,
                                                    CreatedBy = p.CreatedBy,
                                                    ModifiedDate = p.ModifiedDate,
                                                    ModifiedBy = p.ModifiedBy,
                                                    PatientAccountNumber = p.PatientAccountNumber,
                                                    SalutationID = p.SalutationID,
                                                    DeathDate = p.DeathDate,
                                                    CauseOfDeath = p.CauseOfDeath,
                                                    PreferredLanguageID = p.PreferredLanguageID,
                                                    MothersMaidenNameFirst = p.MothersMaidenNameFirst,
                                                    MothersMaidenNameLast = p.MothersMaidenNameLast,
                                                    MedicalRecordNumber = p.MedicalRecordNumber,
                                                    OtherEthnicity = p.OtherEthnicity,
                                                    OtherLanguage = p.OtherLanguage,
                                                    OtherRace = p.OtherRace,

                                                }).AsEnumerable().Select(x => new PatientModel
                                                {
                                                    PatientID = x.PatientID,
                                                    PatientSSN = x.PatientSSN,
                                                    NameLast = x.NameLast,
                                                    NameFirst = x.NameFirst,
                                                    NameMiddle = x.NameMiddle,
                                                    NamePrefix = x.NamePrefix,
                                                    NameSuffix = x.NameSuffix,
                                                    GenderID = x.GenderID,
                                                    BirthDate = x.BirthDate,
                                                    MaritalStatusID = x.MaritalStatusID,
                                                    RaceID = x.RaceID,
                                                    EthnicityID = x.EthnicityID,
                                                    LanguageID = x.LanguageID,
                                                    AddressLine1 = x.AddressLine1,
                                                    AddressLine2 = x.AddressLine2,
                                                    City = x.City,
                                                    State = x.State,
                                                    County = x.County,
                                                    ZIP = x.ZIP,
                                                    AddressEffectiveDate = x.AddressEffectiveDate,
                                                    AddressTermDate = x.AddressTermDate,
                                                    Country = x.County,
                                                    Phone = x.Phone,
                                                    AlternatePhone = x.AlternatePhone,
                                                    Email = x.Email,
                                                    MailAddressLine1 = x.MailAddressLine1,
                                                    MailAddressLine2 = x.MailAddressLine2,
                                                    MailCity = x.MailCity,
                                                    MailState = x.MailState,
                                                    MailCounty = x.MailCounty,
                                                    MailZIP = x.MailZIP,
                                                    MailCountry = x.MailCountry,
                                                    IsActive = x.IsActive,
                                                    PassportNo = x.PassportNo,
                                                    DrivingLicenseNo = x.DrivingLicenseNo,
                                                    Deleted = x.Deleted,
                                                    CreatedDate = x.CreatedDate,
                                                    CreatedBy = x.CreatedBy,
                                                    ModifiedDate = x.ModifiedDate,
                                                    ModifiedBy = x.ModifiedBy,
                                                    PatientAccountNumber = x.PatientAccountNumber,
                                                    SalutationID = x.SalutationID,
                                                    DeathDate = x.DeathDate,
                                                    CauseOfDeath = x.CauseOfDeath,
                                                    PreferredLanguageID = x.PreferredLanguageID,
                                                    MothersMaidenNameFirst = x.MothersMaidenNameFirst,
                                                    MothersMaidenNameLast = x.MothersMaidenNameLast,
                                                    MedicalRecordNumber = x.MedicalRecordNumber,
                                                    OtherEthnicity = x.OtherEthnicity,
                                                    OtherLanguage = x.OtherLanguage,
                                                    OtherRace = x.OtherRace,
                                                    Age = x.BirthDate != null ? (DateTime.Now - x.BirthDate.Value).Days / 365 : 0,
                                                }).ToList();
            var patientlist = queryPatients.Where(x => x.CreatedDate.Year == year).ToList();

            var patientLists = queryPatients.Where(x => x.CreatedDate.Year == year & x.IsActive == true).ToList();

            var PatientListss = queryPatients.Where(x => x.CreatedDate.Year == year).ToList();

            PatientcountModel Count = new PatientcountModel();

            Count.PatientTotalCount = patientlist.Count;
            Count.Patientactive = patientLists.Count;
            Count.newPatientCount = PatientListss.Count;
            Count.age = this._uow.GenericRepository<Patient>().Table().ToList();
            return Count;

        }

        public CountModel GetCount(SearchModel searchModel)
        {
            string date = searchModel.date;
            string viewMode = searchModel.viewMode;
            DateTime selectedDate = this._MasterService.GetLocalTime(Convert.ToDateTime(date));
            //DateTime selectedDate = Convert.ToDateTime(date);
            DateTime Fromdate = new DateTime();
            DateTime Todate = new DateTime();
            //DateTime CreatedDate = new DateTime();
            if (viewMode.ToLower().Trim() == "day")
            {
                Fromdate = Convert.ToDateTime(selectedDate.ToShortDateString());
                Todate = Fromdate.AddDays(1);
            }
            else if (viewMode.ToLower().Trim() == "week")
            {
                Fromdate = selectedDate.AddDays(selectedDate.DayOfWeek.GetHashCode() * -1);
                Todate = Fromdate.AddDays(7);
            }
            else if (viewMode.ToLower().Trim() == "month")
            {
                Fromdate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                Todate = Fromdate.AddMonths(1);
            }
            else if (viewMode.ToLower().Trim() == "year")
            {
                Fromdate = new DateTime(selectedDate.Year, 1, 1);
                Todate = new DateTime(selectedDate.Year, 12, 31);
            }
            else if (viewMode.ToLower().Trim() == "customrange")
            {
                Fromdate = searchModel.Fromdate;
                Todate = searchModel.Todate;
            }

            List<PatientAppointmentModel> appointments = new List<PatientAppointmentModel>();

            appointments = (from app in this._uow.GenericRepository<PatientAppointment>().Table()

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
                                //Appointmentime = PAM.AppointmentDate.ToString("hh:mm:ss tt"),
                                StartTime = PAM.AppointmentDate,
                                EndTime = (PAM.Duration != null && Convert.ToInt32(PAM.Duration) > 0) ? PAM.AppointmentDate.AddMinutes(Convert.ToInt32(PAM.Duration)) : PAM.AppointmentDate.AddMinutes(0),
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


            var patinetlist = this._uow.GenericRepository<Patient>().Table().ToList();






            var appointmentList = appointments.Where(x => x.AppointmentDate.Date >= Fromdate.Date && x.AppointmentDate.Date <= Todate).ToList();
            var patcount = patinetlist.Where(x => x.CreatedDate.Date >= Fromdate.Date && x.CreatedDate.Date <= Todate).ToList();


            CountModel count = new CountModel();

            count.Patientcount = patcount.Count();
            count.Appointmentcount = appointmentList.Count();

            return count;
        }

        public AppointmentDatemodel GetAppointmentfordate(DateTime date)
        {
            AppointmentDatemodel dateAppointment = new AppointmentDatemodel();
            var Appointmenttodaydate = this.GetAllAppointment().Where(x => x.AppointmentDate.Date == date).ToList();


            // List<PatientAppointmentModel> appoin= new List<PatientAppointmentModel>();


            var newrequest = (from appt in Appointmenttodaydate
                              join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                              on appt.AppointmentStatusCode equals status.Code
                              where status.Description.ToLower().Trim() == "requested"
                              select appt).ToList();

            var cancelled = (from appt in Appointmenttodaydate
                             join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                             on appt.AppointmentStatusCode equals status.Code
                             where status.Description.ToLower().Trim() == "cancelled"
                             select appt).ToList();


            var reshceduled = (from appt in Appointmenttodaydate
                               join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                               on appt.AppointmentStatusCode equals status.Code
                               where status.Description.ToLower().Trim() == "re-schedule"
                               select appt).ToList();

            var Arrived = (from appt in Appointmenttodaydate
                           join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                           on appt.AppointmentStatusCode equals status.Code
                           where status.Description.ToLower().Trim() == "arrived"
                           select appt).ToList();

            var Confirmed = (from appt in Appointmenttodaydate
                             join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                             on appt.AppointmentStatusCode equals status.Code
                             where status.Description.ToLower().Trim() == "confirmed"
                             select appt).ToList();

            var Deleted = (from appt in Appointmenttodaydate
                           join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                           on appt.AppointmentStatusCode equals status.Code
                           where status.Description.ToLower().Trim() == "deleted"
                           select appt).ToList();

            var NotArrived = (from appt in Appointmenttodaydate
                              join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                              on appt.AppointmentStatusCode equals status.Code
                              where status.Description.ToLower().Trim() == "not arrived"
                              select appt).ToList();

            var WaitingList = (from appt in Appointmenttodaydate
                               join status in this._uow.GenericRepository<AppointmentStatus>().Table()
                               on appt.AppointmentStatusCode equals status.Code
                               where status.Description.ToLower().Trim() == "waiting list"
                               select appt).ToList();






            dateAppointment.Cancelled = cancelled;
            dateAppointment.Newrequest = newrequest;
            dateAppointment.Reschedule = reshceduled;
            dateAppointment.Arrived = Arrived;
            dateAppointment.Confirmed = Confirmed;
            dateAppointment.Deleted = Deleted;
            dateAppointment.NotArrived = NotArrived;
            dateAppointment.WaitingList = WaitingList;



            return dateAppointment;

        }

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

        public List<Patient> getbypatientadultorchildren()
        {
            var patient = this._uow.GenericRepository<Patient>().Table().ToList();



            return patient;
        }

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
                                StartTime = PAM.StartTime,
                                EndTime = PAM.EndTime,
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


    }
}
