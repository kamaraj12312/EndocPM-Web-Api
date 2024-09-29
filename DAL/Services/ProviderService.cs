using EndocPM.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class ProviderService : IProviderService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _iMasterService;
        private IWebHostEnvironment _hostingEnvironment;

        //public string ConnectionString = ConfigurationManager.ConnectionStrings["EndocDataContext"].ConnectionString;
        public ProviderService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService iMasterService, IWebHostEnvironment hostingEnvironment)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _iMasterService = iMasterService;
            _hostingEnvironment = hostingEnvironment;
        }


        #region  ProviderModel by provider
        public ProviderModel ProvidersModel(int providerID)
        {

            if (providerID <= 0)
                return null;
            var Providers = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true && x.ProviderID == providerID)
                             join u in this._uow.GenericRepository<UserData>().Table()
                            on a.UserID equals u.UserID
                             select
                             new
                             {
                                 a.ProviderID,
                                 a.UserID,
                                 a.NPI,
                                 a.TaxID,
                                 a.Title,
                                 a.Fax,
                                 u.SSNID,
                                 a.GenderID,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.ZIP,
                                 a.City,
                                 a.State,
                                 a.County,
                                 a.Country,
                                 a.BillingAddressLine1,
                                 a.BillingAddressLine2,
                                 a.BillingZIP,
                                 a.BillingCity,
                                 a.BillingState,
                                 a.BillingCounty,
                                 a.BillingCountry,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.Deleted,
                                 a.BirthDate,
                                 a.UPIN,
                                 a.Phone,
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
                                 a.NameMiddle,
                                 a.NamePrefix,
                                 a.NameSuffix,
                                 a.PreferredLanguageID,
                                 a.FeeScheduleToUse,
                                 a.WebsiteName,
                                 a.PrimaryFacilityID,
                                 a.Biography,
                                 a.DoximityURL,
                                 a.LinkedinURL,
                                 a.TwitterURL


                             }).AsEnumerable().Select(ss => new ProviderModel
                             {
                                 ProviderID = ss.ProviderID,
                                 UserID = ss.UserID,
                                 NPI = ss.NPI,
                                 Fax = ss.Fax,
                                 TaxID = ss.TaxID,
                                 GenderID = ss.GenderID,
                                 GenderDescription = ss.GenderID != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.GenderID).FirstOrDefault().Description : "",
                                 ProviderSSN = ss.SSNID.ToString(),
                                 Title = ss.Title != null ? ss.Title : this._uow.GenericRepository<UserData>().Table().
                                            Where(x => x.UserID == ss.UserID).FirstOrDefault().Title,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 ZIP = ss.ZIP,
                                 City = ss.City,
                                 State = ss.State,
                                 County = ss.County,
                                 Country = ss.Country,
                                 BillingAddressLine1 = ss.BillingAddressLine1,
                                 BillingAddressLine2 = ss.BillingAddressLine2,
                                 BillingZIP = ss.BillingZIP,
                                 BillingCounty = ss.BillingCounty,
                                 BillingCountry = ss.BillingCountry,
                                 BillingState = ss.BillingState,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 Deleted = ss.Deleted,
                                 BirthDate = ss.BirthDate,
                                 BillingCity = ss.BillingCity,
                                 UPIN = ss.UPIN,
                                 Phone = ss.Phone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Credential = ss.Credential,
                                 Email = ss.Email,
                                 IsBillingForeign = ss.IsBillingForeign,
                                 IsForeign = ss.IsForeign,
                                 IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                 LanguageID = ss.LanguageID,
                                 LanguageDescription = ss.LanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.LanguageID).FirstOrDefault().Description : "",
                                 MedicaidID = ss.MedicaidID,
                                 MedicareID = ss.MedicareID,
                                 ModifiedBy = ss.ModifiedBy,
                                 ModifiedDate = ss.ModifiedDate,
                                 MothersMaidenName = ss.MothersMaidenName,
                                 NameFirst = ss.NameFirst,
                                 NameLast = ss.NameLast,
                                 NameMiddle = ss.NameMiddle,
                                 NamePrefix = ss.NamePrefix,
                                 NameSuffix = ss.NameSuffix,
                                 PreferredLanguageID = ss.PreferredLanguageID,
                                 PreferredLanguageDescription = ss.PreferredLanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.PreferredLanguageID).FirstOrDefault().Description : "",
                                 FeeScheduleToUse = ss.FeeScheduleToUse,
                                 FeeScheduleDescription = ss.FeeScheduleToUse > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.FeeScheduleToUse).FirstOrDefault().Description : "",
                                 PrimaryFacilityID = ss.PrimaryFacilityID,
                                 PrimaryFacilityName = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == ss.PrimaryFacilityID.Value).FirstOrDefault().FacilityName : "",
                                 WebsiteName = ss.WebsiteName,
                                 Biography = ss.Biography,
                                 DoximityURL = ss.DoximityURL,
                                 LinkedinURL = ss.LinkedinURL,
                                 TwitterURL = ss.TwitterURL,
                                 PrimaryFacilityAddress = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this.FacilityAddress(ss.PrimaryFacilityID.Value) : "",
                                 providerLocationsModels = this.GetProviderLocationsbyProviderId(ss.ProviderID),
                                 providerStateLicenseModels = this.providerStateLicenseModelbyProvider(ss.ProviderID),
                                 providerVacationModels = this.providerVacationsbyproviderID(ss.ProviderID),
                                 providerInsuranceModels = this.GetProviderInsurancesbyProviderID(ss.ProviderID),
                                 providerAwardsandRecognitionModels = this.GetProviderAwardsAndRecognitionModelByProviderID(ss.ProviderID),
                                 ProviderPhoto = this.GetFile(ss.ProviderID.ToString(), "Provider").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Provider") : new List<clsViewFile>(),
                                 ProviderSignature = this.GetFile(ss.ProviderID.ToString(), "Providersignature").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Providersignature") : new List<clsViewFile>()


                             }).FirstOrDefault();

            return Providers;
        }

        #endregion

        #region Get Provider Photo
        public List<clsViewFile> GetFile(string Id, string screen)
        {
            string moduleName = "";
            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            //if (hostingEnvironment.WebRootPath != null)
            moduleName = _hostingEnvironment.WebRootPath + "\\Documents\\" + screen + "\\" + Id;

            var fileLoc = this.GetFiles(moduleName);

            return fileLoc;
        }
        public List<clsViewFile> GetFiles(string modulePath)
        {
            List<clsViewFile> viewLst = new List<clsViewFile>();
            try
            {
                const string DefaultContentType = "application/octet-stream";
                if (Directory.Exists(modulePath))
                {
                    string[] fileEntries = Directory.GetFiles(modulePath);

                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        clsViewFile vwFile = new clsViewFile();
                        FileInfo file = new FileInfo(fileEntries[i]);
                        FileStream reader = new FileStream(fileEntries[i], FileMode.Open, FileAccess.Read);

                        var provider = new FileExtensionContentTypeProvider();
                        if (!provider.TryGetContentType(fileEntries[i], out string contentType))
                        {
                            contentType = DefaultContentType;
                        }

                        vwFile.FileUrl = fileEntries[i].Replace("\\", "/");
                        vwFile.FileName = Path.GetFileName(fileEntries[i]);
                        vwFile.FileType = contentType;
                        vwFile.FileSize = Convert.ToString(file.Length / 1024) + " KB";

                        byte[] buffer = new byte[reader.Length];
                        reader.Read(buffer, 0, (int)reader.Length);
                        reader.ReadByte();
                        var b = Convert.ToBase64String(buffer);
                        vwFile.ActualFile = b;
                        viewLst.Add(vwFile);
                        reader.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return viewLst;
        }
        #endregion

        #region GetProviderLocationsbyProviderId
        public List<ProviderLocationsModel> GetProviderLocationsbyProviderId(int ProviderID)
        {
            var location = (from a in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == ProviderID && x.Deleted != true)
                            join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID
                            // join c in this._uow.GenericRepository<SchedulerSetup>().Table() on a.FacilityID equals c.FacilityID
                            select
                            new
                            {
                                a.ProviderID,
                                a.ProviderLocationID,
                                a.EffectiveDate,
                                a.CreatedBy,
                                a.CreatedDate,
                                a.ModifiedBy,
                                a.ModifiedDate,
                                a.FacilityID,
                                a.TerminationDate,
                                a.Deleted,

                            }).AsEnumerable().Select(x => new ProviderLocationsModel
                            {
                                ProviderID = x.ProviderID,
                                ProviderLocationID = x.ProviderLocationID,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                Deleted = x.Deleted,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                EffectiveDate = x.EffectiveDate,
                                TerminationDate = x.TerminationDate,
                                FacilityID = x.FacilityID,
                                FacilityName = getbyfacilityname(x.FacilityID),
                                locationTimings = this.GetProviderLocationTimings(x.ProviderLocationID)
                            }).ToList();
            return location;
        }
        #endregion

        #region providerStateLicenseModelbyProvider
        public List<ProviderStateLicenseModel> providerStateLicenseModelbyProvider(int ProviderID)
        {
            var StateLincense = (from a in this._uow.GenericRepository<ProviderStateLicense>().Table().Where(x => x.ProviderID == ProviderID && x.Deleted != true)
                                 join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID

                                 select
                                 new
                                 {
                                     ProviderStateLicenseID = a.ProviderStateLicenseID,
                                     a.ProviderID,
                                     a.StateCode,
                                     a.LicenseNumber,
                                     a.EffectiveDate,
                                     a.TerminationDate,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedBy,
                                     a.ModifiedDate,

                                 }).AsEnumerable().Select(ss => new ProviderStateLicenseModel
                                 {
                                     ProviderStateLicenseID = ss.ProviderStateLicenseID,
                                     ProviderID = ss.ProviderID,
                                     StateCode = ss.StateCode,
                                     LicenseNumber = ss.LicenseNumber,
                                     EffectiveDate = ss.EffectiveDate,
                                     TerminationDate = ss.TerminationDate,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedBy = ss.ModifiedBy,
                                     ModifiedDate = ss.ModifiedDate,
                                 }).ToList();
            return StateLincense;

        }
        #endregion

        #region schedulerSetupModelsByFacility
        public List<SchedulerSetupModel> schedulerSetupModelsByFacility(int Facility)
        {
            var Scheduler = (from a in this._uow.GenericRepository<SchedulerSetup>().Table().Where(x => x.FacilityID == Facility && x.Deleted != true)
                             join b in this._uow.GenericRepository<ProviderLocation>().Table() on a.FacilityID equals b.FacilityID
                             select
                             new
                             {
                                 a.FacilityID,
                                 a.SchedulerSetupID,
                                 a.SchedulerStartTime,
                                 a.SchedulerEndTime,
                                 a.NumberOfSlotsPerHour,
                                 a.VacationColor,
                                 a.OutOfOfficeColor,
                                 a.LeaveColor,
                                 a.HolidayColor,
                                 a.AllowAppInNonScheduledTime,
                                 a.AllowReminder,
                                 a.EffectiveDate,
                                 a.TerminationDate,
                                 a.Deleted,
                                 a.CreatedDate,
                                 a.CreatedBy,
                                 a.ModifiedBy,
                                 a.ModifiedDate,
                                 a.NoOfWaitingPerDay,
                                 a.IsCancelPastWaitingOfAppointment,
                                 a.IsCommon,
                                 a.CancelPastWaitingOfAppointment

                             }).AsEnumerable().Select(x => new SchedulerSetupModel
                             {
                                 FacilityID = x.FacilityID,
                                 SchedulerSetupID = x.SchedulerSetupID,
                                 SchedulerStartTime = x.SchedulerStartTime,
                                 SchedulerEndTime = x.SchedulerEndTime,
                                 NumberOfSlotsPerHour = x.NumberOfSlotsPerHour,
                                 VacationColor = x.VacationColor,
                                 OutOfOfficeColor = x.OutOfOfficeColor,
                                 LeaveColor = x.LeaveColor,
                                 HolidayColor = x.HolidayColor,
                                 AllowAppInNonScheduledTime = x.AllowAppInNonScheduledTime,
                                 AllowReminder = x.AllowReminder,
                                 EffectiveDate = x.EffectiveDate,
                                 TerminationDate = x.TerminationDate,
                                 Deleted = x.Deleted,
                                 CreatedDate = x.CreatedDate,
                                 CreatedBy = x.CreatedBy,
                                 ModifiedBy = x.ModifiedBy,
                                 ModifiedDate = x.ModifiedDate,
                                 NoOfWaitingPerDay = x.NoOfWaitingPerDay,
                                 IsCancelPastWaitingOfAppointment = x.IsCancelPastWaitingOfAppointment,
                                 IsCommon = x.IsCommon,
                                 CancelPastWaitingOfAppointment = x.CancelPastWaitingOfAppointment

                             }).ToList();
            return Scheduler;


        }
        #endregion

        #region providerVacationsbyproviderID
        public List<ProviderVacationModel> providerVacationsbyproviderID(int ProviderID)
        {
            var vacation = (from e in this._uow.GenericRepository<ProviderVacation>().Table().Where(x => x.ProviderID == ProviderID && x.Deleted != true)
                            join f in this._uow.GenericRepository<Provider>().Table() on e.ProviderID equals f.ProviderID
                            select
                            new
                            {
                                e.ProviderVacationID,
                                e.ProviderID,
                                e.StartDate,
                                e.EndDate,
                                e.Reason,
                                e.Deleted,
                                e.CreatedDate,
                                e.CreatedBy,
                                e.ModifiedBy,
                                e.ModifiedDate,
                            }
                          ).AsEnumerable().Select(ss => new ProviderVacationModel
                          {
                              ProviderVacationID = ss.ProviderVacationID,
                              ProviderID = ss.ProviderID,
                              StartDate = ss.StartDate,
                              EndDate = ss.EndDate,
                              Reason = ss.Reason,
                              Deleted = ss.Deleted,
                              CreatedDate = ss.CreatedDate,
                              CreatedBy = ss.CreatedBy,
                              ModifiedBy = ss.ModifiedBy,
                              ModifiedDate = ss.ModifiedDate
                          }).ToList();
            return vacation;
        }
        public List<ProviderVacationModel> GetvacationDatesForCalendar(string viewMode, string date, int providerId)
        {
            List<ProviderVacationModel> providerVacationRecords = new List<ProviderVacationModel>();
            DateTime selectedDate = this._iMasterService.GetLocalTime(Convert.ToDateTime(date));

            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (viewMode.ToLower().Trim() == "day")
            {
                startDate = Convert.ToDateTime(selectedDate.ToShortDateString());
                endDate = startDate;
            }
            else if (viewMode.ToLower().Trim() == "week")
            {
                startDate = selectedDate.AddDays(selectedDate.DayOfWeek.GetHashCode() * -1);
                endDate = startDate.AddDays(6);
            }
            else if (viewMode.ToLower().Trim() == "month")
            {
                startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                endDate = startDate.AddMonths(1);
            }

            var vacationRecords = (from pv in this._uow.GenericRepository<ProviderVacation>().Table()
                                       .Where(x => x.ProviderID == providerId)
                                   select pv).ToList();

            var records = vacationRecords.Count() > 0 ? vacationRecords.Where(x => x.StartDate.Value.Date >= startDate.Date & x.EndDate.Value.Date <= endDate.Date).ToList() : new List<ProviderVacation>();

            if (vacationRecords.Count() > 0)
            {

                foreach (var record in vacationRecords)
                {
                    ProviderVacationModel vacateModel = new ProviderVacationModel();

                    vacateModel.ProviderVacationID = record.ProviderVacationID;
                    vacateModel.ProviderID = record.ProviderID;
                    //vacateModel.StartDate = record.StartDate;
                    vacateModel.StartDate = viewMode.ToLower().Trim() == "day" ? record.StartDate.Value.AddMinutes(1): record.StartDate;
                    vacateModel.EndDate = record.EndDate.Value.AddMinutes(-1);
                    vacateModel.Reason = record.Reason;

                    providerVacationRecords.Add(vacateModel);
                }
            }

            return providerVacationRecords;
        }

        #endregion

        #region GetProviderInsurancesbyProviderID
        public List<ProviderInsuranceModel> GetProviderInsurancesbyProviderID(int ProviderID)
        {
            var Insurance = (from a in this._uow.GenericRepository<ProviderInsurance>().Table().Where(x => x.ProviderID == ProviderID && x.Deleted != true)
                             join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID
                             select
                             new
                             {
                                 a.ProviderInsuranceID,
                                 a.ProviderID,
                                 a.InsuranceCompanyID,
                                 a.InsuranceID,
                                 a.EffectiveDate,
                                 a.TerminationDate,
                                 a.Deleted,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.ModifiedDate,
                                 a.ModifiedBy,
                                 a.InsurancePaymentTypeID,
                                 a.SpecialityID,
                                 a.TaxonomyCode,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.City,
                                 a.State,
                                 a.Country,
                                 a.ZIP,
                                 a.County,
                                 a.Telephone,
                                 a.AlternatePhone,
                                 a.Fax,
                                 a.Email,
                                 a.InsuranceCategoryID
                             }).AsEnumerable().Select(ss => new ProviderInsuranceModel
                             {
                                 ProviderInsuranceID = ss.ProviderInsuranceID,
                                 ProviderID = ss.ProviderID,
                                 InsuranceCompanyID = ss.InsuranceCompanyID,
                                 InsuranceID = ss.InsuranceID,
                                 EffectiveDate = ss.EffectiveDate,
                                 TerminationDate = ss.TerminationDate,
                                 Deleted = ss.Deleted,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 ModifiedDate = ss.ModifiedDate,
                                 ModifiedBy = ss.ModifiedBy,
                                 InsurancePaymentTypeID = ss.InsurancePaymentTypeID,
                                 SpecialityID = ss.SpecialityID,
                                 TaxonomyCode = ss.TaxonomyCode,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 City = ss.City,
                                 State = ss.State,
                                 Country = ss.Country,
                                 ZIP = ss.ZIP,
                                 County = ss.County,
                                 Telephone = ss.Telephone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Fax = ss.Fax,
                                 Email = ss.Email,
                                 InsuranceCompanyName = ss.InsuranceCompanyID > 0 ? this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => x.InsuranceCompanyID == ss.InsuranceCompanyID).FirstOrDefault().OrganizationName : "",
                                 InsurancePaymentTypeDescription = ss.InsurancePaymentTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.InsurancePaymentTypeID).FirstOrDefault().Description : "",
                                 InsuranceCategoryDescription = ss.InsuranceCategoryID > 0 ? this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => x.InsuranceCategoryID == ss.InsuranceCategoryID).FirstOrDefault().Description : "",
                             }).ToList();

            return Insurance;

        }


        #endregion

        #region Get ProviderModel
        public List<ProviderModel> ProviderModel()
        {
            var Providers = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true)
                             join u in this._uow.GenericRepository<UserData>().Table()
                             on a.UserID equals u.UserID
                             select
                             new
                             {
                                 a.ProviderID,
                                 a.UserID,
                                 a.NPI,
                                 a.TaxID,
                                 a.Title,
                                 a.Fax,
                                 u.SSNID,
                                 a.GenderID,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.ZIP,
                                 a.County,
                                 a.Country,
                                 a.City,
                                 a.State,
                                 a.BillingAddressLine1,
                                 a.BillingAddressLine2,
                                 a.BillingState,
                                 a.BillingZIP,
                                 a.BillingCountry,
                                 a.BillingCounty,
                                 a.BillingCity,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.Deleted,
                                 a.BirthDate,
                                 a.UPIN,
                                 a.Phone,
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
                                 a.NameMiddle,
                                 a.NamePrefix,
                                 a.NameSuffix,
                                 a.PreferredLanguageID,
                                 a.FeeScheduleToUse,
                                 a.WebsiteName,
                                 a.PrimaryFacilityID,
                                 a.Biography,
                                 a.DoximityURL,
                                 a.LinkedinURL,
                                 a.TwitterURL

                             }).AsEnumerable().Select(ss => new ProviderModel
                             {
                                 ProviderID = ss.ProviderID,
                                 UserID = ss.UserID,
                                 NPI = ss.NPI,
                                 Fax = ss.Fax,
                                 TaxID = ss.TaxID,
                                 GenderID = ss.GenderID,
                                 GenderDescription = ss.GenderID != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.GenderID).FirstOrDefault().Description : "",
                                 ProviderSSN = ss.SSNID.ToString(),
                                 Title = ss.Title,  
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 ZIP = ss.ZIP,
                                 City = ss.City,
                                 State = ss.State,
                                 County = ss.County,
                                 Country = ss.Country,
                                 BillingAddressLine1 = ss.BillingAddressLine1,
                                 BillingAddressLine2 = ss.BillingAddressLine2,
                                 BillingZIP = ss.BillingZIP,
                                 BillingCity = ss.BillingCity,
                                 BillingCounty = ss.BillingCounty,
                                 BillingCountry = ss.BillingCountry,
                                 BillingState = ss.BillingState,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 Deleted = ss.Deleted,
                                 BirthDate = ss.BirthDate,
                                 UPIN = ss.UPIN,
                                 Phone = ss.Phone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Credential = ss.Credential,
                                 Email = ss.Email,
                                 IsBillingForeign = ss.IsBillingForeign,
                                 IsForeign = ss.IsForeign,
                                 IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                 LanguageID = ss.LanguageID,
                                 LanguageDescription = ss.LanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.LanguageID).FirstOrDefault().Description : "",
                                 MedicaidID = ss.MedicaidID,
                                 MedicareID = ss.MedicareID,
                                 ModifiedBy = ss.ModifiedBy,
                                 ModifiedDate = ss.ModifiedDate,
                                 MothersMaidenName = ss.MothersMaidenName,
                                 NameFirst = ss.NameFirst,
                                 NameLast = ss.NameLast,
                                 NameMiddle = ss.NameMiddle,
                                 NamePrefix = ss.NamePrefix,
                                 NameSuffix = ss.NameSuffix,
                                 PreferredLanguageID = ss.PreferredLanguageID,
                                 PreferredLanguageDescription = ss.PreferredLanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.PreferredLanguageID).FirstOrDefault().Description : "",
                                 FeeScheduleToUse = ss.FeeScheduleToUse,
                                 FeeScheduleDescription = ss.FeeScheduleToUse > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.FeeScheduleToUse).FirstOrDefault().Description : "",
                                 PrimaryFacilityID = ss.PrimaryFacilityID,
                                 PrimaryFacilityName = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == ss.PrimaryFacilityID.Value).FirstOrDefault().FacilityName : "",
                                 WebsiteName = ss.WebsiteName,
                                 Biography = ss.Biography,
                                 DoximityURL = ss.DoximityURL,
                                 LinkedinURL = ss.LinkedinURL,
                                 TwitterURL = ss.TwitterURL,
                                 PrimaryFacilityAddress = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this.FacilityAddress(ss.PrimaryFacilityID.Value) : "",
                                 ProviderPhoto = this.GetFile(ss.ProviderID.ToString(), "Provider").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Provider") : new List<clsViewFile>(),
                                 ProviderSignature = this.GetFile(ss.ProviderID.ToString(), "Providersignature").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Providersignature") : new List<clsViewFile>()

                             }).ToList();
            return Providers;
        }
        #endregion

        #region GetProviderLocations
        public List<ProviderLocationsModel> GetProviderLocations()
        {
            var location = (from a in this._uow.GenericRepository<ProviderLocation>().Table()
                            join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID
                            select
                            new
                            {

                                a.ProviderID,
                                a.ProviderLocationID,
                                a.EffectiveDate,
                                a.CreatedBy,
                                a.CreatedDate,
                                a.ModifiedBy,
                                a.ModifiedDate,
                                a.FacilityID,
                                a.TerminationDate,
                                a.Deleted,

                            }).AsEnumerable().Select(x => new ProviderLocationsModel
                            {

                                ProviderID = x.ProviderID,
                                ProviderLocationID = x.ProviderLocationID,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                Deleted = x.Deleted,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                FacilityID = x.FacilityID,
                                FacilityName = getbyfacilityname(x.FacilityID),
                                EffectiveDate = x.EffectiveDate,
                                TerminationDate = x.TerminationDate,
                                locationTimings = this.GetProviderLocationTimings(x.ProviderLocationID),
                                BookingPerDay = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().BookingPerDay : 0,//x.BookingPerDay,
                                BookingPerSlot = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().BookingPerSlot : 0,// x.BookingPerSlot,
                                TimeSlotDuration = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().TimeSlotDuration : 0,// x.TimeSlotDuration,
                                RegularWorkHrsFrom = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().RegularWorkHrsFrom : "",//x.RegularWorkHrsFrom
                                RegularWorkHrsTo = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().RegularWorkHrsTo : "",//x.RegularWorkHrsTo
                            }).ToList();

            return location;
        }

        #endregion

        #region Get SchedulerSetups
        public List<SchedulerSetupModel> SchedulerSetups()
        {
            var scheduler = (from s in this._uow.GenericRepository<SchedulerSetup>().Table().Where(x => x.Deleted != true)
                             select
                             new
                             {
                                 s.SchedulerSetupID,
                                 s.FacilityID,
                                 s.SchedulerStartTime,
                                 s.SchedulerEndTime,
                                 s.NumberOfSlotsPerHour,
                                 s.VacationColor,
                                 s.OutOfOfficeColor,
                                 s.LeaveColor,
                                 s.HolidayColor,
                                 s.AllowAppInNonScheduledTime,
                                 s.AllowReminder,
                                 s.EffectiveDate,
                                 s.TerminationDate,
                                 s.Deleted,
                                 s.CreatedDate,
                                 s.CreatedBy,
                                 s.ModifiedBy,
                                 s.ModifiedDate,
                                 s.NoOfWaitingPerDay,
                                 s.IsCancelPastWaitingOfAppointment,
                                 s.IsCommon,
                                 s.CancelPastWaitingOfAppointment,

                             }).AsEnumerable().Select(ss => new SchedulerSetupModel
                             {
                                 FacilityID = ss.FacilityID,
                                 EffectiveDate = ss.EffectiveDate,
                                 TerminationDate = ss.TerminationDate,
                                 SchedulerEndTime = ss.SchedulerEndTime,
                                 SchedulerStartTime = ss.SchedulerStartTime,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 ModifiedDate = ss.ModifiedDate
                             }).ToList();
            return scheduler;

        }
        #endregion

        #region providerVacations
        public List<ProviderVacationModel> providerVacations()
        {
            var vacation = (from e in this._uow.GenericRepository<ProviderVacation>().Table().Where(x => x.Deleted != true)
                            select
                            new
                            {
                                e.ProviderVacationID,
                                e.ProviderID,
                                e.StartDate,
                                e.EndDate,
                                e.Reason,
                                e.Deleted,
                                e.CreatedDate,
                                e.CreatedBy,
                                e.ModifiedBy,
                                e.ModifiedDate,
                            }
                           ).AsEnumerable().Select(ss => new ProviderVacationModel
                           {
                               ProviderVacationID = ss.ProviderVacationID,
                               ProviderID = ss.ProviderID,
                               StartDate = ss.StartDate,
                               EndDate = ss.EndDate,
                               Reason = ss.Reason,
                               Deleted = ss.Deleted,
                               CreatedDate = ss.CreatedDate,
                               CreatedBy = ss.CreatedBy,
                               ModifiedBy = ss.ModifiedBy,
                               ModifiedDate = ss.ModifiedDate
                           }).ToList();
            return vacation;

        }
        #endregion

        #region providerStateLincenses
        public List<ProviderStateLicenseModel> providerStateLincenses()
        {
            var StateLincense = (from a in this._uow.GenericRepository<ProviderStateLicense>().Table().Where(x => x.Deleted != true)
                                 select
                                 new
                                 {
                                     a.ProviderStateLicenseID,
                                     a.ProviderID,
                                     a.StateCode,
                                     a.LicenseNumber,
                                     a.EffectiveDate,
                                     a.TerminationDate,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedBy,
                                     a.ModifiedDate,

                                 }).AsEnumerable().Select(ss => new ProviderStateLicenseModel
                                 {
                                     ProviderStateLicenseID = ss.ProviderStateLicenseID,
                                     ProviderID = ss.ProviderID,
                                     StateCode = ss.StateCode,
                                     LicenseNumber = ss.LicenseNumber,
                                     EffectiveDate = ss.EffectiveDate,
                                     TerminationDate = ss.TerminationDate,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedBy = ss.ModifiedBy,
                                     ModifiedDate = ss.ModifiedDate,
                                 }).ToList();
            return StateLincense;
        }
        #endregion

        #region GetProviderInsurances
        public List<ProviderInsuranceModel> GetProviderInsurances()
        {
            var Insurance = (from a in this._uow.GenericRepository<ProviderInsurance>().Table().Where(x => x.Deleted != true)
                             select
                             new
                             {
                                 a.ProviderInsuranceID,
                                 a.ProviderID,
                                 a.InsuranceCompanyID,
                                 a.InsuranceID,
                                 a.EffectiveDate,
                                 a.TerminationDate,
                                 a.Deleted,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.ModifiedDate,
                                 a.ModifiedBy,
                                 a.InsurancePaymentTypeID,
                                 a.SpecialityID,
                                 a.TaxonomyCode,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.City,
                                 a.State,
                                 a.Country,
                                 a.ZIP,
                                 a.County,
                                 a.Telephone,
                                 a.AlternatePhone,
                                 a.Fax,
                                 a.Email,
                                 a.InsuranceCategoryID
                             }).AsEnumerable().Select(ss => new ProviderInsuranceModel
                             {
                                 ProviderInsuranceID = ss.ProviderInsuranceID,
                                 ProviderID = ss.ProviderID,
                                 InsuranceCompanyID = ss.InsuranceCompanyID,
                                 InsuranceID = ss.InsuranceID,
                                 EffectiveDate = ss.EffectiveDate,
                                 TerminationDate = ss.TerminationDate,
                                 Deleted = ss.Deleted,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 ModifiedDate = ss.ModifiedDate,
                                 ModifiedBy = ss.ModifiedBy,
                                 InsurancePaymentTypeID = ss.InsurancePaymentTypeID,
                                 SpecialityID = ss.SpecialityID,
                                 TaxonomyCode = ss.TaxonomyCode,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 City = ss.City,
                                 State = ss.State,
                                 Country = ss.Country,
                                 ZIP = ss.ZIP,
                                 County = ss.County,
                                 Telephone = ss.Telephone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Fax = ss.Fax,
                                 Email = ss.Email,
                                 InsuranceCompanyName = ss.InsuranceCompanyID > 0 ? this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => x.InsuranceCompanyID == ss.InsuranceCompanyID).FirstOrDefault().OrganizationName : "",
                                 InsurancePaymentTypeDescription = ss.InsurancePaymentTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.InsurancePaymentTypeID).FirstOrDefault().Description : "",
                                 InsuranceCategoryDescription = ss.InsuranceCategoryID > 0 ? this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => x.InsuranceCategoryID == ss.InsuranceCategoryID).FirstOrDefault().Description : "",

                             }).ToList();

            return Insurance;
        }
        #endregion

        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModels()
        {
            var Awards = (from a in this._uow.GenericRepository<ProviderAwardsAndRecognition>().Table().Where(x => x.Deleted != true)
                          select
                          new
                          {
                              a.ProviderID,
                              a.ProviderAwardsAndRecognitionID,
                              a.Description,
                              a.DateFrom,
                              a.RecognizedBy,
                              a.Deleted,
                              a.CreatedDate,
                              a.CreatedBy,
                              a.ModifiedBy,
                              a.ModifiedDate
                          }).AsEnumerable().Select(xx => new ProviderAwardsAndRecognitionModel
                          {
                              ProviderID = xx.ProviderID,
                              ProviderAwardsAndRecognitionID = xx.ProviderAwardsAndRecognitionID,
                              Description = xx.Description,
                              DateFrom = xx.DateFrom,
                              RecognizedBy = xx.RecognizedBy,
                              Deleted = xx.Deleted,
                              CreatedDate = xx.CreatedDate,
                              CreatedBy = xx.CreatedBy,
                              ModifiedBy = xx.ModifiedBy,
                              ModifiedDate = xx.ModifiedDate
                          }).ToList();

            return Awards;
        }

        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModelByProviderID(int ProviderID)
        {
            var Awards = (from a in this._uow.GenericRepository<ProviderAwardsAndRecognition>().Table().Where(x => x.Deleted != true && x.ProviderID == ProviderID)
                          join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID
                          select
                          new
                          {
                              a.ProviderID,
                              a.ProviderAwardsAndRecognitionID,
                              a.Description,
                              a.DateFrom,
                              a.RecognizedBy,
                              a.Deleted,
                              a.CreatedDate,
                              a.CreatedBy,
                              a.ModifiedBy,
                              a.ModifiedDate
                          }).AsEnumerable().Select(xx => new ProviderAwardsAndRecognitionModel
                          {
                              ProviderID = xx.ProviderID,
                              ProviderAwardsAndRecognitionID = xx.ProviderAwardsAndRecognitionID,
                              Description = xx.Description,
                              DateFrom = xx.DateFrom,
                              RecognizedBy = xx.RecognizedBy,
                              Deleted = xx.Deleted,
                              CreatedDate = xx.CreatedDate,
                              CreatedBy = xx.CreatedBy,
                              ModifiedBy = xx.ModifiedBy,
                              ModifiedDate = xx.ModifiedDate
                          }).ToList();

            return Awards;
        }

        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModel(int ProviderAwardsAndRecognitionID)
        {
            var Awards = (from a in this._uow.GenericRepository<ProviderAwardsAndRecognition>().Table().Where(x => x.Deleted != true && x.ProviderAwardsAndRecognitionID == ProviderAwardsAndRecognitionID)
                          join b in this._uow.GenericRepository<Provider>().Table()
                                on a.ProviderID equals b.ProviderID
                          select
                          new
                          {
                              a.ProviderID,
                              a.ProviderAwardsAndRecognitionID,
                              a.Description,
                              a.DateFrom,
                              a.RecognizedBy,
                              a.Deleted,
                              a.CreatedDate,
                              a.CreatedBy,
                              a.ModifiedBy,
                              a.ModifiedDate
                          }).AsEnumerable().Select(xx => new ProviderAwardsAndRecognitionModel
                          {
                              ProviderID = xx.ProviderID,
                              ProviderAwardsAndRecognitionID = xx.ProviderAwardsAndRecognitionID,
                              Description = xx.Description,
                              DateFrom = xx.DateFrom,
                              RecognizedBy = xx.RecognizedBy,
                              Deleted = xx.Deleted,
                              CreatedDate = xx.CreatedDate,
                              CreatedBy = xx.CreatedBy,
                              ModifiedBy = xx.ModifiedBy,
                              ModifiedDate = xx.ModifiedDate
                          }).ToList();

            return Awards;
        }

        #region GetProviderLocation called on single providerLocationID
        public List<ProviderLocationsModel> GetProviderLocationByproviderlocationID(int ProviderLocationID)
        {
            var location = (from a in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderLocationID == ProviderLocationID)
                            join b in this._uow.GenericRepository<Provider>().Table() on a.ProviderID equals b.ProviderID
                            //join c in this._uow.GenericRepository<SchedulerSetup>().Table() on a.FacilityID equals c.FacilityID
                            select
                            new
                            {
                                a.ProviderID,
                                a.ProviderLocationID,
                                a.EffectiveDate,
                                a.CreatedBy,
                                a.CreatedDate,
                                a.ModifiedBy,
                                a.ModifiedDate,
                                a.FacilityID,
                                a.TerminationDate,
                                a.Deleted,

                            }).AsEnumerable().Select(x => new ProviderLocationsModel
                            {
                                ProviderID = x.ProviderID,
                                ProviderLocationID = x.ProviderLocationID,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                Deleted = x.Deleted,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                FacilityID = x.FacilityID,
                                EffectiveDate = x.EffectiveDate,
                                TerminationDate = x.TerminationDate,
                                locationTimings = this.GetProviderLocationTimings(x.ProviderLocationID),
                                BookingPerDay = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().BookingPerDay : 0,//x.BookingPerDay,
                                BookingPerSlot = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().BookingPerSlot : 0,// x.BookingPerSlot,
                                TimeSlotDuration = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().TimeSlotDuration : 0,// x.TimeSlotDuration,
                                RegularWorkHrsFrom = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().RegularWorkHrsFrom : "",//x.RegularWorkHrsFrom
                                RegularWorkHrsTo = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault() != null ?
                                                this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(k => k.ProviderLocationID == x.ProviderLocationID).FirstOrDefault().RegularWorkHrsTo : "",//x.RegularWorkHrsTo
                            }).ToList();
            return location;
            #endregion
        }
        #region SchedulerSetupss called on single SchedulerSetupID
        public List<SchedulerSetupModel> SchedulerSetupsByschedulersetup(int SchedulerSetupID)
        {
            var scheduler = (from s in this._uow.GenericRepository<SchedulerSetup>().Table().Where(x => x.Deleted != true && x.SchedulerSetupID == SchedulerSetupID)
                             select
                             new
                             {
                                 s.SchedulerSetupID,
                                 s.FacilityID,
                                 s.SchedulerStartTime,
                                 s.SchedulerEndTime,
                                 s.NumberOfSlotsPerHour,
                                 s.VacationColor,
                                 s.OutOfOfficeColor,
                                 s.LeaveColor,
                                 s.HolidayColor,
                                 s.AllowAppInNonScheduledTime,
                                 s.AllowReminder,
                                 s.EffectiveDate,
                                 s.TerminationDate,
                                 s.Deleted,
                                 s.CreatedDate,
                                 s.CreatedBy,
                                 s.ModifiedBy,
                                 s.ModifiedDate,
                                 s.NoOfWaitingPerDay,
                                 s.IsCancelPastWaitingOfAppointment,
                                 s.IsCommon,
                                 s.CancelPastWaitingOfAppointment,

                             }).AsEnumerable().Select(ss => new SchedulerSetupModel
                             {
                                 FacilityID = ss.FacilityID,
                                 EffectiveDate = ss.EffectiveDate,
                                 TerminationDate = ss.TerminationDate,
                                 SchedulerEndTime = ss.SchedulerEndTime,
                                 SchedulerStartTime = ss.SchedulerStartTime,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 ModifiedDate = ss.ModifiedDate
                             }).ToList();
            return scheduler;

        }
        #endregion

        #region ProviderVacation single called ProviderVacationID
        public List<ProviderVacationModel> GetproviderVacationByproviderVacationID(int ProviderVacationID)
        {
            var vacation = (from e in this._uow.GenericRepository<ProviderVacation>().Table().Where(x => x.Deleted != true && x.ProviderVacationID == ProviderVacationID)
                            select
                            new
                            {
                                e.ProviderVacationID,
                                e.ProviderID,
                                e.StartDate,
                                e.EndDate,
                                e.Reason,
                                e.Deleted,
                                e.CreatedDate,
                                e.CreatedBy,
                                e.ModifiedBy,
                                e.ModifiedDate,
                            }
                         ).AsEnumerable().Select(ss => new ProviderVacationModel
                         {
                             ProviderVacationID = ss.ProviderVacationID,
                             ProviderID = ss.ProviderID,
                             StartDate = ss.StartDate,
                             EndDate = ss.EndDate,
                             Reason = ss.Reason,
                             Deleted = ss.Deleted,
                             CreatedDate = ss.CreatedDate,
                             CreatedBy = ss.CreatedBy,
                             ModifiedBy = ss.ModifiedBy,
                             ModifiedDate = ss.ModifiedDate
                         }).ToList();
            return vacation;
        }

        #endregion

        #region Providersatatelincense called single providerlincenseID
        public List<ProviderStateLicenseModel> GetproviderStateLincensesByStatelincenseID(int ProviderStateLicenseID)
        {

            var StateLincense = (from a in this._uow.GenericRepository<ProviderStateLicense>().Table().Where(x => (x.Deleted != true) && (x.ProviderStateLicenseID == ProviderStateLicenseID))

                                 select
                                 new
                                 {
                                     a.ProviderStateLicenseID,
                                     a.ProviderID,
                                     a.StateCode,
                                     a.LicenseNumber,
                                     a.EffectiveDate,
                                     a.TerminationDate,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedBy,
                                     a.ModifiedDate,

                                 }).AsEnumerable().Select(ss => new ProviderStateLicenseModel
                                 {
                                     ProviderStateLicenseID = ss.ProviderStateLicenseID,
                                     ProviderID = ss.ProviderID,
                                     StateCode = ss.StateCode,
                                     LicenseNumber = ss.LicenseNumber,
                                     EffectiveDate = ss.EffectiveDate,
                                     TerminationDate = ss.TerminationDate,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedBy = ss.ModifiedBy,
                                     ModifiedDate = ss.ModifiedDate,
                                 }).ToList();
            return StateLincense;


        }
        #endregion


        public List<ProviderInsuranceModel> GetProviderInsurancesByInsuranceID(int ProviderInsuranceID)
        {
            var Insurance = (from a in this._uow.GenericRepository<ProviderInsurance>().Table().Where(x => x.Deleted != true && x.ProviderInsuranceID == ProviderInsuranceID)
                             select
                             new
                             {
                                 a.ProviderInsuranceID,
                                 a.ProviderID,
                                 a.InsuranceCompanyID,
                                 a.InsuranceID,
                                 a.EffectiveDate,
                                 a.TerminationDate,
                                 a.Deleted,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.ModifiedDate,
                                 a.ModifiedBy,
                                 a.InsurancePaymentTypeID,
                                 a.SpecialityID,
                                 a.TaxonomyCode,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.City,
                                 a.State,
                                 a.Country,
                                 a.ZIP,
                                 a.County,
                                 a.Telephone,
                                 a.AlternatePhone,
                                 a.Fax,
                                 a.Email,
                                 a.InsuranceCategoryID
                             }).AsEnumerable().Select(ss => new ProviderInsuranceModel
                             {
                                 ProviderInsuranceID = ss.ProviderInsuranceID,
                                 ProviderID = ss.ProviderID,
                                 InsuranceCompanyID = ss.InsuranceCompanyID,
                                 InsuranceID = ss.InsuranceID,
                                 EffectiveDate = ss.EffectiveDate,
                                 TerminationDate = ss.TerminationDate,
                                 Deleted = ss.Deleted,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 ModifiedDate = ss.ModifiedDate,
                                 ModifiedBy = ss.ModifiedBy,
                                 InsurancePaymentTypeID = ss.InsurancePaymentTypeID,
                                 SpecialityID = ss.SpecialityID,
                                 TaxonomyCode = ss.TaxonomyCode,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 City = ss.City,
                                 State = ss.State,
                                 Country = ss.Country,
                                 ZIP = ss.ZIP,
                                 County = ss.County,
                                 Telephone = ss.Telephone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Fax = ss.Fax,
                                 Email = ss.Email,
                                 InsuranceCompanyName = ss.InsuranceCompanyID > 0 ? this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => x.InsuranceCompanyID == ss.InsuranceCompanyID).FirstOrDefault().OrganizationName : "",
                                 InsurancePaymentTypeDescription = ss.InsurancePaymentTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.InsurancePaymentTypeID).FirstOrDefault().Description : "",
                                 InsuranceCategoryDescription = ss.InsuranceCategoryID > 0 ? this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => x.InsuranceCategoryID == ss.InsuranceCategoryID).FirstOrDefault().Description : "",
                             }).ToList();

            return Insurance;
        }

        #region addupdate providerModel value
        public ProviderModel AddupdateProviderModel(ProviderModel providerModel)
        {
            var provider = this._uow.GenericRepository<Provider>().Table().Where(x => x.ProviderID == providerModel.ProviderID).FirstOrDefault();
            if (provider == null)
            {
                provider = new Provider();

                //provider.ProviderID = providerModel.ProviderID;
                provider.NPI = providerModel.NPI;
                provider.TaxID = providerModel.TaxID;
                provider.NameLast = providerModel.NameLast;
                provider.NameMiddle = providerModel.NameMiddle;
                provider.NameFirst = providerModel.NameFirst;
                provider.NamePrefix = providerModel.NamePrefix;
                provider.NameSuffix = providerModel.NameSuffix;
                provider.Credential = providerModel.Credential;
                provider.Title = providerModel.Title;
                provider.BirthDate = providerModel.BirthDate;
                provider.GenderID = providerModel.GenderID;
                provider.MedicaidID = providerModel.MedicaidID;
                provider.MedicareID = providerModel.MedicareID;
                provider.UPIN = providerModel.UPIN;
                provider.AddressLine1 = providerModel.AddressLine1;
                provider.AddressLine2 = providerModel.AddressLine2;
                provider.City = providerModel.City;
                provider.State = providerModel.State;
                provider.County = providerModel.County;
                provider.Country = providerModel.Country;
                provider.ZIP = providerModel.ZIP;
                provider.Phone = providerModel.Phone;
                provider.AlternatePhone = providerModel.AlternatePhone;
                provider.Fax = providerModel.Fax;
                provider.Email = providerModel.Email;
                provider.BillingAddressLine1 = providerModel.BillingAddressLine1;
                provider.BillingAddressLine2 = providerModel.BillingAddressLine2;
                provider.BillingCity = providerModel.BillingCity;
                provider.BillingState = providerModel.BillingState;
                provider.BillingCounty = providerModel.County;
                provider.BillingZIP = providerModel.BillingZIP;
                provider.BillingCountry = providerModel.BillingCountry;
                provider.SubscriptionFlag = providerModel.SubscriptionFlag;
                provider.IsActive = providerModel.IsActive;
                provider.Deleted = providerModel.Deleted;
                provider.CreatedDate = DateTime.Now;
                provider.CreatedBy = "User";
                provider.IsSameAsMailingAddress = providerModel.IsSameAsMailingAddress;
                provider.LanguageID = providerModel.LanguageID;
                provider.PreferredLanguageID = providerModel.PreferredLanguageID;
                provider.MothersMaidenName = providerModel.MothersMaidenName;
                provider.WebsiteName = providerModel.WebsiteName;
                provider.IsForeign = providerModel.IsForeign;
                provider.IsBillingForeign = providerModel.IsBillingForeign;
                provider.PrimaryFacilityID = providerModel.PrimaryFacilityID;
                provider.Biography = providerModel.Biography;
                provider.DoximityURL = providerModel.DoximityURL;
                provider.TwitterURL = providerModel.TwitterURL;
                provider.LinkedinURL = providerModel.LinkedinURL;


                this._uow.GenericRepository<Provider>().Insert(provider);
            }
            else
            {
                provider.NPI = providerModel.NPI;
                provider.TaxID = providerModel.TaxID;
                provider.NameLast = providerModel.NameLast;
                provider.NameMiddle = providerModel.NameMiddle;
                provider.NameFirst = providerModel.NameFirst;
                provider.NamePrefix = providerModel.NamePrefix;
                provider.NameSuffix = providerModel.NameSuffix;
                provider.Credential = providerModel.Credential;
                provider.Title = providerModel.Title;
                provider.BirthDate = providerModel.BirthDate;
                provider.GenderID = providerModel.GenderID;
                provider.MedicaidID = providerModel.MedicaidID;
                provider.MedicareID = providerModel.MedicareID;
                provider.UPIN = providerModel.UPIN;
                provider.AddressLine1 = providerModel.AddressLine1;
                provider.AddressLine2 = providerModel.AddressLine2;
                provider.City = providerModel.City;
                provider.State = providerModel.State;
                provider.County = providerModel.County;
                provider.Country = providerModel.Country;
                provider.ZIP = providerModel.ZIP;
                provider.Phone = providerModel.Phone;
                provider.AlternatePhone = providerModel.AlternatePhone;
                provider.Fax = providerModel.Fax;
                provider.Email = providerModel.Email;
                provider.BillingAddressLine1 = providerModel.BillingAddressLine1;
                provider.BillingAddressLine2 = providerModel.BillingAddressLine2;
                provider.BillingCity = providerModel.BillingCity;
                provider.BillingState = providerModel.BillingState;
                provider.BillingCounty = providerModel.County;
                provider.BillingZIP = providerModel.BillingZIP;
                provider.BillingCountry = providerModel.BillingCountry;
                provider.SubscriptionFlag = providerModel.SubscriptionFlag;
                provider.IsActive = providerModel.IsActive;
                provider.Deleted = providerModel.Deleted;
                provider.ModifiedBy = "User";
                provider.ModifiedDate = DateTime.Now;
                provider.IsSameAsMailingAddress = providerModel.IsSameAsMailingAddress;
                provider.LanguageID = providerModel.LanguageID;
                provider.PreferredLanguageID = providerModel.PreferredLanguageID;
                provider.MothersMaidenName = providerModel.MothersMaidenName;
                provider.WebsiteName = providerModel.WebsiteName;
                provider.IsForeign = providerModel.IsForeign;
                provider.IsBillingForeign = providerModel.IsBillingForeign;
                provider.PrimaryFacilityID = providerModel.PrimaryFacilityID;
                provider.Biography = providerModel.Biography;
                provider.DoximityURL = providerModel.DoximityURL;
                provider.TwitterURL = providerModel.TwitterURL;
                provider.LinkedinURL = providerModel.LinkedinURL;

                this._uow.GenericRepository<Provider>().Update(provider);
            }
            this._uow.Save();
            providerModel.ProviderID = provider.ProviderID;

            return providerModel;
        }
        #endregion

        #region ProviderLocation addupdate providermodel 
        public List<ProviderLocationTimingModel> GetLocationDatesForCalendar(string viewMode, string date, int providerId, int facilityID)
        {
            List<ProviderLocationTimingModel> locationRecords = new List<ProviderLocationTimingModel>();
            DateTime selectedDate = this._iMasterService.GetLocalTime(Convert.ToDateTime(date));

            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (viewMode.ToLower().Trim() == "day")
            {
                startDate = Convert.ToDateTime(selectedDate.ToShortDateString());
                endDate = startDate;
            }
            else if (viewMode.ToLower().Trim() == "week")
            {
                startDate = selectedDate.AddDays(selectedDate.DayOfWeek.GetHashCode() * -1);
                endDate = startDate.AddDays(6);
            }
            else if (viewMode.ToLower().Trim() == "month")
            {
                startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                endDate = startDate.AddMonths(1);
            }

            var locationTimeRecords = (from pl in this._uow.GenericRepository<ProviderLocation>().Table()
                                       .Where(x => x.ProviderID == providerId & x.FacilityID == facilityID & x.EffectiveDate.Date <= startDate.Date & x.TerminationDate.Value.Date >= endDate.Date)
                                       join plt in this._uow.GenericRepository<ProviderLocationTiming>().Table()
                                        on pl.ProviderLocationID equals plt.ProviderLocationID
                                       select plt).ToList();

            if (locationTimeRecords.Count() > 0)
            {
                for (DateTime currentdate = startDate; currentdate <= endDate; currentdate = currentdate.AddDays(1))
                {
                    foreach (var record in locationTimeRecords)
                    {
                        if (record.AppointmentDay.ToLower().Trim() == currentdate.DayOfWeek.ToString().ToLower().Trim())
                        {
                            ProviderLocationTimingModel locateModel = new ProviderLocationTimingModel();

                            locateModel.ProviderLocationID = record.ProviderLocationID;
                            locateModel.TimeSlotDuration = record.TimeSlotDuration;
                            locateModel.EffectiveDate = record.EffectiveDate;
                            locateModel.TerminationDate = record.TerminationDate;
                            locateModel.TimeSlotDuration = record.TimeSlotDuration;
                            locateModel.BookingPerSlot = record.BookingPerSlot;
                            locateModel.AppointmentAllowed = record.AppointmentAllowed;
                            locateModel.AppointmentDay = record.AppointmentDay;
                            locateModel.RegularWorkHrsFrom = record.RegularWorkHrsFrom;
                            locateModel.RegularWorkHrsTo = record.RegularWorkHrsTo;
                            locateModel.BreakHrsFrom = record.BreakHrsFrom;
                            locateModel.BreakHrsTo = record.BreakHrsTo;
                            locateModel.NoOfSlots = record.NoOfSlots; ;
                            locateModel.BookingPerDay = record.BookingPerDay;
                            locateModel.AppointmentDate = currentdate;

                            locationRecords.Add(locateModel);
                        }
                    }
                }
            }

            return locationRecords;
        }

        public ProviderLocationsModel AddupdateProviderLocationModel(ProviderLocationsModel providerLocationsModel)
        {
            ProviderLocation location = this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == providerLocationsModel.ProviderID & x.FacilityID == providerLocationsModel.FacilityID).FirstOrDefault();

            if (location == null)
            {
                location = new ProviderLocation();

                location.ProviderID = providerLocationsModel.ProviderID;
                location.FacilityID = providerLocationsModel.FacilityID;
                location.EffectiveDate = providerLocationsModel.EffectiveDate;
                location.TerminationDate = providerLocationsModel.TerminationDate;
                location.Deleted = false;
                location.CreatedBy = "User";
                location.CreatedDate = DateTime.Now;

                this._uow.GenericRepository<ProviderLocation>().Insert(location);
            }
            else
            {
                location.EffectiveDate = providerLocationsModel.EffectiveDate;
                location.TerminationDate = providerLocationsModel.TerminationDate;
                location.Deleted = false;
                location.ModifiedBy = "User";
                location.ModifiedDate = DateTime.Now;

                this._uow.GenericRepository<ProviderLocation>().Update(location);
            }
            this._uow.Save();

            List<string> days = new List<string>();

            int SlotCount = 0;

            var locationtime = this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(x => x.ProviderLocationID == location.ProviderLocationID).ToList();

            if (locationtime.Count() == 0)
            {
                foreach (var item in providerLocationsModel.locationTimings)
                {
                    var data = new ProviderLocationTimingModel();

                    data.AppointmentDay = item.AppointmentDay;
                    data.RegularWorkHrsFrom = (item.RegularWorkHrsFrom != null && item.RegularWorkHrsFrom != "" && item.RegularWorkHrsFrom != "00:00:00") ? item.RegularWorkHrsFrom : (item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom);
                    data.RegularWorkHrsTo = (item.RegularWorkHrsTo != null && item.RegularWorkHrsTo != "" && item.RegularWorkHrsTo != "00:00:00") ? item.RegularWorkHrsTo : (item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo);
                    data.BreakHrsFrom = (item.BreakHrsFrom != null && item.BreakHrsFrom != "" && item.BreakHrsFrom != "00:00:00") ? item.BreakHrsFrom : (item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom);
                    data.BreakHrsTo = (item.BreakHrsTo != null && item.BreakHrsTo != "" && item.BreakHrsTo != "00:00:00") ? item.BreakHrsTo : (item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo);

                    SlotCount = this.GetTimingsforProviderLocation(item.TimeSlotDuration, data).Count();

                    var scheduleRecord = (from pl in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == location.ProviderID)
                                          join plt in this._uow.GenericRepository<ProviderLocationTiming>().Table().
                                           Where(x => x.AppointmentDay == item.AppointmentDay)
                                           on pl.ProviderLocationID equals plt.ProviderLocationID
                                          select plt).FirstOrDefault();
                    if (scheduleRecord != null)
                    {
                        if ((this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) <= this.GetRailwayTime(item.RegularWorkHrsFrom)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) >= this.GetRailwayTime(item.RegularWorkHrsFrom))
                                        | (this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) <= this.GetRailwayTime(item.RegularWorkHrsTo)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) >= this.GetRailwayTime(item.RegularWorkHrsTo))
                                        | (this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) >= this.GetRailwayTime(item.RegularWorkHrsFrom)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) <= this.GetRailwayTime(item.RegularWorkHrsTo))
                                        )
                        {
                            if (!days.Contains(item.AppointmentDay))
                            {
                                days.Add(item.AppointmentDay);
                            }
                        }
                        else
                        {
                            scheduleRecord = new ProviderLocationTiming();

                            scheduleRecord.ProviderLocationID = location.ProviderLocationID;
                            scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                            scheduleRecord.EffectiveDate = providerLocationsModel.EffectiveDate;
                            scheduleRecord.TerminationDate = providerLocationsModel.TerminationDate;
                            scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                            scheduleRecord.BookingPerSlot = item.BookingPerSlot;
                            scheduleRecord.AppointmentAllowed = item.AppointmentAllowed;
                            scheduleRecord.AppointmentDay = item.AppointmentDay;
                            scheduleRecord.RegularWorkHrsFrom = item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom;
                            scheduleRecord.RegularWorkHrsTo = item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo;
                            scheduleRecord.BreakHrsFrom = item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom;
                            scheduleRecord.BreakHrsTo = item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo;
                            scheduleRecord.NoOfSlots = SlotCount;
                            scheduleRecord.BookingPerDay = item.BookingPerSlot * SlotCount;
                            scheduleRecord.Deleted = false;
                            scheduleRecord.CreatedDate = DateTime.Now;
                            scheduleRecord.CreatedBy = "User";

                            this._uow.GenericRepository<ProviderLocationTiming>().Insert(scheduleRecord);
                            this._uow.Save();
                        }
                    }
                    else
                    {
                        scheduleRecord = new ProviderLocationTiming();

                        scheduleRecord.ProviderLocationID = location.ProviderLocationID;
                        scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                        scheduleRecord.EffectiveDate = providerLocationsModel.EffectiveDate;
                        scheduleRecord.TerminationDate = providerLocationsModel.TerminationDate;
                        scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                        scheduleRecord.BookingPerSlot = item.BookingPerSlot;
                        scheduleRecord.AppointmentAllowed = item.AppointmentAllowed;
                        scheduleRecord.AppointmentDay = item.AppointmentDay;
                        scheduleRecord.RegularWorkHrsFrom = item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom;
                        scheduleRecord.RegularWorkHrsTo = item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo;
                        scheduleRecord.BreakHrsFrom = item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom;
                        scheduleRecord.BreakHrsTo = item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo;
                        scheduleRecord.NoOfSlots = SlotCount;
                        scheduleRecord.BookingPerDay = item.BookingPerSlot * SlotCount;
                        scheduleRecord.Deleted = false;
                        scheduleRecord.CreatedDate = DateTime.Now;
                        scheduleRecord.CreatedBy = "User";

                        this._uow.GenericRepository<ProviderLocationTiming>().Insert(scheduleRecord);
                        this._uow.Save();
                    }
                }
                this._uow.Save();
            }
            else
            {
                for (int i = 0; i < locationtime.Count(); i++)
                {
                    var locateTime = this._uow.GenericRepository<ProviderLocationTiming>().Table().FirstOrDefault(x => x.ProviderLocationTimingID == locationtime[i].ProviderLocationTimingID);
                    if (locateTime != null)
                    {
                        this._uow.GenericRepository<ProviderLocationTiming>().Delete(locateTime);
                        this._uow.Save();
                    }
                }

                foreach (var item in providerLocationsModel.locationTimings)
                {
                    var data = new ProviderLocationTimingModel();

                    data.AppointmentDay = item.AppointmentDay;
                    data.RegularWorkHrsFrom = (item.RegularWorkHrsFrom != null && item.RegularWorkHrsFrom != "" && item.RegularWorkHrsFrom != "00:00:00") ? item.RegularWorkHrsFrom : (item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom);
                    data.RegularWorkHrsTo = (item.RegularWorkHrsTo != null && item.RegularWorkHrsTo != "" && item.RegularWorkHrsTo != "00:00:00") ? item.RegularWorkHrsTo : (item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo);
                    data.BreakHrsFrom = (item.BreakHrsFrom != null && item.BreakHrsFrom != "" && item.BreakHrsFrom != "00:00:00") ? item.BreakHrsFrom : (item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom);
                    data.BreakHrsTo = (item.BreakHrsTo != null && item.BreakHrsTo != "" && item.BreakHrsTo != "00:00:00") ? item.BreakHrsTo : (item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo);

                    SlotCount = this.GetTimingsforProviderLocation(item.TimeSlotDuration, data).Count();


                    var scheduleRecord = (from pl in this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderID == location.ProviderID)
                                          join plt in this._uow.GenericRepository<ProviderLocationTiming>().Table().
                                           Where(x => x.AppointmentDay == item.AppointmentDay)
                                           on pl.ProviderLocationID equals plt.ProviderLocationID
                                          select plt).FirstOrDefault();

                    if (scheduleRecord != null)
                    {
                        if ((this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) <= this.GetRailwayTime(item.RegularWorkHrsFrom)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) >= this.GetRailwayTime(item.RegularWorkHrsFrom))
                                        | (this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) <= this.GetRailwayTime(item.RegularWorkHrsTo)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) >= this.GetRailwayTime(item.RegularWorkHrsTo))
                                        | (this.GetRailwayTime(scheduleRecord.RegularWorkHrsFrom) >= this.GetRailwayTime(item.RegularWorkHrsFrom)
                                        & this.GetRailwayTime(scheduleRecord.RegularWorkHrsTo) <= this.GetRailwayTime(item.RegularWorkHrsTo))
                                        )
                        {
                            if (!days.Contains(item.AppointmentDay))
                            {
                                days.Add(item.AppointmentDay);
                            }
                        }
                        else
                        {
                            scheduleRecord = new ProviderLocationTiming();

                            scheduleRecord.ProviderLocationID = location.ProviderLocationID;
                            scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                            scheduleRecord.EffectiveDate = providerLocationsModel.EffectiveDate;
                            scheduleRecord.TerminationDate = providerLocationsModel.TerminationDate;
                            scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                            scheduleRecord.BookingPerSlot = item.BookingPerSlot;
                            scheduleRecord.AppointmentAllowed = item.AppointmentAllowed;
                            scheduleRecord.AppointmentDay = item.AppointmentDay;
                            scheduleRecord.RegularWorkHrsFrom = item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom;
                            scheduleRecord.RegularWorkHrsTo = item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo;
                            scheduleRecord.BreakHrsFrom = item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom;
                            scheduleRecord.BreakHrsTo = item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo;
                            scheduleRecord.NoOfSlots = SlotCount;
                            scheduleRecord.BookingPerDay = item.BookingPerSlot * SlotCount;
                            scheduleRecord.Deleted = false;
                            scheduleRecord.CreatedDate = DateTime.Now;
                            scheduleRecord.CreatedBy = "User";

                            this._uow.GenericRepository<ProviderLocationTiming>().Insert(scheduleRecord);
                            this._uow.Save();
                        }
                    }
                    else
                    {
                        scheduleRecord = new ProviderLocationTiming();

                        scheduleRecord.ProviderLocationID = location.ProviderLocationID;
                        scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                        scheduleRecord.EffectiveDate = providerLocationsModel.EffectiveDate;
                        scheduleRecord.TerminationDate = providerLocationsModel.TerminationDate;
                        scheduleRecord.TimeSlotDuration = item.TimeSlotDuration;
                        scheduleRecord.BookingPerSlot = item.BookingPerSlot;
                        scheduleRecord.AppointmentAllowed = item.AppointmentAllowed;
                        scheduleRecord.AppointmentDay = item.AppointmentDay;
                        scheduleRecord.RegularWorkHrsFrom = item.RegularWorkHrsFrom == "00:00:00" ? null : item.RegularWorkHrsFrom;
                        scheduleRecord.RegularWorkHrsTo = item.RegularWorkHrsTo == "00:00:00" ? null : item.RegularWorkHrsTo;
                        scheduleRecord.BreakHrsFrom = item.BreakHrsFrom == "00:00:00" ? null : item.BreakHrsFrom;
                        scheduleRecord.BreakHrsTo = item.BreakHrsTo == "00:00:00" ? null : item.BreakHrsTo;
                        scheduleRecord.NoOfSlots = SlotCount;
                        scheduleRecord.BookingPerDay = item.BookingPerSlot * SlotCount;
                        scheduleRecord.Deleted = false;
                        scheduleRecord.CreatedDate = DateTime.Now;
                        scheduleRecord.CreatedBy = "User";

                        this._uow.GenericRepository<ProviderLocationTiming>().Insert(scheduleRecord);
                        this._uow.Save();
                    }
                }
            }

            if (days.Count() > 0)
            {
                string daynames = "";

                for (int i = 0; i < days.Count(); i++)
                {
                    if (i + 1 == days.Count())
                    {
                        if (daynames == null || daynames == "")
                        {
                            daynames = days[i];
                        }
                        else
                        {
                            daynames = daynames + days[i];
                        }
                    }
                    else
                    {
                        if (daynames == null || daynames == "")
                        {
                            daynames = days[i] + ", ";
                        }
                        else
                        {
                            daynames = daynames + days[i] + ", ";
                        }
                    }
                }

                providerLocationsModel.TimeavailabilityStatus = "Selected Timing Not available on " + daynames;
            }
            else
            {
                providerLocationsModel.TimeavailabilityStatus = "Available";
            }

            return providerLocationsModel;
        }

        public List<string> GetTimingsforProviderLocation(int SlotDuration, ProviderLocationTimingModel item)
        {
            List<string> Timings = new List<string>();

            TimeSpan time = new TimeSpan();
            TimeSpan timeSet = new TimeSpan();
            TimeSpan duration = new TimeSpan(0, SlotDuration, 0);

            //if (this.GetRailwayTime(item.RegularWorkHrsFrom) < this.GetRailwayTime(item.RegularWorkHrsTo))
            //{
            time = (item.RegularWorkHrsFrom == "12:00:00 am" || item.RegularWorkHrsFrom == "12:00 am") ? this.GetRailwayTime("00:00 am") : this.GetRailwayTime(item.RegularWorkHrsFrom);

            if ((item.BreakHrsFrom != null && item.BreakHrsFrom != "")
                && (item.BreakHrsFrom != null && item.BreakHrsFrom != ""))
            {
                timeSet = (item.BreakHrsFrom == "12:00:00 am" || item.BreakHrsFrom == "12:00 am") ? this.GetRailwayTime("00:00 am") : this.GetRailwayTime(item.BreakHrsFrom);

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

                timeSet = (item.BreakHrsTo == "12:00:00 am" || item.BreakHrsTo == "12:00 am") ? this.GetRailwayTime("00:00 am") : this.GetRailwayTime(item.BreakHrsTo);

                time = timeSet;
            }
            if (item.RegularWorkHrsTo != null && item.RegularWorkHrsTo != "")
            {
                timeSet = (item.RegularWorkHrsTo == "12:00:00 am" || item.RegularWorkHrsTo == "12:00 am") ? this.GetRailwayTime("00:00 am") : this.GetRailwayTime(item.RegularWorkHrsTo);

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
            }
            //}
            return Timings;
        }

        public TimeSpan GetRailwayTime(string scheduledTime)
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

        #endregion

        #region ProviderInsurance addupdate called providerInsurance
        public ProviderInsuranceModel AddupdateProviderInsuranceModels(ProviderInsuranceModel providerInsuranceModel)
        {
            var insurance = this._uow.GenericRepository<ProviderInsurance>().Table().Where(x => x.ProviderInsuranceID == providerInsuranceModel.ProviderInsuranceID).FirstOrDefault();
            if (insurance == null)
            {
                insurance = new ProviderInsurance();

                insurance.ProviderID = providerInsuranceModel.ProviderID;
                insurance.InsuranceCompanyID = providerInsuranceModel.InsuranceCompanyID;
                insurance.InsuranceID = providerInsuranceModel.InsuranceID;
                insurance.EffectiveDate = providerInsuranceModel.EffectiveDate;
                insurance.TerminationDate = providerInsuranceModel.TerminationDate;
                insurance.Deleted = false;
                insurance.CreatedDate = DateTime.Now;
                insurance.CreatedBy = "User";
                insurance.InsurancePaymentTypeID = providerInsuranceModel.InsurancePaymentTypeID;
                insurance.SpecialityID = providerInsuranceModel.SpecialityID;
                insurance.TaxonomyCode = providerInsuranceModel.TaxonomyCode;
                insurance.AddressLine1 = providerInsuranceModel.AddressLine1;
                insurance.AddressLine2 = providerInsuranceModel.AddressLine2;
                insurance.City = providerInsuranceModel.City;
                insurance.State = providerInsuranceModel.State;
                insurance.Country = providerInsuranceModel.Country;
                insurance.ZIP = providerInsuranceModel.ZIP;
                insurance.Country = providerInsuranceModel.Country;
                insurance.Telephone = providerInsuranceModel.Telephone;
                insurance.AlternatePhone = providerInsuranceModel.AlternatePhone;
                insurance.Fax = providerInsuranceModel.Fax;
                insurance.Email = providerInsuranceModel.Email;

                this._uow.GenericRepository<ProviderInsurance>().Insert(insurance);
            }
            else
            {
                insurance.ProviderID = providerInsuranceModel.ProviderID;
                insurance.InsuranceCompanyID = providerInsuranceModel.InsuranceCompanyID;
                insurance.InsuranceID = providerInsuranceModel.InsuranceID;
                insurance.EffectiveDate = providerInsuranceModel.EffectiveDate;
                insurance.TerminationDate = providerInsuranceModel.TerminationDate;
                insurance.Deleted = false;
                insurance.ModifiedDate = DateTime.Now;
                insurance.ModifiedBy = "User";
                insurance.InsurancePaymentTypeID = providerInsuranceModel.InsurancePaymentTypeID;
                insurance.SpecialityID = providerInsuranceModel.SpecialityID;
                insurance.TaxonomyCode = providerInsuranceModel.TaxonomyCode;
                insurance.AddressLine1 = providerInsuranceModel.AddressLine1;
                insurance.AddressLine2 = providerInsuranceModel.AddressLine2;
                insurance.City = providerInsuranceModel.City;
                insurance.State = providerInsuranceModel.State;
                insurance.Country = providerInsuranceModel.Country;
                insurance.ZIP = providerInsuranceModel.ZIP;
                insurance.Country = providerInsuranceModel.Country;
                insurance.Telephone = providerInsuranceModel.Telephone;
                insurance.AlternatePhone = providerInsuranceModel.AlternatePhone;
                insurance.Fax = providerInsuranceModel.Fax;
                insurance.Email = providerInsuranceModel.Email;

                this._uow.GenericRepository<ProviderInsurance>().Update(insurance);
            }
            this._uow.Save();
            providerInsuranceModel.ProviderInsuranceID = insurance.ProviderInsuranceID;
            return providerInsuranceModel;
        }

        #endregion
        #region ProviderVacation called on addupdate value
        public ProviderVacationModel AddupdateProviderVacationModels(ProviderVacationModel providerVacationModel)
        {
            var vacation = this._uow.GenericRepository<ProviderVacation>().Table().Where(x => x.ProviderVacationID == providerVacationModel.ProviderVacationID).FirstOrDefault();
            if (vacation == null)
            {
                vacation = new ProviderVacation();

                vacation.ProviderID = providerVacationModel.ProviderID;
                vacation.StartDate = this._iMasterService.GetLocalTime(providerVacationModel.StartDate.Value);
                vacation.EndDate = this._iMasterService.GetLocalTime(providerVacationModel.EndDate.Value).AddDays(1);
                vacation.Reason = providerVacationModel.Reason;
                vacation.Deleted = false;
                vacation.CreatedDate = DateTime.Now;
                vacation.CreatedBy = "User";

                this._uow.GenericRepository<ProviderVacation>().Insert(vacation);

            }
            else
            {
                vacation.ProviderID = providerVacationModel.ProviderID;
                vacation.StartDate = this._iMasterService.GetLocalTime(providerVacationModel.StartDate.Value);
                vacation.EndDate = this._iMasterService.GetLocalTime(providerVacationModel.EndDate.Value).AddDays(1);
                vacation.Reason = providerVacationModel.Reason;
                vacation.Deleted = false;
                vacation.ModifiedDate = DateTime.Now;
                vacation.ModifiedBy = "User";

                this._uow.GenericRepository<ProviderVacation>().Update(vacation);
            }
            this._uow.Save();
            providerVacationModel.ProviderVacationID = vacation.ProviderVacationID;
            return providerVacationModel;
        }
        #endregion

        #region this addupdate called on ProviderStateLicenseModel
        public ProviderStateLicenseModel AddupdateProviderStateLicenseModel(ProviderStateLicenseModel providerStateLicenseModel)
        {
            var license = this._uow.GenericRepository<ProviderStateLicense>().Table().Where(X => X.ProviderStateLicenseID == providerStateLicenseModel.ProviderStateLicenseID).FirstOrDefault();
            if (license == null)
            {
                license = new ProviderStateLicense();
                license.ProviderID = providerStateLicenseModel.ProviderID;
                license.StateCode = providerStateLicenseModel.StateCode;
                license.LicenseNumber = providerStateLicenseModel.LicenseNumber;
                license.EffectiveDate = providerStateLicenseModel.EffectiveDate;
                license.TerminationDate = providerStateLicenseModel.TerminationDate;
                license.Deleted = false;
                license.CreatedDate = DateTime.Now;
                license.CreatedBy = "User";

                this._uow.GenericRepository<ProviderStateLicense>().Insert(license);
            }
            else
            {
                license.ProviderID = providerStateLicenseModel.ProviderID;
                license.StateCode = providerStateLicenseModel.StateCode;
                license.LicenseNumber = providerStateLicenseModel.LicenseNumber;
                license.EffectiveDate = providerStateLicenseModel.EffectiveDate;
                license.TerminationDate = providerStateLicenseModel.TerminationDate;
                license.Deleted = false;
                license.ModifiedDate = DateTime.Now;
                license.ModifiedBy = "User";

                this._uow.GenericRepository<ProviderStateLicense>().Update(license);
            }
            this._uow.Save();
            providerStateLicenseModel.ProviderStateLicenseID = license.ProviderStateLicenseID;

            return providerStateLicenseModel;
        }

        #endregion

        #region providerAwardsAndRecognitionModel addupdate
        public ProviderAwardsAndRecognitionModel AddupdateProviderAwardsAndRecognitionModel(ProviderAwardsAndRecognitionModel providerAwardsAndRecognitionModel)
        {
            var awards = this._uow.GenericRepository<ProviderAwardsAndRecognition>().Table().Where(x => x.ProviderAwardsAndRecognitionID == providerAwardsAndRecognitionModel.ProviderAwardsAndRecognitionID).FirstOrDefault();
            if (awards == null)
            {
                awards = new ProviderAwardsAndRecognition();

                awards.ProviderID = providerAwardsAndRecognitionModel.ProviderID;
                awards.Description = providerAwardsAndRecognitionModel.Description;
                awards.DateFrom = providerAwardsAndRecognitionModel.DateFrom;
                awards.RecognizedBy = providerAwardsAndRecognitionModel.RecognizedBy;
                awards.Deleted = false;
                awards.CreatedDate = DateTime.Now;
                awards.CreatedBy = "User";

                this._uow.GenericRepository<ProviderAwardsAndRecognition>().Insert(awards);
            }
            else
            {
                awards.ProviderID = providerAwardsAndRecognitionModel.ProviderID;
                awards.Description = providerAwardsAndRecognitionModel.Description;
                awards.DateFrom = providerAwardsAndRecognitionModel.DateFrom;
                awards.RecognizedBy = providerAwardsAndRecognitionModel.RecognizedBy;
                awards.Deleted = false;
                awards.ModifiedDate = DateTime.Now;
                awards.ModifiedBy = "User";

                this._uow.GenericRepository<ProviderAwardsAndRecognition>().Update(awards);
            }
            this._uow.Save();
            providerAwardsAndRecognitionModel.ProviderAwardsAndRecognitionID = awards.ProviderAwardsAndRecognitionID;

            return providerAwardsAndRecognitionModel;

        }
        #endregion

        public List<ProviderModel> ProvidersingleID()
        {
            var Providers = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true)
                             join u in this._uow.GenericRepository<UserData>().Table()
                             on a.UserID equals u.UserID
                             select
                             new
                             {
                                 a.ProviderID,
                                 a.UserID,
                                 a.NPI,
                                 a.TaxID,
                                 a.Title,
                                 a.Fax,
                                 u.SSNID,
                                 a.GenderID,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.ZIP,
                                 a.County,
                                 a.Country,
                                 a.City,
                                 a.State,
                                 a.BillingAddressLine1,
                                 a.BillingAddressLine2,
                                 a.BillingState,
                                 a.BillingZIP,
                                 a.BillingCountry,
                                 a.BillingCounty,
                                 a.BillingCity,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.Deleted,
                                 a.BirthDate,
                                 a.UPIN,
                                 a.Phone,
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
                                 a.NameMiddle,
                                 a.NamePrefix,
                                 a.NameSuffix,
                                 a.PreferredLanguageID,
                                 a.FeeScheduleToUse,
                                 a.WebsiteName,
                                 a.PrimaryFacilityID,
                                 a.Biography,
                                 a.DoximityURL,
                                 a.LinkedinURL,
                                 a.TwitterURL

                             }).AsEnumerable().Select(ss => new ProviderModel
                             {
                                 ProviderID = ss.ProviderID,
                                 UserID = ss.UserID,
                                 NPI = ss.NPI,
                                 Fax = ss.Fax,
                                 TaxID = ss.TaxID,
                                 GenderID = ss.GenderID,
                                 GenderDescription = ss.GenderID != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.GenderID).FirstOrDefault().Description : "",
                                 ProviderSSN = ss.SSNID.ToString(),
                                 Title = ss.Title,  // != null ? ss.Title : this._uow.GenericRepository<UserData>().Table().
                                                    // Where(x => x.UserID == ss.UserID).FirstOrDefault().Title,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 ZIP = ss.ZIP,
                                 City = ss.City,
                                 State = ss.State,
                                 County = ss.County,
                                 Country = ss.Country,
                                 BillingAddressLine1 = ss.BillingAddressLine1,
                                 BillingAddressLine2 = ss.BillingAddressLine2,
                                 BillingZIP = ss.BillingZIP,
                                 BillingCity = ss.BillingCity,
                                 BillingCounty = ss.BillingCounty,
                                 BillingCountry = ss.BillingCountry,
                                 BillingState = ss.BillingState,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 Deleted = ss.Deleted,
                                 BirthDate = ss.BirthDate,
                                 UPIN = ss.UPIN,
                                 Phone = ss.Phone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Credential = ss.Credential,
                                 Email = ss.Email,
                                 IsBillingForeign = ss.IsBillingForeign,
                                 IsForeign = ss.IsForeign,
                                 IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                 LanguageID = ss.LanguageID,
                                 LanguageDescription = ss.LanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.LanguageID).FirstOrDefault().Description : "",
                                 MedicaidID = ss.MedicaidID,
                                 MedicareID = ss.MedicareID,
                                 ModifiedBy = ss.ModifiedBy,
                                 ModifiedDate = ss.ModifiedDate,
                                 MothersMaidenName = ss.MothersMaidenName,
                                 NameFirst = ss.NameFirst,
                                 NameLast = ss.NameLast,
                                 NameMiddle = ss.NameMiddle,
                                 NamePrefix = ss.NamePrefix,
                                 NameSuffix = ss.NameSuffix,
                                 PreferredLanguageID = ss.PreferredLanguageID,
                                 PreferredLanguageDescription = ss.PreferredLanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.PreferredLanguageID).FirstOrDefault().Description : "",
                                 FeeScheduleToUse = ss.FeeScheduleToUse,
                                 FeeScheduleDescription = ss.FeeScheduleToUse > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.FeeScheduleToUse).FirstOrDefault().Description : "",
                                 PrimaryFacilityID = ss.PrimaryFacilityID,
                                 PrimaryFacilityName = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == ss.PrimaryFacilityID.Value).FirstOrDefault().FacilityName : "",
                                 WebsiteName = ss.WebsiteName,
                                 Biography = ss.Biography,
                                 DoximityURL = ss.DoximityURL,
                                 LinkedinURL = ss.LinkedinURL,
                                 TwitterURL = ss.TwitterURL,
                                 PrimaryFacilityAddress = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this.FacilityAddress(ss.PrimaryFacilityID.Value) : "",
                                 ProviderPhoto = this.GetFile(ss.ProviderID.ToString(), "Provider").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Provider") : new List<clsViewFile>(),
                                 ProviderSignature = this.GetFile(ss.ProviderID.ToString(), "Providersignature").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Providersignature") : new List<clsViewFile>()


                             }).ToList();

            return Providers;
        }

        public List<ProviderModel> ProvidersingleIDProviderID(int ProviderID)
        {
            if (ProviderID <= 0)
                return null;
            var Providers = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true && x.ProviderID == ProviderID)
                             join u in this._uow.GenericRepository<UserData>().Table()
                            on a.UserID equals u.UserID
                             select
                             new
                             {
                                 a.ProviderID,
                                 a.UserID,
                                 a.NPI,
                                 a.TaxID,
                                 a.Title,
                                 a.Fax,
                                 u.SSNID,
                                 a.GenderID,
                                 a.AddressLine1,
                                 a.AddressLine2,
                                 a.ZIP,
                                 a.County,
                                 a.Country,
                                 a.City,
                                 a.State,
                                 a.BillingAddressLine1,
                                 a.BillingAddressLine2,
                                 a.BillingState,
                                 a.BillingZIP,
                                 a.BillingCountry,
                                 a.BillingCounty,
                                 a.BillingCity,
                                 a.CreatedBy,
                                 a.CreatedDate,
                                 a.Deleted,
                                 a.BirthDate,
                                 a.UPIN,
                                 a.Phone,
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
                                 a.NameMiddle,
                                 a.NamePrefix,
                                 a.NameSuffix,
                                 a.PreferredLanguageID,
                                 a.FeeScheduleToUse,
                                 a.WebsiteName,
                                 a.PrimaryFacilityID,
                                 a.Biography,
                                 a.DoximityURL,
                                 a.LinkedinURL,
                                 a.TwitterURL


                             }).AsEnumerable().Select(ss => new ProviderModel
                             {
                                 ProviderID = ss.ProviderID,
                                 UserID = ss.UserID,
                                 NPI = ss.NPI,
                                 Fax = ss.Fax,
                                 TaxID = ss.TaxID,
                                 GenderID = ss.GenderID,
                                 GenderDescription = ss.GenderID != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.GenderID).FirstOrDefault().Description : "",
                                 ProviderSSN = ss.SSNID.ToString(),
                                 Title = ss.Title != null ? ss.Title : this._uow.GenericRepository<UserData>().Table().
                                            Where(x => x.UserID == ss.UserID).FirstOrDefault().Title,
                                 AddressLine1 = ss.AddressLine1,
                                 AddressLine2 = ss.AddressLine2,
                                 ZIP = ss.ZIP,
                                 City = ss.City,
                                 State = ss.State,
                                 County = ss.County,
                                 Country = ss.Country,
                                 BillingAddressLine1 = ss.BillingAddressLine1,
                                 BillingAddressLine2 = ss.BillingAddressLine2,
                                 BillingZIP = ss.BillingZIP,
                                 BillingCity = ss.BillingCity,
                                 BillingCounty = ss.BillingCounty,
                                 BillingCountry = ss.BillingCountry,
                                 BillingState = ss.BillingState,
                                 CreatedBy = ss.CreatedBy,
                                 CreatedDate = ss.CreatedDate,
                                 Deleted = ss.Deleted,
                                 BirthDate = ss.BirthDate,
                                 UPIN = ss.UPIN,
                                 Phone = ss.Phone,
                                 AlternatePhone = ss.AlternatePhone,
                                 Credential = ss.Credential,
                                 Email = ss.Email,
                                 IsBillingForeign = ss.IsBillingForeign,
                                 IsForeign = ss.IsForeign,
                                 IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                 LanguageID = ss.LanguageID,
                                 LanguageDescription = ss.LanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.LanguageID).FirstOrDefault().Description : "",
                                 MedicaidID = ss.MedicaidID,
                                 MedicareID = ss.MedicareID,
                                 ModifiedBy = ss.ModifiedBy,
                                 ModifiedDate = ss.ModifiedDate,
                                 MothersMaidenName = ss.MothersMaidenName,
                                 NameFirst = ss.NameFirst,
                                 NameLast = ss.NameLast,
                                 NameMiddle = ss.NameMiddle,
                                 NamePrefix = ss.NamePrefix,
                                 NameSuffix = ss.NameSuffix,
                                 PreferredLanguageID = ss.PreferredLanguageID,
                                 PreferredLanguageDescription = ss.PreferredLanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.PreferredLanguageID).FirstOrDefault().Description : "",
                                 FeeScheduleToUse = ss.FeeScheduleToUse,
                                 FeeScheduleDescription = ss.FeeScheduleToUse > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.FeeScheduleToUse).FirstOrDefault().Description : "",
                                 PrimaryFacilityID = ss.PrimaryFacilityID,
                                 PrimaryFacilityName = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == ss.PrimaryFacilityID.Value).FirstOrDefault().FacilityName : "",
                                 WebsiteName = ss.WebsiteName,
                                 Biography = ss.Biography,
                                 DoximityURL = ss.DoximityURL,
                                 LinkedinURL = ss.LinkedinURL,
                                 TwitterURL = ss.TwitterURL,
                                 PrimaryFacilityAddress = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this.FacilityAddress(ss.PrimaryFacilityID.Value) : "",
                                 providerLocationsModels = this.GetProviderLocationsbyProviderId(ss.ProviderID),
                                 providerStateLicenseModels = this.providerStateLicenseModelbyProvider(ss.ProviderID),
                                 providerVacationModels = this.providerVacationsbyproviderID(ss.ProviderID),
                                 providerInsuranceModels = this.GetProviderInsurancesbyProviderID(ss.ProviderID),
                                 providerAwardsandRecognitionModels = this.GetProviderAwardsAndRecognitionModelByProviderID(ss.ProviderID),
                                 ProviderPhoto = this.GetFile(ss.ProviderID.ToString(), "Provider").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Provider") : new List<clsViewFile>(),
                                 ProviderSignature = this.GetFile(ss.ProviderID.ToString(), "Providersignature").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Providersignature") : new List<clsViewFile>()

                             }).ToList();

            return Providers;

        }

        public ProviderModel GetProviderRecordbyUserID(int userID)
        {
            UserData userRecord = this._uow.GenericRepository<UserData>().Table().Where(x => x.UserID == userID).FirstOrDefault();

            var providerRecord = (from a in this._uow.GenericRepository<Provider>().Table().Where(x => x.Deleted != true && x.UserID == userID)
                                  join u in this._uow.GenericRepository<UserData>().Table()
                                  on a.UserID equals u.UserID
                                  select
                                  new
                                  {
                                      a.ProviderID,
                                      a.UserID,
                                      u.SSNID,
                                      a.NPI,
                                      a.TaxID,
                                      a.Title,
                                      a.GenderID,
                                      a.AddressLine1,
                                      a.AddressLine2,
                                      a.ZIP,
                                      a.County,
                                      a.Country,
                                      a.City,
                                      a.State,
                                      a.BillingAddressLine1,
                                      a.BillingAddressLine2,
                                      a.BillingState,
                                      a.BillingZIP,
                                      a.BillingCountry,
                                      a.BillingCounty,
                                      a.BillingCity,
                                      a.CreatedBy,
                                      a.CreatedDate,
                                      a.Deleted,
                                      a.BirthDate,
                                      a.UPIN,
                                      a.Phone,
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
                                      a.PreferredLanguageID,
                                      a.FeeScheduleToUse,
                                      a.WebsiteName,
                                      a.PrimaryFacilityID,
                                      a.Biography,
                                      a.DoximityURL,
                                      a.LinkedinURL,
                                      a.TwitterURL,
                                      u.Sex

                                  }).AsEnumerable().Select(ss => new ProviderModel
                                  {
                                      ProviderID = ss.ProviderID,
                                      UserID = ss.UserID,
                                      NPI = ss.NPI,
                                      TaxID = ss.TaxID,
                                      GenderID = ss.GenderID != null ? ss.GenderID : (userRecord != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Code.ToLower().Trim().Contains(ss.Sex.ToLower().Trim()) ||
                                                         x.Description.ToLower().Trim().Contains(ss.Sex.ToLower().Trim())).FirstOrDefault().CommonMasterID : 0),
                                      GenderDescription = ss.Sex != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Code.ToLower().Trim().Contains(ss.Sex.ToLower().Trim()) ||
                                                         x.Description.ToLower().Trim().Contains(ss.Sex.ToLower().Trim())).FirstOrDefault().Description : "",
                                      Sex = ss.GenderID != null ? ss.GenderID.ToString() : (userRecord != null ? userRecord.Sex : ""),
                                      ProviderSSN = ss.SSNID.ToString(),
                                      Title = ss.Title != null ? ss.Title : (userRecord != null ? userRecord.Title : ""),
                                      AddressLine1 = ss.AddressLine1,
                                      AddressLine2 = ss.AddressLine2,
                                      ZIP = ss.ZIP,
                                      City = ss.City,
                                      State = ss.State,
                                      County = ss.County,
                                      Country = ss.Country,
                                      BillingAddressLine1 = ss.BillingAddressLine1,
                                      BillingAddressLine2 = ss.BillingAddressLine2,
                                      BillingZIP = ss.BillingZIP,
                                      BillingCity = ss.BillingCity,
                                      BillingCounty = ss.BillingCounty,
                                      BillingCountry = ss.BillingCountry,
                                      BillingState = ss.BillingState,
                                      CreatedBy = ss.CreatedBy,
                                      CreatedDate = ss.CreatedDate,        
                                      Deleted = ss.Deleted,
                                      BirthDate = ss.BirthDate,
                                      UPIN = ss.UPIN,
                                      Phone = ss.Phone != null ? ss.Phone : (userRecord != null ? userRecord.Telephone : ""),
                                      AlternatePhone = (ss.AlternatePhone != null && ss.AlternatePhone != "") ? ss.AlternatePhone : (userRecord != null ? userRecord.PhoneNumber : ""),
                                      Credential = ss.Credential,
                                      Email = ss.Email,
                                      IsBillingForeign = ss.IsBillingForeign,
                                      IsForeign = ss.IsForeign,
                                      IsSameAsMailingAddress = ss.IsSameAsMailingAddress,
                                      LanguageID = ss.LanguageID,
                                      LanguageDescription = ss.LanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.LanguageID).FirstOrDefault().Description : "",
                                      MedicaidID = ss.MedicaidID,
                                      MedicareID = ss.MedicareID,
                                      ModifiedBy = ss.ModifiedBy,
                                      ModifiedDate = ss.ModifiedDate,
                                      MothersMaidenName = ss.MothersMaidenName,
                                      NameFirst = ss.NameFirst != null ? ss.NameFirst : (userRecord != null ? userRecord.NameFirst : ""),
                                      NameLast = ss.NameLast != null ? ss.NameLast : (userRecord != null ? userRecord.NameLast : ""),
                                      NamePrefix = ss.NamePrefix != null ? ss.NamePrefix : (userRecord != null ? userRecord.NamePrefix : ""),
                                      NameSuffix = ss.NameSuffix != null ? ss.NameSuffix : (userRecord != null ? userRecord.NameSuffix : ""),
                                      PreferredLanguageID = ss.PreferredLanguageID,
                                      PreferredLanguageDescription = ss.PreferredLanguageID > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.RegionalLanguageID == ss.PreferredLanguageID).FirstOrDefault().Description : "",
                                      FeeScheduleToUse = ss.FeeScheduleToUse,
                                      FeeScheduleDescription = ss.FeeScheduleToUse > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.FeeScheduleToUse).FirstOrDefault().Description : "",
                                      PrimaryFacilityID = ss.PrimaryFacilityID,
                                      PrimaryFacilityName = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == ss.PrimaryFacilityID.Value).FirstOrDefault().FacilityName : "",
                                      WebsiteName = ss.WebsiteName,
                                      Biography = ss.Biography,
                                      DoximityURL = ss.DoximityURL,
                                      LinkedinURL = ss.LinkedinURL,
                                      TwitterURL = ss.TwitterURL,
                                      PrimaryFacilityAddress = (ss.PrimaryFacilityID != null && ss.PrimaryFacilityID > 0) ? this.FacilityAddress(ss.PrimaryFacilityID.Value) : "",
                                      providerLocationsModels = this.GetProviderLocationsbyProviderId(ss.ProviderID),
                                      providerStateLicenseModels = this.providerStateLicenseModelbyProvider(ss.ProviderID),
                                      providerVacationModels = this.providerVacationsbyproviderID(ss.ProviderID),
                                      providerInsuranceModels = this.GetProviderInsurancesbyProviderID(ss.ProviderID),
                                      providerAwardsandRecognitionModels = this.GetProviderAwardsAndRecognitionModelByProviderID(ss.ProviderID),
                                      ProviderPhoto = this.GetFile(ss.ProviderID.ToString(), "Provider").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Provider") : new List<clsViewFile>(),
                                      ProviderSignature = this.GetFile(ss.ProviderID.ToString(), "Providersignature").Count > 0 ? this.GetFile(ss.ProviderID.ToString(), "Providersignature") : new List<clsViewFile>()

                                  }).FirstOrDefault();


            return providerRecord;

        }

        public string FacilityAddress(int FacilityID)
        {
            string facValue = "";
            Facility facData = this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == FacilityID).FirstOrDefault();

            if(facData != null)
            {
                facValue = facData.FacilityName + ", " + facData.AddressLine1 + ", " + facData.AddressLine2 + ", ";
            }

            return facValue;
        }

        #region this ProviderLocation Delete Model
        public ProviderLocation DeleteProviderLocationModel(int ProviderLocationID)
        {
            var Locations = this._uow.GenericRepository<ProviderLocation>().Table().Where(x => x.ProviderLocationID == ProviderLocationID).SingleOrDefault();
            if (Locations != null)
            {
                Locations.Deleted = true;
                this._uow.GenericRepository<ProviderLocation>().Update(Locations);
                this._uow.Save();

            }

            return Locations;

        }
        #endregion

        #region this ProviderStateLicense Delete Model
        public ProviderStateLicense DeleteProviderStateLincense(int ProviderStateLicenseID)
        {
            var sateLincense = this._uow.GenericRepository<ProviderStateLicense>().Table().Where(x => x.ProviderStateLicenseID == ProviderStateLicenseID).SingleOrDefault();
            if (sateLincense != null)
            {
                sateLincense.Deleted = true;
                this._uow.GenericRepository<ProviderStateLicense>().Update(sateLincense);
                this._uow.Save();
            }
            return sateLincense;
        }

        #endregion


        #region ProviderVacation Delete Model
        public ProviderVacation DeleteProviderVacation(int ProviderVacationID)
        {
            var vacation = this._uow.GenericRepository<ProviderVacation>().Table().Where(x => x.ProviderVacationID == ProviderVacationID).SingleOrDefault();
            if (vacation != null)
            {
                vacation.Deleted = true;
                this._uow.GenericRepository<ProviderVacation>().Update(vacation);
                this._uow.Save();
            }
            return vacation;
        }

        #endregion

        #region ProviderAwardsAndRecognition Delete Model
        public ProviderAwardsAndRecognition DeleteProviderAwardsAndRecognition(int ProviderAwardsAndRecognitionID)
        {
            var Awards = this._uow.GenericRepository<ProviderAwardsAndRecognition>().Table().Where(x => x.ProviderAwardsAndRecognitionID == ProviderAwardsAndRecognitionID).SingleOrDefault();
            if (Awards != null)
            {
                Awards.Deleted = true;
                this._uow.GenericRepository<ProviderAwardsAndRecognition>().Update(Awards);
                this._uow.Save();
            }
            return Awards;
        }

        #endregion

        #region Delete ProviderInsurance 
        public ProviderInsurance DeleteProviderInsurance(int ProviderInsuranceID)
        {
            var insur = this._uow.GenericRepository<ProviderInsurance>().Table().Where(x => x.ProviderInsuranceID == ProviderInsuranceID).SingleOrDefault();
            if (insur != null)
            {
                insur.Deleted = true;
                this._uow.GenericRepository<ProviderInsurance>().Update(insur);
                this._uow.Save();
            }
            return insur;
        }

        #endregion

        public List<ProviderLocationTimingModel> GetProviderLocationTimings(int providerLocationID)
        {
            var loationtiming = (from lt in this._uow.GenericRepository<ProviderLocationTiming>().Table().Where(x => x.Deleted != true && x.ProviderLocationID == providerLocationID)
                                 join jd in this._uow.GenericRepository<ProviderLocation>().Table() on lt.ProviderLocationID equals jd.ProviderLocationID
                                 select
                                  new
                                  {
                                      lt.ProviderLocationTimingID,
                                      lt.ProviderLocationID,
                                      lt.TimeSlotDuration,
                                      lt.BookingPerSlot,
                                      lt.BookingPerDay,
                                      lt.AppointmentDay,
                                      lt.AppointmentAllowed,
                                      lt.RegularWorkHrsFrom,
                                      lt.RegularWorkHrsTo,
                                      lt.BreakHrsFrom,
                                      lt.BreakHrsTo,
                                      lt.EffectiveDate,
                                      lt.TerminationDate,
                                      lt.NoOfSlots,
                                      jd.FacilityID

                                  }).AsEnumerable().Select(PTL => new ProviderLocationTimingModel
                                  {
                                      ProviderLocationTimingID = PTL.ProviderLocationTimingID,
                                      ProviderLocationID = PTL.ProviderLocationID,
                                      TimeSlotDuration = PTL.TimeSlotDuration,
                                      BookingPerSlot = PTL.BookingPerSlot,
                                      BookingPerDay = PTL.BookingPerDay,
                                      AppointmentDay = PTL.AppointmentDay,
                                      AppointmentAllowed = PTL.AppointmentAllowed,
                                      RegularWorkHrsFrom = PTL.RegularWorkHrsFrom,
                                      RegularWorkHrsTo = PTL.RegularWorkHrsTo,
                                      BreakHrsFrom = PTL.BreakHrsFrom,
                                      BreakHrsTo = PTL.BreakHrsTo,
                                      EffectiveDate = PTL.EffectiveDate,
                                      TerminationDate = PTL.TerminationDate,
                                      NoOfSlots = PTL.NoOfSlots,
                                      FacilityName = this.getbyfacilityname(PTL.FacilityID)

                                  }).ToList();

            return loationtiming;


        }

        public string getbyfacilityname(int FacilityID)
        {
            string facilityname = "";


            var facilityrecord = this._uow.GenericRepository<Facility>().Table().Where(x => x.FacilityID == FacilityID).FirstOrDefault();


            if (facilityrecord != null)
            {
                facilityname = facilityrecord.FacilityName;
            }


            return facilityname;
        }




    }
}
