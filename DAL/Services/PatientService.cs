using EndocPM.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EndocPM.WebAPI
{
    public class PatientService : IPatientService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _iMasterService;
        private IWebHostEnvironment _hostingEnvironment;

        //public string ConnectionString = ConfigurationManager.ConnectionStrings["EndocDataContext"].ConnectionString;
        public PatientService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService iMasterService, IWebHostEnvironment hostingEnvironment)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _iMasterService = iMasterService;
            _hostingEnvironment = hostingEnvironment;
        }


        #region GetPatients
        public List<PatientModel> GetPatients()
        {
            var queryPatients = (from p in this._uow.GenericRepository<Patient>().Table().Where(x => x.Deleted != true)
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
                                     DrugName = this.PatientMedicationModelsbyPatientID(x.PatientID).Count != 0 ?
                                                this.PatientMedicationModelsbyPatientID(x.PatientID).FirstOrDefault().DrugName : "None",// x.DrugName,
                                     Quantity = this.PatientMedicationModelsbyPatientID(x.PatientID).Count != 0 ?
                                                this.PatientMedicationModelsbyPatientID(x.PatientID).FirstOrDefault().Quantity : 0,//x.Quantity,
                                                                                                                                   //VitalSignModelss = this.vitalSignModelByPatientID(x.PatientID),
                                                                                                                                   //PatientMedicationModelss = this.PatientMedicationModelsbyPatientID(x.PatientID),
                                                                                                                                   //PatientAllergyModelss = this.AllergyModelByPatientID(x.PatientID),
                                                                                                                                   //PatientWorkHistoryModelss = this.patientWorkHistoryModelsByPatientID(x.PatientID),
                                                                                                                                   //FamilyHealthHistoryModelss = this.familyHealthHistoryModelByPatientID(x.PatientID),
                                                                                                                                   //PatientImmunizationModels = this.patientImmunizationModelByPatientID(x.PatientID),
                                                                                                                                   //PatientDiagnosticListModels = this.patientDiagnosticListModelByPatientID(x.PatientID),
                                                                                                                                   //PatientInsuranceModels = this.patientInsuranceModelByPaientID(x.PatientID),
                                                                                                                                   //PatientLabOrderModels = this.PatientLabOrderTestModelByPatientID(x.PatientID)

                                 }).ToList();

            return queryPatients;
        }
        #endregion

        #region vitalSignModelByPatientID
        public List<VitalSignModel> vitalSignModelByPatientID(int PatientID)
        {
            var VitalSign = (from a in this._uow.GenericRepository<VitalSign>().Table().Where(x => x.PatientID == PatientID)
                             join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                             select
                             new
                             {
                                 a.VitalSignID,
                                 a.PatientID,
                                 a.PatientEncounterID,
                                 a.RecordedDate,
                                 a.Height,
                                 a.Weight,
                                 a.Temperature,
                                 a.TemperatureLocationID,
                                 a.OxygenSaturation,
                                 a.BloodPressureSystolic,
                                 a.BloodPressureDiastolic,
                                 a.HeartRate,
                                 a.RespiratoryRate,
                                 a.HeadCircumference,
                                 a.WaistCircumference,
                                 a.SmokingCategoryID,
                                 a.Notes,
                                 a.Deleted,
                                 a.CreatedDate,
                                 a.CreatedBy,
                                 a.ModifiedBy,
                                 a.ModifiedDate,
                                 a.PatientVisitID,
                                 a.IsPrinted,
                                 a.RecordedTime,
                                 a.NotesSnomedCT,
                                 a.VitalCodeForCDS,
                                 a.ExternalVitalSignID
                             }).AsEnumerable().Select(xx => new VitalSignModel
                             {
                                 VitalSignID = xx.VitalSignID,
                                 PatientID = xx.PatientID,
                                 PatientEncounterID = xx.PatientEncounterID,
                                 RecordedDate = xx.RecordedDate,
                                 Height = xx.Height,
                                 Weight = xx.Weight,
                                 Temperature = xx.Temperature,
                                 TemperatureLocationID = xx.TemperatureLocationID,
                                 OxygenSaturation = xx.OxygenSaturation,
                                 BloodPressureSystolic = xx.BloodPressureSystolic,
                                 BloodPressureDiastolic = xx.BloodPressureDiastolic,
                                 HeartRate = xx.HeartRate,
                                 RespiratoryRate = xx.RespiratoryRate,
                                 HeadCircumference = xx.HeadCircumference,
                                 WaistCircumference = xx.WaistCircumference,
                                 SmokingCategoryID = xx.SmokingCategoryID,
                                 Notes = xx.Notes,
                                 Deleted = xx.Deleted,
                                 CreatedDate = xx.CreatedDate,
                                 CreatedBy = xx.CreatedBy,
                                 ModifiedBy = xx.ModifiedBy,
                                 ModifiedDate = xx.ModifiedDate,
                                 PatientVisitID = xx.PatientVisitID,
                                 IsPrinted = xx.IsPrinted,
                                 RecordedTime = xx.RecordedTime,
                                 NotesSnomedCT = xx.NotesSnomedCT,
                                 VitalCodeForCDS = xx.VitalCodeForCDS,
                                 ExternalVitalSignID = xx.ExternalVitalSignID,
                             }).ToList();
            return VitalSign;
        }
        #endregion

        #region PatientMedicationModelsbyPatientID

        public List<PatientMedicationModel> PatientMedicationModelsbyPatientID(int PatientID)
        {
            var getmedication = (from a in this._uow.GenericRepository<PatientMedication>().Table().Where(x => x.Deleted != true & x.PatientID == PatientID)
                                 join b in this._uow.GenericRepository<Patient>().Table() //.Where(x=>x.PatientID == PatientID)
                                 on a.PatientID equals b.PatientID
                                 select
                                 new
                                 {
                                     a.PatientEncounterID,
                                     a.PatientID,
                                     a.RecordedDate,
                                     a.PatientMedicationID,
                                     a.StartedDate,
                                     a.DrugCodeID,
                                     a.PatientInstructions,
                                     a.CurrentStatus,
                                     a.Quantity,
                                     a.DispenseFormID,
                                     a.Refill,
                                     a.AllowSubstitution,
                                     a.Prescriber,
                                     a.DrugName,
                                     a.ExpiryDate,
                                     a.PrescribedDate,
                                     a.DosageFormID,
                                     a.SubstitutionDrug,
                                     a.SideEffects,
                                     a.NotesToPharmacist,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.PatientVisitID,
                                     a.DeleteReason,
                                     a.RxObjectID,
                                     a.Sig,
                                     a.IsPrinted,
                                     a.RxNormConceptID,
                                     a.RxNormCode,
                                     a.RecordedTime,
                                     a.DispenseAsWritten,
                                     a.RxNormAtomID,
                                     a.ScheduledTestStatusID,
                                     a.Units,
                                     a.MedicationRefusalReasonID,
                                     a.MedicationOrderNotPerformedID,
                                     a.IsScheduled,
                                     a.MedicationBarcode,
                                     a.BarcodeImage,
                                     a.IsReminder,
                                     a.AppointmentDateMetDateEarlierThan,
                                     a.AppointmentDateMetDateEarlierThanHrs,
                                     a.NumberOfMessagesToSendPerPatient,
                                     a.IntervalPerMessage,
                                     a.IntervalBetweenMessagesTypeId,
                                     a.ImmunizationRouteID,
                                     a.MedicatedDate,
                                     a.MedicatedTime,
                                     a.IsFormularyCheck,
                                     a.DrugCodeForCDS,
                                     a.ExternalMedicationID,
                                     a.Frequency,
                                     a.PackageDescription

                                 }).AsEnumerable().Select(ss => new PatientMedicationModel
                                 {
                                     PatientEncounterID = ss.PatientEncounterID,
                                     PatientID = ss.PatientID,
                                     RecordedDate = ss.RecordedDate,
                                     PatientMedicationID = ss.PatientMedicationID,
                                     StartedDate = ss.StartedDate,
                                     DrugCodeID = ss.DrugCodeID,
                                     PatientInstructions = ss.PatientInstructions,
                                     CurrentStatus = ss.CurrentStatus,
                                     Quantity = ss.Quantity,
                                     DispenseFormID = ss.DispenseFormID,
                                     Refill = ss.Refill,
                                     AllowSubstitution = ss.AllowSubstitution,
                                     Prescriber = ss.Prescriber,
                                     DrugName = ss.DrugName,
                                     ExpiryDate = ss.ExpiryDate,
                                     PrescribedDate = ss.PrescribedDate,
                                     DosageFormID = ss.DosageFormID,
                                     SubstitutionDrug = ss.SubstitutionDrug,
                                     SideEffects = ss.SideEffects,
                                     NotesToPharmacist = ss.NotesToPharmacist,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedDate = ss.MedicatedDate,
                                     ModifiedBy = ss.ModifiedBy,
                                     PatientVisitID = ss.PatientVisitID,
                                     DeleteReason = ss.DeleteReason,
                                     RxObjectID = ss.RxObjectID,
                                     Sig = ss.Sig,
                                     IsPrinted = ss.IsPrinted,
                                     RxNormConceptID = ss.RxNormConceptID,
                                     RxNormCode = ss.RxNormCode,
                                     RecordedTime = ss.RecordedTime,
                                     DispenseAsWritten = ss.DispenseAsWritten,
                                     RxNormAtomID = ss.RxNormAtomID,
                                     ScheduledTestStatusID = ss.ScheduledTestStatusID,
                                     Units = ss.Units,
                                     MedicationRefusalReasonID = ss.MedicationRefusalReasonID,
                                     MedicationOrderNotPerformedID = ss.MedicationOrderNotPerformedID,
                                     IsScheduled = ss.IsScheduled,
                                     MedicationBarcode = ss.MedicationBarcode,
                                     BarcodeImage = ss.BarcodeImage,
                                     IsReminder = ss.IsReminder,
                                     AppointmentDateMetDateEarlierThan = ss.AppointmentDateMetDateEarlierThan,
                                     AppointmentDateMetDateEarlierThanHrs = ss.AppointmentDateMetDateEarlierThanHrs,
                                     NumberOfMessagesToSendPerPatient = ss.NumberOfMessagesToSendPerPatient,
                                     IntervalPerMessage = ss.IntervalPerMessage,
                                     IntervalBetweenMessagesTypeId = ss.IntervalBetweenMessagesTypeId,
                                     ImmunizationRouteID = ss.ImmunizationRouteID,
                                     MedicatedDate = ss.MedicatedDate,
                                     MedicatedTime = ss.MedicatedTime,
                                     IsFormularyCheck = ss.IsFormularyCheck,
                                     DrugCodeForCDS = ss.DrugCodeForCDS,
                                     ExternalMedicationID = ss.ExternalMedicationID,
                                     Frequency =ss.Frequency,
                                     PackageDescription =ss.PackageDescription,
                                     MedicationRefusalReasonDescription = ss.MedicationRefusalReasonID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == ss.MedicationRefusalReasonID).FirstOrDefault().Description : "",
                                     StatusDescription = ss.CurrentStatus > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.CurrentStatus).FirstOrDefault().Description : "",
                                     DosageFormDescription = ss.DosageFormID > 0 ? this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Description : "",
                                     DispenseFormDescription = ss.DispenseFormID > 0 ? this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Description : "",
                                     DrugCodeDescription = ss.DrugCodeID > 0 ? this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().NDCCode
                                                            + "/" + this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().Description : "",
                                     ImmunizationRouteDescription = ss.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == ss.ImmunizationRouteID).FirstOrDefault().Route : "",
                                 }).ToList();

            return getmedication;
        }
        #endregion

        #region PatientMedicationModelsbyPatientMedicationID

        public PatientMedicationModel GetpatientMedicationRecordByID(int PatientMedicationID)
        {
            var getmedication = (from a in this._uow.GenericRepository<PatientMedication>().Table().Where(x => x.Deleted != true & x.PatientMedicationID == PatientMedicationID)
                                 join b in this._uow.GenericRepository<Patient>().Table()
                                 on a.PatientID equals b.PatientID
                                 select
                                 new
                                 {
                                     a.PatientEncounterID,
                                     a.PatientID,
                                     a.RecordedDate,
                                     a.PatientMedicationID,
                                     a.StartedDate,
                                     a.DrugCodeID,
                                     a.PatientInstructions,
                                     a.CurrentStatus,
                                     a.Quantity,
                                     a.DispenseFormID,
                                     a.Refill,
                                     a.AllowSubstitution,
                                     a.Prescriber,
                                     a.DrugName,
                                     a.ExpiryDate,
                                     a.PrescribedDate,
                                     a.DosageFormID,
                                     a.SubstitutionDrug,
                                     a.SideEffects,
                                     a.NotesToPharmacist,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.PatientVisitID,
                                     a.DeleteReason,
                                     a.RxObjectID,
                                     a.Sig,
                                     a.IsPrinted,
                                     a.RxNormConceptID,
                                     a.RxNormCode,
                                     a.RecordedTime,
                                     a.DispenseAsWritten,
                                     a.RxNormAtomID,
                                     a.ScheduledTestStatusID,
                                     a.Units,
                                     a.MedicationRefusalReasonID,
                                     a.MedicationOrderNotPerformedID,
                                     a.IsScheduled,
                                     a.MedicationBarcode,
                                     a.BarcodeImage,
                                     a.IsReminder,
                                     a.AppointmentDateMetDateEarlierThan,
                                     a.AppointmentDateMetDateEarlierThanHrs,
                                     a.NumberOfMessagesToSendPerPatient,
                                     a.IntervalPerMessage,
                                     a.IntervalBetweenMessagesTypeId,
                                     a.ImmunizationRouteID,
                                     a.MedicatedDate,
                                     a.MedicatedTime,
                                     a.IsFormularyCheck,
                                     a.DrugCodeForCDS,
                                     a.ExternalMedicationID,
                                     a.Frequency,
                                     a.PackageDescription
                                 }).AsEnumerable().Select(ss => new PatientMedicationModel
                                 {
                                     PatientEncounterID = ss.PatientEncounterID,
                                     PatientID = ss.PatientID,
                                     RecordedDate = ss.RecordedDate,
                                     PatientMedicationID = ss.PatientMedicationID,
                                     StartedDate = ss.StartedDate,
                                     DrugCodeID = ss.DrugCodeID,
                                     PatientInstructions = ss.PatientInstructions,
                                     CurrentStatus = ss.CurrentStatus,
                                     Quantity = ss.Quantity,
                                     DispenseFormID = ss.DispenseFormID,
                                     Refill = ss.Refill,
                                     AllowSubstitution = ss.AllowSubstitution,
                                     Prescriber = ss.Prescriber,
                                     DrugName = ss.DrugName,
                                     ExpiryDate = ss.ExpiryDate,
                                     PrescribedDate = ss.PrescribedDate,
                                     DosageFormID = ss.DosageFormID,
                                     SubstitutionDrug = ss.SubstitutionDrug,
                                     SideEffects = ss.SideEffects,
                                     NotesToPharmacist = ss.NotesToPharmacist,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedDate = ss.MedicatedDate,
                                     ModifiedBy = ss.ModifiedBy,
                                     PatientVisitID = ss.PatientVisitID,
                                     DeleteReason = ss.DeleteReason,
                                     RxObjectID = ss.RxObjectID,
                                     Sig = ss.Sig,
                                     IsPrinted = ss.IsPrinted,
                                     RxNormConceptID = ss.RxNormConceptID,
                                     RxNormCode = ss.RxNormCode,
                                     RecordedTime = ss.RecordedTime,
                                     DispenseAsWritten = ss.DispenseAsWritten,
                                     RxNormAtomID = ss.RxNormAtomID,
                                     ScheduledTestStatusID = ss.ScheduledTestStatusID,
                                     Units = ss.Units,
                                     MedicationRefusalReasonID = ss.MedicationRefusalReasonID,
                                     MedicationOrderNotPerformedID = ss.MedicationOrderNotPerformedID,
                                     IsScheduled = ss.IsScheduled,
                                     MedicationBarcode = ss.MedicationBarcode,
                                     BarcodeImage = ss.BarcodeImage,
                                     IsReminder = ss.IsReminder,
                                     AppointmentDateMetDateEarlierThan = ss.AppointmentDateMetDateEarlierThan,
                                     AppointmentDateMetDateEarlierThanHrs = ss.AppointmentDateMetDateEarlierThanHrs,
                                     NumberOfMessagesToSendPerPatient = ss.NumberOfMessagesToSendPerPatient,
                                     IntervalPerMessage = ss.IntervalPerMessage,
                                     IntervalBetweenMessagesTypeId = ss.IntervalBetweenMessagesTypeId,
                                     ImmunizationRouteID = ss.ImmunizationRouteID,
                                     MedicatedDate = ss.MedicatedDate,
                                     MedicatedTime = ss.MedicatedTime,
                                     IsFormularyCheck = ss.IsFormularyCheck,
                                     DrugCodeForCDS = ss.DrugCodeForCDS,
                                     ExternalMedicationID = ss.ExternalMedicationID,
                                     Frequency =ss.Frequency,
                                     PackageDescription =ss.PackageDescription,
                                     MedicationRefusalReasonDescription =ss.MedicationRefusalReasonID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == ss.MedicationRefusalReasonID).FirstOrDefault().Description:"",
                                     StatusDescription = ss.CurrentStatus > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.CurrentStatus).FirstOrDefault().Description : "",
                                     DosageFormDescription = ss.DosageFormID > 0 ? this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Description : "",
                                     DispenseFormDescription = ss.DispenseFormID > 0 ? this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Description : "",
                                     DrugCodeDescription = ss.DrugCodeID > 0 ? this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().NDCCode
                                                            + "/" + this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().Description : "",
                                     ImmunizationRouteDescription = ss.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == ss.ImmunizationRouteID).FirstOrDefault().Route : "",
                                 }).FirstOrDefault();

            return getmedication;
        }
        #endregion

        #region AllergyModelByPatientID
        public List<PatientAllergyModel> AllergyModelByPatientID(int PatientID)
        {
            var Allergy = (from a in this._uow.GenericRepository<PatientAllergy>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                           join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                           select
                           new
                           {
                               a.PatientAllergyID,
                               a.PatientID,
                               a.PatientEncounterID,
                               a.RecordedDate,
                               a.AllergyTypeID,
                               a.AllergySeverityID,
                               a.AllergyName,
                               a.Reaction,
                               a.IsActive,
                               a.AllergyOnsetID,
                               a.OnSetDate,
                               a.Deleted,
                               a.CreatedDate,
                               a.CreatedBy,
                               a.ModifiedDate,
                               a.ModifiedBy,
                               a.Notes,
                               a.AllergyDescription,
                               a.PatientVisitID,
                               a.DeleteReason,
                               a.IsPrinted,
                               a.AllergyObjectID,
                               a.AllergyCode,
                               a.RxNormConceptID,
                               a.NotesSnomedCT,
                               a.AllergyNameID,
                               a.ExternalAllergyID,
                           }).AsEnumerable().Select(xx => new PatientAllergyModel
                           {
                               PatientAllergyID = xx.PatientAllergyID,
                               PatientID = xx.PatientID,
                               PatientEncounterID = xx.PatientEncounterID,
                               RecordedDate = xx.RecordedDate,
                               AllergyTypeID = xx.AllergyTypeID,
                               AllergyCode = xx.AllergyCode,
                               AllergySeverityID = xx.AllergySeverityID,
                               AllergyName = xx.AllergyName,
                               Reaction = xx.Reaction,
                               IsActive = xx.IsActive,
                               AllergyOnsetID = xx.AllergyOnsetID,
                               OnSetDate = xx.OnSetDate,
                               Deleted = xx.Deleted,
                               CreatedDate = xx.CreatedDate,
                               CreatedBy = xx.CreatedBy,
                               ModifiedDate = xx.ModifiedDate,
                               ModifiedBy = xx.ModifiedBy,
                               Notes = xx.Notes,
                               AllergyDescription = xx.AllergyDescription,
                               PatientVisitID = xx.PatientVisitID,
                               DeleteReason = xx.DeleteReason,
                               IsPrinted = xx.IsPrinted,
                               AllergyObjectID = xx.AllergyObjectID,
                               RxNormConceptID = xx.RxNormConceptID,
                               NotesSnomedCT = xx.NotesSnomedCT,
                               AllergyNameID = xx.AllergyNameID,
                               ExternalAllergyID = xx.ExternalAllergyID,
                               AllergyTypeDescription = xx.AllergyTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergyTypeID.Value).FirstOrDefault().Description : "",
                               AllergyOnsetDescription = xx.AllergyOnsetID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergyOnsetID.Value).FirstOrDefault().Description : "",
                               AllergySeverityDescription = xx.AllergySeverityID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergySeverityID.Value).FirstOrDefault().Description : ""

                           }).ToList();
            return Allergy;
        }

        #endregion


        #region AllergyModelByPatientAllergyID
        public PatientAllergyModel GetallergyRecordByID(int PatientAllergyID)
        {
            var Allergy = (from a in this._uow.GenericRepository<PatientAllergy>().Table().Where(x => x.Deleted != true && x.PatientAllergyID == PatientAllergyID)
                           join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                           select
                           new
                           {
                               a.PatientAllergyID,
                               a.PatientID,
                               a.PatientEncounterID,
                               a.RecordedDate,
                               a.AllergyTypeID,
                               a.AllergySeverityID,
                               a.AllergyName,
                               a.Reaction,
                               a.IsActive,
                               a.AllergyOnsetID,
                               a.OnSetDate,
                               a.Deleted,
                               a.CreatedDate,
                               a.CreatedBy,
                               a.ModifiedDate,
                               a.ModifiedBy,
                               a.Notes,
                               a.AllergyDescription,
                               a.PatientVisitID,
                               a.DeleteReason,
                               a.IsPrinted,
                               a.AllergyObjectID,
                               a.AllergyCode,
                               a.RxNormConceptID,
                               a.NotesSnomedCT,
                               a.AllergyNameID,
                               a.ExternalAllergyID,
                           }).AsEnumerable().Select(xx => new PatientAllergyModel
                           {
                               PatientAllergyID = xx.PatientAllergyID,
                               PatientID = xx.PatientID,
                               PatientEncounterID = xx.PatientEncounterID,
                               RecordedDate = xx.RecordedDate,
                               AllergyTypeID = xx.AllergyTypeID,
                               AllergyCode = xx.AllergyCode,
                               AllergySeverityID = xx.AllergySeverityID,
                               AllergyName = xx.AllergyName,
                               Reaction = xx.Reaction,
                               IsActive = xx.IsActive,
                               AllergyOnsetID = xx.AllergyOnsetID,
                               OnSetDate = xx.OnSetDate,
                               Deleted = xx.Deleted,
                               CreatedDate = xx.CreatedDate,
                               CreatedBy = xx.CreatedBy,
                               ModifiedDate = xx.ModifiedDate,
                               ModifiedBy = xx.ModifiedBy,
                               Notes = xx.Notes,
                               AllergyDescription = xx.AllergyDescription,
                               PatientVisitID = xx.PatientVisitID,
                               DeleteReason = xx.DeleteReason,
                               IsPrinted = xx.IsPrinted,
                               AllergyObjectID = xx.AllergyObjectID,
                               RxNormConceptID = xx.RxNormConceptID,
                               NotesSnomedCT = xx.NotesSnomedCT,
                               AllergyNameID = xx.AllergyNameID,
                               ExternalAllergyID = xx.ExternalAllergyID,
                               AllergyTypeDescription = xx.AllergyTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergyTypeID.Value).FirstOrDefault().Description : "",
                               AllergyOnsetDescription = xx.AllergyOnsetID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergyOnsetID.Value).FirstOrDefault().Description : "",
                               AllergySeverityDescription = xx.AllergySeverityID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.CommonMasterID == xx.AllergySeverityID.Value).FirstOrDefault().Description : ""

                           }).FirstOrDefault();
            return Allergy;
        }

        #endregion


        #region patientWorkHistoryModelsByPatientID
        public List<PatientWorkHistoryModel> patientWorkHistoryModelsByPatientID(int PatientID)
        {
            var workHistory = (from a in this._uow.GenericRepository<PatientWorkHistory>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                               join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                               select
                               new
                               {
                                   a.PatientWorkHistoryID,
                                   a.PatientID,
                                   a.RecordedDate,
                                   a.EmployerName,
                                   a.AddressLine1,
                                   a.AddressLine2,
                                   a.City,
                                   a.State,
                                   a.Country,
                                   a.ZIP,
                                   a.County,
                                   a.ContactPerson,
                                   a.Telephone,
                                   a.AlternatePhone,
                                   a.WorkDateFrom,
                                   a.WorkDateTo,
                                   a.Deleted,
                                   a.CreatedDate,
                                   a.CreatedBy,
                                   a.ModifiedDate,
                                   a.ModifiedBy,
                                   a.PatientVisitID,
                                   a.Notes
                               }).AsEnumerable().Select(xx => new PatientWorkHistoryModel
                               {
                                   PatientWorkHistoryID = xx.PatientWorkHistoryID,
                                   PatientID = xx.PatientID,
                                   RecordedDate = xx.RecordedDate,
                                   EmployerName = xx.EmployerName,
                                   AddressLine1 = xx.AddressLine1,
                                   AddressLine2 = xx.AddressLine2,
                                   City = xx.City,
                                   State = xx.State,
                                   Country = xx.Country,
                                   ZIP = xx.ZIP,
                                   County = xx.Country,
                                   CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                   ContactPerson = xx.ContactPerson,
                                   Telephone = xx.Telephone,
                                   AlternatePhone = xx.AlternatePhone,
                                   WorkDateFrom = xx.WorkDateFrom,
                                   WorkDateTo = xx.WorkDateTo,
                                   Deleted = xx.Deleted,
                                   CreatedDate = xx.CreatedDate,
                                   CreatedBy = xx.CreatedBy,
                                   ModifiedDate = xx.ModifiedDate,
                                   ModifiedBy = xx.ModifiedBy,
                                   PatientVisitID = xx.PatientVisitID,
                                   Notes = xx.Notes
                               }).ToList();

            return workHistory;
        }

        #endregion

        #region patientWorkHistoryModelsByPatientWorkHistoryID
        public PatientWorkHistoryModel GetpatientWorkHistoryRecordByID(int PatientWorkHistoryID)
        {
            var workHistory = (from a in this._uow.GenericRepository<PatientWorkHistory>().Table().Where(x => x.Deleted != true && x.PatientWorkHistoryID == PatientWorkHistoryID)
                               join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                               select
                               new
                               {
                                   a.PatientWorkHistoryID,
                                   a.PatientID,
                                   a.RecordedDate,
                                   a.EmployerName,
                                   a.AddressLine1,
                                   a.AddressLine2,
                                   a.City,
                                   a.State,
                                   a.Country,
                                   a.ZIP,
                                   a.County,
                                   a.ContactPerson,
                                   a.Telephone,
                                   a.AlternatePhone,
                                   a.WorkDateFrom,
                                   a.WorkDateTo,
                                   a.Deleted,
                                   a.CreatedDate,
                                   a.CreatedBy,
                                   a.ModifiedDate,
                                   a.ModifiedBy,
                                   a.PatientVisitID,
                                   a.Notes
                               }).AsEnumerable().Select(xx => new PatientWorkHistoryModel
                               {
                                   PatientWorkHistoryID = xx.PatientWorkHistoryID,
                                   PatientID = xx.PatientID,
                                   RecordedDate = xx.RecordedDate,
                                   EmployerName = xx.EmployerName,
                                   AddressLine1 = xx.AddressLine1,
                                   AddressLine2 = xx.AddressLine2,
                                   City = xx.City,
                                   State = xx.State,
                                   Country = xx.Country,
                                   CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                   ZIP = xx.ZIP,
                                   County = xx.Country,
                                   ContactPerson = xx.ContactPerson,
                                   Telephone = xx.Telephone,
                                   AlternatePhone = xx.AlternatePhone,
                                   WorkDateFrom = xx.WorkDateFrom,
                                   WorkDateTo = xx.WorkDateTo,
                                   Deleted = xx.Deleted,
                                   CreatedDate = xx.CreatedDate,
                                   CreatedBy = xx.CreatedBy,
                                   ModifiedDate = xx.ModifiedDate,
                                   ModifiedBy = xx.ModifiedBy,
                                   PatientVisitID = xx.PatientVisitID,
                                   Notes = xx.Notes
                               }).FirstOrDefault();

            return workHistory;
        }

        #endregion

        #region familyHealthHistoryModelByPatientID

        public List<FamilyHealthHistoryModel> familyHealthHistoryModelByPatientID(int PatientID)
        {
            var FamilyHealthHistory = (from a in this._uow.GenericRepository<FamilyHealthHistory>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                                       join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID

                                       select
                                       new
                                       {
                                           a.FamilyHealthHistoryID,
                                           a.PatientID,
                                           a.PatientRelationID,
                                           a.PersonName,
                                           a.ClinicalNotes,
                                           a.RecordedDate,
                                           a.Deleted,
                                           a.CreatedDate,
                                           a.CreatedBy,
                                           a.ModifiedBy,
                                           a.ModifiedDate,
                                           a.PatientVisitID,
                                           a.Notes,
                                           a.StatusCodeID,
                                           a.AgeatDeath,
                                           a.AgeatDiagnosis,
                                           a.GenderID,
                                           a.DateOfBirth,
                                           a.Disease,
                                           a.Living
                                       }).AsEnumerable().Select(xx => new FamilyHealthHistoryModel
                                       {
                                           FamilyHealthHistoryID = xx.FamilyHealthHistoryID,
                                           PatientID = xx.PatientID,
                                           PatientRelationID = xx.PatientRelationID,
                                           PersonName = xx.PersonName,
                                           ClinicalNotes = xx.ClinicalNotes,
                                           RecordedDate = xx.RecordedDate,
                                           Deleted = xx.Deleted,
                                           CreatedDate = xx.CreatedDate,
                                           CreatedBy = xx.CreatedBy,
                                           ModifiedBy = xx.ModifiedBy,
                                           ModifiedDate = xx.ModifiedDate,
                                           PatientVisitID = xx.PatientVisitID,
                                           Notes = xx.Notes,
                                           StatusCodeID = xx.StatusCodeID,
                                           StatusDescription = xx.StatusCodeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.StatusCodeID).FirstOrDefault().Description : "",
                                           AgeatDeath = xx.AgeatDeath,
                                           AgeatDiagnosis = xx.AgeatDiagnosis,
                                           GenderID = xx.GenderID,
                                           GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                           PatientRelationShipDescription = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                           DateOfBirth = xx.DateOfBirth,
                                           Disease = xx.Disease,
                                           Living = xx.Living,
                                       }).ToList();

            return FamilyHealthHistory;
        }
        #endregion

        #region familyHealthHistoryModelByFamilyHealthHistoryID

        public FamilyHealthHistoryModel GetfamilyHealthHistoryRecordByID(int FamilyHealthHistoryID)
        {
            var FamilyHealthHistory = (from a in this._uow.GenericRepository<FamilyHealthHistory>().Table().Where(x => x.Deleted != true && x.FamilyHealthHistoryID == FamilyHealthHistoryID)
                                       join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID

                                       select
                                       new
                                       {
                                           a.FamilyHealthHistoryID,
                                           a.PatientID,
                                           a.PatientRelationID,
                                           a.PersonName,
                                           a.ClinicalNotes,
                                           a.RecordedDate,
                                           a.Deleted,
                                           a.CreatedDate,
                                           a.CreatedBy,
                                           a.ModifiedBy,
                                           a.ModifiedDate,
                                           a.PatientVisitID,
                                           a.Notes,
                                           a.StatusCodeID,
                                           a.AgeatDeath,
                                           a.AgeatDiagnosis,
                                           a.GenderID,
                                           a.DateOfBirth,
                                           a.Disease,
                                           a.Living
                                       }).AsEnumerable().Select(xx => new FamilyHealthHistoryModel
                                       {
                                           FamilyHealthHistoryID = xx.FamilyHealthHistoryID,
                                           PatientID = xx.PatientID,
                                           PatientRelationID = xx.PatientRelationID,
                                           PersonName = xx.PersonName,
                                           ClinicalNotes = xx.ClinicalNotes,
                                           RecordedDate = xx.RecordedDate,
                                           Deleted = xx.Deleted,
                                           CreatedDate = xx.CreatedDate,
                                           CreatedBy = xx.CreatedBy,
                                           ModifiedBy = xx.ModifiedBy,
                                           ModifiedDate = xx.ModifiedDate,
                                           PatientVisitID = xx.PatientVisitID,
                                           Notes = xx.Notes,
                                           StatusCodeID = xx.StatusCodeID,
                                           StatusDescription = xx.StatusCodeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.StatusCodeID).FirstOrDefault().Description : "",
                                           AgeatDeath = xx.AgeatDeath,
                                           AgeatDiagnosis = xx.AgeatDiagnosis,
                                           GenderID = xx.GenderID,
                                           GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                           PatientRelationShipDescription = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                           DateOfBirth = xx.DateOfBirth,
                                           Disease = xx.Disease,
                                           Living = xx.Living,
                                       }).FirstOrDefault();

            return FamilyHealthHistory;
        }
        #endregion


        #region  patientImmunizationModelByPatientID

        public List<PatientImmunizationModel> patientImmunizationModelByPatientID(int PatientID)
        {
            var Immunization = (from a in this._uow.GenericRepository<PatientImmunization>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                               join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID
                                select
                                new
                                {
                                    a.PatientImmunizationID,
                                    a.PatientID,
                                    a.VaccinationID,
                                    a.ImmunizationID,
                                    a.VaccinationManufacturerID,
                                    a.ImmunizedAge,
                                    a.Dose,
                                    a.LotNumber,
                                    a.Route,
                                    a.HumanBodySite,
                                    a.InjectedOn,
                                    a.InjectedTime,
                                    a.InjectedBy,
                                    a.DoseUnits,
                                    a.RemindBeforeDays,
                                    a.RemindBeforeHours,
                                    a.Notes,
                                    a.ExpirationDate,
                                    a.ImmunizationRouteID,
                                    a.Product,
                                    a.Manufacturer,
                                    a.HumanBodySiteID,
                                    a.ImmunizationNotes,
                                    a.IsPrinted,
                                    a.ImmunizationRegistrySentStatusID,
                                    a.PatientVisitID,        
                                    a.RecordedDate,
                                    a.ReviewedByID,
                                    a.Deleted,
                                    a.CreatedDate,
                                    a.CreatedBy,
                                    a.ModifiedDate,
                                    a.ModifiedBy,
                                    a.DiseasePresumedImmunity,
                                    a.RegistryPublicityEffectiveDate,
                                    a.PublicityCodeID,
                                    a.RegistryStatusEffectiveDate,
                                    a.NotesSnomedCT,
                                    a.VFCFinancialClassID,
                                    a.RefusalReasonCodeID,      
                                    a.ImmunizationInformationSourceID,
                                    a.ProtectionIndicator,
                                    a.ProtectionIndicatorEffective,
                                    a.InjectedByID,
                                    a.IsReminder,
                                    a.NumberOfMessagesToSendPerPatient,
                                    a.IntervalPerMessage,
                                    a.IntervalBetweenMessagesTypeId,
                                    a.ImmunizationDate

                                   
                                }).AsEnumerable().Select(xx => new PatientImmunizationModel
                                {
                                    PatientImmunizationID = xx.PatientImmunizationID,
                                    PatientID = xx.PatientID,
                                    VaccinationID = xx.VaccinationID,
                                    ImmunizationID = xx.ImmunizationID,
                                    ImmunizedAge = xx.ImmunizedAge,
                                    Dose = xx.Dose,
                                    LotNumber = xx.LotNumber,
                                    Route = xx.Route,
                                    HumanBodySiteID = xx.HumanBodySiteID,
                                    InjectedOn = xx.InjectedOn,
                                    InjectedTime = xx.InjectedTime,
                                    InjectedBy = xx.InjectedBy,
                                    DoseUnits = xx.DoseUnits,
                                    ExpirationDate = xx.ExpirationDate,
                                    ImmunizationRouteID = xx.ImmunizationRouteID,
                                    ImmunizationNotes = xx.ImmunizationNotes,
                                    Deleted = xx.Deleted,
                                    CreatedBy = xx.CreatedBy,
                                    CreatedDate = xx.CreatedDate,
                                    ModifiedBy = xx.ModifiedBy,
                                    ModifiedDate = xx.ModifiedDate,
                                    PatientVisitID = xx.PatientVisitID,
                                    IsPrinted = xx.IsPrinted,
                                    ImmunizationRegistrySentStatusID = xx.ImmunizationRegistrySentStatusID,
                                    RecordedDate = xx.RecordedDate,
                                    ReviewedByID = xx.ReviewedByID,
                                    DiseasePresumedImmunity = xx.DiseasePresumedImmunity,
                                    RegistryStatusEffectiveDate = xx.RegistryStatusEffectiveDate,
                                    PublicityCodeID = xx.PublicityCodeID,
                                    RegistryPublicityEffectiveDate = xx.RegistryPublicityEffectiveDate,
                                    NotesSnomedCT = xx.NotesSnomedCT,
                                    VFCFinancialClassID = xx.VFCFinancialClassID,
                                    RefusalReasonCodeID = xx.RefusalReasonCodeID,
                                    ImmunizationInformationSourceID = xx.ImmunizationInformationSourceID,
                                    ProtectionIndicator = xx.ProtectionIndicator,
                                    ProtectionIndicatorEffective = xx.ProtectionIndicatorEffective,
                                    InjectedByID = xx.InjectedByID,
                                    IsReminder = xx.IsReminder,
                                    RemindBeforeDays = xx.RemindBeforeDays,
                                    RemindBeforeHours = xx.RemindBeforeHours,
                                    NumberOfMessagesToSendPerPatient = xx.NumberOfMessagesToSendPerPatient,
                                    IntervalPerMessage = xx.IntervalPerMessage,
                                    IntervalBetweenMessagesTypeId = xx.IntervalBetweenMessagesTypeId,
                                    ImmunizationDate = xx.ImmunizationDate,
                                    Product = xx.Product,
                                    Manufacturer = xx.Manufacturer,
                                    VaccinationManufacturerID = xx.VaccinationManufacturerID,
                                    HumanBodySiteDescription = xx.HumanBodySiteID > 0 ? this._uow.GenericRepository<HumanBodySite>().Table().Where(x => x.HumanBodySiteID == xx.HumanBodySiteID).FirstOrDefault().Description : "",
                                    PublicityCodeDescription = xx.PublicityCodeID > 0 ? this._uow.GenericRepository<PublicityCode>().Table().Where(x => x.PublicityCodeID == xx.PublicityCodeID).FirstOrDefault().Description : "",
                                    RefusalReasonCodeDescription = xx.RefusalReasonCodeID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == xx.RefusalReasonCodeID).FirstOrDefault().Description : "",
                                    VFCFinancialClassDescription = xx.VFCFinancialClassID > 0 ? this._uow.GenericRepository<VFCFinancialClass>().Table().Where(x => x.VFCFinancialClassID == xx.VFCFinancialClassID).FirstOrDefault().Description : "",
                                    ImmunizationInformationSourceDescription = xx.ImmunizationInformationSourceID > 0 ? this._uow.GenericRepository<ImmunizationInformationSource>().Table().Where(x => x.ImmunizationInformationSourceID == xx.ImmunizationInformationSourceID).FirstOrDefault().Description : "",
                                    ImmunizationRegistryStatusDescription = xx.ImmunizationRegistrySentStatusID > 0 ? this._uow.GenericRepository<ImmunizationRegistryStatus>().Table().Where(x => x.ImmunizationRegistryStatusID == xx.ImmunizationRegistrySentStatusID).FirstOrDefault().Description : "",
                                    RouteDescription = xx.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == xx.ImmunizationRouteID).FirstOrDefault().Route : "",
                                    IntervalBetweenMessagesTypeDescription = xx.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                                }).ToList();

            return Immunization;
        }

        #endregion


        #region  patientImmunizationModelByPatientImmunizationID

        public PatientImmunizationModel GetpatientImmunizationRecordByID(int PatientImmunizationID)
        {
            var Immunization = (from a in this._uow.GenericRepository<PatientImmunization>().Table().Where(x => x.Deleted != true && x.PatientImmunizationID == PatientImmunizationID)
                                join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID
                                select
                                new
                                {
                                    a.PatientImmunizationID,
                                    a.PatientID,
                                    a.VaccinationID,
                                    a.ImmunizationID,
                                    a.VaccinationManufacturerID,
                                    a.ImmunizedAge,
                                    a.Dose,
                                    a.LotNumber,
                                    a.Route,
                                    a.HumanBodySite,
                                    a.InjectedOn,
                                    a.InjectedTime,
                                    a.InjectedBy,
                                    a.DoseUnits,
                                    a.RemindBeforeDays,
                                    a.RemindBeforeHours,
                                    a.Notes,
                                    a.ExpirationDate,
                                    a.ImmunizationRouteID,
                                    a.Product,
                                    a.Manufacturer,
                                    a.HumanBodySiteID,
                                    a.ImmunizationNotes,
                                    a.IsPrinted,
                                    a.ImmunizationRegistrySentStatusID,
                                    a.PatientVisitID,
                                    a.RecordedDate,
                                    a.ReviewedByID,
                                    a.Deleted,
                                    a.CreatedDate,
                                    a.CreatedBy,
                                    a.ModifiedDate,
                                    a.ModifiedBy,
                                    a.DiseasePresumedImmunity,
                                    a.RegistryPublicityEffectiveDate,
                                    a.PublicityCodeID,
                                    a.RegistryStatusEffectiveDate,
                                    a.NotesSnomedCT,
                                    a.VFCFinancialClassID,
                                    a.RefusalReasonCodeID,
                                    a.ImmunizationInformationSourceID,
                                    a.ProtectionIndicator,
                                    a.ProtectionIndicatorEffective,
                                    a.InjectedByID,
                                    a.IsReminder,
                                    a.NumberOfMessagesToSendPerPatient,
                                    a.IntervalPerMessage,
                                    a.IntervalBetweenMessagesTypeId,
                                    a.ImmunizationDate
                                }).AsEnumerable().Select(xx => new PatientImmunizationModel
                                {
                                    PatientImmunizationID = xx.PatientImmunizationID,
                                    PatientID = xx.PatientID,
                                    VaccinationID = xx.VaccinationID,
                                    ImmunizationID = xx.ImmunizationID,
                                    ImmunizedAge = xx.ImmunizedAge,
                                    Dose = xx.Dose,
                                    LotNumber = xx.LotNumber,
                                    Route = xx.Route,
                                    HumanBodySiteID = xx.HumanBodySiteID,
                                    InjectedOn = xx.InjectedOn,
                                    InjectedTime = xx.InjectedTime,
                                    InjectedBy = xx.InjectedBy,
                                    DoseUnits = xx.DoseUnits,
                                    ExpirationDate = xx.ExpirationDate,
                                    ImmunizationRouteID = xx.ImmunizationRouteID,
                                    ImmunizationNotes = xx.ImmunizationNotes,
                                    Deleted = xx.Deleted,
                                    CreatedBy = xx.CreatedBy,
                                    CreatedDate = xx.CreatedDate,
                                    ModifiedBy = xx.ModifiedBy,
                                    ModifiedDate = xx.ModifiedDate,
                                    PatientVisitID = xx.PatientVisitID,
                                    IsPrinted = xx.IsPrinted,
                                    ImmunizationRegistrySentStatusID = xx.ImmunizationRegistrySentStatusID,
                                    RecordedDate = xx.RecordedDate,
                                    ReviewedByID = xx.ReviewedByID,
                                    DiseasePresumedImmunity = xx.DiseasePresumedImmunity,
                                    RegistryStatusEffectiveDate = xx.RegistryStatusEffectiveDate,
                                    PublicityCodeID = xx.PublicityCodeID,
                                    RegistryPublicityEffectiveDate = xx.RegistryPublicityEffectiveDate,
                                    NotesSnomedCT = xx.NotesSnomedCT,
                                    VFCFinancialClassID = xx.VFCFinancialClassID,
                                    RefusalReasonCodeID = xx.RefusalReasonCodeID,
                                    ImmunizationInformationSourceID = xx.ImmunizationInformationSourceID,
                                    ProtectionIndicator = xx.ProtectionIndicator,
                                    ProtectionIndicatorEffective = xx.ProtectionIndicatorEffective,
                                    InjectedByID = xx.InjectedByID,
                                    IsReminder = xx.IsReminder,
                                    RemindBeforeDays = xx.RemindBeforeDays,
                                    RemindBeforeHours = xx.RemindBeforeHours,
                                    NumberOfMessagesToSendPerPatient = xx.NumberOfMessagesToSendPerPatient,
                                    IntervalPerMessage = xx.IntervalPerMessage,
                                    IntervalBetweenMessagesTypeId = xx.IntervalBetweenMessagesTypeId,
                                    ImmunizationDate = xx.ImmunizationDate,
                                    Product = xx.Product,
                                    Manufacturer = xx.Manufacturer,
                                    VaccinationManufacturerID = xx.VaccinationManufacturerID,
                                    HumanBodySiteDescription = xx.HumanBodySiteID > 0 ? this._uow.GenericRepository<HumanBodySite>().Table().Where(x => x.HumanBodySiteID == xx.HumanBodySiteID).FirstOrDefault().Description : "",
                                    PublicityCodeDescription = xx.PublicityCodeID > 0 ? this._uow.GenericRepository<PublicityCode>().Table().Where(x => x.PublicityCodeID == xx.PublicityCodeID).FirstOrDefault().Description : "",
                                    RefusalReasonCodeDescription = xx.RefusalReasonCodeID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == xx.RefusalReasonCodeID).FirstOrDefault().Description : "",
                                    VFCFinancialClassDescription = xx.VFCFinancialClassID > 0 ? this._uow.GenericRepository<VFCFinancialClass>().Table().Where(x => x.VFCFinancialClassID == xx.VFCFinancialClassID).FirstOrDefault().Description : "",
                                    ImmunizationInformationSourceDescription = xx.ImmunizationInformationSourceID > 0 ? this._uow.GenericRepository<ImmunizationInformationSource>().Table().Where(x => x.ImmunizationInformationSourceID == xx.ImmunizationInformationSourceID).FirstOrDefault().Description : "",
                                    ImmunizationRegistryStatusDescription = xx.ImmunizationRegistrySentStatusID > 0 ? this._uow.GenericRepository<ImmunizationRegistryStatus>().Table().Where(x => x.ImmunizationRegistryStatusID == xx.ImmunizationRegistrySentStatusID).FirstOrDefault().Description : "",
                                    RouteDescription = xx.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == xx.ImmunizationRouteID).FirstOrDefault().Route : "",
                                    IntervalBetweenMessagesTypeDescription = xx.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                                }).FirstOrDefault();

            return Immunization;
        }

        #endregion

        #region patientDiagnosticListModelByPatientID
        public List<PatientDiagnosticListModel> patientDiagnosticListModelByPatientID(int PatientID)
        {
            var patientDiagnosticList = (from a in this._uow.GenericRepository<PatientDiagnosticList>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                                         join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                                         select
                                         new
                                         {
                                             a.PatientDiagnosticListID,
                                             a.PatientID,
                                             a.RecordedDate,
                                             a.ICDCode1,
                                             a.ICDCode2,
                                             a.ICDCode3,
                                             a.ICDCode4,
                                             a.ICDCode5,
                                             a.ICDCode6,
                                             a.ICDCode7,
                                             a.ICDCode8,
                                             a.ICDCode9,
                                             a.ICDCode10,
                                             a.ICDCode11,
                                             a.ICDCode12,
                                             a.ServiceDate,
                                             a.PatientVisitID,
                                             a.Deleted,
                                             a.CreatedDate,
                                             a.CreatedBy,
                                             a.ModifiedBy,
                                             a.ModifiedDate,
                                             a.IsPrinted
                                         }).AsEnumerable().Select(xx => new PatientDiagnosticListModel
                                         {
                                             PatientDiagnosticListID = xx.PatientDiagnosticListID,
                                             PatientID = xx.PatientID,
                                             RecordedDate = xx.RecordedDate,
                                             ICDCode1 = xx.ICDCode1,
                                             ICDCode2 = xx.ICDCode2,
                                             ICDCode3 = xx.ICDCode3,
                                             ICDCode4 = xx.ICDCode4,
                                             ICDCode5 = xx.ICDCode5,
                                             ICDCode6 = xx.ICDCode6,
                                             ICDCode7 = xx.ICDCode7,
                                             ICDCode8 = xx.ICDCode8,
                                             ICDCode9 = xx.ICDCode9,
                                             ICDCode10 = xx.ICDCode10,
                                             ICDCode11 = xx.ICDCode11,
                                             ICDCode12 = xx.ICDCode12,
                                             ServiceDate = xx.ServiceDate,
                                             PatientVisitID = xx.PatientVisitID,
                                             Deleted = xx.Deleted,
                                             CreatedDate = xx.CreatedDate,
                                             CreatedBy = xx.CreatedBy,
                                             ModifiedBy = xx.ModifiedBy,
                                             ModifiedDate = xx.ModifiedDate,
                                             IsPrinted = xx.IsPrinted,
                                             ICDCode1Description = this.GetdiagDescription(xx.ICDCode1.ToLower().Trim()),
                                             ICDCode2Description = this.GetdiagDescription(xx.ICDCode2.ToLower().Trim()),
                                             ICDCode3Description = this.GetdiagDescription(xx.ICDCode3.ToLower().Trim()),
                                             ICDCode4Description = this.GetdiagDescription(xx.ICDCode4.ToLower().Trim()),
                                             ICDCode5Description = this.GetdiagDescription(xx.ICDCode5.ToLower().Trim()),
                                             ICDCode6Description = this.GetdiagDescription(xx.ICDCode6.ToLower().Trim()),
                                             ICDCode7Description = this.GetdiagDescription(xx.ICDCode7.ToLower().Trim()),
                                             ICDCode8Description = this.GetdiagDescription(xx.ICDCode8.ToLower().Trim()),
                                             ICDCode9Description = this.GetdiagDescription(xx.ICDCode9.ToLower().Trim()),
                                             ICDCode10Description = this.GetdiagDescription(xx.ICDCode10.ToLower().Trim()),
                                             ICDCode11Description = this.GetdiagDescription(xx.ICDCode11.ToLower().Trim()),
                                             ICDCode12Description = this.GetdiagDescription(xx.ICDCode12.ToLower().Trim())

                                         }).ToList();

            return patientDiagnosticList;
        }

        public string GetdiagDescription(string icdCode)
        {
            string description = "";

            if (icdCode != null && icdCode != "")
            {
                var diagData = this._uow.GenericRepository<DiagnosisCode>().Table().Where(x => x.ICDCode.ToLower().Trim() == icdCode).FirstOrDefault();

                description = diagData != null ? (diagData.ICDCode + "-" + diagData.ShortDescription) : "";
            }


            return description;
        }
        #endregion

        #region patientDiagnosticListModelByPatientDiagnosticListID
        public PatientDiagnosticListModel GetpatientDiagnosticListRecordByID(int PatientDiagnosticListID)
        {
            var patientDiagnosticList = (from a in this._uow.GenericRepository<PatientDiagnosticList>().Table().Where(x => x.Deleted != true && x.PatientDiagnosticListID == PatientDiagnosticListID)
                                         join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                                         select
                                         new
                                         {
                                             a.PatientDiagnosticListID,
                                             a.PatientID,
                                             a.RecordedDate,
                                             a.ICDCode1,
                                             a.ICDCode2,
                                             a.ICDCode3,
                                             a.ICDCode4,
                                             a.ICDCode5,
                                             a.ICDCode6,
                                             a.ICDCode7,
                                             a.ICDCode8,
                                             a.ICDCode9,
                                             a.ICDCode10,
                                             a.ICDCode11,
                                             a.ICDCode12,
                                             a.ServiceDate,
                                             a.PatientVisitID,
                                             a.Deleted,
                                             a.CreatedDate,
                                             a.CreatedBy,
                                             a.ModifiedBy,
                                             a.ModifiedDate,
                                             a.IsPrinted
                                         }).AsEnumerable().Select(xx => new PatientDiagnosticListModel
                                         {
                                             PatientDiagnosticListID = xx.PatientDiagnosticListID,
                                             PatientID = xx.PatientID,
                                             RecordedDate = xx.RecordedDate,
                                             ICDCode1 = xx.ICDCode1,
                                             ICDCode2 = xx.ICDCode2,
                                             ICDCode3 = xx.ICDCode3,
                                             ICDCode4 = xx.ICDCode4,
                                             ICDCode5 = xx.ICDCode5,
                                             ICDCode6 = xx.ICDCode6,
                                             ICDCode7 = xx.ICDCode7,
                                             ICDCode8 = xx.ICDCode8,
                                             ICDCode9 = xx.ICDCode9,
                                             ICDCode10 = xx.ICDCode10,
                                             ICDCode11 = xx.ICDCode11,
                                             ICDCode12 = xx.ICDCode12,
                                             ServiceDate = xx.ServiceDate,
                                             PatientVisitID = xx.PatientVisitID,
                                             Deleted = xx.Deleted,
                                             CreatedDate = xx.CreatedDate,
                                             CreatedBy = xx.CreatedBy,
                                             ModifiedBy = xx.ModifiedBy,
                                             ModifiedDate = xx.ModifiedDate,
                                             IsPrinted = xx.IsPrinted,
                                             ICDCode1Description = this.GetdiagDescription(xx.ICDCode1.ToLower().Trim()),
                                             ICDCode2Description = this.GetdiagDescription(xx.ICDCode2.ToLower().Trim()),
                                             ICDCode3Description = this.GetdiagDescription(xx.ICDCode3.ToLower().Trim()),
                                             ICDCode4Description = this.GetdiagDescription(xx.ICDCode4.ToLower().Trim()),
                                             ICDCode5Description = this.GetdiagDescription(xx.ICDCode5.ToLower().Trim()),
                                             ICDCode6Description = this.GetdiagDescription(xx.ICDCode6.ToLower().Trim()),
                                             ICDCode7Description = this.GetdiagDescription(xx.ICDCode7.ToLower().Trim()),
                                             ICDCode8Description = this.GetdiagDescription(xx.ICDCode8.ToLower().Trim()),
                                             ICDCode9Description = this.GetdiagDescription(xx.ICDCode9.ToLower().Trim()),
                                             ICDCode10Description = this.GetdiagDescription(xx.ICDCode10.ToLower().Trim()),
                                             ICDCode11Description = this.GetdiagDescription(xx.ICDCode11.ToLower().Trim()),
                                             ICDCode12Description = this.GetdiagDescription(xx.ICDCode12.ToLower().Trim())
                                         }).FirstOrDefault();

            return patientDiagnosticList;
        }
        #endregion

        #region patientInsuranceModelByPaientID
        public List<PatientInsuranceModel> patientInsuranceModelByPaientID(int PatientID)
        {
            var PatientInsurance = (from a in this._uow.GenericRepository<PatientInsurance>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                                    join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                                    join c in this._uow.GenericRepository<InsuranceType>().Table() on a.InsuranceTypeID equals c.InsuranceTypeID

                                    select
                                    new
                                    {
                                        a.PatientInsuranceID,
                                        a.PatientID,
                                        a.SelfInsured,
                                        a.InsuranceTypeID,
                                        a.InsuranceCompanyID,
                                        a.PatientRelationID,
                                        a.SSN,
                                        a.NameLast,
                                        a.NameFirst,
                                        a.NamePrefix,
                                        a.NameSuffix,
                                        a.GenderID,
                                        a.BirthDate,
                                        a.AddressLine1,
                                        a.AddressLine2,
                                        a.City,
                                        a.State,
                                        a.Country,
                                        a.Phone,
                                        a.AlternatePhone,
                                        a.Email,
                                        a.GroupName,
                                        a.GroupNumber,
                                        a.PolicyNumber,
                                        a.Copay,
                                        a.EffectiveDate,
                                        a.TerminationDate,
                                        a.EligibilityRequestedDate,
                                        a.EligibilityStatus,
                                        a.SubscriberInsuredID,
                                        a.PatientInsuredID,
                                        a.Deleted,
                                        a.CreatedDate,
                                        a.CreatedBy,
                                        a.ModifiedDate,
                                        a.ModifiedBy,
                                        a.BillingMethodID,
                                        a.IsForeign,
                                        c.TypeDescription,
                                    }).AsEnumerable().Select(xx => new PatientInsuranceModel
                                    {
                                        PatientInsuranceID = xx.PatientInsuranceID,
                                        PatientID = xx.PatientID,
                                        SelfInsured = xx.SelfInsured,
                                        InsuranceTypeID = xx.InsuranceTypeID,
                                        InsuranceCompanyID = xx.InsuranceCompanyID,
                                        PatientRelationID = xx.PatientRelationID,
                                        SSN = xx.SSN,
                                        NameLast = xx.NameLast,
                                        NameFirst = xx.NameFirst,
                                        NamePrefix = xx.NamePrefix,
                                        NameSuffix = xx.NameSuffix,
                                        GenderID = xx.GenderID,
                                        BirthDate = xx.BirthDate,
                                        AddressLine1 = xx.AddressLine1,
                                        AddressLine2 = xx.AddressLine2,
                                        City = xx.City,
                                        State = xx.State,
                                        Country = xx.Country,
                                        Phone = xx.Phone,
                                        AlternatePhone = xx.AlternatePhone,
                                        Email = xx.Email,
                                        GroupName = xx.GroupName,
                                        GroupNumber = xx.GroupNumber,
                                        PolicyNumber = xx.PolicyNumber,
                                        Copay = xx.Copay,
                                        EffectiveDate = xx.EffectiveDate,
                                        TerminationDate = xx.TerminationDate,
                                        EligibilityRequestedDate = xx.EligibilityRequestedDate,
                                        EligibilityStatus = xx.EligibilityStatus,
                                        SubscriberInsuredID = xx.SubscriberInsuredID,
                                        PatientInsuredID = xx.PatientInsuredID,
                                        Deleted = xx.Deleted,
                                        CreatedDate = xx.CreatedDate,
                                        CreatedBy = xx.CreatedBy,
                                        ModifiedDate = xx.ModifiedDate,
                                        ModifiedBy = xx.ModifiedBy,
                                        BillingMethodID = xx.BillingMethodID,
                                        IsForeign = xx.IsForeign,
                                        TypeDescription = xx.TypeDescription,
                                    }).ToList();
            return PatientInsurance;
        }
        #endregion

        #region PatientLabOrderTestModelByPatientID
        public List<PatientLabOrderTestModel> PatientLabOrderTestModelByPatientID(int patientID)
        {
            var patientLab = (from a in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => x.Deleted != true && x.PatientID == patientID)
                              select
                              new
                              {
                                  a.PatientLabOrderTestID,
                                  a.FacilityID,
                                  a.FacilityName,
                                  a.RecordedDate,
                                  a.ProviderID,
                                  a.ProviderName,
                                  a.OrderingProviderID,
                                  a.OrderingProviderName,
                                  a.PatientID,
                                  a.LabName,
                                  a.LabTestDate,
                                  a.LabAddressLine1,
                                  a.LabAddressLine2,
                                  a.LabCity,
                                  a.LabState,
                                  a.LabCounty,
                                  a.LabZIP,
                                  a.LoincCode1,
                                  a.LoincCode2,
                                  a.LoincCode3,
                                  a.LoincCode4,
                                  a.LoincCode5,
                                  a.LoincCode6,
                                  a.LoincCode7,
                                  a.LoincCode8,
                                  a.LoincCode9,
                                  a.LoincCode10,
                                  a.LoincCode11,
                                  a.LoincCode12,
                                  a.LoincCode13,
                                  a.LoincCode14,
                                  a.LoincCode15,
                                  a.LoincCode16,
                                  a.ICDCode1,
                                  a.ICDCode2,
                                  a.ICDCode3,
                                  a.ICDCode4,
                                  a.ICDCode5,
                                  a.ICDCode6,
                                  a.ICDCode7,
                                  a.ICDCode8,
                                  a.ICDCode9,
                                  a.ICDCode10,
                                  a.Notes,
                                  a.IsActive,
                                  a.IsPastTest,
                                  a.DocumentReferenceIds,
                                  a.Deleted,
                                  a.CreatedBy,
                                  a.CreatedDate,
                                  a.ModifiedBy,
                                  a.ModifiedDate,
                                  a.PatientVisitID,
                                  a.EmdeonLabID,
                                  a.PlacerOrderNumber,
                                  a.OrderRequestMSGPIDGRTORCID,
                                  a.ScheduledTestStatusID,
                                  a.LoincCode1Result,
                                  a.LoincCode1ResultDate,
                                  a.LoincCode1ResultUnits,
                                  a.LoincCode2Result,
                                  a.LoincCode2ResultDate,
                                  a.LoincCode2ResultUnits,
                                  a.LoincCode3Result,
                                  a.LoincCode3ResultDate,
                                  a.LoincCode3ResultUnits,
                                  a.LoincCode4Result,
                                  a.LoincCode4ResultDate,
                                  a.LoincCode4ResultUnits,
                                  a.LoincCode5Result,
                                  a.LoincCode5ResultDate,
                                  a.LoincCode5ResultUnits,
                                  a.LoincCode6Result,
                                  a.LoincCode6ResultDate,
                                  a.LoincCode6ResultUnits,
                                  a.LoincCode7Result,
                                  a.LoincCode7ResultDate,
                                  a.LoincCode7ResultUnits,
                                  a.LoincCode8Result,
                                  a.LoincCode8ResultDate,
                                  a.LoincCode8ResultUnits,
                                  a.LoincCode9Result,
                                  a.LoincCode9ResultDate,
                                  a.LoincCode9ResultUnits,
                                  a.LoincCode10Result,
                                  a.LoincCode10ResultDate,
                                  a.LoincCode10ResultUnits,
                                  a.LoincCode11Result,
                                  a.LoincCode11ResultDate,
                                  a.LoincCode11ResultUnits,
                                  a.LoincCode12Result,
                                  a.LoincCode12ResultDate,
                                  a.LoincCode12ResultUnits,
                                  a.LoincCode13Result,
                                  a.LoincCode13ResultDate,
                                  a.LoincCode13ResultUnits,
                                  a.LoincCode14Result,
                                  a.LoincCode14ResultDate,
                                  a.LoincCode14ResultUnits,
                                  a.LoincCode15Result,
                                  a.LoincCode15ResultDate,
                                  a.LoincCode15ResultUnits,
                                  a.LoincCode16Result,
                                  a.LoincCode16ResultDate,
                                  a.LoincCode16ResultUnits,
                                  a.IsPrinted,
                                  a.IsEditable
                              }).AsEnumerable().Select(xx => new PatientLabOrderTestModel
                              {
                                  PatientLabOrderTestID = xx.PatientLabOrderTestID,
                                  FacilityID = xx.FacilityID,
                                  FacilityName = xx.FacilityName.ToString(),
                                  ProviderID = xx.ProviderID,
                                  RecordedDate = xx.RecordedDate,
                                  ProviderName = xx.ProviderName,
                                  OrderingProviderID = xx.OrderingProviderID,
                                  OrderingProviderName = xx.OrderingProviderName,
                                  PatientID = xx.PatientID,
                                  LabName = xx.LabName,
                                  LabTestDate = xx.LabTestDate,
                                  LabAddressLine1 = xx.LabAddressLine1,
                                  LabAddressLine2 = xx.LabAddressLine2,
                                  LabCity = xx.LabCity,
                                  LabState = xx.LabState,
                                  LabCounty = xx.LabCounty,
                                  LabZIP = xx.LabZIP,
                                  LoincCode1 = xx.LoincCode1,
                                  LoincCode2 = xx.LoincCode2,
                                  LoincCode3 = xx.LoincCode3,
                                  LoincCode4 = xx.LoincCode4,
                                  LoincCode5 = xx.LoincCode5,
                                  LoincCode6 = xx.LoincCode6,
                                  LoincCode7 = xx.LoincCode7,
                                  LoincCode8 = xx.LoincCode8,
                                  LoincCode9 = xx.LoincCode9,
                                  LoincCode10 = xx.LoincCode10,
                                  LoincCode11 = xx.LoincCode11,
                                  LoincCode12 = xx.LoincCode12,
                                  LoincCode13 = xx.LoincCode13,
                                  LoincCode14 = xx.LoincCode14,
                                  LoincCode15 = xx.LoincCode15,
                                  LoincCode16 = xx.LoincCode16,
                                  ICDCode1 = xx.ICDCode1,
                                  ICDCode2 = xx.ICDCode2,
                                  ICDCode3 = xx.ICDCode3,
                                  ICDCode4 = xx.ICDCode4,
                                  ICDCode5 = xx.ICDCode5,
                                  ICDCode6 = xx.ICDCode6,
                                  ICDCode7 = xx.ICDCode7,
                                  ICDCode8 = xx.ICDCode8,
                                  ICDCode9 = xx.ICDCode9,
                                  ICDCode10 = xx.ICDCode10,
                                  Notes = xx.Notes,
                                  IsActive = xx.IsActive,
                                  IsPastTest = xx.IsPastTest,
                                  DocumentReferenceIds = xx.DocumentReferenceIds,
                                  Deleted = xx.Deleted,
                                  CreatedBy = xx.CreatedBy,
                                  CreatedDate = xx.CreatedDate,
                                  ModifiedBy = xx.ModifiedBy,
                                  ModifiedDate = xx.ModifiedDate,
                                  PatientVisitID = xx.PatientVisitID,
                                  EmdeonLabID = xx.EmdeonLabID,
                                  PlacerOrderNumber = xx.PlacerOrderNumber,
                                  OrderRequestMSGPIDGRTORCID = xx.OrderRequestMSGPIDGRTORCID,
                                  ScheduledTestStatusID = xx.ScheduledTestStatusID,
                                  LabOrderScheduledTestStatusDescription = xx.ScheduledTestStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                  LoincCode1Result = xx.LoincCode1Result,
                                  LoincCode1ResultDate = xx.LoincCode1ResultDate,
                                  LoincCode1ResultUnits = xx.LoincCode1ResultUnits,
                                  LoincCode2Result = xx.LoincCode2Result,
                                  LoincCode2ResultDate = xx.LoincCode2ResultDate,
                                  LoincCode2ResultUnits = xx.LoincCode2ResultUnits,
                                  LoincCode3Result = xx.LoincCode3Result,
                                  LoincCode3ResultDate = xx.LoincCode3ResultDate,
                                  LoincCode3ResultUnits = xx.LoincCode3ResultUnits,
                                  LoincCode4Result = xx.LoincCode4Result,
                                  LoincCode4ResultDate = xx.LoincCode4ResultDate,
                                  LoincCode4ResultUnits = xx.LoincCode4ResultUnits,
                                  LoincCode5Result = xx.LoincCode5Result,
                                  LoincCode5ResultDate = xx.LoincCode5ResultDate,
                                  LoincCode5ResultUnits = xx.LoincCode5ResultUnits,
                                  LoincCode6Result = xx.LoincCode6Result,
                                  LoincCode6ResultDate = xx.LoincCode6ResultDate,
                                  LoincCode6ResultUnits = xx.LoincCode6ResultUnits,
                                  LoincCode7Result = xx.LoincCode7Result,
                                  LoincCode7ResultDate = xx.LoincCode7ResultDate,
                                  LoincCode7ResultUnits = xx.LoincCode7ResultUnits,
                                  LoincCode8Result = xx.LoincCode8Result,
                                  LoincCode8ResultDate = xx.LoincCode8ResultDate,
                                  LoincCode8ResultUnits = xx.LoincCode8ResultUnits,
                                  LoincCode9Result = xx.LoincCode9Result,
                                  LoincCode9ResultDate = xx.LoincCode9ResultDate,
                                  LoincCode9ResultUnits = xx.LoincCode9ResultUnits,
                                  LoincCode10Result = xx.LoincCode10Result,
                                  LoincCode10ResultDate = xx.LoincCode10ResultDate,
                                  LoincCode10ResultUnits = xx.LoincCode10ResultUnits,
                                  LoincCode11Result = xx.LoincCode11Result,
                                  LoincCode11ResultDate = xx.LoincCode11ResultDate,
                                  LoincCode11ResultUnits = xx.LoincCode11ResultUnits,
                                  LoincCode12Result = xx.LoincCode12Result,
                                  LoincCode12ResultDate = xx.LoincCode12ResultDate,
                                  LoincCode12ResultUnits = xx.LoincCode12ResultUnits,
                                  LoincCode13Result = xx.LoincCode13Result,
                                  LoincCode13ResultDate = xx.LoincCode13ResultDate,
                                  LoincCode13ResultUnits = xx.LoincCode13ResultUnits,
                                  LoincCode14Result = xx.LoincCode14Result,
                                  LoincCode14ResultDate = xx.LoincCode14ResultDate,
                                  LoincCode14ResultUnits = xx.LoincCode14ResultUnits,
                                  LoincCode15Result = xx.LoincCode15Result,
                                  LoincCode15ResultDate = xx.LoincCode15ResultDate,
                                  LoincCode15ResultUnits = xx.LoincCode15ResultUnits,
                                  LoincCode16Result = xx.LoincCode16Result,
                                  LoincCode16ResultDate = xx.LoincCode16ResultDate,
                                  LoincCode16ResultUnits = xx.LoincCode16ResultUnits,
                                  IsPrinted = xx.IsPrinted,
                                  IsEditable = xx.IsEditable,
                              }).ToList();

            return patientLab;
        }
        #endregion

        #region GetPatientLabOrderTestRecordByID
        public PatientLabOrderTestModel GetPatientLabOrderTestRecordByID(int patientLabOrderTestID)
        {
            var patientLab = (from a in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => x.Deleted != true && x.PatientLabOrderTestID == patientLabOrderTestID)
                              select
                              new
                              {
                                  a.PatientLabOrderTestID,
                                  a.FacilityID,
                                  a.FacilityName,
                                  a.ProviderID,
                                  a.ProviderName,
                                  a.OrderingProviderID,
                                  a.OrderingProviderName,
                                  a.PatientID,
                                  a.LabName,
                                  a.LabTestDate,
                                  a.LabAddressLine1,
                                  a.LabAddressLine2,
                                  a.LabCity,
                                  a.LabState,
                                  a.LabCounty,
                                  a.LabZIP,
                                  a.LoincCode1,
                                  a.LoincCode2,
                                  a.LoincCode3,
                                  a.LoincCode4,
                                  a.LoincCode5,
                                  a.LoincCode6,
                                  a.LoincCode7,
                                  a.LoincCode8,
                                  a.LoincCode9,
                                  a.LoincCode10,
                                  a.LoincCode11,
                                  a.LoincCode12,
                                  a.LoincCode13,
                                  a.LoincCode14,
                                  a.LoincCode15,
                                  a.LoincCode16,
                                  a.ICDCode1,
                                  a.ICDCode2,
                                  a.ICDCode3,
                                  a.ICDCode4,
                                  a.ICDCode5,
                                  a.ICDCode6,
                                  a.ICDCode7,
                                  a.ICDCode8,
                                  a.ICDCode9,
                                  a.ICDCode10,
                                  a.Notes,
                                  a.IsActive,
                                  a.IsPastTest,
                                  a.DocumentReferenceIds,
                                  a.Deleted,
                                  a.CreatedBy,
                                  a.CreatedDate,
                                  a.ModifiedBy,
                                  a.ModifiedDate,
                                  a.PatientVisitID,
                                  a.EmdeonLabID,
                                  a.PlacerOrderNumber,
                                  a.OrderRequestMSGPIDGRTORCID,
                                  a.ScheduledTestStatusID,
                                  a.LoincCode1Result,
                                  a.LoincCode1ResultDate,
                                  a.LoincCode1ResultUnits,
                                  a.LoincCode2Result,
                                  a.LoincCode2ResultDate,
                                  a.LoincCode2ResultUnits,
                                  a.LoincCode3Result,
                                  a.LoincCode3ResultDate,
                                  a.LoincCode3ResultUnits,
                                  a.LoincCode4Result,
                                  a.LoincCode4ResultDate,
                                  a.LoincCode4ResultUnits,
                                  a.LoincCode5Result,
                                  a.LoincCode5ResultDate,
                                  a.LoincCode5ResultUnits,
                                  a.LoincCode6Result,
                                  a.LoincCode6ResultDate,
                                  a.LoincCode6ResultUnits,
                                  a.LoincCode7Result,
                                  a.LoincCode7ResultDate,
                                  a.LoincCode7ResultUnits,
                                  a.LoincCode8Result,
                                  a.LoincCode8ResultDate,
                                  a.LoincCode8ResultUnits,
                                  a.LoincCode9Result,
                                  a.LoincCode9ResultDate,
                                  a.LoincCode9ResultUnits,
                                  a.LoincCode10Result,
                                  a.LoincCode10ResultDate,
                                  a.LoincCode10ResultUnits,
                                  a.LoincCode11Result,
                                  a.LoincCode11ResultDate,
                                  a.LoincCode11ResultUnits,
                                  a.LoincCode12Result,
                                  a.LoincCode12ResultDate,
                                  a.LoincCode12ResultUnits,
                                  a.LoincCode13Result,
                                  a.LoincCode13ResultDate,
                                  a.LoincCode13ResultUnits,
                                  a.LoincCode14Result,
                                  a.LoincCode14ResultDate,
                                  a.LoincCode14ResultUnits,
                                  a.LoincCode15Result,
                                  a.LoincCode15ResultDate,
                                  a.LoincCode15ResultUnits,
                                  a.LoincCode16Result,
                                  a.LoincCode16ResultDate,
                                  a.LoincCode16ResultUnits,
                                  a.IsPrinted,
                                  a.IsEditable
                              }).AsEnumerable().Select(xx => new PatientLabOrderTestModel
                              {
                                  PatientLabOrderTestID = xx.PatientLabOrderTestID,
                                  FacilityID = xx.FacilityID,
                                  FacilityName = xx.FacilityName.ToString(),
                                  ProviderID = xx.ProviderID,
                                  ProviderName = xx.ProviderName,
                                  OrderingProviderID = xx.OrderingProviderID,
                                  OrderingProviderName = xx.OrderingProviderName,
                                  PatientID = xx.PatientID,
                                  LabName = xx.LabName,
                                  LabTestDate = xx.LabTestDate,
                                  LabAddressLine1 = xx.LabAddressLine1,
                                  LabAddressLine2 = xx.LabAddressLine2,
                                  LabCity = xx.LabCity,
                                  LabState = xx.LabState,
                                  LabCounty = xx.LabCounty,
                                  LabZIP = xx.LabZIP,
                                  LoincCode1 = xx.LoincCode1,
                                  LoincCode2 = xx.LoincCode2,
                                  LoincCode3 = xx.LoincCode3,
                                  LoincCode4 = xx.LoincCode4,
                                  LoincCode5 = xx.LoincCode5,
                                  LoincCode6 = xx.LoincCode6,
                                  LoincCode7 = xx.LoincCode7,
                                  LoincCode8 = xx.LoincCode8,
                                  LoincCode9 = xx.LoincCode9,
                                  LoincCode10 = xx.LoincCode10,
                                  LoincCode11 = xx.LoincCode11,
                                  LoincCode12 = xx.LoincCode12,
                                  LoincCode13 = xx.LoincCode13,
                                  LoincCode14 = xx.LoincCode14,
                                  LoincCode15 = xx.LoincCode15,
                                  LoincCode16 = xx.LoincCode16,
                                  ICDCode1 = xx.ICDCode1,
                                  ICDCode2 = xx.ICDCode2,
                                  ICDCode3 = xx.ICDCode3,
                                  ICDCode4 = xx.ICDCode4,
                                  ICDCode5 = xx.ICDCode5,
                                  ICDCode6 = xx.ICDCode6,
                                  ICDCode7 = xx.ICDCode7,
                                  ICDCode8 = xx.ICDCode8,
                                  ICDCode9 = xx.ICDCode9,
                                  ICDCode10 = xx.ICDCode10,
                                  Notes = xx.Notes,
                                  IsActive = xx.IsActive,
                                  IsPastTest = xx.IsPastTest,
                                  DocumentReferenceIds = xx.DocumentReferenceIds,
                                  Deleted = xx.Deleted,
                                  CreatedBy = xx.CreatedBy,
                                  CreatedDate = xx.CreatedDate,
                                  ModifiedBy = xx.ModifiedBy,
                                  ModifiedDate = xx.ModifiedDate,
                                  PatientVisitID = xx.PatientVisitID,
                                  EmdeonLabID = xx.EmdeonLabID,
                                  PlacerOrderNumber = xx.PlacerOrderNumber,
                                  OrderRequestMSGPIDGRTORCID = xx.OrderRequestMSGPIDGRTORCID,
                                  ScheduledTestStatusID = xx.ScheduledTestStatusID,
                                  LabOrderScheduledTestStatusDescription= xx.ScheduledTestStatusID  > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                  LoincCode1Result = xx.LoincCode1Result,
                                  LoincCode1ResultDate = xx.LoincCode1ResultDate,
                                  LoincCode1ResultUnits = xx.LoincCode1ResultUnits,
                                  LoincCode2Result = xx.LoincCode2Result,
                                  LoincCode2ResultDate = xx.LoincCode2ResultDate,
                                  LoincCode2ResultUnits = xx.LoincCode2ResultUnits,
                                  LoincCode3Result = xx.LoincCode3Result,
                                  LoincCode3ResultDate = xx.LoincCode3ResultDate,
                                  LoincCode3ResultUnits = xx.LoincCode3ResultUnits,
                                  LoincCode4Result = xx.LoincCode4Result,
                                  LoincCode4ResultDate = xx.LoincCode4ResultDate,
                                  LoincCode4ResultUnits = xx.LoincCode4ResultUnits,
                                  LoincCode5Result = xx.LoincCode5Result,
                                  LoincCode5ResultDate = xx.LoincCode5ResultDate,
                                  LoincCode5ResultUnits = xx.LoincCode5ResultUnits,
                                  LoincCode6Result = xx.LoincCode6Result,
                                  LoincCode6ResultDate = xx.LoincCode6ResultDate,
                                  LoincCode6ResultUnits = xx.LoincCode6ResultUnits,
                                  LoincCode7Result = xx.LoincCode7Result,
                                  LoincCode7ResultDate = xx.LoincCode7ResultDate,
                                  LoincCode7ResultUnits = xx.LoincCode7ResultUnits,
                                  LoincCode8Result = xx.LoincCode8Result,
                                  LoincCode8ResultDate = xx.LoincCode8ResultDate,
                                  LoincCode8ResultUnits = xx.LoincCode8ResultUnits,
                                  LoincCode9Result = xx.LoincCode9Result,
                                  LoincCode9ResultDate = xx.LoincCode9ResultDate,
                                  LoincCode9ResultUnits = xx.LoincCode9ResultUnits,
                                  LoincCode10Result = xx.LoincCode10Result,
                                  LoincCode10ResultDate = xx.LoincCode10ResultDate,
                                  LoincCode10ResultUnits = xx.LoincCode10ResultUnits,
                                  LoincCode11Result = xx.LoincCode11Result,
                                  LoincCode11ResultDate = xx.LoincCode11ResultDate,
                                  LoincCode11ResultUnits = xx.LoincCode11ResultUnits,
                                  LoincCode12Result = xx.LoincCode12Result,
                                  LoincCode12ResultDate = xx.LoincCode12ResultDate,
                                  LoincCode12ResultUnits = xx.LoincCode12ResultUnits,
                                  LoincCode13Result = xx.LoincCode13Result,
                                  LoincCode13ResultDate = xx.LoincCode13ResultDate,
                                  LoincCode13ResultUnits = xx.LoincCode13ResultUnits,
                                  LoincCode14Result = xx.LoincCode14Result,
                                  LoincCode14ResultDate = xx.LoincCode14ResultDate,
                                  LoincCode14ResultUnits = xx.LoincCode14ResultUnits,
                                  LoincCode15Result = xx.LoincCode15Result,
                                  LoincCode15ResultDate = xx.LoincCode15ResultDate,
                                  LoincCode15ResultUnits = xx.LoincCode15ResultUnits,
                                  LoincCode16Result = xx.LoincCode16Result,
                                  LoincCode16ResultDate = xx.LoincCode16ResultDate,
                                  LoincCode16ResultUnits = xx.LoincCode16ResultUnits,
                                  IsPrinted = xx.IsPrinted,
                                  IsEditable = xx.IsEditable,
                              }).FirstOrDefault();

            return patientLab;
        }

        #endregion

        #region GetPatientModels
        public PatientModel GetPatientModels(int PatientID)
        {

            if (PatientID <= 0)
                return null;
            var patientess = (from p in this._uow.GenericRepository<Patient>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                              select
                              new
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
                                  BirthDate = x.BirthDate,
                                  PatientName =x.NameFirst +" "+x.NameMiddle+" "+" "+x.NameLast,
                                  Age = x.BirthDate != null ? (DateTime.Now - x.BirthDate.Value).Days / 365 : 0,
                                  GenderDescription =x.GenderID >0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(xx=> xx.CommonMasterID ==x.GenderID).FirstOrDefault().Description:"",      
                                  DrugName = this.PatientMedicationModelsbyPatientID(x.PatientID).Count != 0 ?
                                                this.PatientMedicationModelsbyPatientID(x.PatientID).FirstOrDefault().DrugName : "None",// x.DrugName,
                                  Quantity = this.PatientMedicationModelsbyPatientID(x.PatientID).Count != 0 ?
                                                this.PatientMedicationModelsbyPatientID(x.PatientID).FirstOrDefault().Quantity : 0,//x.Quantity,
                                  VitalSignModelss = this.vitalSignModelByPatientID(x.PatientID),
                                  PatientMedicationModelss = this.PatientMedicationModelsbyPatientID(x.PatientID),
                                  PatientAllergyModelss = this.AllergyModelByPatientID(x.PatientID),
                                  PatientWorkHistoryModelss = this.patientWorkHistoryModelsByPatientID(x.PatientID),
                                  FamilyHealthHistoryModelss = this.familyHealthHistoryModelByPatientID(x.PatientID),
                                  PatientImmunizationModels = this.patientImmunizationModelByPatientID(x.PatientID),
                                  PatientDiagnosticListModels = this.patientDiagnosticListModelByPatientID(x.PatientID),
                                  PatientInsuranceModels = this.patientInsuranceModelByPaientID(x.PatientID),
                                  PatientLabOrderModels = this.PatientLabOrderTestModelByPatientID(x.PatientID),
                                  allergynames = this.getallergynamesbyPatientID(x.PatientID)

                              }).OrderBy(x =>x.PatientName).FirstOrDefault();
            return patientess;
        }

        public string getallergynamesbyPatientID(int patientID)
        {
            string allergyName = "";
            var allergyrecords = this._uow.GenericRepository<PatientAllergy>().Table().Where(x => x.PatientID == patientID).ToList();

            if (allergyrecords.Count > 0)
            {
                for (int i = 0; i < allergyrecords.Count; i++)
                {
                    if (i == allergyrecords.Count - 1)
                    {
                        allergyName += allergyrecords[i].AllergyName;
                    }
                    else
                    {
                        allergyName += allergyrecords[i].AllergyName + ", ";
                    }

                }
            }
            return allergyName;
        }





        #endregion

        #region GetVitalSignModel
        public List<VitalSignModel> GetVitalSignModel()
        {
            var VitalSign = (from a in this._uow.GenericRepository<VitalSign>().Table().Where(x => x.Deleted != true)
                             select
                             new
                             {
                                 a.VitalSignID,
                                 a.PatientID,
                                 a.PatientEncounterID,
                                 a.RecordedDate,
                                 a.Height,
                                 a.Weight,
                                 a.Temperature,
                                 a.TemperatureLocationID,
                                 a.OxygenSaturation,
                                 a.BloodPressureSystolic,
                                 a.BloodPressureDiastolic,
                                 a.HeartRate,
                                 a.RespiratoryRate,
                                 a.HeadCircumference,
                                 a.WaistCircumference,
                                 a.SmokingCategoryID,
                                 a.Notes,
                                 a.Deleted,
                                 a.CreatedDate,
                                 a.CreatedBy,
                                 a.ModifiedBy,
                                 a.ModifiedDate,
                                 a.PatientVisitID,
                                 a.IsPrinted,
                                 a.RecordedTime,
                                 a.NotesSnomedCT,
                                 a.VitalCodeForCDS,
                                 a.ExternalVitalSignID
                             }).AsEnumerable().Select(xx => new VitalSignModel
                             {
                                 VitalSignID = xx.VitalSignID,
                                 PatientID = xx.PatientID,
                                 PatientEncounterID = xx.PatientEncounterID,
                                 RecordedDate = xx.RecordedDate,
                                 Height = xx.Height,
                                 Weight = xx.Weight,
                                 Temperature = xx.Temperature,
                                 TemperatureLocationID = xx.TemperatureLocationID,
                                 OxygenSaturation = xx.OxygenSaturation,
                                 BloodPressureSystolic = xx.BloodPressureSystolic,
                                 BloodPressureDiastolic = xx.BloodPressureDiastolic,
                                 HeartRate = xx.HeartRate,
                                 RespiratoryRate = xx.RespiratoryRate,
                                 HeadCircumference = xx.HeadCircumference,
                                 WaistCircumference = xx.WaistCircumference,
                                 SmokingCategoryID = xx.SmokingCategoryID,
                                 Notes = xx.Notes,
                                 Deleted = xx.Deleted,
                                 CreatedDate = xx.CreatedDate,
                                 CreatedBy = xx.CreatedBy,
                                 ModifiedBy = xx.ModifiedBy,
                                 ModifiedDate = xx.ModifiedDate,
                                 PatientVisitID = xx.PatientVisitID,
                                 IsPrinted = xx.IsPrinted,
                                 RecordedTime = xx.RecordedTime,
                                 NotesSnomedCT = xx.NotesSnomedCT,
                                 VitalCodeForCDS = xx.VitalCodeForCDS,
                                 ExternalVitalSignID = xx.ExternalVitalSignID,
                             }).ToList();
            return VitalSign;
        }
        #endregion

        #region PatientMedications
        public List<PatientMedicationModel> PatientMedications()
        {
            var getmedication = (from a in this._uow.GenericRepository<PatientMedication>().Table()  //.Where(x => x.Deleted != true)
                                 select
                                 new
                                 {
                                     a.PatientEncounterID,
                                     a.PatientID,
                                     a.RecordedDate,
                                     a.PatientMedicationID,
                                     a.StartedDate,
                                     a.DrugCodeID,
                                     a.PatientInstructions,
                                     a.CurrentStatus,
                                     a.Quantity,
                                     a.DispenseFormID,
                                     a.Refill,
                                     a.AllowSubstitution,
                                     a.Prescriber,
                                     a.DrugName,
                                     a.ExpiryDate,
                                     a.PrescribedDate,
                                     a.DosageFormID,
                                     a.SubstitutionDrug,
                                     a.SideEffects,
                                     a.NotesToPharmacist,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.PatientVisitID,
                                     a.DeleteReason,
                                     a.RxObjectID,
                                     a.Sig,
                                     a.IsPrinted,
                                     a.RxNormConceptID,
                                     a.RxNormCode,
                                     a.RecordedTime,
                                     a.DispenseAsWritten,
                                     a.RxNormAtomID,
                                     a.ScheduledTestStatusID,
                                     a.Units,
                                     a.MedicationRefusalReasonID,
                                     a.MedicationOrderNotPerformedID,
                                     a.IsScheduled,
                                     a.MedicationBarcode,
                                     a.BarcodeImage,
                                     a.IsReminder,
                                     a.AppointmentDateMetDateEarlierThan,
                                     a.AppointmentDateMetDateEarlierThanHrs,
                                     a.NumberOfMessagesToSendPerPatient,
                                     a.IntervalPerMessage,
                                     a.IntervalBetweenMessagesTypeId,
                                     a.ImmunizationRouteID,
                                     a.MedicatedDate,
                                     a.MedicatedTime,
                                     a.IsFormularyCheck,
                                     a.DrugCodeForCDS,
                                     a.ExternalMedicationID,
                                     a.Frequency,
                                     a.PackageDescription
                                 }).AsEnumerable().Select(ss => new PatientMedicationModel
                                 {
                                     PatientEncounterID = ss.PatientEncounterID,
                                     PatientID = ss.PatientID,
                                     RecordedDate = ss.RecordedDate,
                                     PatientMedicationID = ss.PatientMedicationID,
                                     StartedDate = ss.StartedDate,
                                     DrugCodeID = ss.DrugCodeID,
                                     PatientInstructions = ss.PatientInstructions,
                                     CurrentStatus = ss.CurrentStatus,
                                     Quantity = ss.Quantity,
                                     DispenseFormID = ss.DispenseFormID,
                                     Refill = ss.Refill,
                                     AllowSubstitution = ss.AllowSubstitution,
                                     Prescriber = ss.Prescriber,
                                     DrugName = ss.DrugName,
                                     ExpiryDate = ss.ExpiryDate,
                                     PrescribedDate = ss.PrescribedDate,
                                     DosageFormID = ss.DosageFormID,
                                     SubstitutionDrug = ss.SubstitutionDrug,
                                     SideEffects = ss.SideEffects,
                                     NotesToPharmacist = ss.NotesToPharmacist,
                                     Deleted = ss.Deleted,
                                     CreatedDate = ss.CreatedDate,
                                     CreatedBy = ss.CreatedBy,
                                     ModifiedDate = ss.MedicatedDate,
                                     ModifiedBy = ss.ModifiedBy,
                                     PatientVisitID = ss.PatientVisitID,
                                     DeleteReason = ss.DeleteReason,
                                     RxObjectID = ss.RxObjectID,
                                     Sig = ss.Sig,
                                     IsPrinted = ss.IsPrinted,
                                     RxNormConceptID = ss.RxNormConceptID,
                                     RxNormCode = ss.RxNormCode,
                                     RecordedTime = ss.RecordedTime,
                                     DispenseAsWritten = ss.DispenseAsWritten,
                                     RxNormAtomID = ss.RxNormAtomID,
                                     ScheduledTestStatusID = ss.ScheduledTestStatusID,
                                     Units = ss.Units,
                                     MedicationRefusalReasonID = ss.MedicationRefusalReasonID,
                                     MedicationOrderNotPerformedID = ss.MedicationOrderNotPerformedID,
                                     IsScheduled = ss.IsScheduled,
                                     MedicationBarcode = ss.MedicationBarcode,
                                     BarcodeImage = ss.BarcodeImage,
                                     IsReminder = ss.IsReminder,
                                     AppointmentDateMetDateEarlierThan = ss.AppointmentDateMetDateEarlierThan,
                                     AppointmentDateMetDateEarlierThanHrs = ss.AppointmentDateMetDateEarlierThanHrs,
                                     NumberOfMessagesToSendPerPatient = ss.NumberOfMessagesToSendPerPatient,
                                     IntervalPerMessage = ss.IntervalPerMessage,
                                     IntervalBetweenMessagesTypeId = ss.IntervalBetweenMessagesTypeId,
                                     ImmunizationRouteID = ss.ImmunizationRouteID,
                                     MedicatedDate = ss.MedicatedDate,
                                     MedicatedTime = ss.MedicatedTime,
                                     IsFormularyCheck = ss.IsFormularyCheck,
                                     DrugCodeForCDS = ss.DrugCodeForCDS,
                                     ExternalMedicationID = ss.ExternalMedicationID,
                                     Frequency =ss.Frequency,
                                     PackageDescription =ss.PackageDescription,
                                     MedicationRefusalReasonDescription = ss.MedicationRefusalReasonID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == ss.MedicationRefusalReasonID).FirstOrDefault().Description : "",
                                     StatusDescription = ss.CurrentStatus > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == ss.CurrentStatus).FirstOrDefault().Description : "",
                                     DosageFormDescription = ss.DosageFormID > 0 ? this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DosageForm>().Table().Where(x => x.DosageFormID == ss.DosageFormID).FirstOrDefault().Description : "",
                                     DispenseFormDescription = ss.DispenseFormID > 0 ? this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Code
                                                                + "/" + this._uow.GenericRepository<DispenseForm>().Table().Where(x => x.DispenseFormID == ss.DispenseFormID).FirstOrDefault().Description : "",
                                     DrugCodeDescription = ss.DrugCodeID > 0 ? this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().NDCCode
                                                            + "/" + this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == ss.DrugCodeID).FirstOrDefault().Description : "",
                                     ImmunizationRouteDescription = ss.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == ss.ImmunizationRouteID).FirstOrDefault().Route : "",
                                 }).ToList();

            return getmedication;
        }
        #endregion

        #region patientAllergyModels
        public List<PatientAllergyModel> patientAllergyModels()
        {
            var Allergy = (from a in this._uow.GenericRepository<PatientAllergy>().Table().Where(x => x.Deleted != true)
                           select
                           new
                           {
                               a.PatientAllergyID,
                               a.PatientID,
                               a.PatientEncounterID,
                               a.RecordedDate,
                               a.AllergyTypeID,
                               a.AllergySeverityID,
                               a.AllergyName,
                               a.Reaction,
                               a.IsActive,
                               a.AllergyOnsetID,
                               a.OnSetDate,
                               a.Deleted,
                               a.CreatedDate,
                               a.CreatedBy,
                               a.ModifiedDate,
                               a.ModifiedBy,
                               a.Notes,
                               a.AllergyDescription,
                               a.PatientVisitID,
                               a.DeleteReason,
                               a.IsPrinted,
                               a.AllergyObjectID,
                               a.AllergyCode,
                               a.RxNormConceptID,
                               a.NotesSnomedCT,
                               a.AllergyNameID,
                               a.ExternalAllergyID,
                           }).AsEnumerable().Select(xx => new PatientAllergyModel
                           {
                               PatientAllergyID = xx.PatientAllergyID,
                               PatientID = xx.PatientID,
                               PatientEncounterID = xx.PatientEncounterID,
                               RecordedDate = xx.RecordedDate,
                               AllergyTypeID = xx.AllergyTypeID,
                               AllergyCode = xx.AllergyCode,
                               AllergySeverityID = xx.AllergySeverityID,
                               AllergyName = xx.AllergyName,
                               Reaction = xx.Reaction,
                               IsActive = xx.IsActive,
                               AllergyOnsetID = xx.AllergyOnsetID,
                               OnSetDate = xx.OnSetDate,
                               Deleted = xx.Deleted,
                               CreatedDate = xx.CreatedDate,
                               CreatedBy = xx.CreatedBy,
                               ModifiedDate = xx.ModifiedDate,
                               ModifiedBy = xx.ModifiedBy,
                               Notes = xx.Notes,
                               AllergyDescription = xx.AllergyDescription,
                               PatientVisitID = xx.PatientVisitID,
                               DeleteReason = xx.DeleteReason,
                               IsPrinted = xx.IsPrinted,
                               AllergyObjectID = xx.AllergyObjectID,
                               RxNormConceptID = xx.RxNormConceptID,
                               NotesSnomedCT = xx.NotesSnomedCT,
                               AllergyNameID = xx.AllergyNameID,
                               ExternalAllergyID = xx.ExternalAllergyID

                           }).ToList();
            return Allergy;
        }

        #endregion

        #region patientWorkHistoryModels
        public List<PatientWorkHistoryModel> patientWorkHistoryModels()
        {
            var workHistory = (from a in this._uow.GenericRepository<PatientWorkHistory>().Table().Where(x => x.Deleted != true)
                               select
                               new
                               {
                                   a.PatientWorkHistoryID,
                                   a.PatientID,
                                   a.RecordedDate,
                                   a.EmployerName,
                                   a.AddressLine1,
                                   a.AddressLine2,
                                   a.City,
                                   a.State,
                                   a.Country,
                                   a.ZIP,
                                   a.County,
                                   a.ContactPerson,
                                   a.Telephone,
                                   a.AlternatePhone,
                                   a.WorkDateFrom,
                                   a.WorkDateTo,
                                   a.Deleted,
                                   a.CreatedDate,
                                   a.CreatedBy,
                                   a.ModifiedDate,
                                   a.ModifiedBy,
                                   a.PatientVisitID,
                                   a.Notes
                               }).AsEnumerable().Select(xx => new PatientWorkHistoryModel
                               {
                                   PatientWorkHistoryID = xx.PatientWorkHistoryID,
                                   PatientID = xx.PatientID,
                                   RecordedDate = xx.RecordedDate,
                                   EmployerName = xx.EmployerName,
                                   AddressLine1 = xx.AddressLine1,
                                   AddressLine2 = xx.AddressLine2,
                                   City = xx.City,
                                   State = xx.State,
                                   Country = xx.Country,
                                   ZIP = xx.ZIP,
                                   County = xx.Country,
                                   CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                   ContactPerson = xx.ContactPerson,
                                   Telephone = xx.Telephone,
                                   AlternatePhone = xx.AlternatePhone,
                                   WorkDateFrom = xx.WorkDateFrom,
                                   WorkDateTo = xx.WorkDateTo,
                                   Deleted = xx.Deleted,
                                   CreatedDate = xx.CreatedDate,
                                   CreatedBy = xx.CreatedBy,
                                   ModifiedDate = xx.ModifiedDate,
                                   ModifiedBy = xx.ModifiedBy,
                                   PatientVisitID = xx.PatientVisitID,
                                   Notes = xx.Notes
                               }).ToList();

            return workHistory;

        }
        #endregion

        #region FamilyHealthHistoryModels
        public List<FamilyHealthHistoryModel> FamilyHealthHistoryModels()
        {
            var FamilyHealthHistory = (from a in this._uow.GenericRepository<FamilyHealthHistory>().Table().Where(x => x.Deleted != true)
                                       select
                                       new
                                       {
                                           a.FamilyHealthHistoryID,
                                           a.PatientID,
                                           a.PatientRelationID,
                                           a.PersonName,
                                           a.ClinicalNotes,
                                           a.RecordedDate,
                                           a.Deleted,
                                           a.CreatedDate,
                                           a.CreatedBy,
                                           a.ModifiedBy,
                                           a.ModifiedDate,
                                           a.PatientVisitID,
                                           a.Notes,
                                           a.StatusCodeID,
                                           a.AgeatDeath,
                                           a.AgeatDiagnosis,
                                           a.GenderID,
                                           a.DateOfBirth,
                                           a.Disease,
                                           a.Living
                                       }).AsEnumerable().Select(xx => new FamilyHealthHistoryModel
                                       {
                                           FamilyHealthHistoryID = xx.FamilyHealthHistoryID,
                                           PatientID = xx.PatientID,
                                           PatientRelationID = xx.PatientRelationID,
                                           PersonName = xx.PersonName,
                                           ClinicalNotes = xx.ClinicalNotes,
                                           RecordedDate = xx.RecordedDate,
                                           Deleted = xx.Deleted,
                                           CreatedDate = xx.CreatedDate,
                                           CreatedBy = xx.CreatedBy,
                                           ModifiedBy = xx.ModifiedBy,
                                           ModifiedDate = xx.ModifiedDate,
                                           PatientVisitID = xx.PatientVisitID,
                                           Notes = xx.Notes,
                                           StatusCodeID = xx.StatusCodeID,
                                           StatusDescription = xx.StatusCodeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.StatusCodeID).FirstOrDefault().Description : "",
                                           AgeatDeath = xx.AgeatDeath,
                                           AgeatDiagnosis = xx.AgeatDiagnosis,
                                           GenderID = xx.GenderID,
                                           GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                           PatientRelationShipDescription = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                           DateOfBirth = xx.DateOfBirth,
                                           Disease = xx.Disease,
                                           Living = xx.Living,

                                       }).ToList();

            return FamilyHealthHistory;
        }
        #endregion

        #region patientImmunizationModels

        public List<PatientImmunizationModel> patientImmunizationModels()
        {
            var Immunization = (from a in this._uow.GenericRepository<PatientImmunization>().Table().Where(x => x.Deleted != true)
                                select
                                new
                                {
                                    a.PatientImmunizationID,
                                    a.PatientID,
                                    a.VaccinationID,
                                    a.ImmunizationID,
                                    a.VaccinationManufacturerID,
                                    a.ImmunizedAge,
                                    a.Dose,
                                    a.LotNumber,
                                    a.Route,
                                    a.HumanBodySite,
                                    a.InjectedOn,
                                    a.InjectedTime,
                                    a.InjectedBy,
                                    a.DoseUnits,
                                    a.RemindBeforeDays,
                                    a.RemindBeforeHours,
                                    a.Notes,
                                    a.ExpirationDate,
                                    a.ImmunizationRouteID,
                                    a.Product,
                                    a.Manufacturer,
                                    a.HumanBodySiteID,
                                    a.ImmunizationNotes,
                                    a.IsPrinted,
                                    a.ImmunizationRegistrySentStatusID,
                                    a.PatientVisitID,
                                    a.RecordedDate,
                                    a.ReviewedByID,
                                    a.Deleted,
                                    a.CreatedDate,
                                    a.CreatedBy,
                                    a.ModifiedDate,
                                    a.ModifiedBy,
                                    a.DiseasePresumedImmunity,
                                    a.RegistryPublicityEffectiveDate,
                                    a.PublicityCodeID,
                                    a.RegistryStatusEffectiveDate,
                                    a.NotesSnomedCT,
                                    a.VFCFinancialClassID,
                                    a.RefusalReasonCodeID,
                                    a.ImmunizationInformationSourceID,
                                    a.ProtectionIndicator,
                                    a.ProtectionIndicatorEffective,
                                    a.InjectedByID,
                                    a.IsReminder,
                                    a.NumberOfMessagesToSendPerPatient,
                                    a.IntervalPerMessage,
                                    a.IntervalBetweenMessagesTypeId,
                                    a.ImmunizationDate
                                }).AsEnumerable().Select(xx => new PatientImmunizationModel
                                {
                                    PatientImmunizationID = xx.PatientImmunizationID,
                                    PatientID = xx.PatientID,
                                    VaccinationID = xx.VaccinationID,
                                    ImmunizationID = xx.ImmunizationID,
                                    ImmunizedAge = xx.ImmunizedAge,
                                    Dose = xx.Dose,
                                    LotNumber = xx.LotNumber,
                                    Route = xx.Route,
                                    HumanBodySiteID = xx.HumanBodySiteID,
                                    InjectedOn = xx.InjectedOn,
                                    InjectedTime = xx.InjectedTime,
                                    InjectedBy = xx.InjectedBy,
                                    DoseUnits = xx.DoseUnits,
                                    ExpirationDate = xx.ExpirationDate,
                                    ImmunizationRouteID = xx.ImmunizationRouteID,
                                    ImmunizationNotes = xx.ImmunizationNotes,
                                    Deleted = xx.Deleted,
                                    CreatedBy = xx.CreatedBy,
                                    CreatedDate = xx.CreatedDate,
                                    ModifiedBy = xx.ModifiedBy,
                                    ModifiedDate = xx.ModifiedDate,
                                    PatientVisitID = xx.PatientVisitID,
                                    IsPrinted = xx.IsPrinted,
                                    ImmunizationRegistrySentStatusID = xx.ImmunizationRegistrySentStatusID,
                                    RecordedDate = xx.RecordedDate,
                                    ReviewedByID = xx.ReviewedByID,
                                    DiseasePresumedImmunity = xx.DiseasePresumedImmunity,
                                    RegistryStatusEffectiveDate = xx.RegistryStatusEffectiveDate,
                                    PublicityCodeID = xx.PublicityCodeID,
                                    RegistryPublicityEffectiveDate = xx.RegistryPublicityEffectiveDate,
                                    NotesSnomedCT = xx.NotesSnomedCT,
                                    VFCFinancialClassID = xx.VFCFinancialClassID,
                                    RefusalReasonCodeID = xx.RefusalReasonCodeID,
                                    ImmunizationInformationSourceID = xx.ImmunizationInformationSourceID,
                                    ProtectionIndicator = xx.ProtectionIndicator,
                                    ProtectionIndicatorEffective = xx.ProtectionIndicatorEffective,
                                    InjectedByID = xx.InjectedByID,
                                    IsReminder = xx.IsReminder,
                                    RemindBeforeDays = xx.RemindBeforeDays,
                                    RemindBeforeHours = xx.RemindBeforeHours,
                                    NumberOfMessagesToSendPerPatient = xx.NumberOfMessagesToSendPerPatient,
                                    IntervalPerMessage = xx.IntervalPerMessage,
                                    IntervalBetweenMessagesTypeId = xx.IntervalBetweenMessagesTypeId,
                                    ImmunizationDate = xx.ImmunizationDate,
                                    Product = xx.Product,
                                    Manufacturer = xx.Manufacturer,
                                    VaccinationManufacturerID = xx.VaccinationManufacturerID,
                                    HumanBodySiteDescription = xx.HumanBodySiteID > 0 ? this._uow.GenericRepository<HumanBodySite>().Table().Where(x => x.HumanBodySiteID == xx.HumanBodySiteID).FirstOrDefault().Description : "",
                                    PublicityCodeDescription = xx.PublicityCodeID > 0 ? this._uow.GenericRepository<PublicityCode>().Table().Where(x => x.PublicityCodeID == xx.PublicityCodeID).FirstOrDefault().Description : "",
                                    RefusalReasonCodeDescription = xx.RefusalReasonCodeID > 0 ? this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.RefusalReasonCodeID == xx.RefusalReasonCodeID).FirstOrDefault().Description : "",
                                    VFCFinancialClassDescription = xx.VFCFinancialClassID > 0 ? this._uow.GenericRepository<VFCFinancialClass>().Table().Where(x => x.VFCFinancialClassID == xx.VFCFinancialClassID).FirstOrDefault().Description : "",
                                    ImmunizationInformationSourceDescription = xx.ImmunizationInformationSourceID > 0 ? this._uow.GenericRepository<ImmunizationInformationSource>().Table().Where(x => x.ImmunizationInformationSourceID == xx.ImmunizationInformationSourceID).FirstOrDefault().Description : "",
                                    ImmunizationRegistryStatusDescription = xx.ImmunizationRegistrySentStatusID > 0 ? this._uow.GenericRepository<ImmunizationRegistryStatus>().Table().Where(x => x.ImmunizationRegistryStatusID == xx.ImmunizationRegistrySentStatusID).FirstOrDefault().Description : "",
                                    RouteDescription = xx.ImmunizationRouteID > 0 ? this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => x.ImmunizationRouteID == xx.ImmunizationRouteID).FirstOrDefault().Route : "",
                                    IntervalBetweenMessagesTypeDescription = xx.IntervalBetweenMessagesTypeId > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.IntervalBetweenMessagesTypeId).FirstOrDefault().Description : "",
                                }).ToList();

            return Immunization;

        }

        #endregion

        #region patientDiagnosticListModels
        public List<PatientDiagnosticListModel> patientDiagnosticListModels()
        {
            var patientDiagnosticList = (from a in this._uow.GenericRepository<PatientDiagnosticList>().Table().Where(x => x.Deleted != true)
                                         select
                                         new
                                         {
                                             a.PatientDiagnosticListID,
                                             a.PatientID,
                                             a.RecordedDate,
                                             a.ICDCode1,
                                             a.ICDCode2,
                                             a.ICDCode3,
                                             a.ICDCode4,
                                             a.ICDCode5,
                                             a.ICDCode6,
                                             a.ICDCode7,
                                             a.ICDCode8,
                                             a.ICDCode9,
                                             a.ICDCode10,
                                             a.ICDCode11,
                                             a.ICDCode12,
                                             a.ServiceDate,
                                             a.PatientVisitID,
                                             a.Deleted,
                                             a.CreatedDate,
                                             a.CreatedBy,
                                             a.ModifiedBy,
                                             a.ModifiedDate,
                                             a.IsPrinted
                                         }).AsEnumerable().Select(xx => new PatientDiagnosticListModel
                                         {
                                             PatientDiagnosticListID = xx.PatientDiagnosticListID,
                                             PatientID = xx.PatientID,
                                             RecordedDate = xx.RecordedDate,
                                             ICDCode1 = xx.ICDCode1,
                                             ICDCode2 = xx.ICDCode2,
                                             ICDCode3 = xx.ICDCode3,
                                             ICDCode4 = xx.ICDCode4,
                                             ICDCode5 = xx.ICDCode5,
                                             ICDCode6 = xx.ICDCode6,
                                             ICDCode7 = xx.ICDCode7,
                                             ICDCode8 = xx.ICDCode8,
                                             ICDCode9 = xx.ICDCode9,
                                             ICDCode10 = xx.ICDCode10,
                                             ICDCode11 = xx.ICDCode11,
                                             ICDCode12 = xx.ICDCode12,
                                             ServiceDate = xx.ServiceDate,
                                             PatientVisitID = xx.PatientVisitID,
                                             Deleted = xx.Deleted,
                                             CreatedDate = xx.CreatedDate,
                                             CreatedBy = xx.CreatedBy,
                                             ModifiedBy = xx.ModifiedBy,
                                             ModifiedDate = xx.ModifiedDate,
                                             IsPrinted = xx.IsPrinted
                                         }).ToList();

            return patientDiagnosticList;
        }
        #endregion

        #region PatientAppointmentHistoryModels
        public List<PatientAppointmentHistoryModel> PatientAppointmentHistoryModels()
        {
            var AppointmentHistory = (from a in this._uow.GenericRepository<PatientAppointmentHistory>().Table()
                                      join b in this._uow.GenericRepository<PatientAppointment>().Table() on a.PatientAppointmentID equals b.PatientAppointmentID
                                      select
                                      new
                                      {
                                          a.PatientAppointmentID,
                                          a.PatientAppointmentHistoryID,
                                          a.AppointmentStatusCode,
                                          a.Comments,
                                          a.ChangedDate,
                                          a.ChangedBy
                                      }).AsEnumerable().Select(xx => new PatientAppointmentHistoryModel
                                      {
                                          PatientAppointmentID = xx.PatientAppointmentID,
                                          PatientAppointmentHistoryID = xx.PatientAppointmentHistoryID,
                                          AppointmentStatusCode = xx.AppointmentStatusCode,
                                          Comments = xx.Comments,
                                          ChangedDate = xx.ChangedDate,
                                          ChangedBy = xx.ChangedBy
                                      }).ToList();
            return AppointmentHistory;
        }
        #endregion

        #region patientInsuranceModels
        public List<PatientInsuranceModel> patientInsuranceModels()
        {
            var PatientInsurance = (from a in this._uow.GenericRepository<PatientInsurance>().Table().Where(x => x.Deleted != true)
                                    join c in this._uow.GenericRepository<InsuranceType>().Table() on a.InsuranceTypeID equals c.InsuranceTypeID
                                    select
                                    new
                                    {
                                        a.PatientInsuranceID,
                                        a.PatientID,
                                        a.SelfInsured,
                                        a.InsuranceTypeID,
                                        a.InsuranceCompanyID,
                                        a.PatientRelationID,
                                        a.SSN,
                                        a.NameLast,
                                        a.NameFirst,
                                        a.NamePrefix,
                                        a.NameSuffix,
                                        a.GenderID,
                                        a.BirthDate,
                                        a.AddressLine1,
                                        a.AddressLine2,
                                        a.City,
                                        a.State,
                                        a.Country,
                                        a.Phone,
                                        a.AlternatePhone,
                                        a.Email,
                                        a.GroupName,
                                        a.GroupNumber,
                                        a.PolicyNumber,
                                        a.Copay,
                                        a.EffectiveDate,
                                        a.TerminationDate,
                                        a.EligibilityRequestedDate,
                                        a.EligibilityStatus,
                                        a.SubscriberInsuredID,
                                        a.PatientInsuredID,
                                        a.Deleted,
                                        a.CreatedDate,
                                        a.CreatedBy,
                                        a.ModifiedDate,
                                        a.ModifiedBy,
                                        a.BillingMethodID,
                                        a.IsForeign,
                                        c.TypeDescription

                                    }).AsEnumerable().Select(xx => new PatientInsuranceModel
                                    {
                                        PatientInsuranceID = xx.PatientInsuranceID,
                                        PatientID = xx.PatientID,
                                        SelfInsured = xx.SelfInsured,
                                        InsuranceTypeID = xx.InsuranceTypeID,
                                        InsuranceCompanyID = xx.InsuranceCompanyID,
                                        PatientRelationID = xx.PatientRelationID,
                                        SSN = xx.SSN,
                                        NameLast = xx.NameLast,
                                        NameFirst = xx.NameFirst,
                                        NamePrefix = xx.NamePrefix,
                                        NameSuffix = xx.NameSuffix,
                                        GenderID = xx.GenderID,
                                        BirthDate = xx.BirthDate,
                                        AddressLine1 = xx.AddressLine1,
                                        AddressLine2 = xx.AddressLine2,
                                        City = xx.City,
                                        State = xx.State,
                                        Country = xx.Country,
                                        Phone = xx.Phone,
                                        AlternatePhone = xx.AlternatePhone,
                                        Email = xx.Email,
                                        GroupName = xx.GroupName,
                                        GroupNumber = xx.GroupNumber,
                                        PolicyNumber = xx.PolicyNumber,
                                        Copay = xx.Copay,
                                        EffectiveDate = xx.EffectiveDate,
                                        TerminationDate = xx.TerminationDate,
                                        EligibilityRequestedDate = xx.EligibilityRequestedDate,
                                        EligibilityStatus = xx.EligibilityStatus,
                                        SubscriberInsuredID = xx.SubscriberInsuredID,
                                        PatientInsuredID = xx.PatientInsuredID,
                                        Deleted = xx.Deleted,
                                        CreatedDate = xx.CreatedDate,
                                        CreatedBy = xx.CreatedBy,
                                        ModifiedDate = xx.ModifiedDate,
                                        ModifiedBy = xx.ModifiedBy,
                                        BillingMethodID = xx.BillingMethodID,
                                        IsForeign = xx.IsForeign,
                                        TypeDescription = xx.TypeDescription

                                    }).ToList();
            return PatientInsurance;
        }
        #endregion

        #region PatientLabOrderTestModels
        public List<PatientLabOrderTestModel> PatientLabOrderTestModels()
        {
            var patientLab = (from a in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => x.Deleted != true)
                              select
                              new
                              {
                                  a.PatientLabOrderTestID,
                                  a.FacilityID,
                                  a.FacilityName,
                                  a.ProviderID,
                                  a.ProviderName,
                                  a.RecordedDate,
                                  a.OrderingProviderID,
                                  a.OrderingProviderName,
                                  a.PatientID,
                                  a.LabName,
                                  a.LabTestDate,
                                  a.LabAddressLine1,
                                  a.LabAddressLine2,
                                  a.LabCity,
                                  a.LabState,
                                  a.LabCounty,
                                  a.LabZIP,
                                  a.LoincCode1,
                                  a.LoincCode2,
                                  a.LoincCode3,
                                  a.LoincCode4,
                                  a.LoincCode5,
                                  a.LoincCode6,
                                  a.LoincCode7,
                                  a.LoincCode8,
                                  a.LoincCode9,
                                  a.LoincCode10,
                                  a.LoincCode11,
                                  a.LoincCode12,
                                  a.LoincCode13,
                                  a.LoincCode14,
                                  a.LoincCode15,
                                  a.LoincCode16,
                                  a.ICDCode1,
                                  a.ICDCode2,
                                  a.ICDCode3,
                                  a.ICDCode4,
                                  a.ICDCode5,
                                  a.ICDCode6,
                                  a.ICDCode7,
                                  a.ICDCode8,
                                  a.ICDCode9,
                                  a.ICDCode10,
                                  a.Notes,
                                  a.IsActive,
                                  a.IsPastTest,
                                  a.DocumentReferenceIds,
                                  a.Deleted,
                                  a.CreatedBy,
                                  a.CreatedDate,
                                  a.ModifiedBy,
                                  a.ModifiedDate,
                                  a.PatientVisitID,
                                  a.EmdeonLabID,
                                  a.PlacerOrderNumber,
                                  a.OrderRequestMSGPIDGRTORCID,
                                  a.ScheduledTestStatusID,
                                  a.LoincCode1Result,
                                  a.LoincCode1ResultDate,
                                  a.LoincCode1ResultUnits,
                                  a.LoincCode2Result,
                                  a.LoincCode2ResultDate,
                                  a.LoincCode2ResultUnits,
                                  a.LoincCode3Result,
                                  a.LoincCode3ResultDate,
                                  a.LoincCode3ResultUnits,
                                  a.LoincCode4Result,
                                  a.LoincCode4ResultDate,
                                  a.LoincCode4ResultUnits,
                                  a.LoincCode5Result,
                                  a.LoincCode5ResultDate,
                                  a.LoincCode5ResultUnits,
                                  a.LoincCode6Result,
                                  a.LoincCode6ResultDate,
                                  a.LoincCode6ResultUnits,
                                  a.LoincCode7Result,
                                  a.LoincCode7ResultDate,
                                  a.LoincCode7ResultUnits,
                                  a.LoincCode8Result,
                                  a.LoincCode8ResultDate,
                                  a.LoincCode8ResultUnits,
                                  a.LoincCode9Result,
                                  a.LoincCode9ResultDate,
                                  a.LoincCode9ResultUnits,
                                  a.LoincCode10Result,
                                  a.LoincCode10ResultDate,
                                  a.LoincCode10ResultUnits,
                                  a.LoincCode11Result,
                                  a.LoincCode11ResultDate,
                                  a.LoincCode11ResultUnits,
                                  a.LoincCode12Result,
                                  a.LoincCode12ResultDate,
                                  a.LoincCode12ResultUnits,
                                  a.LoincCode13Result,
                                  a.LoincCode13ResultDate,
                                  a.LoincCode13ResultUnits,
                                  a.LoincCode14Result,
                                  a.LoincCode14ResultDate,
                                  a.LoincCode14ResultUnits,
                                  a.LoincCode15Result,
                                  a.LoincCode15ResultDate,
                                  a.LoincCode15ResultUnits,
                                  a.LoincCode16Result,
                                  a.LoincCode16ResultDate,
                                  a.LoincCode16ResultUnits,
                                  a.IsPrinted,
                                  a.IsEditable
                              }).AsEnumerable().Select(xx => new PatientLabOrderTestModel
                              {
                                  PatientLabOrderTestID = xx.PatientLabOrderTestID,
                                  FacilityID = xx.FacilityID,
                                  FacilityName = xx.FacilityName.ToString(),
                                  ProviderID = xx.ProviderID,
                                  RecordedDate = xx.RecordedDate,
                                  ProviderName = xx.ProviderName,
                                  OrderingProviderID = xx.OrderingProviderID,
                                  OrderingProviderName = xx.OrderingProviderName,
                                  PatientID = xx.PatientID,
                                  LabName = xx.LabName,
                                  LabTestDate = xx.LabTestDate,
                                  LabAddressLine1 = xx.LabAddressLine1,
                                  LabAddressLine2 = xx.LabAddressLine2,
                                  LabCity = xx.LabCity,
                                  LabState = xx.LabState,
                                  LabCounty = xx.LabCounty,
                                  LabZIP = xx.LabZIP,
                                  LoincCode1 = xx.LoincCode1,
                                  LoincCode2 = xx.LoincCode2,
                                  LoincCode3 = xx.LoincCode3,
                                  LoincCode4 = xx.LoincCode4,
                                  LoincCode5 = xx.LoincCode5,
                                  LoincCode6 = xx.LoincCode6,
                                  LoincCode7 = xx.LoincCode7,
                                  LoincCode8 = xx.LoincCode8,
                                  LoincCode9 = xx.LoincCode9,
                                  LoincCode10 = xx.LoincCode10,
                                  LoincCode11 = xx.LoincCode11,
                                  LoincCode12 = xx.LoincCode12,
                                  LoincCode13 = xx.LoincCode13,
                                  LoincCode14 = xx.LoincCode14,
                                  LoincCode15 = xx.LoincCode15,
                                  LoincCode16 = xx.LoincCode16,
                                  ICDCode1 = xx.ICDCode1,
                                  ICDCode2 = xx.ICDCode2,
                                  ICDCode3 = xx.ICDCode3,
                                  ICDCode4 = xx.ICDCode4,
                                  ICDCode5 = xx.ICDCode5,
                                  ICDCode6 = xx.ICDCode6,
                                  ICDCode7 = xx.ICDCode7,
                                  ICDCode8 = xx.ICDCode8,
                                  ICDCode9 = xx.ICDCode9,
                                  ICDCode10 = xx.ICDCode10,
                                  Notes = xx.Notes,
                                  IsActive = xx.IsActive,
                                  IsPastTest = xx.IsPastTest,
                                  DocumentReferenceIds = xx.DocumentReferenceIds,
                                  Deleted = xx.Deleted,
                                  CreatedBy = xx.CreatedBy,
                                  CreatedDate = xx.CreatedDate,
                                  ModifiedBy = xx.ModifiedBy,
                                  ModifiedDate = xx.ModifiedDate,
                                  PatientVisitID = xx.PatientVisitID,
                                  EmdeonLabID = xx.EmdeonLabID,
                                  PlacerOrderNumber = xx.PlacerOrderNumber,
                                  OrderRequestMSGPIDGRTORCID = xx.OrderRequestMSGPIDGRTORCID,
                                  ScheduledTestStatusID = xx.ScheduledTestStatusID,
                                  LabOrderScheduledTestStatusDescription = xx.ScheduledTestStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                  LoincCode1Result = xx.LoincCode1Result,
                                  LoincCode1ResultDate = xx.LoincCode1ResultDate,
                                  LoincCode1ResultUnits = xx.LoincCode1ResultUnits,
                                  LoincCode2Result = xx.LoincCode2Result,
                                  LoincCode2ResultDate = xx.LoincCode2ResultDate,
                                  LoincCode2ResultUnits = xx.LoincCode2ResultUnits,
                                  LoincCode3Result = xx.LoincCode3Result,
                                  LoincCode3ResultDate = xx.LoincCode3ResultDate,
                                  LoincCode3ResultUnits = xx.LoincCode3ResultUnits,
                                  LoincCode4Result = xx.LoincCode4Result,
                                  LoincCode4ResultDate = xx.LoincCode4ResultDate,
                                  LoincCode4ResultUnits = xx.LoincCode4ResultUnits,
                                  LoincCode5Result = xx.LoincCode5Result,
                                  LoincCode5ResultDate = xx.LoincCode5ResultDate,
                                  LoincCode5ResultUnits = xx.LoincCode5ResultUnits,
                                  LoincCode6Result = xx.LoincCode6Result,
                                  LoincCode6ResultDate = xx.LoincCode6ResultDate,
                                  LoincCode6ResultUnits = xx.LoincCode6ResultUnits,
                                  LoincCode7Result = xx.LoincCode7Result,
                                  LoincCode7ResultDate = xx.LoincCode7ResultDate,
                                  LoincCode7ResultUnits = xx.LoincCode7ResultUnits,
                                  LoincCode8Result = xx.LoincCode8Result,
                                  LoincCode8ResultDate = xx.LoincCode8ResultDate,
                                  LoincCode8ResultUnits = xx.LoincCode8ResultUnits,
                                  LoincCode9Result = xx.LoincCode9Result,
                                  LoincCode9ResultDate = xx.LoincCode9ResultDate,
                                  LoincCode9ResultUnits = xx.LoincCode9ResultUnits,
                                  LoincCode10Result = xx.LoincCode10Result,
                                  LoincCode10ResultDate = xx.LoincCode10ResultDate,
                                  LoincCode10ResultUnits = xx.LoincCode10ResultUnits,
                                  LoincCode11Result = xx.LoincCode11Result,
                                  LoincCode11ResultDate = xx.LoincCode11ResultDate,
                                  LoincCode11ResultUnits = xx.LoincCode11ResultUnits,
                                  LoincCode12Result = xx.LoincCode12Result,
                                  LoincCode12ResultDate = xx.LoincCode12ResultDate,
                                  LoincCode12ResultUnits = xx.LoincCode12ResultUnits,
                                  LoincCode13Result = xx.LoincCode13Result,
                                  LoincCode13ResultDate = xx.LoincCode13ResultDate,
                                  LoincCode13ResultUnits = xx.LoincCode13ResultUnits,
                                  LoincCode14Result = xx.LoincCode14Result,
                                  LoincCode14ResultDate = xx.LoincCode14ResultDate,
                                  LoincCode14ResultUnits = xx.LoincCode14ResultUnits,
                                  LoincCode15Result = xx.LoincCode15Result,
                                  LoincCode15ResultDate = xx.LoincCode15ResultDate,
                                  LoincCode15ResultUnits = xx.LoincCode15ResultUnits,
                                  LoincCode16Result = xx.LoincCode16Result,
                                  LoincCode16ResultDate = xx.LoincCode16ResultDate,
                                  LoincCode16ResultUnits = xx.LoincCode16ResultUnits,
                                  IsPrinted = xx.IsPrinted,
                                  IsEditable = xx.IsEditable,
                              }).ToList();

            return patientLab;
        }
        #endregion

        #region Post Method to Add or update Patient
        public PatientModel AddUpdatePatient(PatientModel patientModel)
        {

            var patientadd = this._uow.GenericRepository<Patient>().Table().Where(a => a.NameFirst.ToLower().Trim() == patientModel.NameFirst.ToLower().Trim()).FirstOrDefault();

            if (patientadd == null)
            {
                patientadd = new Patient();

                patientadd.PatientID = patientModel.PatientID;
                patientadd.PatientSSN = patientModel.PatientSSN;
                patientadd.NameLast = patientModel.NameLast;
                patientadd.NameFirst = patientModel.NameFirst;
                patientadd.NameMiddle = patientModel.NameMiddle;
                patientadd.NamePrefix = patientModel.NamePrefix;
                patientadd.NameSuffix = patientModel.NameSuffix;
                patientadd.GenderID = patientModel.GenderID;
                patientadd.BirthDate = patientModel.BirthDate != null ? this._iMasterService.GetLocalTime(patientModel.BirthDate.Value) : null;
                patientadd.MaritalStatusID = patientModel.MaritalStatusID;
                patientadd.RaceID = patientModel.RaceID;
                patientadd.EthnicityID = patientModel.EthnicityID;
                patientadd.LanguageID = patientModel.LanguageID;
                patientadd.AddressLine1 = patientModel.AddressLine1;
                patientadd.AddressLine2 = patientModel.AddressLine2;
                patientadd.City = patientModel.City;
                patientadd.State = patientModel.State;
                patientadd.County = patientModel.County;
                patientadd.ZIP = patientModel.ZIP;
                patientadd.Country = patientModel.Country;
                patientadd.Phone = patientModel.Phone;
                patientadd.AlternatePhone = patientModel.AlternatePhone;
                patientadd.Email = patientModel.Email;
                patientadd.MailAddressLine1 = patientModel.AddressLine1;
                patientadd.MailAddressLine2 = patientModel.AddressLine2;
                patientadd.MailCity = patientModel.City;
                patientadd.MailState = patientModel.State;
                patientadd.MailCounty = patientModel.County;
                patientadd.MailZIP = patientModel.MailZIP;
                patientadd.MailCountry = patientModel.Country;
                patientadd.IsActive = patientModel.IsActive;
                patientadd.IsSameAsBillingAddress = patientModel.IsSameAsBillingAddress;
                patientadd.PassportNo = patientModel.PassportNo;
                patientadd.DrivingLicenseNo = patientModel.DrivingLicenseNo;
                patientadd.Deleted = false;
                patientadd.CreatedDate = DateTime.Now;
                patientadd.CreatedBy = "User";
                patientadd.SalutationID = patientModel.SalutationID;
                patientadd.DeathDate = patientModel.DeathDate;
                patientadd.CauseOfDeath = patientModel.CauseOfDeath;
                patientadd.PreferredLanguageID = patientModel.PreferredLanguageID;
                patientadd.MothersMaidenNameFirst = patientModel.MothersMaidenNameFirst;
                patientadd.MothersMaidenNameLast = patientModel.MothersMaidenNameLast;

                this._uow.GenericRepository<Patient>().Insert(patientadd);
            }
            else
            {
                patientadd.PatientSSN = patientModel.PatientSSN;
                patientadd.NameLast = patientModel.NameLast;
                patientadd.NameFirst = patientModel.NameFirst;
                patientadd.NameMiddle = patientModel.NameMiddle;
                patientadd.NamePrefix = patientModel.NamePrefix;
                patientadd.NameSuffix = patientModel.NameSuffix;
                patientadd.GenderID = patientModel.GenderID;
                patientadd.BirthDate = patientModel.BirthDate != null ? this._iMasterService.GetLocalTime(patientModel.BirthDate.Value) : null;
                patientadd.MaritalStatusID = patientModel.MaritalStatusID;
                patientadd.RaceID = patientModel.RaceID;
                patientadd.EthnicityID = patientModel.EthnicityID;
                patientadd.LanguageID = patientModel.LanguageID;
                patientadd.AddressLine1 = patientModel.AddressLine1;
                patientadd.AddressLine2 = patientModel.AddressLine2;
                patientadd.City = patientModel.City;
                patientadd.State = patientModel.State;
                patientadd.County = patientModel.County;
                patientadd.ZIP = patientModel.ZIP;
                patientadd.Country = patientModel.Country;
                patientadd.Phone = patientModel.Phone;
                patientadd.AlternatePhone = patientModel.AlternatePhone;
                patientadd.Email = patientModel.Email;
                patientadd.MailAddressLine1 = patientModel.AddressLine1;
                patientadd.MailAddressLine2 = patientModel.AddressLine2;
                patientadd.MailCity = patientModel.City;
                patientadd.MailState = patientModel.State;
                patientadd.MailCounty = patientModel.County;
                patientadd.MailZIP = patientModel.MailZIP;
                patientadd.MailCountry = patientModel.Country;
                patientadd.IsActive = patientModel.IsActive;
                patientadd.IsSameAsBillingAddress = patientModel.IsSameAsBillingAddress;
                patientadd.PassportNo = patientModel.PassportNo;
                patientadd.DrivingLicenseNo = patientModel.DrivingLicenseNo;
                patientadd.Deleted = false;
                patientadd.ModifiedDate = DateTime.UtcNow;
                patientadd.ModifiedBy = "User";
                patientadd.SalutationID = patientModel.SalutationID;
                patientadd.DeathDate = patientModel.DeathDate;
                patientadd.CauseOfDeath = patientModel.CauseOfDeath;
                patientadd.PreferredLanguageID = patientModel.PreferredLanguageID;
                patientadd.MothersMaidenNameFirst = patientModel.MothersMaidenNameFirst;
                patientadd.MothersMaidenNameLast = patientModel.MothersMaidenNameLast;

                this._uow.GenericRepository<Patient>().Update(patientadd);
            }
            this._uow.Save();
            patientModel.PatientID = patientadd.PatientID;

            return patientModel;
        }

        #endregion

        #region Post Method to Add or Update Patient Medication

        public PatientMedicationModel AddupdatePatientMedication(PatientMedicationModel patientMedicationModel)
        {
            var patmedadd = this._uow.GenericRepository<PatientMedication>().Table().Where(x => x.PatientMedicationID == patientMedicationModel.PatientMedicationID).FirstOrDefault();

            if (patmedadd == null)
            {
                patmedadd = new PatientMedication();

                patmedadd.PatientEncounterID = patientMedicationModel.PatientEncounterID;
                patmedadd.PatientID = patientMedicationModel.PatientID;
                patmedadd.RecordedDate = this._iMasterService.GetLocalTime(patientMedicationModel.RecordedDate);
                patmedadd.PatientMedicationID = patientMedicationModel.PatientMedicationID;
                patmedadd.StartedDate = this._iMasterService.GetLocalTime(patientMedicationModel.StartedDate);
                patmedadd.DrugCodeID = patientMedicationModel.DrugCodeID;
                patmedadd.PatientInstructions = patientMedicationModel.PatientInstructions;
                patmedadd.CurrentStatus = patientMedicationModel.CurrentStatus;
                patmedadd.Quantity = patientMedicationModel.Quantity;
                patmedadd.DispenseFormID = patientMedicationModel.DispenseFormID;
                patmedadd.Refill = patientMedicationModel.Refill;
                patmedadd.AllowSubstitution = patientMedicationModel.AllowSubstitution;
                patmedadd.Prescriber = patientMedicationModel.Prescriber;
                patmedadd.DrugName = patientMedicationModel.DrugName;
                patmedadd.ExpiryDate = patientMedicationModel.ExpiryDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.ExpiryDate.Value) : null;
                patmedadd.PrescribedDate = patientMedicationModel.PrescribedDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.PrescribedDate.Value) : null;
                patmedadd.DosageFormID = patientMedicationModel.DosageFormID;
                patmedadd.SubstitutionDrug = patientMedicationModel.SubstitutionDrug;
                patmedadd.SideEffects = patientMedicationModel.SideEffects;
                patmedadd.NotesToPharmacist = patientMedicationModel.NotesToPharmacist;
                patmedadd.PatientVisitID = patientMedicationModel.PatientVisitID;
                patmedadd.DeleteReason = patientMedicationModel.DeleteReason;
                patmedadd.RxObjectID = patientMedicationModel.RxObjectID;
                patmedadd.Sig = patientMedicationModel.Sig;
                patmedadd.IsPrinted = patientMedicationModel.IsPrinted;
                patmedadd.RxNormConceptID = patientMedicationModel.RxNormConceptID;
                patmedadd.RxNormCode = patientMedicationModel.RxNormCode;
                patmedadd.RecordedTime = patientMedicationModel.RecordedTime != null ? this._iMasterService.GetLocalTime(patientMedicationModel.RecordedTime.Value) : null;
                patmedadd.DispenseAsWritten = patientMedicationModel.DispenseAsWritten;
                patmedadd.RxNormAtomID = patientMedicationModel.RxNormAtomID;
                patmedadd.ScheduledTestStatusID = patientMedicationModel.ScheduledTestStatusID;
                patmedadd.Units = patientMedicationModel.Units;
                patmedadd.MedicationRefusalReasonID = patientMedicationModel.MedicationRefusalReasonID;
                patmedadd.MedicationOrderNotPerformedID = patientMedicationModel.MedicationOrderNotPerformedID;
                patmedadd.IsScheduled = patientMedicationModel.IsScheduled;
                patmedadd.MedicationBarcode = patientMedicationModel.MedicationBarcode;
                patmedadd.BarcodeImage = patientMedicationModel.BarcodeImage;
                patmedadd.IsReminder = patientMedicationModel.IsReminder;
                patmedadd.Frequency = patientMedicationModel.Frequency;
                patmedadd.PackageDescription = patientMedicationModel.PackageDescription;
                patmedadd.AppointmentDateMetDateEarlierThan = patientMedicationModel.AppointmentDateMetDateEarlierThan;
                patmedadd.AppointmentDateMetDateEarlierThanHrs = patientMedicationModel.AppointmentDateMetDateEarlierThanHrs;
                patmedadd.NumberOfMessagesToSendPerPatient = patientMedicationModel.NumberOfMessagesToSendPerPatient;
                patmedadd.IntervalPerMessage = patientMedicationModel.IntervalPerMessage;
                patmedadd.IntervalBetweenMessagesTypeId = patientMedicationModel.IntervalBetweenMessagesTypeId;
                patmedadd.ImmunizationRouteID = patientMedicationModel.ImmunizationRouteID;
                patmedadd.MedicatedDate = patientMedicationModel.MedicatedDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.MedicatedDate.Value) : null;
                patmedadd.MedicatedTime = patientMedicationModel.MedicatedTime != null ? this._iMasterService.GetLocalTime(patientMedicationModel.MedicatedTime.Value) : null;
                patmedadd.IsFormularyCheck = patientMedicationModel.IsFormularyCheck;
                patmedadd.DrugCodeForCDS = patientMedicationModel.DrugCodeForCDS;
                patmedadd.ExternalMedicationID = patientMedicationModel.ExternalMedicationID;
                patmedadd.Deleted = false;
                patmedadd.CreatedDate = DateTime.Now;
                patmedadd.CreatedBy = "User";

                this._uow.GenericRepository<PatientMedication>().Insert(patmedadd);
            }

            else
            {
                patmedadd.PatientEncounterID = patientMedicationModel.PatientEncounterID;
                patmedadd.PatientID = patientMedicationModel.PatientID;
                patmedadd.RecordedDate = this._iMasterService.GetLocalTime(patientMedicationModel.RecordedDate);
                patmedadd.PatientMedicationID = patientMedicationModel.PatientMedicationID;
                patmedadd.StartedDate = this._iMasterService.GetLocalTime(patientMedicationModel.StartedDate);
                patmedadd.DrugCodeID = patientMedicationModel.DrugCodeID;
                patmedadd.PatientInstructions = patientMedicationModel.PatientInstructions;
                patmedadd.CurrentStatus = patientMedicationModel.CurrentStatus;
                patmedadd.Quantity = patientMedicationModel.Quantity;
                patmedadd.DispenseFormID = patientMedicationModel.DispenseFormID;
                patmedadd.Refill = patientMedicationModel.Refill;
                patmedadd.AllowSubstitution = patientMedicationModel.AllowSubstitution;
                patmedadd.Prescriber = patientMedicationModel.Prescriber;
                patmedadd.DrugName = patientMedicationModel.DrugName;
                patmedadd.ExpiryDate = patientMedicationModel.ExpiryDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.ExpiryDate.Value) : null;
                patmedadd.PrescribedDate = patientMedicationModel.PrescribedDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.PrescribedDate.Value) : null;
                patmedadd.DosageFormID = patientMedicationModel.DosageFormID;
                patmedadd.SubstitutionDrug = patientMedicationModel.SubstitutionDrug;
                patmedadd.SideEffects = patientMedicationModel.SideEffects;
                patmedadd.NotesToPharmacist = patientMedicationModel.NotesToPharmacist;
                patmedadd.PatientVisitID = patientMedicationModel.PatientVisitID;
                patmedadd.DeleteReason = patientMedicationModel.DeleteReason;
                patmedadd.RxObjectID = patientMedicationModel.RxObjectID;
                patmedadd.Sig = patientMedicationModel.Sig;
                patmedadd.IsPrinted = patientMedicationModel.IsPrinted;
                patmedadd.RxNormConceptID = patientMedicationModel.RxNormConceptID;
                patmedadd.RxNormCode = patientMedicationModel.RxNormCode;
                patmedadd.RecordedTime = patientMedicationModel.RecordedTime != null ? this._iMasterService.GetLocalTime(patientMedicationModel.RecordedTime.Value) : null;
                patmedadd.DispenseAsWritten = patientMedicationModel.DispenseAsWritten;
                patmedadd.RxNormAtomID = patientMedicationModel.RxNormAtomID;
                patmedadd.ScheduledTestStatusID = patientMedicationModel.ScheduledTestStatusID;
                patmedadd.Units = patientMedicationModel.Units;
                patmedadd.MedicationRefusalReasonID = patientMedicationModel.MedicationRefusalReasonID;
                patmedadd.MedicationOrderNotPerformedID = patientMedicationModel.MedicationOrderNotPerformedID;
                patmedadd.IsScheduled = patientMedicationModel.IsScheduled;
                patmedadd.MedicationBarcode = patientMedicationModel.MedicationBarcode;
                patmedadd.BarcodeImage = patientMedicationModel.BarcodeImage;
                patmedadd.IsReminder = patientMedicationModel.IsReminder;
                patmedadd.Frequency = patientMedicationModel.Frequency;
                patmedadd.PackageDescription = patientMedicationModel.PackageDescription;
                patmedadd.AppointmentDateMetDateEarlierThan = patientMedicationModel.AppointmentDateMetDateEarlierThan;
                patmedadd.AppointmentDateMetDateEarlierThanHrs = patientMedicationModel.AppointmentDateMetDateEarlierThanHrs;
                patmedadd.NumberOfMessagesToSendPerPatient = patientMedicationModel.NumberOfMessagesToSendPerPatient;
                patmedadd.IntervalPerMessage = patientMedicationModel.IntervalPerMessage;
                patmedadd.IntervalBetweenMessagesTypeId = patientMedicationModel.IntervalBetweenMessagesTypeId;
                patmedadd.ImmunizationRouteID = patientMedicationModel.ImmunizationRouteID;
                patmedadd.MedicatedDate = patientMedicationModel.MedicatedDate != null ? this._iMasterService.GetLocalTime(patientMedicationModel.MedicatedDate.Value) : null;
                patmedadd.MedicatedTime = patientMedicationModel.MedicatedTime != null ? this._iMasterService.GetLocalTime(patientMedicationModel.MedicatedTime.Value) : null;
                patmedadd.IsFormularyCheck = patientMedicationModel.IsFormularyCheck;
                patmedadd.DrugCodeForCDS = patientMedicationModel.DrugCodeForCDS;
                patmedadd.ExternalMedicationID = patientMedicationModel.ExternalMedicationID;
                patmedadd.Deleted = false;
                patmedadd.ModifiedDate = DateTime.Now;
                patmedadd.ModifiedBy = "User";

                this._uow.GenericRepository<PatientMedication>().Update(patmedadd);

            }
            this._uow.Save();

            patientMedicationModel.PatientID = patmedadd.PatientID;

            return patientMedicationModel;

        }

        #endregion

        #region Post Method to Add or update Patient Allergy

        public PatientAllergyModel AddupdatePatientAllergyModel(PatientAllergyModel patientAllergyModel)
        {

            var patallergy = this._uow.GenericRepository<PatientAllergy>().Table().Where(x => x.PatientAllergyID == patientAllergyModel.PatientAllergyID).FirstOrDefault();

            if (patallergy == null)
            {
                patallergy = new PatientAllergy();



                patallergy.PatientID = patientAllergyModel.PatientID;
                patallergy.PatientEncounterID = patientAllergyModel.PatientEncounterID;
                patallergy.RecordedDate = this._iMasterService.GetLocalTime(patientAllergyModel.RecordedDate);
                patallergy.AllergyTypeID = patientAllergyModel.AllergyTypeID;
                patallergy.AllergyCode = patientAllergyModel.AllergyCode;
                patallergy.AllergySeverityID = patientAllergyModel.AllergySeverityID;
                patallergy.AllergyName = patientAllergyModel.AllergyName;
                patallergy.Reaction = patientAllergyModel.Reaction;
                patallergy.IsActive = patientAllergyModel.IsActive;
                patallergy.AllergyOnsetID = patientAllergyModel.AllergyOnsetID;
                patallergy.OnSetDate = patientAllergyModel.OnSetDate != null ? this._iMasterService.GetLocalTime(patientAllergyModel.OnSetDate.Value) : null;
                patallergy.Notes = patientAllergyModel.Notes;
                patallergy.AllergyDescription = patientAllergyModel.AllergyDescription;
                patallergy.PatientVisitID = patientAllergyModel.PatientVisitID;
                patallergy.DeleteReason = patientAllergyModel.DeleteReason;
                patallergy.IsPrinted = patientAllergyModel.IsPrinted;
                patallergy.AllergyObjectID = patientAllergyModel.AllergyObjectID;
                patallergy.RxNormConceptID = patientAllergyModel.RxNormConceptID;
                patallergy.NotesSnomedCT = patientAllergyModel.NotesSnomedCT;
                patallergy.AllergyNameID = patientAllergyModel.AllergyNameID;
                patallergy.ExternalAllergyID = patientAllergyModel.ExternalAllergyID;
                patallergy.Deleted = false;
                patallergy.CreatedDate = DateTime.Now;
                patallergy.CreatedBy = "User";

                this._uow.GenericRepository<PatientAllergy>().Insert(patallergy);
            }

            else
            {
                //patallergy.PatientID = patientAllergyModel.PatientID;
                patallergy.PatientEncounterID = patientAllergyModel.PatientEncounterID;
                patallergy.RecordedDate = this._iMasterService.GetLocalTime(patientAllergyModel.RecordedDate);
                patallergy.AllergyTypeID = patientAllergyModel.AllergyTypeID;
                patallergy.AllergyCode = patientAllergyModel.AllergyCode;
                patallergy.AllergySeverityID = patientAllergyModel.AllergySeverityID;
                patallergy.AllergyName = patientAllergyModel.AllergyName;
                patallergy.Reaction = patientAllergyModel.Reaction;
                patallergy.IsActive = patientAllergyModel.IsActive;
                patallergy.AllergyOnsetID = patientAllergyModel.AllergyOnsetID;
                patallergy.OnSetDate = patientAllergyModel.OnSetDate != null ? this._iMasterService.GetLocalTime(patientAllergyModel.OnSetDate.Value) : null;
                patallergy.Notes = patientAllergyModel.Notes;
                patallergy.AllergyDescription = patientAllergyModel.AllergyDescription;
                patallergy.PatientVisitID = patientAllergyModel.PatientVisitID;
                patallergy.DeleteReason = patientAllergyModel.DeleteReason;
                patallergy.IsPrinted = patientAllergyModel.IsPrinted;
                patallergy.AllergyObjectID = patientAllergyModel.AllergyObjectID;
                patallergy.RxNormConceptID = patientAllergyModel.RxNormConceptID;
                patallergy.NotesSnomedCT = patientAllergyModel.NotesSnomedCT;
                patallergy.AllergyNameID = patientAllergyModel.AllergyNameID;
                patallergy.ExternalAllergyID = patientAllergyModel.ExternalAllergyID;
                patallergy.Deleted = false;
                patallergy.CreatedDate = DateTime.Now;
                patallergy.CreatedBy = "User";

                this._uow.GenericRepository<PatientAllergy>().Update(patallergy);
            }
            this._uow.Save();

            patientAllergyModel.PatientID = patallergy.PatientID;

            return patientAllergyModel;
        }


        #endregion

        #region Post Method to Add or Update PatientWorkHistoryModel
        public PatientWorkHistoryModel AddupdatePatientWorkHistoryModel(PatientWorkHistoryModel patientWorkHistoryModel)
        {
            var patwork = this._uow.GenericRepository<PatientWorkHistory>().Table().Where(x => x.PatientWorkHistoryID == patientWorkHistoryModel.PatientWorkHistoryID).FirstOrDefault();

            if (patwork == null)
            {
                patwork = new PatientWorkHistory();


                patwork.PatientID = patientWorkHistoryModel.PatientID;
                patwork.RecordedDate = this._iMasterService.GetLocalTime(patientWorkHistoryModel.RecordedDate);
                patwork.EmployerName = patientWorkHistoryModel.EmployerName;
                patwork.AddressLine1 = patientWorkHistoryModel.AddressLine1;
                patwork.AddressLine2 = patientWorkHistoryModel.AddressLine2;
                patwork.City = patientWorkHistoryModel.City;
                patwork.State = patientWorkHistoryModel.State;
                patwork.Country = patientWorkHistoryModel.Country;
                patwork.ZIP = patientWorkHistoryModel.ZIP;
                patwork.County = patientWorkHistoryModel.Country;
                patwork.ContactPerson = patientWorkHistoryModel.ContactPerson;
                patwork.Telephone = patientWorkHistoryModel.Telephone;
                patwork.AlternatePhone = patientWorkHistoryModel.AlternatePhone;
                patwork.WorkDateFrom = patientWorkHistoryModel.WorkDateFrom != null ? this._iMasterService.GetLocalTime(patientWorkHistoryModel.WorkDateFrom.Value) : null;
                patwork.WorkDateTo = patientWorkHistoryModel.WorkDateTo != null ? this._iMasterService.GetLocalTime(patientWorkHistoryModel.WorkDateTo.Value) : null;
                patwork.PatientVisitID = patientWorkHistoryModel.PatientVisitID;
                patwork.Notes = patientWorkHistoryModel.Notes;
                patwork.Deleted = false;
                patwork.CreatedDate = DateTime.Now;
                patwork.CreatedBy = "User";

                this._uow.GenericRepository<PatientWorkHistory>().Insert(patwork);
            }

            else
            {
                patwork.PatientID = patientWorkHistoryModel.PatientID;
                patwork.RecordedDate = this._iMasterService.GetLocalTime(patientWorkHistoryModel.RecordedDate);
                patwork.EmployerName = patientWorkHistoryModel.EmployerName;
                patwork.AddressLine1 = patientWorkHistoryModel.AddressLine1;
                patwork.AddressLine2 = patientWorkHistoryModel.AddressLine2;
                patwork.City = patientWorkHistoryModel.City;
                patwork.State = patientWorkHistoryModel.State;
                patwork.Country = patientWorkHistoryModel.Country;
                patwork.ZIP = patientWorkHistoryModel.ZIP;
                patwork.County = patientWorkHistoryModel.Country;
                patwork.ContactPerson = patientWorkHistoryModel.ContactPerson;
                patwork.Telephone = patientWorkHistoryModel.Telephone;
                patwork.AlternatePhone = patientWorkHistoryModel.AlternatePhone;
                patwork.WorkDateFrom = patientWorkHistoryModel.WorkDateFrom != null ? this._iMasterService.GetLocalTime(patientWorkHistoryModel.WorkDateFrom.Value) : null;
                patwork.WorkDateTo = patientWorkHistoryModel.WorkDateTo != null ? this._iMasterService.GetLocalTime(patientWorkHistoryModel.WorkDateTo.Value) : null;
                patwork.PatientVisitID = patientWorkHistoryModel.PatientVisitID;
                patwork.Notes = patientWorkHistoryModel.Notes;
                patwork.Deleted = false;
                patwork.ModifiedDate = DateTime.Now;
                patwork.ModifiedBy = "User";

                this._uow.GenericRepository<PatientWorkHistory>().Update(patwork);
            }
            this._uow.Save();
            patientWorkHistoryModel.PatientID = patwork.PatientID;

            return patientWorkHistoryModel;
        }

        #endregion

        #region  get method called on socialHistory

        public List<PatientTobaccoAlcoholHistoryModel> GetSocialHistory()
        {
            var SocaialHistory = (from a in this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Table().Where(x => x.Deleted != true)
                                  select
                                  new
                                  {
                                      a.PatientTobaccoAlcoholHistoryID,
                                      a.PatientID,
                                      a.PatientAppointmentID,
                                      a.RecordedDate,
                                      a.SmokingStatusID,
                                      a.DrinkingStatusID,
                                      a.CigarettesPerDay,
                                      a.CigarettesPerYear,
                                      a.ConsumptionMLPerDay,
                                      a.ConsumptionMLPerYear,
                                      a.Notes,
                                      a.Deleted,
                                      a.CreatedDate,
                                      a.CreatedBy,
                                      a.ModifiedDate,
                                      a.ModifiedBy,
                                      a.IsPrinted

                                  }).AsEnumerable().Select(xx => new PatientTobaccoAlcoholHistoryModel
                                  {
                                      PatientTobaccoAlcoholHistoryID = xx.PatientTobaccoAlcoholHistoryID,
                                      PatientID = xx.PatientID,
                                      PatientAppointmentID = xx.PatientAppointmentID,
                                      RecordedDate = xx.RecordedDate,
                                      SmokingStatusID = xx.SmokingStatusID,
                                      DrinkingStatusID = xx.DrinkingStatusID,
                                      CigarettesPerDay = xx.CigarettesPerDay,
                                      CigarettesPerYear = xx.CigarettesPerYear,
                                      ConsumptionMLPerDay = xx.ConsumptionMLPerDay,
                                      ConsumptionMLPerYear = xx.ConsumptionMLPerYear,
                                      Notes = xx.Notes,
                                      Deleted = xx.Deleted,
                                      CreatedDate = xx.CreatedDate,
                                      CreatedBy = xx.CreatedBy,
                                      ModifiedDate = xx.ModifiedDate,
                                      ModifiedBy = xx.ModifiedBy,
                                      IsPrinted = xx.IsPrinted,
                                      SmokingStatusDescription = xx.SmokingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.SmokingStatusID).FirstOrDefault().Description : "",
                                      DrinkingStatusDescription = xx.DrinkingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.DrinkingStatusID).FirstOrDefault().Description : "",
                                  }).ToList();

            return SocaialHistory;

        }

        #endregion

        #region called on parameter patientID socialHistory
        public List<PatientTobaccoAlcoholHistoryModel> GetSocialHistoryByPatientID(int PatientID)
        {
            var SocaialHistory = (from a in this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                                  join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID
                                  select
                                  new
                                  {
                                      a.PatientTobaccoAlcoholHistoryID,
                                      a.PatientID,
                                      a.PatientAppointmentID,
                                      a.RecordedDate,
                                      a.SmokingStatusID,
                                      a.DrinkingStatusID,
                                      a.CigarettesPerDay,
                                      a.CigarettesPerYear,
                                      a.ConsumptionMLPerDay,
                                      a.ConsumptionMLPerYear,
                                      a.Notes,
                                      a.Deleted,
                                      a.CreatedDate,
                                      a.CreatedBy,
                                      a.ModifiedDate,
                                      a.ModifiedBy,
                                      a.IsPrinted

                                  }).AsEnumerable().Select(xx => new PatientTobaccoAlcoholHistoryModel
                                  {
                                      PatientTobaccoAlcoholHistoryID = xx.PatientTobaccoAlcoholHistoryID,
                                      PatientID = xx.PatientID,
                                      PatientAppointmentID = xx.PatientAppointmentID,
                                      RecordedDate = xx.RecordedDate,
                                      SmokingStatusID = xx.SmokingStatusID,
                                      DrinkingStatusID = xx.DrinkingStatusID,
                                      CigarettesPerDay = xx.CigarettesPerDay,
                                      CigarettesPerYear = xx.CigarettesPerYear,
                                      ConsumptionMLPerDay = xx.ConsumptionMLPerDay,
                                      ConsumptionMLPerYear = xx.ConsumptionMLPerYear,
                                      Notes = xx.Notes,
                                      Deleted = xx.Deleted,
                                      CreatedDate = xx.CreatedDate,
                                      CreatedBy = xx.CreatedBy,
                                      ModifiedDate = xx.ModifiedDate,
                                      ModifiedBy = xx.ModifiedBy,
                                      IsPrinted = xx.IsPrinted,
                                      SmokingStatusDescription = xx.SmokingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.SmokingStatusID).FirstOrDefault().Description : "",
                                      DrinkingStatusDescription = xx.DrinkingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.DrinkingStatusID).FirstOrDefault().Description : "",
                                  }).ToList();

            return SocaialHistory;
        }
        #endregion

        public PatientTobaccoAlcoholHistoryModel GetSocialHistoryByPatientTobaccoAlcoholHistoryID(int PatientTobaccoAlcoholHistoryID)
        {
            var SocialHistory = (from a in this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Table().Where(x => x.PatientTobaccoAlcoholHistoryID == PatientTobaccoAlcoholHistoryID)
                                 join B in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals B.PatientID
                                 select
                                 new
                                 {
                                     a.PatientTobaccoAlcoholHistoryID,
                                     a.PatientID,
                                     a.PatientAppointmentID,
                                     a.RecordedDate,
                                     a.SmokingStatusID,
                                     a.DrinkingStatusID,
                                     a.CigarettesPerDay,
                                     a.CigarettesPerYear,
                                     a.ConsumptionMLPerDay,
                                     a.ConsumptionMLPerYear,
                                     a.Notes,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.IsPrinted

                                 }).AsEnumerable().Select(xx => new PatientTobaccoAlcoholHistoryModel
                                 {
                                     PatientTobaccoAlcoholHistoryID = xx.PatientTobaccoAlcoholHistoryID,
                                     PatientID = xx.PatientID,
                                     PatientAppointmentID = xx.PatientAppointmentID,
                                     RecordedDate = xx.RecordedDate,
                                     SmokingStatusID = xx.SmokingStatusID,
                                     DrinkingStatusID = xx.DrinkingStatusID,
                                     CigarettesPerDay = xx.CigarettesPerDay,
                                     CigarettesPerYear = xx.CigarettesPerYear,
                                     ConsumptionMLPerDay = xx.ConsumptionMLPerDay,
                                     ConsumptionMLPerYear = xx.ConsumptionMLPerYear,
                                     Notes = xx.Notes,
                                     Deleted = xx.Deleted,
                                     CreatedDate = xx.CreatedDate,
                                     CreatedBy = xx.CreatedBy,
                                     ModifiedDate = xx.ModifiedDate,
                                     ModifiedBy = xx.ModifiedBy,
                                     IsPrinted = xx.IsPrinted,
                                     SmokingStatusDescription = xx.SmokingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.SmokingStatusID).FirstOrDefault().Description : "",
                                     DrinkingStatusDescription = xx.DrinkingStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.DrinkingStatusID).FirstOrDefault().Description : "",
                                 }).FirstOrDefault();

            return SocialHistory;
        }


        #region get method show on table patientfmaily inforamtion
        public List<PatientFamilyModel> GetPatientFamily()
        {
            var PatientFamily = (from a in this._uow.GenericRepository<PatientFamily>().Table().Where(x => x.Deleted != true)
                                 select
                                 new
                                 {
                                     a.PatientFamilyID,
                                     a.PatientID,
                                     a.SSN,
                                     a.RecordedDate,
                                     a.NameLast,
                                     a.NameFirst,
                                     a.NameMiddle,
                                     a.NamePrefix,
                                     a.NameSuffix,
                                     a.PatientRelationID,
                                     a.GenderID,
                                     a.BirthDate,
                                     a.MaritalStatusID,
                                     a.AddressLine1,
                                     a.AddressLine2,
                                     a.City,
                                     a.State,
                                     a.County,
                                     a.ZIP,
                                     a.Country,
                                     a.Phone,
                                     a.AlternatePhone,
                                     a.Email,
                                     a.IsEmergencyContact,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.IsGuarantor,
                                     a.IsForeign
                                 }).AsEnumerable().Select(xx => new PatientFamilyModel
                                 {
                                     PatientFamilyID = xx.PatientFamilyID,
                                     PatientID = xx.PatientID,
                                     SSN = xx.SSN,
                                     RecordedDate = xx.RecordedDate,
                                     NameLast = xx.NameLast,
                                     NameFirst = xx.NameFirst,
                                     NameMiddle = xx.NameMiddle,
                                     NamePrefix = xx.NamePrefix,
                                     NameSuffix = xx.NameSuffix,
                                     PatientRelationID = xx.PatientRelationID,
                                     GenderID = xx.GenderID,
                                     BirthDate = xx.BirthDate,
                                     Age = xx.BirthDate != null ? (DateTime.Now - xx.BirthDate.Value).Days / 365 : 0,
                                     MaritalStatusID = xx.MaritalStatusID,
                                     AddressLine1 = xx.AddressLine1,
                                     AddressLine2 = xx.AddressLine2,
                                     City = xx.City,
                                     State = xx.State,
                                     County = xx.County,
                                     ZIP = xx.ZIP,
                                     Country = xx.Country,
                                     CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                     Phone = xx.Phone,
                                     AlternatePhone = xx.AlternatePhone,
                                     Email = xx.Email,
                                     IsEmergencyContact = xx.IsEmergencyContact,
                                     Deleted = xx.Deleted,
                                     CreatedDate = xx.CreatedDate,
                                     CreatedBy = xx.CreatedBy,
                                     ModifiedDate = xx.ModifiedDate,
                                     ModifiedBy = xx.ModifiedBy,
                                     IsGuarantor = xx.IsGuarantor,
                                     IsForeign = xx.IsForeign,
                                     GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                     MaritalStatusDescription = xx.MaritalStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.MaritalStatusID).FirstOrDefault().Description : "",
                                     PatientRelationName = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                 }).ToList();
            return PatientFamily;
        }
        #endregion

        #region I have patientFamily parameter values in patientID
        public List<PatientFamilyModel> GetPatientFamilyByPatientID(int PatientID)
        {
            var PatientFamily = (from a in this._uow.GenericRepository<PatientFamily>().Table().Where(x => x.Deleted != true && x.PatientID == PatientID)
                                 join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                                 select
                                 new
                                 {
                                     a.PatientFamilyID,
                                     a.PatientID,
                                     a.SSN,
                                     a.RecordedDate,
                                     a.NameLast,
                                     a.NameFirst,
                                     a.NameMiddle,
                                     a.NamePrefix,
                                     a.NameSuffix,
                                     a.PatientRelationID,
                                     a.GenderID,
                                     a.BirthDate,
                                     a.MaritalStatusID,
                                     a.AddressLine1,
                                     a.AddressLine2,
                                     a.City,
                                     a.State,
                                     a.County,
                                     a.ZIP,
                                     a.Country,
                                     a.Phone,
                                     a.AlternatePhone,
                                     a.Email,
                                     a.IsEmergencyContact,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.IsGuarantor,
                                     a.IsForeign
                                 }).AsEnumerable().Select(xx => new PatientFamilyModel
                                 {
                                     PatientFamilyID = xx.PatientFamilyID,
                                     PatientID = xx.PatientID,
                                     SSN = xx.SSN,
                                     RecordedDate = xx.RecordedDate,
                                     NameLast = xx.NameLast,
                                     NameFirst = xx.NameFirst,
                                     NameMiddle = xx.NameMiddle,
                                     NamePrefix = xx.NamePrefix,
                                     NameSuffix = xx.NameSuffix,
                                     PatientRelationID = xx.PatientRelationID,
                                     GenderID = xx.GenderID,
                                     BirthDate = xx.BirthDate,
                                     Age = xx.BirthDate != null ? (DateTime.Now - xx.BirthDate.Value).Days / 365 : 0,
                                     MaritalStatusID = xx.MaritalStatusID,
                                     AddressLine1 = xx.AddressLine1,
                                     AddressLine2 = xx.AddressLine2,
                                     City = xx.City,
                                     State = xx.State,
                                     County = xx.County,
                                     ZIP = xx.ZIP,
                                     Country = xx.Country,
                                     CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                     Phone = xx.Phone,
                                     AlternatePhone = xx.AlternatePhone,
                                     Email = xx.Email,
                                     IsEmergencyContact = xx.IsEmergencyContact,
                                     Deleted = xx.Deleted,
                                     CreatedDate = xx.CreatedDate,
                                     CreatedBy = xx.CreatedBy,
                                     ModifiedDate = xx.ModifiedDate,
                                     ModifiedBy = xx.ModifiedBy,
                                     IsGuarantor = xx.IsGuarantor,
                                     IsForeign = xx.IsForeign,
                                     GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                     MaritalStatusDescription = xx.MaritalStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.MaritalStatusID).FirstOrDefault().Description : "",
                                     PatientRelationName = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                 }).ToList();
            return PatientFamily;
        }
        #endregion

        #region Post Method to add or Update FamilyHealthHistoryModel
        public FamilyHealthHistoryModel AddupdateFamilyHealthHistoryModel(FamilyHealthHistoryModel familyHealthHistoryModel)
        {
            var fam = this._uow.GenericRepository<FamilyHealthHistory>().Table().Where(x => x.FamilyHealthHistoryID == familyHealthHistoryModel.FamilyHealthHistoryID).FirstOrDefault();

            if (fam == null)
            {
                fam = new FamilyHealthHistory();

                fam.FamilyHealthHistoryID = familyHealthHistoryModel.FamilyHealthHistoryID;
                fam.PatientID = familyHealthHistoryModel.PatientID;
                fam.PatientRelationID = familyHealthHistoryModel.PatientRelationID;
                fam.PersonName = familyHealthHistoryModel.PersonName;
                fam.ClinicalNotes = familyHealthHistoryModel.ClinicalNotes;
                fam.RecordedDate = familyHealthHistoryModel.RecordedDate != null ? this._iMasterService.GetLocalTime(familyHealthHistoryModel.RecordedDate.Value) : null;
                fam.PatientVisitID = familyHealthHistoryModel.PatientVisitID;
                fam.Notes = familyHealthHistoryModel.Notes;
                fam.StatusCodeID = familyHealthHistoryModel.StatusCodeID;
                fam.AgeatDeath = familyHealthHistoryModel.AgeatDeath;
                fam.AgeatDiagnosis = familyHealthHistoryModel.AgeatDiagnosis;
                fam.GenderID = familyHealthHistoryModel.GenderID;
                fam.DateOfBirth = familyHealthHistoryModel.DateOfBirth;
                fam.Disease = familyHealthHistoryModel.Disease;
                fam.Living = familyHealthHistoryModel.Living;
                fam.Deleted = false;
                fam.CreatedDate = DateTime.Now;
                fam.CreatedBy = "User";

                this._uow.GenericRepository<FamilyHealthHistory>().Insert(fam);
            }

            else
            {
                //fam.PatientID = familyHealthHistoryModel.PatientID;
                fam.PatientRelationID = familyHealthHistoryModel.PatientRelationID;
                fam.PersonName = familyHealthHistoryModel.PersonName;
                fam.ClinicalNotes = familyHealthHistoryModel.ClinicalNotes;
                fam.RecordedDate = familyHealthHistoryModel.RecordedDate != null ? this._iMasterService.GetLocalTime(familyHealthHistoryModel.RecordedDate.Value) : null;
                fam.PatientVisitID = familyHealthHistoryModel.PatientVisitID;
                fam.Notes = familyHealthHistoryModel.Notes;
                fam.StatusCodeID = familyHealthHistoryModel.StatusCodeID;
                fam.AgeatDeath = familyHealthHistoryModel.AgeatDeath;
                fam.AgeatDiagnosis = familyHealthHistoryModel.AgeatDiagnosis;
                fam.GenderID = familyHealthHistoryModel.GenderID;
                fam.DateOfBirth = familyHealthHistoryModel.DateOfBirth;
                fam.Disease = familyHealthHistoryModel.Disease;
                fam.Living = familyHealthHistoryModel.Living;
                fam.Deleted = false;
                fam.ModifiedDate = DateTime.Now;
                fam.ModifiedBy = "User";

                this._uow.GenericRepository<FamilyHealthHistory>().Update(fam);
            }

            this._uow.Save();
            familyHealthHistoryModel.PatientID = fam.PatientID;

            return familyHealthHistoryModel;
        }


        #endregion

        public PatientTobaccoAlcoholHistoryModel AddupdateSocialHistory(PatientTobaccoAlcoholHistoryModel patientTobaccoAlcoholHistoryModel)
        {
            var SocialHistory = this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Table().Where(x => x.PatientTobaccoAlcoholHistoryID == patientTobaccoAlcoholHistoryModel.PatientTobaccoAlcoholHistoryID).FirstOrDefault();

            if (SocialHistory == null)
            {
                SocialHistory = new PatientTobaccoAlcoholHistory();

                SocialHistory.PatientID = patientTobaccoAlcoholHistoryModel.PatientID;
                SocialHistory.PatientAppointmentID = patientTobaccoAlcoholHistoryModel.PatientAppointmentID;
                SocialHistory.RecordedDate = this._iMasterService.GetLocalTime(patientTobaccoAlcoholHistoryModel.RecordedDate);
                SocialHistory.SmokingStatusID = patientTobaccoAlcoholHistoryModel.SmokingStatusID;
                SocialHistory.DrinkingStatusID = patientTobaccoAlcoholHistoryModel.DrinkingStatusID;
                SocialHistory.CigarettesPerDay = patientTobaccoAlcoholHistoryModel.CigarettesPerDay;
                SocialHistory.CigarettesPerYear = patientTobaccoAlcoholHistoryModel.CigarettesPerYear;
                SocialHistory.ConsumptionMLPerDay = patientTobaccoAlcoholHistoryModel.ConsumptionMLPerDay;
                SocialHistory.ConsumptionMLPerYear = patientTobaccoAlcoholHistoryModel.ConsumptionMLPerYear;
                SocialHistory.Notes = patientTobaccoAlcoholHistoryModel.Notes;
                SocialHistory.IsPrinted = patientTobaccoAlcoholHistoryModel.IsPrinted;
                SocialHistory.Deleted = false;
                SocialHistory.CreatedDate = DateTime.Now;
                SocialHistory.CreatedBy = "User";

                this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Insert(SocialHistory);
            }

            else
            {
                SocialHistory.PatientTobaccoAlcoholHistoryID = patientTobaccoAlcoholHistoryModel.PatientTobaccoAlcoholHistoryID;
                SocialHistory.PatientID = patientTobaccoAlcoholHistoryModel.PatientID;
                SocialHistory.PatientAppointmentID = patientTobaccoAlcoholHistoryModel.PatientAppointmentID;
                SocialHistory.RecordedDate = this._iMasterService.GetLocalTime(patientTobaccoAlcoholHistoryModel.RecordedDate);
                SocialHistory.SmokingStatusID = patientTobaccoAlcoholHistoryModel.SmokingStatusID;
                SocialHistory.DrinkingStatusID = patientTobaccoAlcoholHistoryModel.DrinkingStatusID;
                SocialHistory.CigarettesPerDay = patientTobaccoAlcoholHistoryModel.CigarettesPerDay;
                SocialHistory.CigarettesPerYear = patientTobaccoAlcoholHistoryModel.CigarettesPerYear;
                SocialHistory.ConsumptionMLPerDay = patientTobaccoAlcoholHistoryModel.ConsumptionMLPerDay;
                SocialHistory.ConsumptionMLPerYear = patientTobaccoAlcoholHistoryModel.ConsumptionMLPerYear;
                SocialHistory.Notes = patientTobaccoAlcoholHistoryModel.Notes;
                SocialHistory.IsPrinted = patientTobaccoAlcoholHistoryModel.IsPrinted;
                SocialHistory.Deleted = false;
                SocialHistory.ModifiedDate = DateTime.Now;
                SocialHistory.ModifiedBy = "User";

                this._uow.GenericRepository<PatientTobaccoAlcoholHistory>().Update(SocialHistory);
            }
            this._uow.Save();

            patientTobaccoAlcoholHistoryModel.PatientTobaccoAlcoholHistoryID = SocialHistory.PatientTobaccoAlcoholHistoryID;

            return patientTobaccoAlcoholHistoryModel;
        }


        #region Post Method to add or update PatientImmunizationModel
        public PatientImmunizationModel AddupdatePatientImmunizationModel(PatientImmunizationModel patientImmunizationModel)
        {
            var immun = this._uow.GenericRepository<PatientImmunization>().Table().Where(x => x.PatientImmunizationID == patientImmunizationModel.PatientImmunizationID).FirstOrDefault();

            if (immun == null)
            {
                immun = new PatientImmunization();

                immun.PatientImmunizationID = patientImmunizationModel.PatientImmunizationID;
                immun.PatientID = patientImmunizationModel.PatientID;
                immun.VaccinationID = patientImmunizationModel.VaccinationID;
                immun.ImmunizationID = patientImmunizationModel.ImmunizationID;
                immun.ImmunizedAge = patientImmunizationModel.ImmunizedAge;
                immun.Dose = patientImmunizationModel.Dose;
                immun.LotNumber = patientImmunizationModel.LotNumber;
                immun.Route = patientImmunizationModel.Route;
                immun.HumanBodySiteID = patientImmunizationModel.HumanBodySiteID;
                immun.InjectedOn = patientImmunizationModel.InjectedOn != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.InjectedOn.Value) : null;
                immun.InjectedTime = patientImmunizationModel.InjectedTime != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.InjectedTime.Value) : null;
                immun.InjectedBy = patientImmunizationModel.InjectedBy;
                immun.DoseUnits = patientImmunizationModel.DoseUnits;
                immun.ExpirationDate = patientImmunizationModel.ExpirationDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ExpirationDate.Value) : null;
                immun.ImmunizationRouteID = patientImmunizationModel.ImmunizationRouteID;
                immun.ImmunizationNotes = patientImmunizationModel.ImmunizationNotes;
                immun.PatientVisitID = patientImmunizationModel.PatientVisitID;
                immun.IsPrinted = patientImmunizationModel.IsPrinted;
                immun.ImmunizationRegistrySentStatusID = patientImmunizationModel.ImmunizationRegistryStatusID;
                immun.RecordedDate = patientImmunizationModel.RecordedDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RecordedDate.Value) : null;
                immun.ReviewedByID = patientImmunizationModel.ReviewedByID;
                immun.DiseasePresumedImmunity = patientImmunizationModel.DiseasePresumedImmunity;
                immun.RegistryStatusEffectiveDate = patientImmunizationModel.RegistryStatusEffectiveDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RegistryStatusEffectiveDate.Value) : null;
                immun.PublicityCodeID = patientImmunizationModel.PublicityCodeID;
                immun.RegistryPublicityEffectiveDate = patientImmunizationModel.RegistryPublicityEffectiveDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RegistryPublicityEffectiveDate.Value) : null;
                immun.NotesSnomedCT = patientImmunizationModel.NotesSnomedCT;
                immun.VFCFinancialClassID = patientImmunizationModel.VFCFinancialClassID;
                immun.RefusalReasonCodeID = patientImmunizationModel.RefusalReasonCodeID;
                immun.ImmunizationRegistryStatusID = patientImmunizationModel.ImmunizationRegistryStatusID;
                immun.ImmunizationInformationSourceID = patientImmunizationModel.ImmunizationInformationSourceID;
                immun.ProtectionIndicator = patientImmunizationModel.ProtectionIndicator;
                immun.ProtectionIndicatorEffective = patientImmunizationModel.ProtectionIndicatorEffective != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ProtectionIndicatorEffective.Value) : null;
                immun.InjectedByID = patientImmunizationModel.InjectedByID;
                immun.IsReminder = patientImmunizationModel.IsReminder;
                immun.RemindBeforeDays = patientImmunizationModel.RemindBeforeDays;
                immun.RemindBeforeHours = patientImmunizationModel.RemindBeforeHours;
                immun.NumberOfMessagesToSendPerPatient = patientImmunizationModel.NumberOfMessagesToSendPerPatient;
                immun.IntervalPerMessage = patientImmunizationModel.IntervalPerMessage;
                immun.IntervalBetweenMessagesTypeId = patientImmunizationModel.IntervalBetweenMessagesTypeId;
                immun.ImmunizationDate = patientImmunizationModel.ImmunizationDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ImmunizationDate.Value) : null;
                immun.Deleted = false;
                immun.CreatedDate = DateTime.Now;
                immun.CreatedBy = "User";
                immun.Product = patientImmunizationModel.Product;
                immun.Manufacturer = patientImmunizationModel.Manufacturer;

                this._uow.GenericRepository<PatientImmunization>().Insert(immun);
            }
            else
            {
                //   immun.PatientID = patientImmunizationModel.PatientID;
                immun.VaccinationID = patientImmunizationModel.VaccinationID;
                immun.ImmunizationID = patientImmunizationModel.ImmunizationID;
                immun.ImmunizedAge = patientImmunizationModel.ImmunizedAge;
                immun.Dose = patientImmunizationModel.Dose;
                immun.LotNumber = patientImmunizationModel.LotNumber;
                immun.Route = patientImmunizationModel.Route;
                immun.HumanBodySiteID = patientImmunizationModel.HumanBodySiteID;
                immun.InjectedOn = patientImmunizationModel.InjectedOn != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.InjectedOn.Value) : null;
                immun.InjectedTime = patientImmunizationModel.InjectedTime != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.InjectedTime.Value) : null;
                immun.InjectedBy = patientImmunizationModel.InjectedBy;
                immun.DoseUnits = patientImmunizationModel.DoseUnits;
                immun.ExpirationDate = patientImmunizationModel.ExpirationDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ExpirationDate.Value) : null;
                immun.ImmunizationRouteID = patientImmunizationModel.ImmunizationRouteID;
                immun.ImmunizationNotes = patientImmunizationModel.ImmunizationNotes;
                immun.PatientVisitID = patientImmunizationModel.PatientVisitID;
                immun.IsPrinted = patientImmunizationModel.IsPrinted;
                immun.ImmunizationRegistrySentStatusID = patientImmunizationModel.ImmunizationRegistryStatusID;
                immun.RecordedDate = patientImmunizationModel.RecordedDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RecordedDate.Value) : null;
                immun.ReviewedByID = patientImmunizationModel.ReviewedByID;
                immun.DiseasePresumedImmunity = patientImmunizationModel.DiseasePresumedImmunity;
                immun.RegistryStatusEffectiveDate = patientImmunizationModel.RegistryStatusEffectiveDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RegistryStatusEffectiveDate.Value) : null;
                immun.PublicityCodeID = patientImmunizationModel.PublicityCodeID;
                immun.RegistryPublicityEffectiveDate = patientImmunizationModel.RegistryPublicityEffectiveDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.RegistryPublicityEffectiveDate.Value) : null;
                immun.NotesSnomedCT = patientImmunizationModel.NotesSnomedCT;
                immun.VFCFinancialClassID = patientImmunizationModel.VFCFinancialClassID;
                immun.RefusalReasonCodeID = patientImmunizationModel.RefusalReasonCodeID;
                immun.ImmunizationRegistryStatusID = patientImmunizationModel.ImmunizationRegistryStatusID;
                immun.ImmunizationInformationSourceID = patientImmunizationModel.ImmunizationInformationSourceID;
                immun.ProtectionIndicator = patientImmunizationModel.ProtectionIndicator;
                immun.ProtectionIndicatorEffective = patientImmunizationModel.ProtectionIndicatorEffective != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ProtectionIndicatorEffective.Value) : null;
                immun.InjectedByID = patientImmunizationModel.InjectedByID;
                immun.IsReminder = patientImmunizationModel.IsReminder;
                immun.RemindBeforeDays = patientImmunizationModel.RemindBeforeDays;
                immun.RemindBeforeHours = patientImmunizationModel.RemindBeforeHours;
                immun.NumberOfMessagesToSendPerPatient = patientImmunizationModel.NumberOfMessagesToSendPerPatient;
                immun.IntervalPerMessage = patientImmunizationModel.IntervalPerMessage;
                immun.IntervalBetweenMessagesTypeId = patientImmunizationModel.IntervalBetweenMessagesTypeId;
                immun.ImmunizationDate = patientImmunizationModel.ImmunizationDate != null ? this._iMasterService.GetLocalTime(patientImmunizationModel.ImmunizationDate.Value) : null;
                immun.Deleted = false;
                immun.ModifiedDate = DateTime.Now;
                immun.ModifiedBy = "User";
                immun.Product = patientImmunizationModel.Product;
                immun.Manufacturer = patientImmunizationModel.Manufacturer;

                this._uow.GenericRepository<PatientImmunization>().Update(immun);
            }
            this._uow.Save();
            patientImmunizationModel.PatientID = immun.PatientID;

            return patientImmunizationModel;

        }

        #endregion

        #region Post Method to add or update Patient Diagnosticmodel

        public PatientDiagnosticListModel AddupdatePatientDiagnosticListModel(PatientDiagnosticListModel patientDiagnosticListModel)
        {
            var diag = this._uow.GenericRepository<PatientDiagnosticList>().Table().Where(x => x.PatientDiagnosticListID == patientDiagnosticListModel.PatientDiagnosticListID).FirstOrDefault();

            if (diag == null)
            {
                diag = new PatientDiagnosticList();

                diag.PatientID = patientDiagnosticListModel.PatientID;
                diag.RecordedDate = this._iMasterService.GetLocalTime(patientDiagnosticListModel.RecordedDate);
                diag.ICDCode1 = patientDiagnosticListModel.ICDCode1;
                diag.ICDCode2 = patientDiagnosticListModel.ICDCode2;
                diag.ICDCode3 = patientDiagnosticListModel.ICDCode3;
                diag.ICDCode4 = patientDiagnosticListModel.ICDCode4;
                diag.ICDCode5 = patientDiagnosticListModel.ICDCode5;
                diag.ICDCode6 = patientDiagnosticListModel.ICDCode6;
                diag.ICDCode7 = patientDiagnosticListModel.ICDCode7;
                diag.ICDCode8 = patientDiagnosticListModel.ICDCode8;
                diag.ICDCode9 = patientDiagnosticListModel.ICDCode9;
                diag.ICDCode10 = patientDiagnosticListModel.ICDCode10;
                diag.ICDCode11 = patientDiagnosticListModel.ICDCode11;
                diag.ICDCode12 = patientDiagnosticListModel.ICDCode12;
                diag.ServiceDate = patientDiagnosticListModel.ServiceDate;
                diag.PatientVisitID = patientDiagnosticListModel.PatientVisitID;
                diag.IsPrinted = patientDiagnosticListModel.IsPrinted;
                diag.Deleted = false;
                diag.CreatedDate = DateTime.Now;
                diag.CreatedBy = "User";

                this._uow.GenericRepository<PatientDiagnosticList>().Insert(diag);
            }

            else
            {
                //diag.PatientID = patientDiagnosticListModel.PatientID;
                diag.RecordedDate = this._iMasterService.GetLocalTime(patientDiagnosticListModel.RecordedDate);
                diag.ICDCode1 = patientDiagnosticListModel.ICDCode1;
                diag.ICDCode2 = patientDiagnosticListModel.ICDCode2;
                diag.ICDCode3 = patientDiagnosticListModel.ICDCode3;
                diag.ICDCode4 = patientDiagnosticListModel.ICDCode4;
                diag.ICDCode5 = patientDiagnosticListModel.ICDCode5;
                diag.ICDCode6 = patientDiagnosticListModel.ICDCode6;
                diag.ICDCode7 = patientDiagnosticListModel.ICDCode7;
                diag.ICDCode8 = patientDiagnosticListModel.ICDCode8;
                diag.ICDCode9 = patientDiagnosticListModel.ICDCode9;
                diag.ICDCode10 = patientDiagnosticListModel.ICDCode10;
                diag.ICDCode11 = patientDiagnosticListModel.ICDCode11;
                diag.ICDCode12 = patientDiagnosticListModel.ICDCode12;
                diag.ServiceDate = patientDiagnosticListModel.ServiceDate;
                diag.PatientVisitID = patientDiagnosticListModel.PatientVisitID;
                diag.IsPrinted = patientDiagnosticListModel.IsPrinted;
                diag.Deleted = false;
                diag.ModifiedDate = DateTime.Now;
                diag.ModifiedBy = "User";

                this._uow.GenericRepository<PatientDiagnosticList>().Update(diag);
            }

            this._uow.Save();
            patientDiagnosticListModel.PatientID = diag.PatientID;

            return patientDiagnosticListModel;

        }

        #endregion

        #region this my addupdate patientFamilyModel 
        public PatientFamilyModel AddupdatePatientFamilyModel(PatientFamilyModel patientFamilyModel)
        {
            var FamilyModel = this._uow.GenericRepository<PatientFamily>().Table().Where(x => x.PatientFamilyID == patientFamilyModel.PatientFamilyID).FirstOrDefault();

            if (FamilyModel == null)
            {
                FamilyModel = new PatientFamily();

                FamilyModel.PatientID = patientFamilyModel.PatientID;
                FamilyModel.SSN = patientFamilyModel.SSN;
                FamilyModel.RecordedDate = this._iMasterService.GetLocalTime(patientFamilyModel.RecordedDate);
                FamilyModel.NameLast = patientFamilyModel.NameLast;
                FamilyModel.NameFirst = patientFamilyModel.NameFirst;
                FamilyModel.NameMiddle = patientFamilyModel.NameMiddle;
                FamilyModel.NamePrefix = patientFamilyModel.NamePrefix;
                FamilyModel.PatientRelationID = patientFamilyModel.PatientRelationID;
                FamilyModel.GenderID = patientFamilyModel.GenderID;
                FamilyModel.BirthDate = patientFamilyModel.BirthDate != null ? this._iMasterService.GetLocalTime(patientFamilyModel.BirthDate.Value):null;
                FamilyModel.MaritalStatusID = patientFamilyModel.MaritalStatusID;
                FamilyModel.AddressLine1 = patientFamilyModel.AddressLine1;
                FamilyModel.AddressLine2 = patientFamilyModel.AddressLine2;
                FamilyModel.City = patientFamilyModel.City;
                FamilyModel.State = patientFamilyModel.State;
                FamilyModel.County = patientFamilyModel.County;
                FamilyModel.ZIP = patientFamilyModel.ZIP;
                FamilyModel.Country = patientFamilyModel.Country;
                FamilyModel.Phone = patientFamilyModel.Phone;
                FamilyModel.AlternatePhone = patientFamilyModel.AlternatePhone;
                FamilyModel.Email = patientFamilyModel.Email;
                FamilyModel.IsEmergencyContact = patientFamilyModel.IsEmergencyContact;
                FamilyModel.IsGuarantor = patientFamilyModel.IsGuarantor;
                FamilyModel.IsForeign = patientFamilyModel.IsForeign;
                FamilyModel.Deleted = false;
                FamilyModel.CreatedDate = DateTime.Now;
                FamilyModel.CreatedBy = "User";

                this._uow.GenericRepository<PatientFamily>().Insert(FamilyModel);
            }
            else
            {
                FamilyModel.PatientID = patientFamilyModel.PatientID;
                FamilyModel.SSN = patientFamilyModel.SSN;
                FamilyModel.RecordedDate = this._iMasterService.GetLocalTime(patientFamilyModel.RecordedDate);
                FamilyModel.NameLast = patientFamilyModel.NameLast;
                FamilyModel.NameFirst = patientFamilyModel.NameFirst;
                FamilyModel.NameMiddle = patientFamilyModel.NameMiddle;
                FamilyModel.NamePrefix = patientFamilyModel.NamePrefix;
                FamilyModel.PatientRelationID = patientFamilyModel.PatientRelationID;
                FamilyModel.GenderID = patientFamilyModel.GenderID;
                FamilyModel.BirthDate = patientFamilyModel.BirthDate != null ? this._iMasterService.GetLocalTime(patientFamilyModel.BirthDate.Value) : null;
                FamilyModel.MaritalStatusID = patientFamilyModel.MaritalStatusID;
                FamilyModel.AddressLine1 = patientFamilyModel.AddressLine1;
                FamilyModel.AddressLine2 = patientFamilyModel.AddressLine2;
                FamilyModel.City = patientFamilyModel.City;
                FamilyModel.State = patientFamilyModel.State;
                FamilyModel.County = patientFamilyModel.County;
                FamilyModel.ZIP = patientFamilyModel.ZIP;
                FamilyModel.Country = patientFamilyModel.Country;
                FamilyModel.Phone = patientFamilyModel.Phone;
                FamilyModel.AlternatePhone = patientFamilyModel.AlternatePhone;
                FamilyModel.Email = patientFamilyModel.Email;
                FamilyModel.IsEmergencyContact = patientFamilyModel.IsEmergencyContact;
                FamilyModel.IsGuarantor = patientFamilyModel.IsGuarantor;
                FamilyModel.IsForeign = patientFamilyModel.IsForeign;
                FamilyModel.Deleted = false;
                FamilyModel.ModifiedDate = DateTime.Now;
                FamilyModel.ModifiedBy = "User";

                this._uow.GenericRepository<PatientFamily>().Update(FamilyModel);
            }
            this._uow.Save();
            patientFamilyModel.PatientFamilyID = FamilyModel.PatientFamilyID;

            return patientFamilyModel;
        }
        #endregion
      
        #region GetPatientFamilyByPatientFamilyID
        public PatientFamilyModel GetPatientFamilyByPatientFamilyID(int PatientFamilyID)
        {
            var PatientFamily = (from a in this._uow.GenericRepository<PatientFamily>().Table().Where(x => x.Deleted != true && x.PatientFamilyID == PatientFamilyID)
                                 join b in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals b.PatientID
                                 select
                                 new
                                 {
                                     a.PatientFamilyID,
                                     a.PatientID,
                                     a.SSN,
                                     a.RecordedDate,
                                     a.NameLast,
                                     a.NameFirst,
                                     a.NameMiddle,
                                     a.NamePrefix,
                                     a.NameSuffix,
                                     a.PatientRelationID,
                                     a.GenderID,
                                     a.BirthDate,
                                     a.MaritalStatusID,
                                     a.AddressLine1,
                                     a.AddressLine2,
                                     a.City,
                                     a.State,
                                     a.County,
                                     a.ZIP,
                                     a.Country,
                                     a.Phone,
                                     a.AlternatePhone,
                                     a.Email,
                                     a.IsEmergencyContact,
                                     a.Deleted,
                                     a.CreatedDate,
                                     a.CreatedBy,
                                     a.ModifiedDate,
                                     a.ModifiedBy,
                                     a.IsGuarantor,
                                     a.IsForeign
                                 }).AsEnumerable().Select(xx => new PatientFamilyModel
                                 {
                                     PatientFamilyID = xx.PatientFamilyID,
                                     PatientID = xx.PatientID,
                                     SSN = xx.SSN,
                                     RecordedDate = xx.RecordedDate,
                                     NameLast = xx.NameLast,
                                     NameFirst = xx.NameFirst,
                                     NameMiddle = xx.NameMiddle,
                                     NamePrefix = xx.NamePrefix,
                                     NameSuffix = xx.NameSuffix,
                                     PatientRelationID = xx.PatientRelationID,
                                     GenderID = xx.GenderID,
                                     BirthDate = xx.BirthDate,
                                     Age = xx.BirthDate != null ? (DateTime.Now - xx.BirthDate.Value).Days/365 : 0,
                                     MaritalStatusID = xx.MaritalStatusID,
                                     AddressLine1 = xx.AddressLine1,
                                     AddressLine2 = xx.AddressLine2,
                                     City = xx.City,
                                     State = xx.State,
                                     County = xx.County,
                                     ZIP = xx.ZIP,
                                     Country = xx.Country,
                                     CountryName = (xx.Country != null && xx.Country != "") ?
                                                    this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code.ToLower().Trim() == xx.Country.ToLower().Trim()).FirstOrDefault().CountryName : "",
                                     Phone = xx.Phone,
                                     AlternatePhone = xx.AlternatePhone,
                                     Email = xx.Email,
                                     IsEmergencyContact = xx.IsEmergencyContact,
                                     Deleted = xx.Deleted,
                                     CreatedDate = xx.CreatedDate,
                                     CreatedBy = xx.CreatedBy,
                                     ModifiedDate = xx.ModifiedDate,
                                     ModifiedBy = xx.ModifiedBy,
                                     IsGuarantor = xx.IsGuarantor,
                                     IsForeign = xx.IsForeign,
                                     GenderDescription = xx.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.GenderID).FirstOrDefault().Description : "",
                                     MaritalStatusDescription = xx.MaritalStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == xx.MaritalStatusID).FirstOrDefault().Description : "",
                                     PatientRelationName = xx.PatientRelationID > 0 ? this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.PatientRelationID == xx.PatientRelationID).FirstOrDefault().RelationDescription : "",
                                 }).FirstOrDefault();
            return PatientFamily;
        }
        #endregion


        #region PatientROS
        public PatientROSModel AddUpdateROSRecord(PatientROSModel rosModel)
        {
            PatientROS ros = this._uow.GenericRepository<PatientROS>().Table().Where(x => x.PatientROSID == rosModel.PatientROSID).FirstOrDefault();

            if (ros == null)
            {
                ros = new PatientROS();

                ros.PatientID = rosModel.PatientID;
                ros.RecordedDate = this._iMasterService.GetLocalTime(rosModel.RecordedDate);
                ros.Sex = rosModel.Sex;
                ros.ConstitutionalNegative = rosModel.ConstitutionalNegative;
                ros.ConstitutionalWeightloss = rosModel.ConstitutionalWeightloss;
                ros.ConstitutionalWeightgain = rosModel.ConstitutionalWeightgain;
                ros.ConstitutionalFever = rosModel.ConstitutionalFever;
                ros.ConstitutionalNightsweats = rosModel.ConstitutionalNightsweats;
                ros.ConstitutionalFatigue = rosModel.ConstitutionalFatigue;
                ros.ENTNegative = rosModel.ENTNegative;
                ros.ENTUlcers = rosModel.ENTUlcers;
                ros.ENTSinus = rosModel.ENTSinus;
                ros.ENTHeadache = rosModel.ENTHeadache;
                ros.ENTHearingLoss = rosModel.ENTHearingLoss;
                ros.ENTFatigue = rosModel.ENTFatigue;
                ros.RespiratoryNegative = rosModel.RespiratoryNegative;
                ros.RespiratoryWheezing = rosModel.RespiratoryWheezing;
                ros.RespiratoryHemoptysis = rosModel.RespiratoryHemoptysis;
                ros.RespiratoryCough = rosModel.RespiratoryCough;
                ros.RespiratoryShortnessofBreath = rosModel.RespiratoryShortnessofBreath;
                ros.GenitourinaryNegative = rosModel.GenitourinaryNegative;
                ros.GenitourinaryUrgency = rosModel.GenitourinaryUrgency;
                ros.GenitourinaryDysuria = rosModel.GenitourinaryDysuria;
                ros.GenitourinaryPolyuria = rosModel.GenitourinaryPolyuria;
                ros.GenitourinaryFrequentUrination = rosModel.GenitourinaryFrequentUrination;
                ros.SkinNegative = rosModel.SkinNegative;
                ros.SkinRash = rosModel.SkinRash;
                ros.SkinUlcers = rosModel.SkinUlcers;
                ros.SkinDrySkin = rosModel.SkinDrySkin;
                ros.SkinPigmentedLesions = rosModel.SkinPigmentedLesions;
                ros.PsychiatricNegative = rosModel.PsychiatricNegative;
                ros.PsychiatricDepression = rosModel.PsychiatricDepression;
                ros.PsychiatricAnxiety = rosModel.PsychiatricAnxiety;
                ros.PsychiatricCrying = rosModel.PsychiatricCrying;
                ros.PsychiatricHighStress = rosModel.PsychiatricHighStress;
                ros.PsychiatricSuicidalIdeation = rosModel.PsychiatricSuicidalIdeation;
                ros.HematologicNegative = rosModel.HematologicNegative;
                ros.HematologicBleeds = rosModel.HematologicBleeds;
                ros.HematologicBruises = rosModel.HematologicBruises;
                ros.HematologicLymphedema = rosModel.HematologicLymphedema;
                ros.HematologicAdenopathys = rosModel.HematologicAdenopathys;
                ros.HematologicIssueswithBloodclots = rosModel.HematologicIssueswithBloodclots;
                ros.EyesNegative = rosModel.EyesNegative;
                ros.EyesVisionChange = rosModel.EyesVisionChange;
                ros.EyesGlassesorContacts = rosModel.EyesGlassesorContacts;
                ros.CardiovascularNegative = rosModel.CardiovascularNegative;
                ros.CardiovascularOrthopnea = rosModel.CardiovascularOrthopnea;
                ros.CardiovascularChestPain = rosModel.CardiovascularChestPain;
                ros.CardiovascularEdema = rosModel.CardiovascularEdema;
                ros.CardiovascularPalpitation = rosModel.CardiovascularPalpitation;
                ros.CardiovascularClaudication = rosModel.CardiovascularClaudication;
                ros.GastrointestinalNegative = rosModel.GastrointestinalNegative;
                ros.GastrointestinalDiarrhea = rosModel.GastrointestinalDiarrhea;
                ros.GastrointestinalAbdominalPain = rosModel.GastrointestinalAbdominalPain;
                ros.GastrointestinalHeartBurn = rosModel.GastrointestinalHeartBurn;
                ros.GastrointestinalBloodyStool = rosModel.GastrointestinalBloodyStool;
                ros.GastrointestinalConstipation = rosModel.GastrointestinalConstipation;
                ros.MusculoSkeletelNegative = rosModel.MusculoSkeletalNegative;
                ros.MusculoSkeletelBackPain = rosModel.MusculoSkeletalBackPain;
                ros.MusculoSkeletelJointPain = rosModel.MusculoSkeletalJointPain;
                ros.MusculoSkeletelNeckPain = rosModel.MusculoSkeletalNeckPain;
                ros.MusculoSkeletelMuscleWeakness = rosModel.MusculoSkeletalMuscleWeakness;
                ros.NeurologicNegative = rosModel.NeurologicNegative;
                ros.NeurologicSyncope = rosModel.NeurologicSyncope;
                ros.NeurologicDizziness = rosModel.NeurologicDizziness;
                ros.NeurologicNumbness = rosModel.NeurologicNumbness;
                ros.NeurologicHeadaches = rosModel.NeurologicHeadaches;
                ros.NeurologicSevereMemoryProblems = rosModel.NeurologicSevereMemoryProblems;
                ros.EndocrinologyNegative = rosModel.EndocrinologyNegative;
                ros.EndocrinologyDiabetes = rosModel.EndocrinologyDiabetes;
                ros.EndocrinologyHypoThyroid = rosModel.EndocrinologyHypoThyroid;
                ros.EndocrinologyHyperThyroid = rosModel.EndocrinologyHyperThyroid;
                ros.EndocrinologyHairLoss = rosModel.EndocrinologyHairLoss;
                ros.EndocrinologyHeatorColdIntolerance = rosModel.EndocrinologyHeatorColdIntolerance;
                ros.ImmunologicNegative = rosModel.ImmunologicNegative;
                ros.ImmunologicFoodAllergies = rosModel.ImmunologicFoodAllergies;
                ros.ImmunologicSeasonalAllergies = rosModel.ImmunologicSeasonalAllergies;
                ros.Notes = rosModel.Notes;
                ros.Deleted = false;
                ros.CreatedDate = DateTime.Now;
                ros.CreatedBy = "User";

                this._uow.GenericRepository<PatientROS>().Insert(ros);
            }
            else
            {
                ros.RecordedDate = this._iMasterService.GetLocalTime(rosModel.RecordedDate);
                ros.Sex = rosModel.Sex;
                ros.ConstitutionalNegative = rosModel.ConstitutionalNegative;
                ros.ConstitutionalWeightloss = rosModel.ConstitutionalWeightloss;
                ros.ConstitutionalWeightgain = rosModel.ConstitutionalWeightgain;
                ros.ConstitutionalFever = rosModel.ConstitutionalFever;
                ros.ConstitutionalNightsweats = rosModel.ConstitutionalNightsweats;
                ros.ConstitutionalFatigue = rosModel.ConstitutionalFatigue;
                ros.ENTNegative = rosModel.ENTNegative;
                ros.ENTUlcers = rosModel.ENTUlcers;
                ros.ENTSinus = rosModel.ENTSinus;
                ros.ENTHeadache = rosModel.ENTHeadache;
                ros.ENTHearingLoss = rosModel.ENTHearingLoss;
                ros.ENTFatigue = rosModel.ENTFatigue;
                ros.RespiratoryNegative = rosModel.RespiratoryNegative;
                ros.RespiratoryWheezing = rosModel.RespiratoryWheezing;
                ros.RespiratoryHemoptysis = rosModel.RespiratoryHemoptysis;
                ros.RespiratoryCough = rosModel.RespiratoryCough;
                ros.RespiratoryShortnessofBreath = rosModel.RespiratoryShortnessofBreath;
                ros.GenitourinaryNegative = rosModel.GenitourinaryNegative;
                ros.GenitourinaryUrgency = rosModel.GenitourinaryUrgency;
                ros.GenitourinaryDysuria = rosModel.GenitourinaryDysuria;
                ros.GenitourinaryPolyuria = rosModel.GenitourinaryPolyuria;
                ros.GenitourinaryFrequentUrination = rosModel.GenitourinaryFrequentUrination;
                ros.SkinNegative = rosModel.SkinNegative;
                ros.SkinRash = rosModel.SkinRash;
                ros.SkinUlcers = rosModel.SkinUlcers;
                ros.SkinDrySkin = rosModel.SkinDrySkin;
                ros.SkinPigmentedLesions = rosModel.SkinPigmentedLesions;
                ros.PsychiatricNegative = rosModel.PsychiatricNegative;
                ros.PsychiatricDepression = rosModel.PsychiatricDepression;
                ros.PsychiatricAnxiety = rosModel.PsychiatricAnxiety;
                ros.PsychiatricCrying = rosModel.PsychiatricCrying;
                ros.PsychiatricHighStress = rosModel.PsychiatricHighStress;
                ros.PsychiatricSuicidalIdeation = rosModel.PsychiatricSuicidalIdeation;
                ros.HematologicNegative = rosModel.HematologicNegative;
                ros.HematologicBleeds = rosModel.HematologicBleeds;
                ros.HematologicBruises = rosModel.HematologicBruises;
                ros.HematologicLymphedema = rosModel.HematologicLymphedema;
                ros.HematologicAdenopathys = rosModel.HematologicAdenopathys;
                ros.HematologicIssueswithBloodclots = rosModel.HematologicIssueswithBloodclots;
                ros.EyesNegative = rosModel.EyesNegative;
                ros.EyesVisionChange = rosModel.EyesVisionChange;
                ros.EyesGlassesorContacts = rosModel.EyesGlassesorContacts;
                ros.CardiovascularNegative = rosModel.CardiovascularNegative;
                ros.CardiovascularOrthopnea = rosModel.CardiovascularOrthopnea;
                ros.CardiovascularChestPain = rosModel.CardiovascularChestPain;
                ros.CardiovascularEdema = rosModel.CardiovascularEdema;
                ros.CardiovascularPalpitation = rosModel.CardiovascularPalpitation;
                ros.CardiovascularClaudication = rosModel.CardiovascularClaudication;
                ros.GastrointestinalNegative = rosModel.GastrointestinalNegative;
                ros.GastrointestinalDiarrhea = rosModel.GastrointestinalDiarrhea;
                ros.GastrointestinalAbdominalPain = rosModel.GastrointestinalAbdominalPain;
                ros.GastrointestinalHeartBurn = rosModel.GastrointestinalHeartBurn;
                ros.GastrointestinalBloodyStool = rosModel.GastrointestinalBloodyStool;
                ros.GastrointestinalConstipation = rosModel.GastrointestinalConstipation;
                ros.MusculoSkeletelNegative = rosModel.MusculoSkeletalNegative;
                ros.MusculoSkeletelBackPain = rosModel.MusculoSkeletalBackPain;
                ros.MusculoSkeletelJointPain = rosModel.MusculoSkeletalJointPain;
                ros.MusculoSkeletelNeckPain = rosModel.MusculoSkeletalNeckPain;
                ros.MusculoSkeletelMuscleWeakness = rosModel.MusculoSkeletalMuscleWeakness;
                ros.NeurologicNegative = rosModel.NeurologicNegative;
                ros.NeurologicSyncope = rosModel.NeurologicSyncope;
                ros.NeurologicDizziness = rosModel.NeurologicDizziness;
                ros.NeurologicNumbness = rosModel.NeurologicNumbness;
                ros.NeurologicHeadaches = rosModel.NeurologicHeadaches;
                ros.NeurologicSevereMemoryProblems = rosModel.NeurologicSevereMemoryProblems;
                ros.EndocrinologyNegative = rosModel.EndocrinologyNegative;
                ros.EndocrinologyDiabetes = rosModel.EndocrinologyDiabetes;
                ros.EndocrinologyHypoThyroid = rosModel.EndocrinologyHypoThyroid;
                ros.EndocrinologyHyperThyroid = rosModel.EndocrinologyHyperThyroid;
                ros.EndocrinologyHairLoss = rosModel.EndocrinologyHairLoss;
                ros.EndocrinologyHeatorColdIntolerance = rosModel.EndocrinologyHeatorColdIntolerance;
                ros.ImmunologicNegative = rosModel.ImmunologicNegative;
                ros.ImmunologicFoodAllergies = rosModel.ImmunologicFoodAllergies;
                ros.ImmunologicSeasonalAllergies = rosModel.ImmunologicSeasonalAllergies;
                ros.Notes = rosModel.Notes;
                ros.Deleted = false;
                ros.ModifiedDate = DateTime.Now;
                ros.ModifiedBy = "User";

                this._uow.GenericRepository<PatientROS>().Update(ros);
            }
            this._uow.Save();
            rosModel.PatientROSID = ros.PatientROSID;

            return rosModel;
        }

        public List<PatientROSModel> GetROSDetailsbyPatientID(int patientID)
        {
            List<PatientROSModel> rosDetails = (from ros in this._uow.GenericRepository<PatientROS>().Table().Where(x => x.Deleted != true & x.PatientID == patientID)
                                                join pat in this._uow.GenericRepository<Patient>().Table() on ros.PatientID equals pat.PatientID
                                                select new
                                                {
                                                    ros.PatientROSID,
                                                    ros.PatientID,
                                                    ros.RecordedDate,
                                                    ros.Sex,
                                                    ros.Notes,
                                                    ros.ConstitutionalNegative,
                                                    ros.ConstitutionalWeightloss,
                                                    ros.ConstitutionalWeightgain,
                                                    ros.ConstitutionalFever,
                                                    ros.ConstitutionalNightsweats,
                                                    ros.ConstitutionalFatigue,
                                                    ros.ENTNegative,
                                                    ros.ENTUlcers,
                                                    ros.ENTSinus,
                                                    ros.ENTHeadache,
                                                    ros.ENTHearingLoss,
                                                    ros.ENTFatigue,
                                                    ros.RespiratoryNegative,
                                                    ros.RespiratoryWheezing,
                                                    ros.RespiratoryHemoptysis,
                                                    ros.RespiratoryCough,
                                                    ros.RespiratoryShortnessofBreath,
                                                    ros.GenitourinaryNegative,
                                                    ros.GenitourinaryUrgency,
                                                    ros.GenitourinaryDysuria,
                                                    ros.GenitourinaryPolyuria,
                                                    ros.GenitourinaryFrequentUrination,
                                                    ros.SkinNegative,
                                                    ros.SkinRash,
                                                    ros.SkinUlcers,
                                                    ros.SkinDrySkin,
                                                    ros.SkinPigmentedLesions,
                                                    ros.PsychiatricNegative,
                                                    ros.PsychiatricDepression,
                                                    ros.PsychiatricAnxiety,
                                                    ros.PsychiatricCrying,
                                                    ros.PsychiatricHighStress,
                                                    ros.PsychiatricSuicidalIdeation,
                                                    ros.HematologicNegative,
                                                    ros.HematologicBleeds,
                                                    ros.HematologicBruises,
                                                    ros.HematologicLymphedema,
                                                    ros.HematologicAdenopathys,
                                                    ros.HematologicIssueswithBloodclots,
                                                    ros.EyesNegative,
                                                    ros.EyesVisionChange,
                                                    ros.EyesGlassesorContacts,
                                                    ros.CardiovascularNegative,
                                                    ros.CardiovascularOrthopnea,
                                                    ros.CardiovascularChestPain,
                                                    ros.CardiovascularEdema,
                                                    ros.CardiovascularPalpitation,
                                                    ros.CardiovascularClaudication,
                                                    ros.GastrointestinalNegative,
                                                    ros.GastrointestinalDiarrhea,
                                                    ros.GastrointestinalAbdominalPain,
                                                    ros.GastrointestinalHeartBurn,
                                                    ros.GastrointestinalBloodyStool,
                                                    ros.GastrointestinalConstipation,
                                                    ros.MusculoSkeletelNegative,
                                                    ros.MusculoSkeletelBackPain,
                                                    ros.MusculoSkeletelJointPain,
                                                    ros.MusculoSkeletelNeckPain,
                                                    ros.MusculoSkeletelMuscleWeakness,
                                                    ros.NeurologicNegative,
                                                    ros.NeurologicSyncope,
                                                    ros.NeurologicDizziness,
                                                    ros.NeurologicNumbness,
                                                    ros.NeurologicHeadaches,
                                                    ros.NeurologicSevereMemoryProblems,
                                                    ros.EndocrinologyNegative,
                                                    ros.EndocrinologyDiabetes,
                                                    ros.EndocrinologyHypoThyroid,
                                                    ros.EndocrinologyHyperThyroid,
                                                    ros.EndocrinologyHairLoss,
                                                    ros.EndocrinologyHeatorColdIntolerance,
                                                    ros.ImmunologicNegative,
                                                    ros.ImmunologicFoodAllergies,
                                                    ros.ImmunologicSeasonalAllergies

                                                }).AsEnumerable().Select(PRM => new PatientROSModel
                                                {
                                                    PatientROSID = PRM.PatientROSID,
                                                    PatientID = PRM.PatientID,
                                                    RecordedDate = PRM.RecordedDate,
                                                    GenderDescription = PRM.Sex != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Description.ToLower().Trim() == PRM.Sex.ToLower().Trim()).FirstOrDefault().Description : "",
                                                    Notes = PRM.Notes,
                                                    ConstitutionalNegative = PRM.ConstitutionalNegative,
                                                    ConstitutionalWeightloss = PRM.ConstitutionalWeightloss,
                                                    ConstitutionalWeightgain = PRM.ConstitutionalWeightgain,
                                                    ConstitutionalFever = PRM.ConstitutionalFever,
                                                    ConstitutionalNightsweats = PRM.ConstitutionalNightsweats,
                                                    ConstitutionalFatigue = PRM.ConstitutionalFatigue,
                                                    ENTNegative = PRM.ENTNegative,
                                                    ENTUlcers = PRM.ENTUlcers,
                                                    ENTSinus = PRM.ENTSinus,
                                                    ENTHeadache = PRM.ENTHeadache,
                                                    ENTHearingLoss = PRM.ENTHearingLoss,
                                                    ENTFatigue = PRM.ENTFatigue,
                                                    RespiratoryNegative = PRM.RespiratoryNegative,
                                                    RespiratoryWheezing = PRM.RespiratoryWheezing,
                                                    RespiratoryHemoptysis = PRM.RespiratoryHemoptysis,
                                                    RespiratoryCough = PRM.RespiratoryCough,
                                                    RespiratoryShortnessofBreath = PRM.RespiratoryShortnessofBreath,
                                                    GenitourinaryNegative = PRM.GenitourinaryNegative,
                                                    GenitourinaryUrgency = PRM.GenitourinaryUrgency,
                                                    GenitourinaryDysuria = PRM.GenitourinaryDysuria,
                                                    GenitourinaryPolyuria = PRM.GenitourinaryPolyuria,
                                                    GenitourinaryFrequentUrination = PRM.GenitourinaryFrequentUrination,
                                                    SkinNegative = PRM.SkinNegative,
                                                    SkinRash = PRM.SkinRash,
                                                    SkinUlcers = PRM.SkinUlcers,
                                                    SkinDrySkin = PRM.SkinDrySkin,
                                                    SkinPigmentedLesions = PRM.SkinPigmentedLesions,
                                                    PsychiatricNegative = PRM.PsychiatricNegative,
                                                    PsychiatricDepression = PRM.PsychiatricDepression,
                                                    PsychiatricAnxiety = PRM.PsychiatricAnxiety,
                                                    PsychiatricCrying = PRM.PsychiatricCrying,
                                                    PsychiatricHighStress = PRM.PsychiatricHighStress,
                                                    PsychiatricSuicidalIdeation = PRM.PsychiatricSuicidalIdeation,
                                                    HematologicNegative = PRM.HematologicNegative,
                                                    HematologicBleeds = PRM.HematologicBleeds,
                                                    HematologicBruises = PRM.HematologicBruises,
                                                    HematologicLymphedema = PRM.HematologicLymphedema,
                                                    HematologicAdenopathys = PRM.HematologicAdenopathys,
                                                    HematologicIssueswithBloodclots = PRM.HematologicIssueswithBloodclots,
                                                    EyesNegative = PRM.EyesNegative,
                                                    EyesVisionChange = PRM.EyesVisionChange,
                                                    EyesGlassesorContacts = PRM.EyesGlassesorContacts,
                                                    CardiovascularNegative = PRM.CardiovascularNegative,
                                                    CardiovascularOrthopnea = PRM.CardiovascularOrthopnea,
                                                    CardiovascularChestPain = PRM.CardiovascularChestPain,
                                                    CardiovascularEdema = PRM.CardiovascularEdema,
                                                    CardiovascularPalpitation = PRM.CardiovascularPalpitation,
                                                    CardiovascularClaudication = PRM.CardiovascularClaudication,
                                                    GastrointestinalNegative = PRM.GastrointestinalNegative,
                                                    GastrointestinalDiarrhea = PRM.GastrointestinalDiarrhea,
                                                    GastrointestinalAbdominalPain = PRM.GastrointestinalAbdominalPain,
                                                    GastrointestinalHeartBurn = PRM.GastrointestinalHeartBurn,
                                                    GastrointestinalBloodyStool = PRM.GastrointestinalBloodyStool,
                                                    GastrointestinalConstipation = PRM.GastrointestinalConstipation,
                                                    MusculoSkeletalNegative = PRM.MusculoSkeletelNegative,
                                                    MusculoSkeletalBackPain = PRM.MusculoSkeletelBackPain,
                                                    MusculoSkeletalJointPain = PRM.MusculoSkeletelJointPain,
                                                    MusculoSkeletalNeckPain = PRM.MusculoSkeletelNeckPain,
                                                    MusculoSkeletalMuscleWeakness = PRM.MusculoSkeletelMuscleWeakness,
                                                    NeurologicNegative = PRM.NeurologicNegative,
                                                    NeurologicSyncope = PRM.NeurologicSyncope,
                                                    NeurologicDizziness = PRM.NeurologicDizziness,
                                                    NeurologicNumbness = PRM.NeurologicNumbness,
                                                    NeurologicHeadaches = PRM.NeurologicHeadaches,
                                                    NeurologicSevereMemoryProblems = PRM.NeurologicSevereMemoryProblems,
                                                    EndocrinologyNegative = PRM.EndocrinologyNegative,
                                                    EndocrinologyDiabetes = PRM.EndocrinologyDiabetes,
                                                    EndocrinologyHypoThyroid = PRM.EndocrinologyHypoThyroid,
                                                    EndocrinologyHyperThyroid = PRM.EndocrinologyHyperThyroid,
                                                    EndocrinologyHairLoss = PRM.EndocrinologyHairLoss,
                                                    EndocrinologyHeatorColdIntolerance = PRM.EndocrinologyHeatorColdIntolerance,
                                                    ImmunologicNegative = PRM.ImmunologicNegative,
                                                    ImmunologicFoodAllergies = PRM.ImmunologicFoodAllergies,
                                                    ImmunologicSeasonalAllergies = PRM.ImmunologicSeasonalAllergies

                                                }).ToList();

            List<PatientROSModel> rosModels = new List<PatientROSModel>();

            if (rosDetails.Count() > 0)
            {
                foreach (var mod in rosDetails)
                {
                    PatientROSModel model = new PatientROSModel();

                    model = mod;
                    model.ConstitutionalValue = this.GetConstitutionalstringValue(mod);
                    model.ENTValue = this.GetENTstringValue(mod);
                    model.RespiratoryValue = this.GetRespiratorystringValue(mod);
                    model.GenitourinaryValue = this.GetGenitourinarystringValue(mod);
                    model.SkinValue = this.GetSkinstringValue(mod);
                    model.psychiatricValue = this.GetPsychiatricstringValue(mod);
                    model.hematologicValue = this.GetHematologicstringValue(mod);
                    model.EyesValue = this.GetEyesstringValue(mod);
                    model.CardiovascularValue = this.GetCardiovascularstringValue(mod);
                    model.GastrointestinalValue = this.GetGastrointestinalstringValue(mod);
                    model.MusculoskeletalValue = this.GetMusculoskeletalstringValue(mod);
                    model.NeurologicValue = this.GetNeurologicstringValue(mod);
                    model.EndocrinologyValue = this.GetEndocrinologystringValue(mod);
                    model.ImmunologicValue = this.GetImmunologictringValue(mod);
                    

                    rosModels.Add(model);
                }
            }

            return rosModels;


        }


        public string GetConstitutionalstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.ConstitutionalNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.ConstitutionalWeightloss == true)
            {
                collectValue = collectValue == "" ? "WeightLoss" : (collectValue + ", WeightLoss");
            }
            if (rosModel.ConstitutionalWeightgain == true)
            {
                collectValue = collectValue == "" ? "WeightGain" : (collectValue + ", WeightGain");
            }
            if (rosModel.ConstitutionalFever == true)
            {
                collectValue = collectValue == "" ? "Fever" : (collectValue + ", Fever");
            }
            if (rosModel.ConstitutionalNightsweats == true)
            {
                collectValue = collectValue == "" ? "Nightsweats" : (collectValue + ", Nightsweats");
            }
            if (rosModel.ConstitutionalFatigue == true)
            {
                collectValue = collectValue == "" ? "Fatigue" : (collectValue + ", Fatigue");
            }

            return collectValue;
        }
        public string GetENTstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.ENTNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.ENTUlcers == true)
            {
                collectValue = collectValue == "" ? "Ulcers" : (collectValue + ", Ulcers");
            }
            if (rosModel.ENTSinus == true)
            {
                collectValue = collectValue == "" ? "Sinus" : (collectValue + ", Sinus");
            }
            if (rosModel.ENTHeadache == true)
            {
                collectValue = collectValue == "" ? "Headache" : (collectValue + ", Headache");
            }
            if (rosModel.ENTHearingLoss == true)
            {
                collectValue = collectValue == "" ? "HearingLoss" : (collectValue + ", HearingLoss");
            }
            if (rosModel.ENTFatigue == true)
            {
                collectValue = collectValue == "" ? "Fatigue" : (collectValue + ", Fatigue");
            }

            return collectValue;
        }
        public string GetRespiratorystringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.RespiratoryNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.RespiratoryWheezing == true)
            {
                collectValue = collectValue == "" ? "Wheezing" : (collectValue + ", Wheezing");
            }
            if (rosModel.RespiratoryHemoptysis == true)
            {
                collectValue = collectValue == "" ? "Hemoptysis" : (collectValue + ", Hemoptysis");
            }
            if (rosModel.RespiratoryCough == true)
            {
                collectValue = collectValue == "" ? "Cough" : (collectValue + ", Cough");
            }
            if (rosModel.RespiratoryShortnessofBreath == true)
            {
                collectValue = collectValue == "" ? "ShortnessofBreath" : (collectValue + ", ShortnessofBreath");
            }


            return collectValue;
        }
        public string GetGenitourinarystringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.GenitourinaryNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.GenitourinaryUrgency == true)
            {
                collectValue = collectValue == "" ? "Urgency" : (collectValue + ", Urgency");
            }
            if (rosModel.GenitourinaryDysuria == true)
            {
                collectValue = collectValue == "" ? "Dysuria" : (collectValue + ", Dysuria");
            }
            if (rosModel.GenitourinaryPolyuria == true)
            {
                collectValue = collectValue == "" ? "Polyuria" : (collectValue + ", Polyuria");
            }
            if (rosModel.GenitourinaryFrequentUrination == true)
            {
                collectValue = collectValue == "" ? "FrequentUrination" : (collectValue + ", FrequentUrination");
            }


            return collectValue;
        }
        public string GetSkinstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.SkinNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.SkinRash == true)
            {
                collectValue = collectValue == "" ? "Rash" : (collectValue + ", Rash");
            }
            if (rosModel.SkinUlcers == true)
            {
                collectValue = collectValue == "" ? "Ulcers" : (collectValue + ", Ulcers");
            }
            if (rosModel.SkinDrySkin == true)
            {
                collectValue = collectValue == "" ? "DrySkin" : (collectValue + ", DrySkin");
            }
            if (rosModel.SkinPigmentedLesions == true)
            {
                collectValue = collectValue == "" ? "PigmentedLesions" : (collectValue + ", PigmentedLesions");
            }


            return collectValue;
        }
        public string GetPsychiatricstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.PsychiatricNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.PsychiatricDepression == true)
            {
                collectValue = collectValue == "" ? "Depression" : (collectValue + ", Depression");
            }
            if (rosModel.PsychiatricAnxiety == true)
            {
                collectValue = collectValue == "" ? "Anxiety" : (collectValue + ", Anxiety");
            }
            if (rosModel.PsychiatricCrying == true)
            {
                collectValue = collectValue == "" ? "Crying" : (collectValue + ", Crying");
            }
            if (rosModel.PsychiatricHighStress == true)
            {
                collectValue = collectValue == "" ? "HighStress" : (collectValue + ", HighStress");
            }
            if (rosModel.PsychiatricSuicidalIdeation == true)
            {
                collectValue = collectValue == "" ? "SuicidalIdeation" : (collectValue + ", SuicidalIdeation");
            }

            return collectValue;
        }
        public string GetHematologicstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.HematologicNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.HematologicBleeds == true)
            {
                collectValue = collectValue == "" ? "Bleeds" : (collectValue + ", Bleeds");
            }
            if (rosModel.HematologicBruises == true)
            {
                collectValue = collectValue == "" ? "Bruises" : (collectValue + ", Bruises");
            }
            if (rosModel.HematologicLymphedema == true)
            {
                collectValue = collectValue == "" ? "Lymphedema" : (collectValue + ", Lymphedema");
            }
            if (rosModel.HematologicAdenopathys == true)
            {
                collectValue = collectValue == "" ? "Adenopathys" : (collectValue + ", Adenopathys");
            }
            if (rosModel.HematologicIssueswithBloodclots == true)
            {
                collectValue = collectValue == "" ? "IssueswithBloodclots" : (collectValue + ", IssueswithBloodclots");
            }

            return collectValue;
        }
        public string GetEyesstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.EyesNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.EyesVisionChange == true)
            {
                collectValue = collectValue == "" ? "VisionChange" : (collectValue + ", VisionChange");
            }
            if (rosModel.EyesGlassesorContacts == true)
            {
                collectValue = collectValue == "" ? "GlassesorContacts" : (collectValue + ", GlassesorContacts");
            }


            return collectValue;
        }
        public string GetCardiovascularstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.CardiovascularNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.CardiovascularOrthopnea == true)
            {
                collectValue = collectValue == "" ? "Orthopnea" : (collectValue + ", Orthopnea");
            }
            if (rosModel.CardiovascularChestPain == true)
            {
                collectValue = collectValue == "" ? "ChestPain" : (collectValue + ", ChestPain");
            }
            if (rosModel.CardiovascularEdema == true)
            {
                collectValue = collectValue == "" ? "Edema" : (collectValue + ", Edema");
            }
            if (rosModel.CardiovascularPalpitation == true)
            {
                collectValue = collectValue == "" ? "Palpitation" : (collectValue + ", Palpitation");
            }
            if (rosModel.CardiovascularClaudication == true)
            {
                collectValue = collectValue == "" ? "Claudication" : (collectValue + ", Claudication");
            }

            return collectValue;
        }
        public string GetGastrointestinalstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.GastrointestinalNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.GastrointestinalDiarrhea == true)
            {
                collectValue = collectValue == "" ? "Diarrhea" : (collectValue + ", Diarrhea");
            }
            if (rosModel.GastrointestinalAbdominalPain == true)
            {
                collectValue = collectValue == "" ? "AbdominalPain" : (collectValue + ", AbdominalPain");
            }
            if (rosModel.GastrointestinalHeartBurn == true)
            {
                collectValue = collectValue == "" ? "HeartBurn" : (collectValue + ", HeartBurn");
            }
            if (rosModel.GastrointestinalBloodyStool == true)
            {
                collectValue = collectValue == "" ? "BloodyStool" : (collectValue + ", BloodyStool");
            }
            if (rosModel.GastrointestinalConstipation == true)
            {
                collectValue = collectValue == "" ? "Constipation" : (collectValue + ", Constipation");
            }

            return collectValue;
        }
        public string GetMusculoskeletalstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.MusculoSkeletalNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.MusculoSkeletalBackPain == true)
            {
                collectValue = collectValue == "" ? "BackPain" : (collectValue + ", BackPain");
            }
            if (rosModel.MusculoSkeletalJointPain == true)
            {
                collectValue = collectValue == "" ? "JointPain" : (collectValue + ", JointPain");
            }
            if (rosModel.MusculoSkeletalNeckPain == true)
            {
                collectValue = collectValue == "" ? "NeckPain" : (collectValue + ", NeckPain");
            }
            if (rosModel.MusculoSkeletalMuscleWeakness == true)
            {
                collectValue = collectValue == "" ? "MuscleWeakness" : (collectValue + ", MuscleWeakness");
            }

            return collectValue;
        }
        public string GetNeurologicstringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.NeurologicNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.NeurologicSyncope == true)
            {
                collectValue = collectValue == "" ? "Syncope" : (collectValue + ", Syncope");
            }
            if (rosModel.NeurologicDizziness == true)
            {
                collectValue = collectValue == "" ? "Dizziness" : (collectValue + ", Dizziness");
            }
            if (rosModel.NeurologicNumbness == true)
            {
                collectValue = collectValue == "" ? "Numbness" : (collectValue + ", Numbness");
            }
            if (rosModel.NeurologicHeadaches == true)
            {
                collectValue = collectValue == "" ? "Headaches" : (collectValue + ", Headaches");
            }
            if (rosModel.NeurologicSevereMemoryProblems == true)
            {
                collectValue = collectValue == "" ? "SevereMemoryProblems" : (collectValue + ", SevereMemoryProblems");
            }

            return collectValue;
        }
        public string GetEndocrinologystringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.EndocrinologyNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.EndocrinologyDiabetes == true)
            {
                collectValue = collectValue == "" ? "Diabetes" : (collectValue + ", Diabetes");
            }
            if (rosModel.EndocrinologyHypoThyroid == true)
            {
                collectValue = collectValue == "" ? "HypoThyroid" : (collectValue + ", HypoThyroid");
            }
            if (rosModel.EndocrinologyHyperThyroid == true)
            {
                collectValue = collectValue == "" ? "HyperThyroid" : (collectValue + ", HyperThyroid");
            }
            if (rosModel.EndocrinologyHairLoss == true)
            {
                collectValue = collectValue == "" ? "HairLoss" : (collectValue + ", HairLoss");
            }
            if (rosModel.EndocrinologyHeatorColdIntolerance == true)
            {
                collectValue = collectValue == "" ? "HeatorColdIntolerance" : (collectValue + ", HeatorColdIntolerance");
            }

            return collectValue;
        }
        public string GetImmunologictringValue(PatientROSModel rosModel)
        {
            string collectValue = "";

            if (rosModel.ImmunologicNegative == true)
            {
                collectValue = collectValue == "" ? "Negative" : (collectValue + ", Negative");
            }
            if (rosModel.ImmunologicFoodAllergies == true)
            {
                collectValue = collectValue == "" ? "FoodAllergies" : (collectValue + ", FoodAllergies");
            }
            if (rosModel.ImmunologicSeasonalAllergies == true)
            {
                collectValue = collectValue == "" ? "SeasonalAllergies" : (collectValue + ", SeasonalAllergies");
            }

            return collectValue;
        }


        public PatientROSModel GetPatientROSDetailbyID(int patientROSID)
        {
            PatientROSModel rosRecord = (from ros in this._uow.GenericRepository<PatientROS>().Table().Where(x => x.Deleted != true & x.PatientROSID == patientROSID)

                                         select new
                                         {
                                             ros.PatientROSID,
                                             ros.PatientID,
                                             ros.RecordedDate,
                                             ros.Sex,
                                             ros.ConstitutionalNegative,
                                             ros.ConstitutionalWeightloss,
                                             ros.ConstitutionalWeightgain,
                                             ros.ConstitutionalFever,
                                             ros.ConstitutionalNightsweats,
                                             ros.ConstitutionalFatigue,
                                             ros.ENTNegative,
                                             ros.ENTUlcers,
                                             ros.ENTSinus,
                                             ros.ENTHeadache,
                                             ros.ENTHearingLoss,
                                             ros.ENTFatigue,
                                             ros.RespiratoryNegative,
                                             ros.RespiratoryWheezing,
                                             ros.RespiratoryHemoptysis,
                                             ros.RespiratoryCough,
                                             ros.RespiratoryShortnessofBreath,
                                             ros.GenitourinaryNegative,
                                             ros.GenitourinaryUrgency,
                                             ros.GenitourinaryDysuria,
                                             ros.GenitourinaryPolyuria,
                                             ros.GenitourinaryFrequentUrination,
                                             ros.SkinNegative,
                                             ros.SkinRash,
                                             ros.SkinUlcers,
                                             ros.SkinDrySkin,
                                             ros.SkinPigmentedLesions,
                                             ros.PsychiatricNegative,
                                             ros.PsychiatricDepression,
                                             ros.PsychiatricAnxiety,
                                             ros.PsychiatricCrying,
                                             ros.PsychiatricHighStress,
                                             ros.PsychiatricSuicidalIdeation,
                                             ros.HematologicNegative,
                                             ros.HematologicBleeds,
                                             ros.HematologicBruises,
                                             ros.HematologicLymphedema,
                                             ros.HematologicAdenopathys,
                                             ros.HematologicIssueswithBloodclots,
                                             ros.EyesNegative,
                                             ros.EyesVisionChange,
                                             ros.EyesGlassesorContacts,
                                             ros.CardiovascularNegative,
                                             ros.CardiovascularOrthopnea,
                                             ros.CardiovascularChestPain,
                                             ros.CardiovascularEdema,
                                             ros.CardiovascularPalpitation,
                                             ros.CardiovascularClaudication,
                                             ros.GastrointestinalNegative,
                                             ros.GastrointestinalDiarrhea,
                                             ros.GastrointestinalAbdominalPain,
                                             ros.GastrointestinalHeartBurn,
                                             ros.GastrointestinalBloodyStool,
                                             ros.GastrointestinalConstipation,
                                             ros.MusculoSkeletelNegative,
                                             ros.MusculoSkeletelBackPain,
                                             ros.MusculoSkeletelJointPain,
                                             ros.MusculoSkeletelNeckPain,
                                             ros.MusculoSkeletelMuscleWeakness,
                                             ros.NeurologicNegative,
                                             ros.NeurologicSyncope,
                                             ros.NeurologicDizziness,
                                             ros.NeurologicNumbness,
                                             ros.NeurologicHeadaches,
                                             ros.NeurologicSevereMemoryProblems,
                                             ros.EndocrinologyNegative,
                                             ros.EndocrinologyDiabetes,
                                             ros.EndocrinologyHypoThyroid,
                                             ros.EndocrinologyHyperThyroid,
                                             ros.EndocrinologyHairLoss,
                                             ros.EndocrinologyHeatorColdIntolerance,
                                             ros.ImmunologicNegative,
                                             ros.ImmunologicFoodAllergies,
                                             ros.ImmunologicSeasonalAllergies

                                         }).AsEnumerable().Select(PRM => new PatientROSModel
                                         {
                                             PatientROSID = PRM.PatientROSID,
                                             PatientID = PRM.PatientID,
                                             RecordedDate = PRM.RecordedDate,
                                             Sex = PRM.Sex,
                                             GenderDescription = PRM.Sex != null ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Description.ToLower().Trim() == PRM.Sex.ToLower().Trim()).FirstOrDefault().Description : "",
                                             ConstitutionalNegative = PRM.ConstitutionalNegative,
                                             ConstitutionalWeightloss = PRM.ConstitutionalWeightloss,
                                             ConstitutionalWeightgain = PRM.ConstitutionalWeightgain,
                                             ConstitutionalFever = PRM.ConstitutionalFever,
                                             ConstitutionalNightsweats = PRM.ConstitutionalNightsweats,
                                             ConstitutionalFatigue = PRM.ConstitutionalFatigue,
                                             ENTNegative = PRM.ENTNegative,
                                             ENTUlcers = PRM.ENTUlcers,
                                             ENTSinus = PRM.ENTSinus,
                                             ENTHeadache = PRM.ENTHeadache,
                                             ENTHearingLoss = PRM.ENTHearingLoss,
                                             ENTFatigue = PRM.ENTFatigue,
                                             RespiratoryNegative = PRM.RespiratoryNegative,
                                             RespiratoryWheezing = PRM.RespiratoryWheezing,
                                             RespiratoryHemoptysis = PRM.RespiratoryHemoptysis,
                                             RespiratoryCough = PRM.RespiratoryCough,
                                             RespiratoryShortnessofBreath = PRM.RespiratoryShortnessofBreath,
                                             GenitourinaryNegative = PRM.GenitourinaryNegative,
                                             GenitourinaryUrgency = PRM.GenitourinaryUrgency,
                                             GenitourinaryDysuria = PRM.GenitourinaryDysuria,
                                             GenitourinaryPolyuria = PRM.GenitourinaryPolyuria,
                                             GenitourinaryFrequentUrination = PRM.GenitourinaryFrequentUrination,
                                             SkinNegative = PRM.SkinNegative,
                                             SkinRash = PRM.SkinRash,
                                             SkinUlcers = PRM.SkinUlcers,
                                             SkinDrySkin = PRM.SkinDrySkin,
                                             SkinPigmentedLesions = PRM.SkinPigmentedLesions,
                                             PsychiatricNegative = PRM.PsychiatricNegative,
                                             PsychiatricDepression = PRM.PsychiatricDepression,
                                             PsychiatricAnxiety = PRM.PsychiatricAnxiety,
                                             PsychiatricCrying = PRM.PsychiatricCrying,
                                             PsychiatricHighStress = PRM.PsychiatricHighStress,
                                             PsychiatricSuicidalIdeation = PRM.PsychiatricSuicidalIdeation,
                                             HematologicNegative = PRM.HematologicNegative,
                                             HematologicBleeds = PRM.HematologicBleeds,
                                             HematologicBruises = PRM.HematologicBruises,
                                             HematologicLymphedema = PRM.HematologicLymphedema,
                                             HematologicAdenopathys = PRM.HematologicAdenopathys,
                                             HematologicIssueswithBloodclots = PRM.HematologicIssueswithBloodclots,
                                             EyesNegative = PRM.EyesNegative,
                                             EyesVisionChange = PRM.EyesVisionChange,
                                             EyesGlassesorContacts = PRM.EyesGlassesorContacts,
                                             CardiovascularNegative = PRM.CardiovascularNegative,
                                             CardiovascularOrthopnea = PRM.CardiovascularOrthopnea,
                                             CardiovascularChestPain = PRM.CardiovascularChestPain,
                                             CardiovascularEdema = PRM.CardiovascularEdema,
                                             CardiovascularPalpitation = PRM.CardiovascularPalpitation,
                                             CardiovascularClaudication = PRM.CardiovascularClaudication,
                                             GastrointestinalNegative = PRM.GastrointestinalNegative,
                                             GastrointestinalDiarrhea = PRM.GastrointestinalDiarrhea,
                                             GastrointestinalAbdominalPain = PRM.GastrointestinalAbdominalPain,
                                             GastrointestinalHeartBurn = PRM.GastrointestinalHeartBurn,
                                             GastrointestinalBloodyStool = PRM.GastrointestinalBloodyStool,
                                             GastrointestinalConstipation = PRM.GastrointestinalConstipation,
                                             MusculoSkeletalNegative = PRM.MusculoSkeletelNegative,
                                             MusculoSkeletalBackPain = PRM.MusculoSkeletelBackPain,
                                             MusculoSkeletalJointPain = PRM.MusculoSkeletelJointPain,
                                             MusculoSkeletalNeckPain = PRM.MusculoSkeletelNeckPain,
                                             MusculoSkeletalMuscleWeakness = PRM.MusculoSkeletelMuscleWeakness,
                                             NeurologicNegative = PRM.NeurologicNegative,
                                             NeurologicSyncope = PRM.NeurologicSyncope,
                                             NeurologicDizziness = PRM.NeurologicDizziness,
                                             NeurologicNumbness = PRM.NeurologicNumbness,
                                             NeurologicHeadaches = PRM.NeurologicHeadaches,
                                             NeurologicSevereMemoryProblems = PRM.NeurologicSevereMemoryProblems,
                                             EndocrinologyNegative = PRM.EndocrinologyNegative,
                                             EndocrinologyDiabetes = PRM.EndocrinologyDiabetes,
                                             EndocrinologyHypoThyroid = PRM.EndocrinologyHypoThyroid,
                                             EndocrinologyHyperThyroid = PRM.EndocrinologyHyperThyroid,
                                             EndocrinologyHairLoss = PRM.EndocrinologyHairLoss,
                                             EndocrinologyHeatorColdIntolerance = PRM.EndocrinologyHeatorColdIntolerance,
                                             ImmunologicNegative = PRM.ImmunologicNegative,
                                             ImmunologicFoodAllergies = PRM.ImmunologicFoodAllergies,
                                             ImmunologicSeasonalAllergies = PRM.ImmunologicSeasonalAllergies

                                         }).FirstOrDefault();

            return rosRecord;
        }

        #endregion

        #region Patient ProblemList

        public PatientProblemListModel AddUpdatePatientProblemList(PatientProblemListModel problemListModel)
        {
            PatientProblemList problemList = this._uow.GenericRepository<PatientProblemList>().Table().Where(x => x.PatientProblemListID == problemListModel.PatientProblemListID).FirstOrDefault();

            if (problemList == null)
            {
                problemList = new PatientProblemList();

                problemList.PatientID = problemListModel.PatientID;
                problemList.DiagnosisCode = problemListModel.DiagnosisCode;
                problemList.RecordedDate = this._iMasterService.GetLocalTime(problemListModel.RecordedDate);
                problemList.StatusID = problemListModel.StatusID;
                problemList.IsAdvancedDirective = problemListModel.IsAdvancedDirective;
                problemList.SourceName = problemListModel.SourceName;
                problemList.DiagnosedDate = problemListModel.DiagnosedDate != null ? this._iMasterService.GetLocalTime(problemListModel.DiagnosedDate.Value) : null;
                problemList.DocumentTypeID = problemListModel.DocumentTypeID;
                problemList.Description = problemListModel.Description;
                problemList.ClinicalNotes = problemListModel.ClinicalNotes;
                problemList.Notes = problemListModel.Notes;
                problemList.Deleted = false;
                problemList.CreatedDate = DateTime.Now;
                problemList.CreatedBy = "User";

                this._uow.GenericRepository<PatientProblemList>().Insert(problemList);
            }
            else
            {
                problemList.RecordedDate = this._iMasterService.GetLocalTime(problemListModel.RecordedDate);
                problemList.StatusID = problemListModel.StatusID;
                problemList.IsAdvancedDirective = problemListModel.IsAdvancedDirective;
                problemList.SourceName = problemListModel.SourceName;
                problemList.DiagnosedDate = problemListModel.DiagnosedDate != null ? this._iMasterService.GetLocalTime(problemListModel.DiagnosedDate.Value) : null;
                problemList.DocumentTypeID = problemListModel.DocumentTypeID;
                problemList.Description = problemListModel.Description;
                problemList.ClinicalNotes = problemListModel.ClinicalNotes;
                problemList.Notes = problemListModel.Notes;
                problemList.Deleted = false;
                problemList.ModifiedDate = DateTime.Now;
                problemList.ModifiedBy = "User";

                this._uow.GenericRepository<PatientProblemList>().Update(problemList);
            }
            this._uow.Save();
            problemListModel.PatientProblemListID = problemList.PatientProblemListID;

            return problemListModel;
        }

        public List<PatientProblemListModel> GetProblemListByPatientID(int patientID)
        {
            List<PatientProblemListModel> problemListDetails = (from problem in this._uow.GenericRepository<PatientProblemList>().Table().Where(x => x.Deleted != true & x.PatientID == patientID)
                                                                join pat in this._uow.GenericRepository<Patient>().Table() on problem.PatientID equals pat.PatientID
                                                                select new
                                                                {
                                                                    problem.PatientProblemListID,
                                                                    problem.PatientID,
                                                                    problem.RecordedDate,
                                                                    problem.StatusID,
                                                                    problem.DiagnosisCode,
                                                                    problem.IsAdvancedDirective,
                                                                    problem.SourceName,
                                                                    problem.DiagnosedDate,
                                                                    problem.DocumentTypeID,
                                                                    problem.Description,
                                                                    problem.ClinicalNotes,
                                                                    problem.Notes

                                                                }).AsEnumerable().Select(PPM => new PatientProblemListModel
                                                                {
                                                                    PatientProblemListID = PPM.PatientProblemListID,
                                                                    PatientID = PPM.PatientID,
                                                                    RecordedDate = PPM.RecordedDate,
                                                                    StatusID = PPM.StatusID,
                                                                    DiagnosisCode = PPM.DiagnosisCode,
                                                                    IsAdvancedDirective = PPM.IsAdvancedDirective,
                                                                    SourceName = PPM.SourceName,
                                                                    DiagnosedDate = PPM.DiagnosedDate,
                                                                    DocumentTypeID = PPM.DocumentTypeID,
                                                                    Description = PPM.Description,
                                                                    ClinicalNotes = PPM.ClinicalNotes,
                                                                    Notes = PPM.Notes,
                                                                    ProblemListFile = this.GetFile(PPM.PatientProblemListID.ToString(), "Patient/ProblemList").Count > 0 ? this.GetFile(PPM.PatientProblemListID.ToString(), "Patient/ProblemList") : new List<clsViewFile>(),
                                                                    StatusDescription = PPM.StatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PPM.StatusID).FirstOrDefault().Description : "",
                                                                    DocumentTypeDescription = PPM.DocumentTypeID > 0 ? this._uow.GenericRepository<DocumentType>().Table().Where(x => x.DocumentTypeID == PPM.DocumentTypeID).FirstOrDefault().Description : "",

                                                                }).ToList();

            return problemListDetails;
        }

        public PatientProblemListModel GetProblemListRecordByID(int patientProblemListID)
        {
            PatientProblemListModel problemListRecord = (from problem in this._uow.GenericRepository<PatientProblemList>().Table().Where(x => x.PatientProblemListID == patientProblemListID)

                                                         select new
                                                         {
                                                             problem.PatientProblemListID,
                                                             problem.PatientID,
                                                             problem.RecordedDate,
                                                             problem.StatusID,
                                                             problem.DiagnosisCode,
                                                             problem.IsAdvancedDirective,
                                                             problem.SourceName,
                                                             problem.DiagnosedDate,
                                                             problem.DocumentTypeID,
                                                             problem.Description,
                                                             problem.ClinicalNotes,
                                                             problem.Notes

                                                         }).AsEnumerable().Select(PPM => new PatientProblemListModel
                                                         {
                                                             PatientProblemListID = PPM.PatientProblemListID,
                                                             PatientID = PPM.PatientID,
                                                             RecordedDate = PPM.RecordedDate,
                                                             StatusID = PPM.StatusID,
                                                             DiagnosisCode = PPM.DiagnosisCode,
                                                             IsAdvancedDirective = PPM.IsAdvancedDirective,
                                                             SourceName = PPM.SourceName,
                                                             DiagnosedDate = PPM.DiagnosedDate,
                                                             DocumentTypeID = PPM.DocumentTypeID,
                                                             Description = PPM.Description,
                                                             ClinicalNotes = PPM.ClinicalNotes,
                                                             Notes = PPM.Notes,
                                                             ProblemListFile = this.GetFile(PPM.PatientProblemListID.ToString(), "Patient/ProblemList").Count > 0 ? this.GetFile(PPM.PatientProblemListID.ToString(), "Patient/ProblemList") : new List<clsViewFile>(),
                                                             StatusDescription = PPM.StatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.CommonMasterID == PPM.StatusID).FirstOrDefault().Description : "",
                                                             DocumentTypeDescription = PPM.DocumentTypeID > 0 ? this._uow.GenericRepository<DocumentType>().Table().Where(x => x.DocumentTypeID == PPM.DocumentTypeID).FirstOrDefault().Description : "",


                                                         }).FirstOrDefault();

            return problemListRecord;
        }

        #endregion

        public SOAPNotesModel GetSOAPNotes (int PatientID)
        {
            SOAPNotesModel notesModel = new SOAPNotesModel();
            
            notesModel.patientWorkHistory = this.patientWorkHistoryModelsByPatientID(PatientID);
            notesModel.PatientMedication = this.PatientMedicationModelsbyPatientID(PatientID);
            notesModel.patientDiagnosticList = this.patientDiagnosticListModelByPatientID(PatientID);
            notesModel.patientImmunization = this.patientImmunizationModelByPatientID(PatientID);
            notesModel.FamilyHealthHistory = this.familyHealthHistoryModelByPatientID(PatientID);
            notesModel.patientAllergy = this.AllergyModelByPatientID(PatientID);
            notesModel.VitalSign = this.vitalSignModelByPatientID(PatientID);
            notesModel.ProblemList = this.GetProblemListByPatientID(PatientID);
            notesModel.ROSDetails = this.GetROSDetailsbyPatientID(PatientID);
            notesModel.PatientFamily = this.GetPatientFamilyByPatientID(PatientID);
          

            return notesModel;
        }

        #region Patient ProblemList File Upload
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

        public List<PatientInsuranceModel> GetPatientInsurance()
        {

            var query = (from pi in this._uow.GenericRepository<PatientInsurance>().Table()
                         where (pi.Deleted == false)
                         join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on pi.PatientID equals p.PatientID
                         join it in this._uow.GenericRepository<InsuranceType>().Table().Where(x => !x.Deleted) on pi.InsuranceTypeID equals it.InsuranceTypeID
                             into insuranceTypeJoin
                         from it in insuranceTypeJoin.DefaultIfEmpty()
                         where ((pi.InsuranceTypeID == it.InsuranceTypeID))
                         join ic in this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => !x.Deleted) on pi.InsuranceCompanyID equals ic.InsuranceCompanyID
                             into insuranceCompanyJoin
                         from ic in insuranceCompanyJoin.DefaultIfEmpty()
                         where ((pi.InsuranceCompanyID == ic.InsuranceCompanyID))
                         join pr in this._uow.GenericRepository<PatientRelation>().Table().Where(x => !x.Deleted) on pi.PatientRelationID equals pr.PatientRelationID
                             into patientRelationJoin
                         from pr in patientRelationJoin.DefaultIfEmpty()
                         where ((pi.PatientRelationID == pr.PatientRelationID))
                         join ica in this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => !x.Deleted) on ic.InsuranceCategoryID equals ica.InsuranceCategoryID
                             into insuranceCategoryJoin
                         from ica in insuranceCategoryJoin.DefaultIfEmpty()
                         join g in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted) on pi.GenderID equals g.CommonMasterID
                             into genderJoin
                         from g in genderJoin.DefaultIfEmpty()
                         orderby pi.InsuranceTypeID ascending
                         select new
                         {
                             PatientInsuranceID = pi.PatientInsuranceID,
                             PatientID = pi.PatientID,
                             SelfInsured = pi.SelfInsured,
                             InsuranceTypeID = pi.InsuranceTypeID,
                             InsuranceTypeDescription = it.TypeDescription,
                             BillingMethodID = pi.BillingMethodID,
                             InsuranceCompanyID = pi.InsuranceCompanyID,
                             OrganizationName = ic.OrganizationName,
                             PatientRelationID = pi.PatientRelationID,
                             OrganizationID = ic.OrganizationID,
                             PatientRelation = pr.RelationDescription,
                             SSN = pi.SSN,
                             NameFirst = pi.NameFirst,
                             NameLast = pi.NameLast,
                             NameMiddle = pi.NameMiddle,
                             NamePrefix = pi.NamePrefix,
                             NameSuffix = pi.NameSuffix,
                             GenderID = pi.GenderID,
                             GenderDescription = g.Description,
                             BirthDate = pi.BirthDate,
                             AddressLine1 = pi.AddressLine1,
                             AddressLine2 = pi.AddressLine2,
                             City = pi.City,
                             State = pi.State,
                             County = pi.County,
                             ZIP = pi.ZIP,
                             Country = pi.Country,
                             CountryName = pi.Country,
                             Phone = pi.Phone,
                             AlternatePhone = pi.AlternatePhone,
                             Email = pi.Email,
                             GroupName = pi.GroupName,
                             GroupNumber = pi.GroupNumber,
                             PolicyNumber = pi.PolicyNumber,
                             Copay = pi.Copay,
                             PatientInsuredID = pi.PatientInsuredID,
                             SubscriberInsuredID = pi.SubscriberInsuredID,
                             EffectiveDate = pi.EffectiveDate,
                             TerminationDate = pi.TerminationDate,
                             EligibilityRequestedDate = pi.EligibilityRequestedDate,
                             InsuranceCategoryID = ica.InsuranceCategoryID,
                             InsuranceCategoryDescription = ica.Description,
                             Deleted = pi.Deleted,
                             CreatedDate = pi.CreatedDate,
                             CreatedBy = pi.CreatedBy,
                             ModifiedDate = pi.ModifiedDate,
                             ModifiedBy = pi.ModifiedBy,


                             InsuranceAddress1 = ic.AddressLine1,
                             InsuranceAddress2 = ic.AddressLine2,
                             InsuranceCity = ic.City,
                             InsuranceState = ic.State,
                             InsuranceZIP = ic.ZIP
                         }).AsEnumerable()
                        .Select(x => new PatientInsuranceModel
                        {
                            PatientInsuranceID = x.PatientInsuranceID,
                            PatientID = x.PatientID,
                            SelfInsured = x.SelfInsured,
                            InsuranceTypeID = x.InsuranceTypeID,
                            InsuranceTypeDescription = x.InsuranceTypeDescription,
                            BillingMethodID = x.BillingMethodID,
                            InsuranceCompanyID = x.InsuranceCompanyID,
                            OrganizationName = x.OrganizationName,
                            PatientRelationID = x.PatientRelationID,
                            OrganizationID = x.OrganizationID,
                            PatientRelation = x.PatientRelation,
                            SSN = x.SSN,
                            NameFirst = x.NameFirst,
                            NameLast = x.NameLast,
                            SubscriberName = x.NameLast + " " + x.NameFirst + " " + x.NameMiddle,
                            NameMiddle = x.NameMiddle,
                            NamePrefix = x.NamePrefix,
                            NameSuffix = x.NameSuffix,
                            GenderID = x.GenderID,
                            GenderDescription = x.GenderDescription,
                            BirthDate = x.BirthDate,
                            AddressLine1 = x.AddressLine1,
                            AddressLine2 = x.AddressLine2,
                            City = x.City,
                            State = x.State,
                            County = x.County,
                            ZIP = x.ZIP,
                            Country = x.Country,
                            CountryName = x.Country,
                            Phone = x.Phone,
                            AlternatePhone = x.AlternatePhone,
                            Email = x.Email,
                            GroupName = x.GroupName,
                            GroupNumber = x.GroupNumber,
                            PolicyNumber = x.PolicyNumber,
                            Copay = x.Copay,
                            PatientInsuredID = x.PatientInsuredID,
                            SubscriberInsuredID = x.SubscriberInsuredID,
                            EffectiveDate = x.EffectiveDate,
                            TerminationDate = x.TerminationDate,
                            EligibilityRequestedDate = x.EligibilityRequestedDate,
                            InsuranceCategoryID = x.InsuranceCategoryID,
                            InsuranceCategoryDescription = x.InsuranceCategoryDescription,
                            Deleted = x.Deleted,
                            CreatedDate = x.CreatedDate,
                            CreatedBy = x.CreatedBy,
                            ModifiedDate = x.ModifiedDate,
                            ModifiedBy = x.ModifiedBy,
                            InsuranceAddress1 = x.InsuranceAddress1,
                            InsuranceAddress2 = x.InsuranceAddress2,
                            InsuranceCity = x.InsuranceCity,
                            InsuranceState = x.InsuranceState,
                            InsuranceZIP = x.InsuranceZIP,

                        });
            var resultPatientInsurance = query.ToList();
            return resultPatientInsurance;
        }

        public List<PatientInsuranceModel> GetPatientInsurancesByPatientID(int patientID)
        {
            if (patientID <= 0)
                return null;
            var query = (from pi in this._uow.GenericRepository<PatientInsurance>().Table()
                         where (pi.Deleted == false) && (pi.PatientID == patientID)
                         join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on pi.PatientID equals p.PatientID
                         join it in this._uow.GenericRepository<InsuranceType>().Table().Where(x => !x.Deleted) on pi.InsuranceTypeID equals it.InsuranceTypeID
                             into insuranceTypeJoin
                         from it in insuranceTypeJoin.DefaultIfEmpty()
                         where ((pi.InsuranceTypeID == it.InsuranceTypeID))
                         join ic in this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => !x.Deleted) on pi.InsuranceCompanyID equals ic.InsuranceCompanyID
                             into insuranceCompanyJoin
                         from ic in insuranceCompanyJoin.DefaultIfEmpty()
                         where ((pi.InsuranceCompanyID == ic.InsuranceCompanyID))
                         join pr in this._uow.GenericRepository<PatientRelation>().Table().Where(x => !x.Deleted) on pi.PatientRelationID equals pr.PatientRelationID
                             into patientRelationJoin
                         from pr in patientRelationJoin.DefaultIfEmpty()
                         where ((pi.PatientRelationID == pr.PatientRelationID))
                         join ica in this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => !x.Deleted) on ic.InsuranceCategoryID equals ica.InsuranceCategoryID
                             into insuranceCategoryJoin
                         from ica in insuranceCategoryJoin.DefaultIfEmpty()
                         join g in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted) on pi.GenderID equals g.CommonMasterID
                             into genderJoin
                         from g in genderJoin.DefaultIfEmpty()
                         orderby pi.InsuranceTypeID ascending
                         select new
                         {
                             PatientInsuranceID = pi.PatientInsuranceID,
                             PatientID = pi.PatientID,
                             SelfInsured = pi.SelfInsured,
                             InsuranceTypeID = pi.InsuranceTypeID,
                             InsuranceTypeDescription = it.TypeDescription,
                             BillingMethodID = pi.BillingMethodID,
                             InsuranceCompanyID = pi.InsuranceCompanyID,
                             OrganizationName = ic.OrganizationName,
                             PatientRelationID = pi.PatientRelationID,
                             OrganizationID = ic.OrganizationID,
                             PatientRelation = pr.RelationDescription,
                             SSN = pi.SSN,
                             NameFirst = pi.NameFirst,
                             NameLast = pi.NameLast,
                             NameMiddle = pi.NameMiddle,
                             NamePrefix = pi.NamePrefix,
                             NameSuffix = pi.NameSuffix,
                             GenderID = pi.GenderID,
                             GenderDescription = g.Description,
                             BirthDate = pi.BirthDate,
                             AddressLine1 = pi.AddressLine1,
                             AddressLine2 = pi.AddressLine2,
                             City = pi.City,
                             State = pi.State,
                             County = pi.County,
                             ZIP = pi.ZIP,
                             Country = pi.Country,
                             CountryName = pi.Country,
                             Phone = pi.Phone,
                             AlternatePhone = pi.AlternatePhone,
                             Email = pi.Email,
                             GroupName = pi.GroupName,
                             GroupNumber = pi.GroupNumber,
                             PolicyNumber = pi.PolicyNumber,
                             Copay = pi.Copay,
                             PatientInsuredID = pi.PatientInsuredID,
                             SubscriberInsuredID = pi.SubscriberInsuredID,
                             EffectiveDate = pi.EffectiveDate,
                             TerminationDate = pi.TerminationDate,
                             EligibilityRequestedDate = pi.EligibilityRequestedDate,
                             InsuranceCategoryID = ica.InsuranceCategoryID,
                             InsuranceCategoryDescription = ica.Description,
                             Deleted = pi.Deleted,
                             CreatedDate = pi.CreatedDate,
                             CreatedBy = pi.CreatedBy,
                             ModifiedDate = pi.ModifiedDate,
                             ModifiedBy = pi.ModifiedBy,


                             InsuranceAddress1 = ic.AddressLine1,
                             InsuranceAddress2 = ic.AddressLine2,
                             InsuranceCity = ic.City,
                             InsuranceState = ic.State,
                             InsuranceZIP = ic.ZIP
                         }).AsEnumerable()
                        .Select(x => new PatientInsuranceModel
                        {
                            PatientInsuranceID = x.PatientInsuranceID,
                            PatientID = x.PatientID,
                            SelfInsured = x.SelfInsured,
                            InsuranceTypeID = x.InsuranceTypeID,
                            InsuranceTypeDescription = x.InsuranceTypeDescription,
                            BillingMethodID = x.BillingMethodID,
                            InsuranceCompanyID = x.InsuranceCompanyID,
                            OrganizationName = x.OrganizationName,
                            PatientRelationID = x.PatientRelationID,
                            OrganizationID = x.OrganizationID,
                            PatientRelation = x.PatientRelation,
                            SSN = x.SSN,
                            NameFirst = x.NameFirst,
                            NameLast = x.NameLast,
                            SubscriberName = x.NameLast + " " + x.NameFirst + " " + x.NameMiddle,
                            NameMiddle = x.NameMiddle,
                            NamePrefix = x.NamePrefix,
                            NameSuffix = x.NameSuffix,
                            GenderID = x.GenderID,
                            GenderDescription = x.GenderDescription,
                            BirthDate = x.BirthDate,
                            AddressLine1 = x.AddressLine1,
                            AddressLine2 = x.AddressLine2,
                            City = x.City,
                            State = x.State,
                            County = x.County,
                            ZIP = x.ZIP,
                            Country = x.Country,
                            CountryName = x.Country,
                            Phone = x.Phone,
                            AlternatePhone = x.AlternatePhone,
                            Email = x.Email,
                            GroupName = x.GroupName,
                            GroupNumber = x.GroupNumber,
                            PolicyNumber = x.PolicyNumber,
                            Copay = x.Copay,
                            PatientInsuredID = x.PatientInsuredID,
                            SubscriberInsuredID = x.SubscriberInsuredID,
                            EffectiveDate = x.EffectiveDate,
                            TerminationDate = x.TerminationDate,
                            EligibilityRequestedDate = x.EligibilityRequestedDate,
                            InsuranceCategoryID = x.InsuranceCategoryID,
                            InsuranceCategoryDescription = x.InsuranceCategoryDescription,
                            Deleted = x.Deleted,
                            CreatedDate = x.CreatedDate,
                            CreatedBy = x.CreatedBy,
                            ModifiedDate = x.ModifiedDate,
                            ModifiedBy = x.ModifiedBy,
                            InsuranceAddress1 = x.InsuranceAddress1,
                            InsuranceAddress2 = x.InsuranceAddress2,
                            InsuranceCity = x.InsuranceCity,
                            InsuranceState = x.InsuranceState,
                            InsuranceZIP = x.InsuranceZIP,

                        });
            var resultPatientInsurance = query.ToList();
            return resultPatientInsurance;
        }

        public List<PatientInsuranceModel> GetPatientInsurancesByPatientInsuranceID(int PatientInsuranceID)
        {
            if (PatientInsuranceID <= 0)
                return null;
            var query = (from pi in this._uow.GenericRepository<PatientInsurance>().Table()
                         where (pi.Deleted == false) && (pi.PatientInsuranceID == PatientInsuranceID)
                         join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on pi.PatientID equals p.PatientID
                         join it in this._uow.GenericRepository<InsuranceType>().Table().Where(x => !x.Deleted) on pi.InsuranceTypeID equals it.InsuranceTypeID
                             into insuranceTypeJoin
                         from it in insuranceTypeJoin.DefaultIfEmpty()
                         where ((pi.InsuranceTypeID == it.InsuranceTypeID))
                         join ic in this._uow.GenericRepository<InsuranceCompany>().Table().Where(x => !x.Deleted) on pi.InsuranceCompanyID equals ic.InsuranceCompanyID
                             into insuranceCompanyJoin
                         from ic in insuranceCompanyJoin.DefaultIfEmpty()
                         where ((pi.InsuranceCompanyID == ic.InsuranceCompanyID))
                         join pr in this._uow.GenericRepository<PatientRelation>().Table().Where(x => !x.Deleted) on pi.PatientRelationID equals pr.PatientRelationID
                             into patientRelationJoin
                         from pr in patientRelationJoin.DefaultIfEmpty()
                         where ((pi.PatientRelationID == pr.PatientRelationID))
                         join ica in this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => !x.Deleted) on ic.InsuranceCategoryID equals ica.InsuranceCategoryID
                             into insuranceCategoryJoin
                         from ica in insuranceCategoryJoin.DefaultIfEmpty()
                         join g in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted) on pi.GenderID equals g.CommonMasterID
                             into genderJoin
                         from g in genderJoin.DefaultIfEmpty()
                         orderby pi.InsuranceTypeID ascending
                         select new
                         {
                             PatientInsuranceID = pi.PatientInsuranceID,
                             PatientID = pi.PatientID,
                             SelfInsured = pi.SelfInsured,
                             InsuranceTypeID = pi.InsuranceTypeID,
                             InsuranceTypeDescription = it.TypeDescription,
                             BillingMethodID = pi.BillingMethodID,
                             InsuranceCompanyID = pi.InsuranceCompanyID,
                             OrganizationName = ic.OrganizationName,
                             PatientRelationID = pi.PatientRelationID,
                             OrganizationID = ic.OrganizationID,
                             PatientRelation = pr.RelationDescription,
                             SSN = pi.SSN,
                             NameFirst = pi.NameFirst,
                             NameLast = pi.NameLast,
                             NameMiddle = pi.NameMiddle,
                             NamePrefix = pi.NamePrefix,
                             NameSuffix = pi.NameSuffix,
                             GenderID = pi.GenderID,
                             GenderDescription = g.Description,
                             BirthDate = pi.BirthDate,
                             AddressLine1 = pi.AddressLine1,
                             AddressLine2 = pi.AddressLine2,
                             City = pi.City,
                             State = pi.State,
                             County = pi.County,
                             ZIP = pi.ZIP,
                             Country = pi.Country,
                             CountryName = pi.Country,
                             Phone = pi.Phone,
                             AlternatePhone = pi.AlternatePhone,
                             Email = pi.Email,
                             GroupName = pi.GroupName,
                             GroupNumber = pi.GroupNumber,
                             PolicyNumber = pi.PolicyNumber,
                             Copay = pi.Copay,
                             PatientInsuredID = pi.PatientInsuredID,
                             SubscriberInsuredID = pi.SubscriberInsuredID,
                             EffectiveDate = pi.EffectiveDate,
                             TerminationDate = pi.TerminationDate,
                             EligibilityRequestedDate = pi.EligibilityRequestedDate,
                             InsuranceCategoryID = ica.InsuranceCategoryID,
                             InsuranceCategoryDescription = ica.Description,
                             Deleted = pi.Deleted,
                             CreatedDate = pi.CreatedDate,
                             CreatedBy = pi.CreatedBy,
                             ModifiedDate = pi.ModifiedDate,
                             ModifiedBy = pi.ModifiedBy,


                             InsuranceAddress1 = ic.AddressLine1,
                             InsuranceAddress2 = ic.AddressLine2,
                             InsuranceCity = ic.City,
                             InsuranceState = ic.State,
                             InsuranceZIP = ic.ZIP
                         }).AsEnumerable()
                        .Select(x => new PatientInsuranceModel
                        {
                            PatientInsuranceID = x.PatientInsuranceID,
                            PatientID = x.PatientID,
                            SelfInsured = x.SelfInsured,
                            InsuranceTypeID = x.InsuranceTypeID,
                            InsuranceTypeDescription = x.InsuranceTypeDescription,
                            BillingMethodID = x.BillingMethodID,
                            InsuranceCompanyID = x.InsuranceCompanyID,
                            OrganizationName = x.OrganizationName,
                            PatientRelationID = x.PatientRelationID,
                            OrganizationID = x.OrganizationID,
                            PatientRelation = x.PatientRelation,
                            SSN = x.SSN,
                            NameFirst = x.NameFirst,
                            NameLast = x.NameLast,
                            SubscriberName = x.NameLast + " " + x.NameFirst + " " + x.NameMiddle,
                            NameMiddle = x.NameMiddle,
                            NamePrefix = x.NamePrefix,
                            NameSuffix = x.NameSuffix,
                            GenderID = x.GenderID,
                            GenderDescription = x.GenderDescription,
                            BirthDate = x.BirthDate,
                            AddressLine1 = x.AddressLine1,
                            AddressLine2 = x.AddressLine2,
                            City = x.City,
                            State = x.State,
                            County = x.County,
                            ZIP = x.ZIP,
                            Country = x.Country,
                            CountryName = x.Country,
                            Phone = x.Phone,
                            AlternatePhone = x.AlternatePhone,
                            Email = x.Email,
                            GroupName = x.GroupName,
                            GroupNumber = x.GroupNumber,
                            PolicyNumber = x.PolicyNumber,
                            Copay = x.Copay,
                            PatientInsuredID = x.PatientInsuredID,
                            SubscriberInsuredID = x.SubscriberInsuredID,
                            EffectiveDate = x.EffectiveDate,
                            TerminationDate = x.TerminationDate,
                            EligibilityRequestedDate = x.EligibilityRequestedDate,
                            InsuranceCategoryID = x.InsuranceCategoryID,
                            InsuranceCategoryDescription = x.InsuranceCategoryDescription,
                            Deleted = x.Deleted,
                            CreatedDate = x.CreatedDate,
                            CreatedBy = x.CreatedBy,
                            ModifiedDate = x.ModifiedDate,
                            ModifiedBy = x.ModifiedBy,
                            InsuranceAddress1 = x.InsuranceAddress1,
                            InsuranceAddress2 = x.InsuranceAddress2,
                            InsuranceCity = x.InsuranceCity,
                            InsuranceState = x.InsuranceState,
                            InsuranceZIP = x.InsuranceZIP,

                        });
            var resultPatientInsurance = query.ToList();
            return resultPatientInsurance;
        }


        public PhysicalExamModel addupdatephysicalexam(PhysicalExamModel physicalExamModel)
        {
            var physical = this._uow.GenericRepository<PhysicalExam>().Table().Where(x => x.PhysicalExamID == physicalExamModel.PhysicalExamID).FirstOrDefault();

            if(physical == null)
            {
                physical = new PhysicalExam();
                physical.PatientID = physicalExamModel.PatientID;
                physical.PhysicalExamID = physicalExamModel.PhysicalExamID;
                physical.PatientVisitID = physicalExamModel.PatientVisitID;
                physical.RecordedDate = physicalExamModel.RecordedDate;
                physical.GeneralWellappearing = physicalExamModel.GeneralWellappearing;
                physical.Generalwellnourished = physicalExamModel.Generalwellnourished;
                physical.Generalinnodistress = physicalExamModel.Generalinnodistress;
                physical.GeneralOrientedx3 = physicalExamModel.GeneralOrientedx3;
                physical.Generalnormalmoodandaffect = physicalExamModel.Generalnormalmoodandaffect;
                physical.GeneralAmbulatingwithoutdifficulty = physicalExamModel.GeneralAmbulatingwithoutdifficulty;
                physical.SkinGoodturgor = physicalExamModel.SkinGoodturgor;
                physical.Skinnorash = physicalExamModel.Skinnorash;
                physical.Skinunusualbruisingorprominentlesions = physicalExamModel.Skinunusualbruisingorprominentlesions;
                physical.HairNormaltextureanddistribution = physicalExamModel.HairNormaltextureanddistribution;
                physical.NailsNormalcolor = physicalExamModel.NailsNormalcolor;
                physical.Nailsnodeformities = physicalExamModel.Nailsnodeformities;
                physical.HeadNormocephalic = physicalExamModel.HeadNormocephalic;
                physical.Headatraumatic = physicalExamModel.Headatraumatic;
                physical.Headnovisibleorpalpablemasses = physicalExamModel.Headnovisibleorpalpablemasses;
                physical.Headdepressions = physicalExamModel.Headdepressions;
                physical.Headorscaring = physicalExamModel.Headorscaring;
                physical.EyesVisualacuityintact = physicalExamModel.EyesVisualacuityintact;
                physical.Eyesconjunctivaclear = physicalExamModel.Eyesconjunctivaclear;
                physical.Eyesscleranonicteric = physicalExamModel.Eyesscleranonicteric;
                physical.EyesEOMintact = physicalExamModel.EyesEOMintact;
                physical.EyesPERRL = physicalExamModel.EyesPERRL;
                physical.Eyesfundihavenormalopticdiscsandvessels = physicalExamModel.Eyesfundihavenormalopticdiscsandvessels;
                physical.Eyesnoexudatesorhemorrhages = physicalExamModel.Eyesnoexudatesorhemorrhages;
                physical.EarsEACsclear = physicalExamModel.EarsEACsclear;
                physical.EarsTMstranslucentmobile = physicalExamModel.EarsTMstranslucentmobile;
                physical.Earsossiclesnlappearance = physicalExamModel.Earsossiclesnlappearance;
                physical.Earshearingintact = physicalExamModel.Earshearingintact;
                physical.NoseNoexternallesions = physicalExamModel.NoseNoexternallesions;
                physical.Nosemucosanoninflamed = physicalExamModel.Nosemucosanoninflamed;
                physical.Noseseptumandturbinatesnormal = physicalExamModel.Noseseptumandturbinatesnormal;
                physical.MouthMucousmembranesmoist = physicalExamModel.MouthMucousmembranesmoist;
                physical.Mouthnomucosallesions = physicalExamModel.Mouthnomucosallesions;
                physical.TeethGumsNoobviouscariesorperiodontaldisease = physicalExamModel.TeethGumsNoobviouscariesorperiodontaldisease;
                physical.TeethGumsNogingivalinflammationorsignificantresorption = physicalExamModel.TeethGumsNogingivalinflammationorsignificantresorption;
                physical.PharynxMucosanoninflamed = physicalExamModel.PharynxMucosanoninflamed;
                physical.Pharynxnotonsillarhypertrophyorexudate = physicalExamModel.Pharynxnotonsillarhypertrophyorexudate;
                physical.PharynxNogingivalinflammationorsignificantresorption = physicalExamModel.PharynxNogingivalinflammationorsignificantresorption;
                physical.NeckSupple = physicalExamModel.NeckSupple;
                physical.Neckwithoutlesions = physicalExamModel.Neckwithoutlesions;
                physical.Neckbruits = physicalExamModel.Neckbruits;
                physical.Neckoradenopathy = physicalExamModel.Neckoradenopathy;
                physical.Neckthyroidnonenlargedandnontender = physicalExamModel.Neckthyroidnonenlargedandnontender;
                physical.HeartNocardiomegalyorthrills = physicalExamModel.HeartNocardiomegalyorthrills;
                physical.Heartregularrateandrhythm = physicalExamModel.Heartregularrateandrhythm;
                physical.Heartnomurmurorgallop = physicalExamModel.Heartnomurmurorgallop;
                physical.HeartAmbulatingwithoutdifficulty = physicalExamModel.HeartAmbulatingwithoutdifficulty;
                physical.LungsCleartoauscultationandpercussion = physicalExamModel.LungsCleartoauscultationandpercussion;
                physical.AbdomenBowelsoundsnormal = physicalExamModel.AbdomenBowelsoundsnormal;
                physical.Abdomennotenderness = physicalExamModel.Abdomennotenderness;
                physical.Abdomenorganomegaly = physicalExamModel.Abdomenorganomegaly;
                physical.Abdomenmasses = physicalExamModel.Abdomenmasses;
                physical.Abdomenorhernia = physicalExamModel.Abdomenorhernia;
                physical.BackSpinenormalwithoutdeformityortenderness = physicalExamModel.BackSpinenormalwithoutdeformityortenderness;
                physical.BacknoCVAtenderness = physicalExamModel.BacknoCVAtenderness;
                physical.Backmasses = physicalExamModel.Backmasses;
                physical.Backorhernia = physicalExamModel.Backorhernia;
                physical.RectalNormalsphinctertone = physicalExamModel.RectalNormalsphinctertone;
                physical.Rectalnohemorrhoidsormassespalpable = physicalExamModel.Rectalnohemorrhoidsormassespalpable;
                physical.ExtremitiesNoamputationsordeformities = physicalExamModel.ExtremitiesNoamputationsordeformities;
                physical.Extremitiescyanosis = physicalExamModel.Extremitiescyanosis;
                physical.Extremitiesedemaorvaricosities = physicalExamModel.Extremitiesedemaorvaricosities;
                physical.Extremitiesperipheralpulsesintact = physicalExamModel.Extremitiesperipheralpulsesintact;
                physical.MusculoskeletalNormalgaitandstation = physicalExamModel.MusculoskeletalNormalgaitandstation;
                physical.MusculoskeletalNomisalignment = physicalExamModel.MusculoskeletalNomisalignment;
                physical.Musculoskeletalasymmetry = physicalExamModel.Musculoskeletalasymmetry;
                physical.Musculoskeletalcrepitation = physicalExamModel.Musculoskeletalcrepitation;
                physical.Musculoskeletaldefects = physicalExamModel.Musculoskeletaldefects;
                physical.Musculoskeletalmasses = physicalExamModel.Musculoskeletalmasses;
                physical.Musculoskeletaleffusions = physicalExamModel.Musculoskeletaleffusions;
                physical.Musculoskeletaldecreasedrangeofmotion = physicalExamModel.Musculoskeletaldecreasedrangeofmotion;
                physical.Musculoskeletalinstability = physicalExamModel.Musculoskeletalinstability;
                physical.Musculoskeletalatrophyorabnormal = physicalExamModel.Musculoskeletalatrophyorabnormal;
                physical.Musculoskeletaltenderness = physicalExamModel.Musculoskeletaltenderness;
                physical.NeurologicCN212normal = physicalExamModel.NeurologicCN212normal;
                physical.NeurologicDTRsnormalinupperandlowerextremities = physicalExamModel.NeurologicDTRsnormalinupperandlowerextremities;
                physical.PsychiatricOrientedX3 = physicalExamModel.PsychiatricOrientedX3;
                physical.Psychiatricintactrecentandremotememory = physicalExamModel.Psychiatricintactrecentandremotememory;
                physical.Psychiatricjudgmentandinsight = physicalExamModel.Psychiatricjudgmentandinsight;
                physical.Psychiatricnormalmoodandaffect = physicalExamModel.Psychiatricnormalmoodandaffect;
                physical.PelvicVaginaandcervixwithoutlesionsordischarge = physicalExamModel.PelvicVaginaandcervixwithoutlesionsordischarge;
                physical.PelvicUterusandadnexaParametrianontenderwithoutmasses = physicalExamModel.PelvicUterusandadnexaParametrianontenderwithoutmasses;
                physical.BreastNonippleabnormality = physicalExamModel.BreastNonippleabnormality;
                physical.Breastdominantmasses = physicalExamModel.Breastdominantmasses;
                physical.Breasttendernesstopalpation = physicalExamModel.Breasttendernesstopalpation;
                physical.Breastaxillaryorsupraclavicularadenopathy = physicalExamModel.Breastaxillaryorsupraclavicularadenopathy;
                physical.GUPeniscircumcisedwithoutlesions = physicalExamModel.GUPeniscircumcisedwithoutlesions;
                physical.GUurethralmeatusnormallocationwithoutdischarge = physicalExamModel.GUurethralmeatusnormallocationwithoutdischarge;
                physical.GUtestesandepididymidesnormalsizewithoutmasses = physicalExamModel.GUtestesandepididymidesnormalsizewithoutmasses;
                physical.GUscrotumwithoutlesions = physicalExamModel.GUscrotumwithoutlesions;
                physical.IsActive = physical.IsActive;
                physical.Createddate = DateTime.Now;
                physical.CreatedBy = "user";
                physical.ModifiedDate = DateTime.Now;
                physical.ModifiedBy = "user";

                this._uow.GenericRepository<PhysicalExam>().Insert(physical);


            }
            else
            {
                physical.PatientID = physicalExamModel.PatientID;
                //physical.PhysicalExamID = physicalExamModel.PhysicalExamID;
                physical.PatientVisitID = physicalExamModel.PatientVisitID;
                physical.RecordedDate = physicalExamModel.RecordedDate;
                physical.GeneralWellappearing = physicalExamModel.GeneralWellappearing;
                physical.Generalwellnourished = physicalExamModel.Generalwellnourished;
                physical.Generalinnodistress = physicalExamModel.Generalinnodistress;
                physical.GeneralOrientedx3 = physicalExamModel.GeneralOrientedx3;
                physical.Generalnormalmoodandaffect = physicalExamModel.Generalnormalmoodandaffect;
                physical.GeneralAmbulatingwithoutdifficulty = physicalExamModel.GeneralAmbulatingwithoutdifficulty;
                physical.SkinGoodturgor = physicalExamModel.SkinGoodturgor;
                physical.Skinnorash = physicalExamModel.Skinnorash;
                physical.Skinunusualbruisingorprominentlesions = physicalExamModel.Skinunusualbruisingorprominentlesions;
                physical.HairNormaltextureanddistribution = physicalExamModel.HairNormaltextureanddistribution;
                physical.NailsNormalcolor = physicalExamModel.NailsNormalcolor;
                physical.Nailsnodeformities = physicalExamModel.Nailsnodeformities;
                physical.HeadNormocephalic = physicalExamModel.HeadNormocephalic;
                physical.Headatraumatic = physicalExamModel.Headatraumatic;
                physical.Headnovisibleorpalpablemasses = physicalExamModel.Headnovisibleorpalpablemasses;
                physical.Headdepressions = physicalExamModel.Headdepressions;
                physical.Headorscaring = physicalExamModel.Headorscaring;
                physical.EyesVisualacuityintact = physicalExamModel.EyesVisualacuityintact;
                physical.Eyesconjunctivaclear = physicalExamModel.Eyesconjunctivaclear;
                physical.Eyesscleranonicteric = physicalExamModel.Eyesscleranonicteric;
                physical.EyesEOMintact = physicalExamModel.EyesEOMintact;
                physical.EyesPERRL = physicalExamModel.EyesPERRL;
                physical.Eyesfundihavenormalopticdiscsandvessels = physicalExamModel.Eyesfundihavenormalopticdiscsandvessels;
                physical.Eyesnoexudatesorhemorrhages = physicalExamModel.Eyesnoexudatesorhemorrhages;
                physical.EarsEACsclear = physicalExamModel.EarsEACsclear;
                physical.EarsTMstranslucentmobile = physicalExamModel.EarsTMstranslucentmobile;
                physical.Earsossiclesnlappearance = physicalExamModel.Earsossiclesnlappearance;
                physical.Earshearingintact = physicalExamModel.Earshearingintact;
                physical.NoseNoexternallesions = physicalExamModel.NoseNoexternallesions;
                physical.Nosemucosanoninflamed = physicalExamModel.Nosemucosanoninflamed;
                physical.Noseseptumandturbinatesnormal = physicalExamModel.Noseseptumandturbinatesnormal;
                physical.MouthMucousmembranesmoist = physicalExamModel.MouthMucousmembranesmoist;
                physical.Mouthnomucosallesions = physicalExamModel.Mouthnomucosallesions;
                physical.TeethGumsNoobviouscariesorperiodontaldisease = physicalExamModel.TeethGumsNoobviouscariesorperiodontaldisease;
                physical.TeethGumsNogingivalinflammationorsignificantresorption = physicalExamModel.TeethGumsNogingivalinflammationorsignificantresorption;
                physical.PharynxMucosanoninflamed = physicalExamModel.PharynxMucosanoninflamed;
                physical.Pharynxnotonsillarhypertrophyorexudate = physicalExamModel.Pharynxnotonsillarhypertrophyorexudate;
                physical.PharynxNogingivalinflammationorsignificantresorption = physicalExamModel.PharynxNogingivalinflammationorsignificantresorption;
                physical.NeckSupple = physicalExamModel.NeckSupple;
                physical.Neckwithoutlesions = physicalExamModel.Neckwithoutlesions;
                physical.Neckbruits = physicalExamModel.Neckbruits;
                physical.Neckoradenopathy = physicalExamModel.Neckoradenopathy;
                physical.Neckthyroidnonenlargedandnontender = physicalExamModel.Neckthyroidnonenlargedandnontender;
                physical.HeartNocardiomegalyorthrills = physicalExamModel.HeartNocardiomegalyorthrills;
                physical.Heartregularrateandrhythm = physicalExamModel.Heartregularrateandrhythm;
                physical.Heartnomurmurorgallop = physicalExamModel.Heartnomurmurorgallop;
                physical.HeartAmbulatingwithoutdifficulty = physicalExamModel.HeartAmbulatingwithoutdifficulty;
                physical.LungsCleartoauscultationandpercussion = physicalExamModel.LungsCleartoauscultationandpercussion;
                physical.AbdomenBowelsoundsnormal = physicalExamModel.AbdomenBowelsoundsnormal;
                physical.Abdomennotenderness = physicalExamModel.Abdomennotenderness;
                physical.Abdomenorganomegaly = physicalExamModel.Abdomenorganomegaly;
                physical.Abdomenmasses = physicalExamModel.Abdomenmasses;
                physical.Abdomenorhernia = physicalExamModel.Abdomenorhernia;
                physical.BackSpinenormalwithoutdeformityortenderness = physicalExamModel.BackSpinenormalwithoutdeformityortenderness;
                physical.BacknoCVAtenderness = physicalExamModel.BacknoCVAtenderness;
                physical.Backmasses = physicalExamModel.Backmasses;
                physical.Backorhernia = physicalExamModel.Backorhernia;
                physical.RectalNormalsphinctertone = physicalExamModel.RectalNormalsphinctertone;
                physical.Rectalnohemorrhoidsormassespalpable = physicalExamModel.Rectalnohemorrhoidsormassespalpable;
                physical.ExtremitiesNoamputationsordeformities = physicalExamModel.ExtremitiesNoamputationsordeformities;
                physical.Extremitiescyanosis = physicalExamModel.Extremitiescyanosis;
                physical.Extremitiesedemaorvaricosities = physicalExamModel.Extremitiesedemaorvaricosities;
                physical.Extremitiesperipheralpulsesintact = physicalExamModel.Extremitiesperipheralpulsesintact;
                physical.MusculoskeletalNormalgaitandstation = physicalExamModel.MusculoskeletalNormalgaitandstation;
                physical.MusculoskeletalNomisalignment = physicalExamModel.MusculoskeletalNomisalignment;
                physical.Musculoskeletalasymmetry = physicalExamModel.Musculoskeletalasymmetry;
                physical.Musculoskeletalcrepitation = physicalExamModel.Musculoskeletalcrepitation;
                physical.Musculoskeletaldefects = physicalExamModel.Musculoskeletaldefects;
                physical.Musculoskeletalmasses = physicalExamModel.Musculoskeletalmasses;
                physical.Musculoskeletaleffusions = physicalExamModel.Musculoskeletaleffusions;
                physical.Musculoskeletaldecreasedrangeofmotion = physicalExamModel.Musculoskeletaldecreasedrangeofmotion;
                physical.Musculoskeletalinstability = physicalExamModel.Musculoskeletalinstability;
                physical.Musculoskeletalatrophyorabnormal = physicalExamModel.Musculoskeletalatrophyorabnormal;
                physical.Musculoskeletaltenderness = physicalExamModel.Musculoskeletaltenderness;
                physical.NeurologicCN212normal = physicalExamModel.NeurologicCN212normal;
                physical.NeurologicDTRsnormalinupperandlowerextremities = physicalExamModel.NeurologicDTRsnormalinupperandlowerextremities;
                physical.PsychiatricOrientedX3 = physicalExamModel.PsychiatricOrientedX3;
                physical.Psychiatricintactrecentandremotememory = physicalExamModel.Psychiatricintactrecentandremotememory;
                physical.Psychiatricjudgmentandinsight = physicalExamModel.Psychiatricjudgmentandinsight;
                physical.Psychiatricnormalmoodandaffect = physicalExamModel.Psychiatricnormalmoodandaffect;
                physical.PelvicVaginaandcervixwithoutlesionsordischarge = physicalExamModel.PelvicVaginaandcervixwithoutlesionsordischarge;
                physical.PelvicUterusandadnexaParametrianontenderwithoutmasses = physicalExamModel.PelvicUterusandadnexaParametrianontenderwithoutmasses;
                physical.BreastNonippleabnormality = physicalExamModel.BreastNonippleabnormality;
                physical.Breastdominantmasses = physicalExamModel.Breastdominantmasses;
                physical.Breasttendernesstopalpation = physicalExamModel.Breasttendernesstopalpation;
                physical.Breastaxillaryorsupraclavicularadenopathy = physicalExamModel.Breastaxillaryorsupraclavicularadenopathy;
                physical.GUPeniscircumcisedwithoutlesions = physicalExamModel.GUPeniscircumcisedwithoutlesions;
                physical.GUurethralmeatusnormallocationwithoutdischarge = physicalExamModel.GUurethralmeatusnormallocationwithoutdischarge;
                physical.GUtestesandepididymidesnormalsizewithoutmasses = physicalExamModel.GUtestesandepididymidesnormalsizewithoutmasses;
                physical.GUscrotumwithoutlesions = physicalExamModel.GUscrotumwithoutlesions;
                physical.IsActive = physical.IsActive;
                physical.Createddate = DateTime.Now;
                physical.CreatedBy = "user";
                physical.ModifiedDate = DateTime.Now;
                physical.ModifiedBy = "user";

                this._uow.GenericRepository<PhysicalExam>().Update(physical);
            }
            this._uow.Save();
            physicalExamModel.PhysicalExamID = physical.PhysicalExamID;

            return physicalExamModel;
        }

        public List<PhysicalExamModel> GetPhysicalExamModelsgetbyPatientID(int PatientID)
        {
            List<PhysicalExamModel> Physical = (from a in this._uow.GenericRepository<PhysicalExam>().Table().Where(x => x.PatientID == PatientID)
                                                join pat in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals pat.PatientID
                                                  select
                                                  new
                             {
                                 a.PhysicalExamID,
                                 a.PatientID,
                                 a.PatientVisitID,
                                 a.RecordedDate,
                                 a.GeneralWellappearing,
                                 a.Generalwellnourished,
                                 a.Generalinnodistress,
                                 a.GeneralOrientedx3,
                                 a.Generalnormalmoodandaffect,
                                 a.GeneralAmbulatingwithoutdifficulty,
                                 a.SkinGoodturgor,
                                 a.Skinnorash,
                                 a.Skinunusualbruisingorprominentlesions,
                                 a.HairNormaltextureanddistribution,
                                 a.NailsNormalcolor,
                                 a.Nailsnodeformities,
                                 a.HeadNormocephalic,
                                 a.Headatraumatic,
                                 a.Headnovisibleorpalpablemasses,
                                 a.Headdepressions,
                                 a.Headorscaring,
                                 a.EyesVisualacuityintact,
                                 a.Eyesconjunctivaclear,
                                 a.Eyesscleranonicteric,
                                 a.EyesEOMintact,
                                 a.EyesPERRL,
                                 a.Eyesfundihavenormalopticdiscsandvessels,
                                 a.Eyesnoexudatesorhemorrhages,
                                 a.EarsEACsclear,
                                 a.EarsTMstranslucentmobile,
                                 a.Earsossiclesnlappearance,
                                 a.Earshearingintact,
                                 a.NoseNoexternallesions,
                                 a.Nosemucosanoninflamed,
                                 a.Noseseptumandturbinatesnormal,
                                 a.MouthMucousmembranesmoist,
                                 a.Mouthnomucosallesions,
                                 a.TeethGumsNoobviouscariesorperiodontaldisease,
                                 a.TeethGumsNogingivalinflammationorsignificantresorption,
                                 a.PharynxMucosanoninflamed,
                                 a.Pharynxnotonsillarhypertrophyorexudate,
                                 a.PharynxNogingivalinflammationorsignificantresorption,
                                 a.NeckSupple,
                                 a.Neckwithoutlesions,
                                 a.Neckbruits,
                                 a.Neckoradenopathy,
                                 a.Neckthyroidnonenlargedandnontender,
                                 a.HeartNocardiomegalyorthrills,
                                 a.Heartregularrateandrhythm,
                                 a.Heartnomurmurorgallop,
                                 a.HeartAmbulatingwithoutdifficulty,
                                 a.LungsCleartoauscultationandpercussion,
                                 a.AbdomenBowelsoundsnormal,
                                 a.Abdomennotenderness,
                                 a.Abdomenorganomegaly,
                                 a.Abdomenmasses,
                                 a.Abdomenorhernia,
                                 a.BackSpinenormalwithoutdeformityortenderness,
                                 a.BacknoCVAtenderness,
                                 a.Backmasses,
                                 a.Backorhernia,
                                 a.RectalNormalsphinctertone,
                                 a.Rectalnohemorrhoidsormassespalpable,
                                 a.ExtremitiesNoamputationsordeformities,
                                 a.Extremitiescyanosis,
                                 a.Extremitiesedemaorvaricosities,
                                 a.Extremitiesperipheralpulsesintact,
                                 a.MusculoskeletalNormalgaitandstation,
                                 a.MusculoskeletalNomisalignment,
                                 a.Musculoskeletalasymmetry,
                                 a.Musculoskeletalcrepitation,
                                 a.Musculoskeletaldefects,
                                 a.Musculoskeletaltenderness,
                                 a.Musculoskeletalmasses,
                                 a.Musculoskeletaleffusions,
                                 a.Musculoskeletaldecreasedrangeofmotion,
                                 a.Musculoskeletalinstability,
                                 a.Musculoskeletalatrophyorabnormal,
                                 a.NeurologicCN212normal,
                                 a.NeurologicSensationtopain,
                                 a.Neurologictouch,
                                 a.Neurologicandproprioceptionnormal,
                                 a.NeurologicDTRsnormalinupperandlowerextremities,
                                 a.NeurologicNopathologicreflexes,
                                 a.PsychiatricOrientedX3,
                                 a.Psychiatricintactrecentandremotememory,
                                 a.Psychiatricjudgmentandinsight,
                                 a.Psychiatricnormalmoodandaffect,
                                 a.PelvicVaginaandcervixwithoutlesionsordischarge,
                                 a.PelvicUterusandadnexaParametrianontenderwithoutmasses,
                                 a.BreastNonippleabnormality,
                                 a.Breastdominantmasses,
                                 a.Breasttendernesstopalpation,
                                 a.Breastaxillaryorsupraclavicularadenopathy,
                                 a.GUPeniscircumcisedwithoutlesions,
                                 a.GUurethralmeatusnormallocationwithoutdischarge,
                                 a.GUtestesandepididymidesnormalsizewithoutmasses,
                                 a.GUscrotumwithoutlesions,
                                 a.IsActive,
                                 a.Createddate,
                                 a.CreatedBy,
                                 a.ModifiedDate,
                                 a.ModifiedBy
                             }).AsEnumerable().Select(xx => new PhysicalExamModel
                             {
                                 PhysicalExamID = xx.PhysicalExamID,
                                 PatientID = xx.PatientID,
                                 PatientVisitID = xx.PatientVisitID,
                                 RecordedDate = xx.RecordedDate,
                                 GeneralWellappearing = xx.GeneralWellappearing,
                                 Generalwellnourished = xx.Generalwellnourished,
                                 Generalinnodistress = xx.Generalinnodistress,
                                 GeneralOrientedx3 = xx.GeneralOrientedx3,
                                 Generalnormalmoodandaffect = xx.Generalnormalmoodandaffect,
                                 GeneralAmbulatingwithoutdifficulty = xx.GeneralAmbulatingwithoutdifficulty,
                                 SkinGoodturgor = xx.SkinGoodturgor,
                                 Skinnorash = xx.Skinnorash,
                                 Skinunusualbruisingorprominentlesions = xx.Skinunusualbruisingorprominentlesions,
                                 HairNormaltextureanddistribution = xx.HairNormaltextureanddistribution,
                                 NailsNormalcolor = xx.NailsNormalcolor,
                                 Nailsnodeformities = xx.Nailsnodeformities,
                                 HeadNormocephalic = xx.HeadNormocephalic,
                                 Headatraumatic = xx.Headatraumatic,
                                 Headnovisibleorpalpablemasses = xx.Headnovisibleorpalpablemasses,
                                 Headdepressions = xx.Headdepressions,
                                 Headorscaring = xx.Headorscaring,
                                 EyesVisualacuityintact = xx.EyesVisualacuityintact,
                                 Eyesconjunctivaclear = xx.Eyesconjunctivaclear,
                                 Eyesscleranonicteric = xx.Eyesscleranonicteric,
                                 EyesEOMintact = xx.EyesEOMintact,
                                 EyesPERRL = xx.EyesPERRL,
                                 Eyesfundihavenormalopticdiscsandvessels = xx.Eyesfundihavenormalopticdiscsandvessels,
                                 Eyesnoexudatesorhemorrhages = xx.Eyesnoexudatesorhemorrhages,
                                 EarsEACsclear = xx.EarsEACsclear,
                                 EarsTMstranslucentmobile = xx.EarsTMstranslucentmobile,
                                 Earsossiclesnlappearance = xx.Earsossiclesnlappearance,
                                 Earshearingintact = xx.Earshearingintact,
                                 NoseNoexternallesions = xx.NoseNoexternallesions,
                                 Nosemucosanoninflamed = xx.Nosemucosanoninflamed,
                                 Noseseptumandturbinatesnormal = xx.Noseseptumandturbinatesnormal,
                                 MouthMucousmembranesmoist = xx.MouthMucousmembranesmoist,
                                 Mouthnomucosallesions = xx.Mouthnomucosallesions,
                                 TeethGumsNoobviouscariesorperiodontaldisease = xx.TeethGumsNoobviouscariesorperiodontaldisease,
                                 TeethGumsNogingivalinflammationorsignificantresorption = xx.TeethGumsNogingivalinflammationorsignificantresorption,
                                 PharynxMucosanoninflamed = xx.PharynxMucosanoninflamed,
                                 Pharynxnotonsillarhypertrophyorexudate = xx.Pharynxnotonsillarhypertrophyorexudate,
                                 PharynxNogingivalinflammationorsignificantresorption = xx.PharynxNogingivalinflammationorsignificantresorption,
                                 NeckSupple = xx.NeckSupple,
                                 Neckwithoutlesions = xx.Neckwithoutlesions,
                                 Neckbruits = xx.Neckbruits,
                                 Neckoradenopathy = xx.Neckoradenopathy,
                                 Neckthyroidnonenlargedandnontender = xx.Neckthyroidnonenlargedandnontender,
                                 HeartNocardiomegalyorthrills = xx.HeartNocardiomegalyorthrills,
                                 Heartregularrateandrhythm = xx.Heartregularrateandrhythm,
                                 Heartnomurmurorgallop = xx.Heartnomurmurorgallop,
                                 HeartAmbulatingwithoutdifficulty = xx.HeartAmbulatingwithoutdifficulty,
                                 LungsCleartoauscultationandpercussion = xx.LungsCleartoauscultationandpercussion,
                                 AbdomenBowelsoundsnormal = xx.AbdomenBowelsoundsnormal,
                                 Abdomennotenderness = xx.Abdomennotenderness,
                                 Abdomenorganomegaly = xx.Abdomenorganomegaly,
                                 Abdomenmasses = xx.Abdomenmasses,
                                 Abdomenorhernia = xx.Abdomenorhernia,
                                 BackSpinenormalwithoutdeformityortenderness = xx.BackSpinenormalwithoutdeformityortenderness,
                                 BacknoCVAtenderness = xx.BacknoCVAtenderness,
                                 Backmasses = xx.Backmasses,
                                 Backorhernia = xx.Backorhernia,
                                 RectalNormalsphinctertone = xx.RectalNormalsphinctertone,
                                 Rectalnohemorrhoidsormassespalpable = xx.Rectalnohemorrhoidsormassespalpable,
                                 ExtremitiesNoamputationsordeformities = xx.ExtremitiesNoamputationsordeformities,
                                 Extremitiescyanosis = xx.Extremitiescyanosis,
                                 Extremitiesedemaorvaricosities = xx.Extremitiesedemaorvaricosities,
                                 Extremitiesperipheralpulsesintact = xx.Extremitiesperipheralpulsesintact,
                                 MusculoskeletalNormalgaitandstation = xx.MusculoskeletalNormalgaitandstation,
                                 MusculoskeletalNomisalignment = xx.MusculoskeletalNomisalignment,
                                 Musculoskeletalasymmetry = xx.Musculoskeletalasymmetry,
                                 Musculoskeletalcrepitation = xx.Musculoskeletalcrepitation,
                                 Musculoskeletaldefects = xx.Musculoskeletaldefects,
                                 Musculoskeletaltenderness = xx.Musculoskeletaltenderness,
                                 Musculoskeletalmasses = xx.Musculoskeletalmasses,
                                 Musculoskeletaleffusions = xx.Musculoskeletaleffusions,
                                 Musculoskeletaldecreasedrangeofmotion = xx.Musculoskeletaldecreasedrangeofmotion,
                                 Musculoskeletalinstability = xx.Musculoskeletalinstability,
                                 Musculoskeletalatrophyorabnormal = xx.Musculoskeletalatrophyorabnormal,
                                 NeurologicCN212normal = xx.NeurologicCN212normal,
                                 NeurologicSensationtopain = xx.NeurologicSensationtopain,
                                 Neurologictouch = xx.Neurologictouch,
                                 Neurologicandproprioceptionnormal = xx.Neurologicandproprioceptionnormal,
                                 NeurologicDTRsnormalinupperandlowerextremities = xx.NeurologicDTRsnormalinupperandlowerextremities,
                                 NeurologicNopathologicreflexes = xx.NeurologicNopathologicreflexes,
                                 PsychiatricOrientedX3 = xx.PsychiatricOrientedX3,
                                 Psychiatricintactrecentandremotememory = xx.Psychiatricintactrecentandremotememory,
                                 Psychiatricjudgmentandinsight = xx.Psychiatricjudgmentandinsight,
                                 Psychiatricnormalmoodandaffect = xx.Psychiatricnormalmoodandaffect,
                                 PelvicVaginaandcervixwithoutlesionsordischarge = xx.PelvicVaginaandcervixwithoutlesionsordischarge,
                                 PelvicUterusandadnexaParametrianontenderwithoutmasses = xx.PelvicUterusandadnexaParametrianontenderwithoutmasses,
                                 BreastNonippleabnormality = xx.BreastNonippleabnormality,
                                 Breastdominantmasses = xx.Breastdominantmasses,
                                 Breasttendernesstopalpation = xx.Breasttendernesstopalpation,
                                 Breastaxillaryorsupraclavicularadenopathy = xx.Breastaxillaryorsupraclavicularadenopathy,
                                 GUPeniscircumcisedwithoutlesions = xx.GUPeniscircumcisedwithoutlesions,
                                 GUurethralmeatusnormallocationwithoutdischarge = xx.GUurethralmeatusnormallocationwithoutdischarge,
                                 GUtestesandepididymidesnormalsizewithoutmasses = xx.GUtestesandepididymidesnormalsizewithoutmasses,
                                 GUscrotumwithoutlesions = xx.GUscrotumwithoutlesions,
                                 IsActive = xx.IsActive,
                                 Createddate = xx.Createddate,
                                 CreatedBy = xx.CreatedBy,
                                 ModifiedDate = xx.ModifiedDate,
                                 ModifiedBy = xx.ModifiedBy
                             }).ToList();

            List<PhysicalExamModel> physicaled = new List<PhysicalExamModel>();

            if (Physical.Count() > 0)
            {
                foreach (var physi in Physical)
                {
                    PhysicalExamModel mode = new PhysicalExamModel();

                    mode = physi;
                    mode.GeneralValue = this.getGeneral(physi);
                    mode.SkinValue = this.GetSkin(physi);
                    mode.HairValue = this.GetHair(physi);
                    mode.NailsValue = this.GetNails(physi);
                    mode.EyesValue = this.GetEyes(physi);
                    mode.EarsValue = this.GetEars(physi);
                    mode.NoseValue = this.GetNose(physi);
                    mode.MouthValue = this.GetMouth(physi);
                    mode.TeethGumsValue = this.GetTeethGums(physi);
                    mode.NeckValue = this.GetNeck(physi);
                    mode.HeartValue = this.GetHeart(physi);
                    mode.LungsValue = this.GetLungs(physi);
                    mode.AbdomenValue = this.GetAbdomen(physi);
                    mode.BackValue = this.GetBack(physi);
                    mode.RectalValue = this.GetRectal(physi);
                    mode.ExtremitiesValue = this.GetExtremities(physi);
                    mode.MusculoskeletalValue = this.GetMusculoskeletal(physi);
                    mode.NeurologicValue = this.getNeurologic(physi);
                    mode.PsychiatricValue = this.GetPsychiatric(physi);
                    mode.PelvicValue = this.GetPelvic(physi);
                    mode.BreastValue = this.GetBreast(physi);
                    mode.GUvalue = this.GetGU(physi);

                    physicaled.Add(mode);
                }
            }



            return physicaled;


         }

        public List<PhysicalExamModel> GetPhysicalExamModelsgetbyPhysicalExamID(int PhysicalExamID)
        {
            List<PhysicalExamModel> Physical = (from a in this._uow.GenericRepository<PhysicalExam>().Table().Where(x => x.PhysicalExamID == PhysicalExamID)
                                                join pat in this._uow.GenericRepository<Patient>().Table() on a.PatientID equals pat.PatientID
                                                select
                             new
                             {
                                 a.PhysicalExamID,
                                 a.PatientID,
                                 a.PatientVisitID,
                                 a.RecordedDate,
                                 a.GeneralWellappearing,
                                 a.Generalwellnourished,
                                 a.Generalinnodistress,
                                 a.GeneralOrientedx3,
                                 a.Generalnormalmoodandaffect,
                                 a.GeneralAmbulatingwithoutdifficulty,
                                 a.SkinGoodturgor,
                                 a.Skinnorash,
                                 a.Skinunusualbruisingorprominentlesions,
                                 a.HairNormaltextureanddistribution,
                                 a.NailsNormalcolor,
                                 a.Nailsnodeformities,
                                 a.HeadNormocephalic,
                                 a.Headatraumatic,
                                 a.Headnovisibleorpalpablemasses,
                                 a.Headdepressions,
                                 a.Headorscaring,
                                 a.EyesVisualacuityintact,
                                 a.Eyesconjunctivaclear,
                                 a.Eyesscleranonicteric,
                                 a.EyesEOMintact,
                                 a.EyesPERRL,
                                 a.Eyesfundihavenormalopticdiscsandvessels,
                                 a.Eyesnoexudatesorhemorrhages,
                                 a.EarsEACsclear,
                                 a.EarsTMstranslucentmobile,
                                 a.Earsossiclesnlappearance,
                                 a.Earshearingintact,
                                 a.NoseNoexternallesions,
                                 a.Nosemucosanoninflamed,
                                 a.Noseseptumandturbinatesnormal,
                                 a.MouthMucousmembranesmoist,
                                 a.Mouthnomucosallesions,
                                 a.TeethGumsNoobviouscariesorperiodontaldisease,
                                 a.TeethGumsNogingivalinflammationorsignificantresorption,
                                 a.PharynxMucosanoninflamed,
                                 a.Pharynxnotonsillarhypertrophyorexudate,
                                 a.PharynxNogingivalinflammationorsignificantresorption,
                                 a.NeckSupple,
                                 a.Neckwithoutlesions,
                                 a.Neckbruits,
                                 a.Neckoradenopathy,
                                 a.Neckthyroidnonenlargedandnontender,
                                 a.HeartNocardiomegalyorthrills,
                                 a.Heartregularrateandrhythm,
                                 a.Heartnomurmurorgallop,
                                 a.HeartAmbulatingwithoutdifficulty,
                                 a.LungsCleartoauscultationandpercussion,
                                 a.AbdomenBowelsoundsnormal,
                                 a.Abdomennotenderness,
                                 a.Abdomenorganomegaly,
                                 a.Abdomenmasses,
                                 a.Abdomenorhernia,
                                 a.BackSpinenormalwithoutdeformityortenderness,
                                 a.BacknoCVAtenderness,
                                 a.Backmasses,
                                 a.Backorhernia,
                                 a.RectalNormalsphinctertone,
                                 a.Rectalnohemorrhoidsormassespalpable,
                                 a.ExtremitiesNoamputationsordeformities,
                                 a.Extremitiescyanosis,
                                 a.Extremitiesedemaorvaricosities,
                                 a.Extremitiesperipheralpulsesintact,
                                 a.MusculoskeletalNormalgaitandstation,
                                 a.MusculoskeletalNomisalignment,
                                 a.Musculoskeletalasymmetry,
                                 a.Musculoskeletalcrepitation,
                                 a.Musculoskeletaldefects,
                                 a.Musculoskeletaltenderness,
                                 a.Musculoskeletalmasses,
                                 a.Musculoskeletaleffusions,
                                 a.Musculoskeletaldecreasedrangeofmotion,
                                 a.Musculoskeletalinstability,
                                 a.Musculoskeletalatrophyorabnormal,
                                 a.NeurologicCN212normal,
                                 a.NeurologicSensationtopain,
                                 a.Neurologictouch,
                                 a.Neurologicandproprioceptionnormal,
                                 a.NeurologicDTRsnormalinupperandlowerextremities,
                                 a.NeurologicNopathologicreflexes,
                                 a.PsychiatricOrientedX3,
                                 a.Psychiatricintactrecentandremotememory,
                                 a.Psychiatricjudgmentandinsight,
                                 a.Psychiatricnormalmoodandaffect,
                                 a.PelvicVaginaandcervixwithoutlesionsordischarge,
                                 a.PelvicUterusandadnexaParametrianontenderwithoutmasses,
                                 a.BreastNonippleabnormality,
                                 a.Breastdominantmasses,
                                 a.Breasttendernesstopalpation,
                                 a.Breastaxillaryorsupraclavicularadenopathy,
                                 a.GUPeniscircumcisedwithoutlesions,
                                 a.GUurethralmeatusnormallocationwithoutdischarge,
                                 a.GUtestesandepididymidesnormalsizewithoutmasses,
                                 a.GUscrotumwithoutlesions,
                                 a.IsActive,
                                 a.Createddate,
                                 a.CreatedBy,
                                 a.ModifiedDate,
                                 a.ModifiedBy
                             }).AsEnumerable().Select(xx => new PhysicalExamModel
                             {
                                 PhysicalExamID = xx.PhysicalExamID,
                                 PatientID = xx.PatientID,
                                 PatientVisitID = xx.PatientVisitID,
                                 RecordedDate = xx.RecordedDate,
                                 GeneralWellappearing = xx.GeneralWellappearing,
                                 Generalwellnourished = xx.Generalwellnourished,
                                 Generalinnodistress = xx.Generalinnodistress,
                                 GeneralOrientedx3 = xx.GeneralOrientedx3,
                                 Generalnormalmoodandaffect = xx.Generalnormalmoodandaffect,
                                 GeneralAmbulatingwithoutdifficulty = xx.GeneralAmbulatingwithoutdifficulty,
                                 SkinGoodturgor = xx.SkinGoodturgor,
                                 Skinnorash = xx.Skinnorash,
                                 Skinunusualbruisingorprominentlesions = xx.Skinunusualbruisingorprominentlesions,
                                 HairNormaltextureanddistribution = xx.HairNormaltextureanddistribution,
                                 NailsNormalcolor = xx.NailsNormalcolor,
                                 Nailsnodeformities = xx.Nailsnodeformities,
                                 HeadNormocephalic = xx.HeadNormocephalic,
                                 Headatraumatic = xx.Headatraumatic,
                                 Headnovisibleorpalpablemasses = xx.Headnovisibleorpalpablemasses,
                                 Headdepressions = xx.Headdepressions,
                                 Headorscaring = xx.Headorscaring,
                                 EyesVisualacuityintact = xx.EyesVisualacuityintact,
                                 Eyesconjunctivaclear = xx.Eyesconjunctivaclear,
                                 Eyesscleranonicteric = xx.Eyesscleranonicteric,
                                 EyesEOMintact = xx.EyesEOMintact,
                                 EyesPERRL = xx.EyesPERRL,
                                 Eyesfundihavenormalopticdiscsandvessels = xx.Eyesfundihavenormalopticdiscsandvessels,
                                 Eyesnoexudatesorhemorrhages = xx.Eyesnoexudatesorhemorrhages,
                                 EarsEACsclear = xx.EarsEACsclear,
                                 EarsTMstranslucentmobile = xx.EarsTMstranslucentmobile,
                                 Earsossiclesnlappearance = xx.Earsossiclesnlappearance,
                                 Earshearingintact = xx.Earshearingintact,
                                 NoseNoexternallesions = xx.NoseNoexternallesions,
                                 Nosemucosanoninflamed = xx.Nosemucosanoninflamed,
                                 Noseseptumandturbinatesnormal = xx.Noseseptumandturbinatesnormal,
                                 MouthMucousmembranesmoist = xx.MouthMucousmembranesmoist,
                                 Mouthnomucosallesions = xx.Mouthnomucosallesions,
                                 TeethGumsNoobviouscariesorperiodontaldisease = xx.TeethGumsNoobviouscariesorperiodontaldisease,
                                 TeethGumsNogingivalinflammationorsignificantresorption = xx.TeethGumsNogingivalinflammationorsignificantresorption,
                                 PharynxMucosanoninflamed = xx.PharynxMucosanoninflamed,
                                 Pharynxnotonsillarhypertrophyorexudate = xx.Pharynxnotonsillarhypertrophyorexudate,
                                 PharynxNogingivalinflammationorsignificantresorption = xx.PharynxNogingivalinflammationorsignificantresorption,
                                 NeckSupple = xx.NeckSupple,
                                 Neckwithoutlesions = xx.Neckwithoutlesions,
                                 Neckbruits = xx.Neckbruits,
                                 Neckoradenopathy = xx.Neckoradenopathy,
                                 Neckthyroidnonenlargedandnontender = xx.Neckthyroidnonenlargedandnontender,
                                 HeartNocardiomegalyorthrills = xx.HeartNocardiomegalyorthrills,
                                 Heartregularrateandrhythm = xx.Heartregularrateandrhythm,
                                 Heartnomurmurorgallop = xx.Heartnomurmurorgallop,
                                 HeartAmbulatingwithoutdifficulty = xx.HeartAmbulatingwithoutdifficulty,
                                 LungsCleartoauscultationandpercussion = xx.LungsCleartoauscultationandpercussion,
                                 AbdomenBowelsoundsnormal = xx.AbdomenBowelsoundsnormal,
                                 Abdomennotenderness = xx.Abdomennotenderness,
                                 Abdomenorganomegaly = xx.Abdomenorganomegaly,
                                 Abdomenmasses = xx.Abdomenmasses,
                                 Abdomenorhernia = xx.Abdomenorhernia,
                                 BackSpinenormalwithoutdeformityortenderness = xx.BackSpinenormalwithoutdeformityortenderness,
                                 BacknoCVAtenderness = xx.BacknoCVAtenderness,
                                 Backmasses = xx.Backmasses,
                                 Backorhernia = xx.Backorhernia,
                                 RectalNormalsphinctertone = xx.RectalNormalsphinctertone,
                                 Rectalnohemorrhoidsormassespalpable = xx.Rectalnohemorrhoidsormassespalpable,
                                 ExtremitiesNoamputationsordeformities = xx.ExtremitiesNoamputationsordeformities,
                                 Extremitiescyanosis = xx.Extremitiescyanosis,
                                 Extremitiesedemaorvaricosities = xx.Extremitiesedemaorvaricosities,
                                 Extremitiesperipheralpulsesintact = xx.Extremitiesperipheralpulsesintact,
                                 MusculoskeletalNormalgaitandstation = xx.MusculoskeletalNormalgaitandstation,
                                 MusculoskeletalNomisalignment = xx.MusculoskeletalNomisalignment,
                                 Musculoskeletalasymmetry = xx.Musculoskeletalasymmetry,
                                 Musculoskeletalcrepitation = xx.Musculoskeletalcrepitation,
                                 Musculoskeletaldefects = xx.Musculoskeletaldefects,
                                 Musculoskeletaltenderness = xx.Musculoskeletaltenderness,
                                 Musculoskeletalmasses = xx.Musculoskeletalmasses,
                                 Musculoskeletaleffusions = xx.Musculoskeletaleffusions,
                                 Musculoskeletaldecreasedrangeofmotion = xx.Musculoskeletaldecreasedrangeofmotion,
                                 Musculoskeletalinstability = xx.Musculoskeletalinstability,
                                 Musculoskeletalatrophyorabnormal = xx.Musculoskeletalatrophyorabnormal,
                                 NeurologicCN212normal = xx.NeurologicCN212normal,
                                 NeurologicSensationtopain = xx.NeurologicSensationtopain,
                                 Neurologictouch = xx.Neurologictouch,
                                 Neurologicandproprioceptionnormal = xx.Neurologicandproprioceptionnormal,
                                 NeurologicDTRsnormalinupperandlowerextremities = xx.NeurologicDTRsnormalinupperandlowerextremities,
                                 NeurologicNopathologicreflexes = xx.NeurologicNopathologicreflexes,
                                 PsychiatricOrientedX3 = xx.PsychiatricOrientedX3,
                                 Psychiatricintactrecentandremotememory = xx.Psychiatricintactrecentandremotememory,
                                 Psychiatricjudgmentandinsight = xx.Psychiatricjudgmentandinsight,
                                 Psychiatricnormalmoodandaffect = xx.Psychiatricnormalmoodandaffect,
                                 PelvicVaginaandcervixwithoutlesionsordischarge = xx.PelvicVaginaandcervixwithoutlesionsordischarge,
                                 PelvicUterusandadnexaParametrianontenderwithoutmasses = xx.PelvicUterusandadnexaParametrianontenderwithoutmasses,
                                 BreastNonippleabnormality = xx.BreastNonippleabnormality,
                                 Breastdominantmasses = xx.Breastdominantmasses,
                                 Breasttendernesstopalpation = xx.Breasttendernesstopalpation,
                                 Breastaxillaryorsupraclavicularadenopathy = xx.Breastaxillaryorsupraclavicularadenopathy,
                                 GUPeniscircumcisedwithoutlesions = xx.GUPeniscircumcisedwithoutlesions,
                                 GUurethralmeatusnormallocationwithoutdischarge = xx.GUurethralmeatusnormallocationwithoutdischarge,
                                 GUtestesandepididymidesnormalsizewithoutmasses = xx.GUtestesandepididymidesnormalsizewithoutmasses,
                                 GUscrotumwithoutlesions = xx.GUscrotumwithoutlesions,
                                 IsActive = xx.IsActive,
                                 Createddate = xx.Createddate,
                                 CreatedBy = xx.CreatedBy,
                                 ModifiedDate = xx.ModifiedDate,
                                 ModifiedBy = xx.ModifiedBy
                             }).ToList();


            List<PhysicalExamModel> physicaled = new List<PhysicalExamModel>();

            if (Physical.Count() >0)
            {
                foreach(var physi in Physical)
                {
                    PhysicalExamModel mode = new PhysicalExamModel();

                    mode = physi;
                    mode.GeneralValue = this.getGeneral(physi);
                    mode.SkinValue = this.GetSkin(physi);
                    mode.HairValue = this.GetHair(physi);
                    mode.NailsValue = this.GetNails(physi);
                    mode.EyesValue = this.GetEyes(physi);
                    mode.EarsValue = this.GetEars(physi);
                    mode.NoseValue = this.GetNose(physi);
                    mode.MouthValue = this.GetMouth(physi);
                    mode.TeethGumsValue = this.GetTeethGums(physi);
                    mode.NeckValue = this.GetNeck(physi);
                    mode.HeartValue = this.GetHeart(physi);
                    mode.LungsValue = this.GetLungs(physi);
                    mode.AbdomenValue = this.GetAbdomen(physi);
                    mode.BackValue = this.GetBack(physi);
                    mode.RectalValue = this.GetRectal(physi);
                    mode.ExtremitiesValue = this.GetExtremities(physi);
                    mode.MusculoskeletalValue = this.GetMusculoskeletal(physi);
                    mode.NeurologicValue = this.getNeurologic(physi);
                    mode.PsychiatricValue = this.GetPsychiatric(physi);
                    mode.PelvicValue = this.GetPelvic(physi);
                    mode.BreastValue = this.GetBreast(physi);
                    mode.GUvalue = this.GetGU(physi);

                    physical.Add(mode);
                }
            }



            return physicaled;


        }

        public string getGeneral(PhysicalExamModel physical)
        {
            string collectValue = "";

            if (physical.GeneralWellappearing == true)
            {
                collectValue = collectValue == "" ? "Well appearing" : (collectValue + ",Well appearing");
            }
            if(physical.Generalwellnourished == true)
            {
                collectValue = collectValue == "" ? "well nourished" : (collectValue + ",well nourished");
            }

            if(physical.Generalinnodistress == true)
            {
                collectValue = collectValue == "" ? "in no distress" : (collectValue + ",in no distress");
            }

            if(physical.GeneralOrientedx3 == true)
            {
                collectValue = collectValue == "" ? "Oriented x 3" : (collectValue + ",Oriented x 3");
            }

            if(physical.Generalnormalmoodandaffect == true)
            {
                collectValue = collectValue == "" ? "normal mood and affect" : (collectValue + ",normal mood and affect");
            }
            
            if(physical.GeneralAmbulatingwithoutdifficulty == true)
            {
                collectValue = collectValue == "" ? "Ambulating without difficulty" : (collectValue + ",Ambulating without difficulty");
            }

            return collectValue;
        }

        public string GetSkin(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.SkinGoodturgor == true)
            {
                collectValue = collectValue == "" ? "Good turgor" : (collectValue + ",Good turgor"); 
            }
            
            if(physical.Skinnorash == true)
            {
                collectValue = collectValue == "" ? "no rash" : (collectValue + ",no rash");
            }

            if(physical.Skinunusualbruisingorprominentlesions == true)
            {
                collectValue = collectValue == "" ? "unusual bruising or prominent lesions" : (collectValue + ",unusual bruising or prominent lesions");
            }

            return collectValue;

        }

        public string GetHair(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.HairNormaltextureanddistribution == true)
            {
                collectValue = collectValue == "" ? "Normal texture and distribution" : (collectValue + ",Normal texture and distribution");
            }
            return collectValue;
        }


        public string GetNails(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.NailsNormalcolor == true)
            {
                collectValue = collectValue == "" ? "Normal color" : (collectValue + ",Normal color");
            }

            if(physical.Nailsnodeformities == true)
            {
                collectValue = collectValue == "" ? "no deformities" : (collectValue + ",no deformities");
            }

            return collectValue;
        }

        public string GetHead(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.HeadNormocephalic == true)
            {
                collectValue = collectValue == "" ? "Normocephalic" : (collectValue + ",Normocephalic");
            }
            if(physical.Headatraumatic == true)
            {
                collectValue = collectValue == "" ? "atraumatic" : (collectValue + ",atraumatic");
            }

            if(physical.Headnovisibleorpalpablemasses == true)
            {
                collectValue = collectValue == "" ? "no visible or palpable masses" : (collectValue + ",no visible or palpable masses");
            }
            if(physical.Headdepressions == true)
            {
                collectValue = collectValue == "" ? "depressions" : (collectValue + ",depressions");
            }
            if(physical.Headorscaring == true)
            {
                collectValue = collectValue == "" ? "or scaring" : (collectValue + ",or scaring");
            }

            return collectValue;
        }

        public string GetEyes(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.EyesVisualacuityintact == true)
            {
                collectValue = collectValue == "" ? "Visual acuity intact" : (collectValue + ",Visual acuity intact");
            }
            if(physical.Eyesconjunctivaclear == true)
            {
                collectValue = collectValue == "" ? "conjunctiva clear" : (collectValue + ", conjunctiva clear");
            }
            if(physical.Eyesscleranonicteric == true)
            {
                collectValue = collectValue == "" ? "sclera non-icteric" : (collectValue + ",sclera non-icteric");
            }
            if(physical.EyesEOMintact == true)
            {
                collectValue = collectValue == "" ? "EOM intact" : (collectValue + ",EOM intact");
            }
            if(physical.EyesPERRL == true)
            {
                collectValue = collectValue == "" ? "PERRL" : (collectValue + ",PERRL");
            }
            if(physical.Eyesfundihavenormalopticdiscsandvessels == true)
            {
                collectValue = collectValue == "" ? "fundi have normal optic discs and vessels" : (collectValue + ",fundi have normal optic discs and vessels");
            }
            if(physical.Eyesnoexudatesorhemorrhages == true)
            {
                collectValue = collectValue == "" ? "no exudates or hemorrhages" : (collectValue + ",no exudates or hemorrhages");
            }

            return collectValue;
        }

        public string GetEars(PhysicalExamModel physical)
        {
            string collectValue = "";

            if(physical.EarsEACsclear == true)
            {
                collectValue = collectValue == "" ? "EACs clear" : (collectValue + ",EACs clear");
            }
            if(physical.EarsTMstranslucentmobile == true)
            {
                collectValue = collectValue == "" ? "TMs translucent & mobile" : (collectValue + ",TMs translucent & mobile");
            }
            if(physical.Earsossiclesnlappearance == true)
            {
                collectValue = collectValue == "" ? "ossicles nl appearance" : (collectValue + ",ossicles nl appearance");
            }
            if(physical.Earshearingintact == true)
            {
                collectValue = collectValue == "" ? "hearing intact" : (collectValue + ",hearing intact");
            }

            return collectValue;

        }

        public string GetNose(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.NoseNoexternallesions == true)
            {
                collectValue = collectValue == "" ? "No external lesions" : (collectValue + ",No external lesions");
            }
            if(physical.Nosemucosanoninflamed == true)
            {
                collectValue = collectValue == "" ? "mucosa non-inflamed" : (collectValue + ",mucosa non-inflamed");
            }
            if(physical.Noseseptumandturbinatesnormal == true)
            {
                collectValue = collectValue == "" ? "septum and turbinates normal" : (collectValue + ",septum and turbinates normal");
            }

            return collectValue;
        }

        public string GetMouth(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.MouthMucousmembranesmoist == true)
            {
                collectValue = collectValue == "" ? "Mucous membranes moist" : (collectValue + ",Mucous membranes moist");
            }
            if(physical.Mouthnomucosallesions == true)
            {
                collectValue = collectValue == "" ? "no mucosal lesions" : (collectValue + ",no mucosal lesions");
            }

            return collectValue;
        }

        public string GetTeethGums(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.TeethGumsNoobviouscariesorperiodontaldisease == true)
            {
                collectValue = collectValue == "" ? "No obvious caries or periodontal disease" : (collectValue + ",No obvious caries or periodontal disease");
            }
            if(physical.TeethGumsNogingivalinflammationorsignificantresorption == true)
            {
                collectValue = collectValue == "" ? "No gingival inflammation or significant resorption." : (collectValue + ",No gingival inflammation or significant resorption.");
            }

            return collectValue;
        }

        public string GetPharynx(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.PharynxMucosanoninflamed == true)
            {
                collectValue = collectValue == "" ? "Mucosa non-inflamed" : (collectValue + ",Mucosa non-inflamed");
            }
            if(physical.Pharynxnotonsillarhypertrophyorexudate == true)
            {
                collectValue = collectValue == "" ? "no tonsillar hypertrophy or exudate" : (collectValue + ",no tonsillar hypertrophy or exudate");
            }
            if(physical.PharynxNogingivalinflammationorsignificantresorption == true)
            {
                collectValue = collectValue == "" ? "No gingival inflammation or significant resorption." : (collectValue + ", No gingival inflammation or significant resorption.");
            }

            return collectValue;
        }

        public string GetNeck(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.NeckSupple == true)
            {
                collectValue = collectValue == "" ? "Supple" : (collectValue + ",Supple");
            }
            if(physical.Neckwithoutlesions == true)
            {
                collectValue = collectValue == "" ? "without lesions" : (collectValue + ",without lesions");
            }
            if(physical.Neckbruits == true)
            {
                collectValue = collectValue == "" ? "bruits" : (collectValue + ",bruits");
            }
            if(physical.Neckoradenopathy == true)
            {
                collectValue = collectValue == "" ? "or adenopathy" : (collectValue + ",or adenopathy");
                    
            }
            if(physical.Neckthyroidnonenlargedandnontender == true)
            {
                collectValue = collectValue == "" ? "thyroid non-enlarged and non-tender" : (collectValue + ",thyroid non-enlarged and non-tender");
            }

            return collectValue;

        }

        public string GetHeart(PhysicalExamModel physical)
        {
            string collectValue = "";

            if(physical.HeartNocardiomegalyorthrills == true)
            {
                collectValue = collectValue == "" ? "No cardiomegaly or thrills" : (collectValue + ",No cardiomegaly or thrills");
            }
            if(physical.Heartregularrateandrhythm == true)
            {
                collectValue = collectValue == "" ? "regular rate and rhythm" : (collectValue + ",regular rate and rhythm");
            }
            if(physical.Heartnomurmurorgallop == true)
            {
                collectValue = collectValue == "" ? "no murmur or gallop" : (collectValue + ",no murmur or gallop");
            }
            if(physical.HeartAmbulatingwithoutdifficulty == true)
            {
                collectValue = collectValue == "" ? "Ambulating without difficulty" : (collectValue + ",Ambulating without difficulty");
            }

            return collectValue;
        }

        public string GetLungs(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.LungsCleartoauscultationandpercussion == true)
            {
                collectValue = collectValue == "" ? "Clear to auscultation and percussion" : (collectValue + ",Clear to auscultation and percussion");
            }

            return collectValue;
        }

        public string GetAbdomen(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.AbdomenBowelsoundsnormal == true)
            {
                collectValue = collectValue == "" ? "Bowel sounds normal" : (collectValue + ",Bowel sounds normal");
            }
            if(physical.Abdomennotenderness == true)
            {
                collectValue = collectValue == "" ? "no tenderness" : (collectValue + ",no tenderness");
            }
            if(physical.Abdomenorganomegaly == true)
            {
                collectValue = collectValue == "" ? "organomegaly" : (collectValue + ",organomegaly");
            }
            if(physical.Abdomenmasses == true)
            {
                collectValue = collectValue == "" ? "masses" : (collectValue + ",masses");
            }
            if(physical.Abdomenorhernia == true)
            {
                collectValue = collectValue == "" ? "or hernia" : (collectValue + ",or hernia");
            }

            return collectValue;

        }

        public string GetBack(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.BackSpinenormalwithoutdeformityortenderness == true)
            {
                collectValue = collectValue == "" ? "Spine normal without deformity or tenderness": (collectValue + ",Spine normal without deformity or tenderness");
            }
            if(physical.BacknoCVAtenderness == true)
            {
                collectValue = collectValue == "" ? "no CVA tenderness" : (collectValue + ",no CVA tenderness");
            }
            if(physical.Backmasses == true)
            {
                collectValue = collectValue == "" ? "masses" : (collectValue + ",masses");
            }
            if(physical.Backorhernia ==true)
            {
                collectValue = collectValue == "" ? "or hernia" : (collectValue + ",or hernia");
            }

            return collectValue;

        }
        public string GetRectal(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.RectalNormalsphinctertone == true)
            {
                collectValue = collectValue == "" ? "Normal sphincter tone" : (collectValue + ",Normal sphincter tone");
            }
            if(physical.Rectalnohemorrhoidsormassespalpable == true)
            {
                collectValue = collectValue == "" ? "no hemorrhoids or masses palpable" : (collectValue + ",no hemorrhoids or masses palpable");
            }

            return collectValue;

        }

        public string GetExtremities(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.ExtremitiesNoamputationsordeformities == true)
            {
                collectValue = collectValue == "" ? "No amputations or deformities" : (collectValue + ",No amputations or deformities");
            }
            if(physical.Extremitiescyanosis == true)
            {
                collectValue = collectValue == "" ? "cyanosis" : (collectValue + ",cyanosis");
            }
            if(physical.Extremitiesedemaorvaricosities == true)
            {
                collectValue = collectValue == "" ? "edema or varicosities" : (collectValue + ",edema or varicosities");
            }
            if(physical.Extremitiesperipheralpulsesintact == true)
            {
                collectValue = collectValue == "" ? "peripheral pulses intact" : (collectValue + ",peripheral pulses intact");
            }

            return collectValue;
        }

        public string GetMusculoskeletal(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.MusculoskeletalNormalgaitandstation == true)
            {
                collectValue = collectValue == "" ? "Normal gait and station." : (collectValue + ",Normal gait and station.");
            }
            if(physical.MusculoskeletalNomisalignment == true)
            {
                collectValue = collectValue == "" ? "No misalignment" : (collectValue + ",No misalignment");
            }
            if(physical.Musculoskeletalasymmetry == true)
            {
                collectValue = collectValue == "" ? "asymmetry" : (collectValue + ",asymmetry");
            }
            if(physical.Musculoskeletalcrepitation == true)
            {
                collectValue = collectValue == "" ? "crepitation" : (collectValue + ",crepitation");
            }
            if (physical.Musculoskeletaldefects == true)
            {
                collectValue = collectValue == "" ? "defects" : (collectValue + ",defects");
            }
            if(physical.Musculoskeletaltenderness == true)
            {
                collectValue = collectValue == "" ? "tenderness" : (collectValue + ",tenderness");
            }
            if(physical.Musculoskeletalmasses == true)
            {
                collectValue = collectValue == "" ? "masses" : (collectValue + ",masses");
            }
            if(physical.Musculoskeletaleffusions == true)
            {
                collectValue = collectValue == "" ? "effusions" : (collectValue + ",effusions");
            }
            if(physical.Musculoskeletaldecreasedrangeofmotion == true)
            {
                collectValue = collectValue == "" ? "decreased range of motion" : (collectValue + ",decreased range of motion");
            }
            if(physical.Musculoskeletalinstability == true)
            {
                collectValue = collectValue == "" ? "instability" : (collectValue + ",instability");
            }
            if(physical.Musculoskeletalatrophyorabnormal == true)
            {
                collectValue = collectValue == "" ? "atrophy or abnormal" : (collectValue + ",atrophy or abnormal");
            }

            return collectValue;

        }

        public string getNeurologic(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.NeurologicCN212normal == true)
            {
                collectValue = collectValue == "" ? "CN 2-12 normal" : (collectValue + ",CN 2-12 normal");
            }
            if(physical.NeurologicSensationtopain == true)
            {
                collectValue = collectValue == "" ? "Sensation to pain" : (collectValue + ",Sensation to pain");
            }
            if(physical.Neurologictouch == true)
            {
                collectValue = collectValue == "" ? "touch" : (collectValue + ",touch");
            }
            if(physical.Neurologicandproprioceptionnormal == true)
            {
                collectValue = collectValue == "" ? "and proprioception normal" : (collectValue + ",and proprioception normal");
            }
            if(physical.NeurologicDTRsnormalinupperandlowerextremities == true)
            {
                collectValue = collectValue == "" ? "DTRs normal in upper and lower extremities" : (collectValue + ",DTRs normal in upper and lower extremities");
            }
            if(physical.NeurologicNopathologicreflexes == true)
            {
                collectValue = collectValue == "" ? "No pathologic reflexes" : (collectValue + ",No pathologic reflexes");
            }

            return collectValue;
        }

        public string GetPsychiatric(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.PsychiatricOrientedX3 == true)
            {
                collectValue = collectValue == "" ? "Oriented X3" : (collectValue + ",Oriented X3");
            }
            if(physical.Psychiatricintactrecentandremotememory == true)
            {
                collectValue = collectValue == "" ? "intact recent and remote memory" : (collectValue + ",intact recent and remote memory");
            }
            if(physical.Psychiatricjudgmentandinsight == true)
            {
                collectValue = collectValue == "" ? "judgment and insight" : (collectValue + ",judgment and insight");
            }
            if(physical.Psychiatricnormalmoodandaffect == true)
            {
                collectValue = collectValue == "" ? "normal mood and affect" : (collectValue + ",normal mood and affect");
            }

            return collectValue;
        }

        public string GetPelvic(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.PelvicVaginaandcervixwithoutlesionsordischarge == true)
            {
                collectValue = collectValue == "" ? "Vagina and cervix without lesions or discharge" : (collectValue + ",Vagina and cervix without lesions or discharge");
            }
            if(physical.PelvicUterusandadnexaParametrianontenderwithoutmasses == true)
            {
                collectValue = collectValue == "" ? "Uterus and adnexa/parametria nontender without masses" : (collectValue + ",Uterus and adnexa/parametria nontender without masses");
            }
            return collectValue;
        }

        public string GetBreast(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.BreastNonippleabnormality == true)
            {
                collectValue = collectValue == "" ? "No nipple abnormality" : (collectValue + ",No nipple abnormality");
            }
            if(physical.Breastdominantmasses == true)
            {
                collectValue = collectValue == "" ? "dominant masses" : (collectValue + ",dominant masses");
            }
            if(physical.Breasttendernesstopalpation == true)
            {
                collectValue = collectValue == "" ? "tenderness to palpation" : (collectValue + ",tenderness to palpation");
            }
            if(physical.Breastaxillaryorsupraclavicularadenopathy == true)
            {
                collectValue = collectValue == "" ? "axillary or supraclavicular adenopathy" : (collectValue + ",axillary or supraclavicular adenopathy");
            }
            return collectValue;
        }

        public string GetGU(PhysicalExamModel physical)
        {
            string collectValue = "";
            if(physical.GUPeniscircumcisedwithoutlesions == true)
            {
                collectValue = collectValue == "" ? "Penis circumcised without lesions" : (collectValue + ",Penis circumcised without lesions");
            }
            if(physical.GUurethralmeatusnormallocationwithoutdischarge == true)
            {
                collectValue = collectValue == "" ? "urethral meatus normal location without discharge" : (collectValue + ",urethral meatus normal location without discharge");
            }
            if(physical.GUtestesandepididymidesnormalsizewithoutmasses == true)
            {
                collectValue = collectValue == "" ? "testes and epididymides normal size without masses" : (collectValue + ",testes and epididymides normal size without masses");
            }
            if(physical.GUscrotumwithoutlesions == true)
            {
                collectValue = collectValue == "" ? "scrotum without lesions" : (collectValue + ",scrotum without lesions");
            }

            return collectValue;
        }











    }
}
