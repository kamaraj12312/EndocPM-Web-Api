using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EndocPM.WebAPI
{
    public class EPrescriptionService : IEPrescriptionService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _iMasterService;
        public EPrescriptionService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService iMasterService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _iMasterService = iMasterService;
        }
        #region getPharmacyList
        public List<PharmacyModel> GetPharmacyList()
        {
            var query = (from ph in this._uow.GenericRepository<Pharmacy>().Table().Where(ph => ph.Deleted != true)
                         select new
                         {
                             PharmacyID = ph.PharmacyID,
                             NPI = ph.NPI,
                             PharmacyName = ph.PharmacyName,
                             Address = ph.AddressLine1 + " " + ph.AddressLine2,
                             Country = ph.Country,
                             Zip = ph.ZIP,
                             County = ph.County,
                             City = ph.City,
                             State = ph.State,
                             Telephone = ph.Telephone,
                             CreatedDate = ph.CreatedDate,
                             CreatedBy = ph.CreatedBy,
                             ModifiedDate = ph.ModifiedDate,
                             ModifiedBy = ph.ModifiedBy
                         }).AsEnumerable().Select(PH => new PharmacyModel
                         {
                             PharmacyID = PH.PharmacyID,
                             NPI = PH.NPI,
                             PharmacyName = PH.PharmacyName,
                             Address = PH.Address,
                             ZIP = PH.Zip,
                             Country = PH.Country,
                             City = PH.City,
                             County = PH.County,
                             State = PH.State,
                             Telephone = PH.Telephone,
                             CreatedDate = PH.CreatedDate,
                             CreatedBy = PH.CreatedBy,
                             ModifiedDate = PH.ModifiedDate,
                             ModifiedBy = PH.ModifiedBy


                         }).ToList();
            return query;
        }
        #endregion
        #region get list Rxhistory
        public List<RxImportHistoryModel> GetRxImportHistories()
        {
            var rximporthistory = (from rx in this._uow.GenericRepository<RxImportHistory>().Table().Where(x => x.Deleted != true)
                                   select
                                   new
                                   {
                                       rx.RxImportHistoryID,
                                       rx.TransmissionStatus,
                                       rx.IssuedDate,
                                       rx.DiscontinuedDate,
                                       rx.IssueType,
                                       rx.Prescriber,
                                       rx.DrugName,
                                       rx.SIG,
                                       rx.Quantity,
                                       rx.Refills,
                                       rx.RxStatusAuthorized,
                                       rx.DaysLeft,
                                       rx.RxType,
                                       rx.Person,
                                       rx.RxStatus,
                                       rx.RxObjid,
                                       rx.CreatedBy,
                                       rx.PatientAccount,
                                       rx.SupervisingPhysiciansDEA,
                                       rx.SupervisingPhysiciansNPI,
                                       rx.DrugID,
                                       rx.PharmacyID,
                                       rx.Diagnosis,
                                       rx.PharmacyName,
                                       rx.PharmacyAddressLine1,
                                       rx.PharmacyAddressLine2,
                                       rx.PharmacyCity,
                                       rx.PharmacyState,
                                       rx.PharmacyZip,
                                       rx.GenericCode,
                                       rx.PatientID,
                                       rx.ProviderID,
                                       rx.SupervisingProviderID,
                                       rx.Deleted,
                                       rx.CreatedDate,
                                       rx.ModifiedBy,
                                       rx.ModifiedDate,
                                       rx.RxNormConceptID,
                                       rx.RxNormCode,
                                       rx.NationalDrugCodeID,
                                       rx.PatientVisitID,
                                       rx.IsFormularyCheck
                                   }).AsEnumerable().Select(rxh => new RxImportHistoryModel
                                   {
                                       RxImportHistoryID = rxh.RxImportHistoryID,
                                       TransmissionStatus = rxh.TransmissionStatus,
                                       IssuedDate = rxh.IssuedDate,
                                       DiscontinuedDate = rxh.DiscontinuedDate,
                                       IssueType = rxh.IssueType,
                                       Prescriber = rxh.Prescriber,
                                       DrugName = rxh.DrugName,
                                       SIG = rxh.SIG,
                                       Quantity = rxh.Quantity,
                                       Refills = rxh.Refills,
                                       RxStatusAuthorized = rxh.RxStatusAuthorized,
                                       DaysLeft = rxh.DaysLeft,
                                       RxType = rxh.RxType,
                                       Person = rxh.Person,
                                       RxStatus = rxh.RxStatus,
                                       RxObjid = rxh.RxObjid,
                                       CreatedBy = rxh.CreatedBy,
                                       PatientAccount = rxh.PatientAccount,
                                       SupervisingPhysiciansDEA = rxh.SupervisingPhysiciansDEA,
                                       SupervisingPhysiciansNPI = rxh.SupervisingPhysiciansDEA,
                                       DrugID = rxh.DrugID,
                                       PharmacyID = rxh.PharmacyID,
                                       Diagnosis = rxh.Diagnosis,
                                       PharmacyName = rxh.PharmacyName,
                                       PharmacyAddressLine1 = rxh.PharmacyAddressLine1,
                                       PharmacyAddressLine2 = rxh.PharmacyAddressLine2,
                                       PharmacyCity = rxh.PharmacyCity,
                                       PharmacyState = rxh.PharmacyState,
                                       PharmacyZip = rxh.PharmacyZip,
                                       GenericCode = rxh.GenericCode,
                                       PatientID = rxh.PatientID,
                                       ProviderID = rxh.ProviderID,
                                       SupervisingProviderID = rxh.SupervisingProviderID,
                                       Deleted = rxh.Deleted,
                                       CreatedDate = rxh.CreatedDate,
                                       ModifiedBy = rxh.ModifiedBy,
                                       ModifiedDate = rxh.ModifiedDate,
                                       RxNormConceptID = rxh.RxNormConceptID,
                                       RxNormCode = rxh.RxNormCode,
                                       NationalDrugCodeID = rxh.NationalDrugCodeID,
                                       PatientVisitID = rxh.PatientVisitID,
                                       IsFormularyCheck = rxh.IsFormularyCheck
                                   }).ToList();

            return rximporthistory;
        }
        #endregion
        #region get singlE id called on GetRxhistory
        public List<RxImportHistoryModel> getBypatientIDRxImportHistories(int PatientID)
        {
            var rximporthistory = (from rx in this._uow.GenericRepository<RxImportHistory>().Table().Where(x => x.Deleted != true & x.PatientID == PatientID)
                                       //  join a in this._uow.GenericRepository<Patient>().Table() on rx.PatientID equals a.PatientID
                                   select
                                   new
                                   {
                                       rx.RxImportHistoryID,
                                       rx.TransmissionStatus,
                                       rx.IssuedDate,
                                       rx.DiscontinuedDate,
                                       rx.IssueType,
                                       rx.Prescriber,
                                       rx.DrugName,
                                       rx.SIG,
                                       rx.Quantity,
                                       rx.Refills,
                                       rx.RxStatusAuthorized,
                                       rx.DaysLeft,
                                       rx.RxType,
                                       rx.Person,
                                       rx.RxStatus,
                                       rx.RxObjid,
                                       rx.CreatedBy,
                                       rx.PatientAccount,
                                       rx.SupervisingPhysiciansDEA,
                                       rx.SupervisingPhysiciansNPI,
                                       rx.DrugID,
                                       rx.PharmacyID,
                                       rx.Diagnosis,
                                       rx.PharmacyName,
                                       rx.PharmacyAddressLine1,
                                       rx.PharmacyAddressLine2,
                                       rx.PharmacyCity,
                                       rx.PharmacyState,
                                       rx.PharmacyZip,
                                       rx.GenericCode,
                                       rx.PatientID,
                                       rx.ProviderID,
                                       rx.SupervisingProviderID,
                                       rx.Deleted,
                                       rx.CreatedDate,
                                       rx.ModifiedBy,
                                       rx.ModifiedDate,
                                       rx.RxNormConceptID,
                                       rx.RxNormCode,
                                       rx.NationalDrugCodeID,
                                       rx.PatientVisitID,
                                       rx.IsFormularyCheck
                                   }).AsEnumerable().Select(rxh => new RxImportHistoryModel
                                   {
                                       RxImportHistoryID = rxh.RxImportHistoryID,
                                       TransmissionStatus = rxh.TransmissionStatus,
                                       IssuedDate = rxh.IssuedDate,
                                       DiscontinuedDate = rxh.DiscontinuedDate,
                                       IssueType = rxh.IssueType,
                                       Prescriber = rxh.Prescriber,
                                       DrugName = rxh.DrugName,
                                       SIG = rxh.SIG,
                                       Quantity = rxh.Quantity,
                                       Refills = rxh.Refills,
                                       RxStatusAuthorized = rxh.RxStatusAuthorized,
                                       DaysLeft = rxh.DaysLeft,
                                       RxType = rxh.RxType,
                                       Person = rxh.Person,
                                       RxStatus = rxh.RxStatus,
                                       RxObjid = rxh.RxObjid,
                                       CreatedBy = rxh.CreatedBy,
                                       PatientAccount = rxh.PatientAccount,
                                       SupervisingPhysiciansDEA = rxh.SupervisingPhysiciansDEA,
                                       SupervisingPhysiciansNPI = rxh.SupervisingPhysiciansDEA,
                                       DrugID = rxh.DrugID,
                                       PharmacyID = rxh.PharmacyID,
                                       Diagnosis = rxh.Diagnosis,
                                       PharmacyName = rxh.PharmacyName,
                                       PharmacyAddressLine1 = rxh.PharmacyAddressLine1,
                                       PharmacyAddressLine2 = rxh.PharmacyAddressLine2,
                                       PharmacyCity = rxh.PharmacyCity,
                                       PharmacyState = rxh.PharmacyState,
                                       PharmacyZip = rxh.PharmacyZip,
                                       GenericCode = rxh.GenericCode,
                                       PatientID = rxh.PatientID,
                                       ProviderID = rxh.ProviderID,
                                       SupervisingProviderID = rxh.SupervisingProviderID,
                                       Deleted = rxh.Deleted,
                                       CreatedDate = rxh.CreatedDate,
                                       ModifiedBy = rxh.ModifiedBy,
                                       ModifiedDate = rxh.ModifiedDate,
                                       RxNormConceptID = rxh.RxNormConceptID,
                                       RxNormCode = rxh.RxNormCode,
                                       NationalDrugCodeID = rxh.NationalDrugCodeID,
                                       PatientVisitID = rxh.PatientVisitID,
                                       IsFormularyCheck = rxh.IsFormularyCheck
                                   }).ToList();

            return rximporthistory;
        }
        #endregion

        #region  this get SIGMODEL
        public List<SigCodeModel> GetSigCodes()
        {
            var sigcode = (from si in this._uow.GenericRepository<SigCode>().Table().Where(x => x.Deleted != true)
                           select new
                           {
                               si.SigCodeID,
                               si.Code,
                               si.Description,
                               si.Deleted,
                               si.CreatedDate,
                               si.CreatedBy,
                               si.ModifiedDate,
                               si.ModifiedBy
                           }).AsEnumerable().Select(sig => new SigCodeModel
                           {
                               SigCodeID = sig.SigCodeID,
                               Code = sig.Code,
                               Description = sig.Description,
                               Deleted = sig.Deleted,
                               CreatedDate = sig.CreatedDate,
                               CreatedBy = sig.CreatedBy,
                               ModifiedDate = sig.ModifiedDate,
                               ModifiedBy = sig.ModifiedBy,
                           }).ToList();

            return sigcode;
        }
        #endregion

        #region   This called on GetEprescriptionmodel
        public List<EPrescriptionModel> GetEPrescriptionModels()
        {
            var query = (from ep in this._uow.GenericRepository<EPrescription>().Table()
                         join ps in this._uow.GenericRepository<PrescriptionStatus>().Table() on ep.PrescriptionStatusID equals ps.PrescriptionStatusID into ePrescription
                         from ePs in ePrescription  //.DefaultIfEmpty()
                         join pr in this._uow.GenericRepository<Provider>().Table() on ep.PrescriberID equals pr.ProviderID into ePrescriptionWithProvider
                         from ePwp in ePrescriptionWithProvider   //.DefaultIfEmpty()
                         join ph in this._uow.GenericRepository<Pharmacy>().Table() on ep.PharmacyID equals ph.PharmacyID
                         into PharmacyName
                         from eph in PharmacyName  //.DefaultIfEmpty()
                         select new
                         {
                             EPrescriptionID = ep.EPrescriptionID,
                             EPrescriptionNumber = ep.EPrescriptionNumber,
                             EPrescriptionDate = ep.EPrescriptionDate,
                             PatientID = ep.PatientID,
                             PrescriberID = ep.PrescriberID,
                             PrNameFirst = ePwp.NameFirst,
                             PrNameLast = ePwp.NameLast,
                             PharmacyID = ep.PharmacyID,
                             PrescriberName = ePwp.NameLast + ", " + ePwp.NameFirst + (ePwp.NameMiddle == null ? "" : " " + ePwp.NameMiddle),
                             PrescriptionStatusID = ep.PrescriptionStatusID,
                             PharmacyName = eph.PharmacyName,
                             EPrescriptionStatusDescription = ePs.Description
                         }).AsEnumerable().Select(E => new EPrescriptionModel
                         {
                             EPrescriptionID = E.EPrescriptionID,
                             EPrescriptionNumber = E.EPrescriptionNumber,
                             EPrescriptionDate = E.EPrescriptionDate,
                             PatientID = E.PatientID,
                             PrescriberID = E.PrescriberID,
                             PrNameFirst = E.PrNameFirst,
                             PrNameLast = E.PrNameLast,
                             PharmacyID = E.PharmacyID,
                             PrescriberName = E.PrescriberName,
                             PrescriptionStatusID = E.PrescriptionStatusID,
                             PharmacyName = E.PharmacyName,
                             EPrescriptionStatusDescription = E.EPrescriptionStatusDescription
                         }).ToList();

            return query;
        }
        #endregion


        #region Get model called on GetEprescription Details 
        public List<EPrescriptionDetailModel> GetEPrescriptionDetails()
        {
            var eprescription = (from ep in this._uow.GenericRepository<EPrescriptionDetail>().Table().Where(x => x.Deleted != true)
                                 select
                                 new
                                 {
                                     ep.EPrescriptionDetailID,
                                     ep.EPrescriptionID,
                                     ep.DiagnosisCode1,
                                     ep.DrugCodeID,
                                     ep.SigCodeID,
                                     ep.InstructionToPatient,
                                     ep.Quantity,
                                     ep.Refill,
                                     ep.AllowSubstitution,
                                     ep.SubDrugCodeID,
                                     ep.NotesToPharmacist,
                                     ep.DispenseAsWritten,
                                     ep.AddToMedication,
                                     ep.StartDate,
                                     ep.EndDate,
                                     ep.AllergyDiscussed,
                                     ep.Deleted,
                                     ep.CreatedDate,
                                     ep.CreatedBy,
                                     ep.ModifiedBy,
                                     ep.ModifiedDate,
                                     ep.DiagnosisCode2,
                                     ep.Weight,
                                     ep.Height,
                                     ep.UnitsofMeasure,
                                     ep.DEA,
                                     ep.Indications,
                                 }).AsEnumerable().Select(epd => new EPrescriptionDetailModel
                                 {
                                     EPrescriptionDetailID = epd.EPrescriptionDetailID,
                                     EPrescriptionID = epd.EPrescriptionID,
                                     DiagnosisCode1 = epd.DiagnosisCode1,
                                     DrugCodeID = epd.DrugCodeID,
                                     SigCodeID = epd.SigCodeID,
                                     InstructionToPatient = epd.InstructionToPatient,
                                     Quantity = epd.Quantity,
                                     Refill = epd.Refill,
                                     AllowSubstitution = epd.AllowSubstitution,
                                     SubDrugCodeID = epd.SubDrugCodeID,
                                     NotesToPharmacist = epd.NotesToPharmacist,
                                     DispenseAsWritten = epd.DispenseAsWritten,
                                     AddToMedication = epd.AddToMedication,
                                     StartDate = epd.StartDate,
                                     EndDate = epd.EndDate,
                                     AllergyDiscussed = epd.AllergyDiscussed,
                                     Deleted = epd.Deleted,
                                     CreatedDate = epd.CreatedDate,
                                     CreatedBy = epd.CreatedBy,
                                     ModifiedBy = epd.ModifiedBy,
                                     ModifiedDate = epd.ModifiedDate,
                                     DiagnosisCode2 = epd.DiagnosisCode2,
                                     Weight = epd.Weight,
                                     Height = epd.Height,
                                     UnitsofMeasure = epd.UnitsofMeasure,
                                     DEA = epd.DEA,
                                     Indications = epd.Indications
                                 }).ToList();

            return eprescription;
        }
        #endregion

        #region this addupdate in SIG CODE 

        public SigCode sigCodes(SigCode sigCode)
        {
            var sig = this._uow.GenericRepository<SigCode>().Table().Where(x => x.SigCodeID == sigCode.SigCodeID).FirstOrDefault();

            if (sig == null)
            {
                sig = new SigCode();

                sig.Code = sigCode.Code;
                sig.Description = sigCode.Description;
                sig.Deleted = sigCode.Deleted;
                sig.CreatedDate = sigCode.CreatedDate;
                sig.CreatedBy = sigCode.CreatedBy;
                sig.ModifiedDate = sigCode.ModifiedDate;
                sig.ModifiedBy = sigCode.ModifiedBy;

                this._uow.GenericRepository<SigCode>().Insert(sig);
            }
            else
            {
                sig.Code = sigCode.Code;
                sig.Description = sigCode.Description;
                sig.Deleted = sigCode.Deleted;
                sig.CreatedDate = sigCode.CreatedDate;
                sig.CreatedBy = sigCode.CreatedBy;
                sig.ModifiedDate = sigCode.ModifiedDate;
                sig.ModifiedBy = sigCode.ModifiedBy;


            }
            this._uow.Save();
            sigCode.SigCodeID = sig.SigCodeID;
            return sigCode;

        }

        #endregion

        public List<PharmacyModel> GetPharmacyListbyPharmacyId(int PharmacyID)
        {
            var query = (from ph in this._uow.GenericRepository<Pharmacy>().Table().Where((ph => ph.PharmacyID == PharmacyID))
                         select new
                         {
                             PharmacyID = ph.PharmacyID,
                             NPI = ph.NPI,
                             PharmacyName = ph.PharmacyName,
                             Address = ph.AddressLine1 + " " + ph.AddressLine2,
                             Country = ph.Country,
                             Zip = ph.ZIP,
                             County = ph.County,
                             City = ph.City,
                             State = ph.State,
                             Telephone = ph.Telephone,
                             CreatedDate = ph.CreatedDate,
                             CreatedBy = ph.CreatedBy,
                             ModifiedDate = ph.ModifiedDate,
                             ModifiedBy = ph.ModifiedBy
                         }).AsEnumerable().Select(PH => new PharmacyModel
                         {
                             PharmacyID = PH.PharmacyID,
                             NPI = PH.NPI,
                             PharmacyName = PH.PharmacyName,
                             Address = PH.Address,
                             ZIP = PH.Zip,
                             Country = PH.Country,
                             City = PH.City,
                             County = PH.County,
                             State = PH.State,
                             Telephone = PH.Telephone,
                             CreatedDate = PH.CreatedDate,
                             CreatedBy = PH.CreatedBy,
                             ModifiedDate = PH.ModifiedDate,
                             ModifiedBy = PH.ModifiedBy


                         }).ToList();
            return query;


        }
        //public List<PatientModel> GetPatientModelscallbySearch(string SearchKey)
        //{
        //    var patientess = (from p in this._uow.GenericRepository<Patient>().Table().Where(x => x.Deleted != true)
        //                      select
        //                      new
        //                      {
        //                          PatientID = p.PatientID,
        //                          PatientSSN = p.PatientSSN,
        //                          NameLast = p.NameLast,
        //                          NameFirst = p.NameFirst,
        //                          NameMiddle = p.NameMiddle,
        //                          NamePrefix = p.NamePrefix,
        //                          NameSuffix = p.NameSuffix,
        //                          GenderID = p.GenderID,
        //                          BirthDate = p.BirthDate,
        //                          MaritalStatusID = p.MaritalStatusID,
        //                          RaceID = p.RaceID,
        //                          EthnicityID = p.EthnicityID,
        //                          LanguageID = p.LanguageID,
        //                          AddressLine1 = p.AddressLine1,
        //                          AddressLine2 = p.AddressLine2,
        //                          City = p.City,
        //                          State = p.State,
        //                          County = p.County,
        //                          ZIP = p.ZIP,
        //                          AddressEffectiveDate = p.AddressEffectiveDate,
        //                          AddressTermDate = p.AddressTermDate,
        //                          Country = p.County,
        //                          Phone = p.Phone,
        //                          AlternatePhone = p.AlternatePhone,
        //                          Email = p.Email,
        //                          MailAddressLine1 = p.MailAddressLine1,
        //                          MailAddressLine2 = p.MailAddressLine2,
        //                          MailCity = p.MailCity,
        //                          MailState = p.MailState,
        //                          MailCounty = p.MailCounty,
        //                          MailZIP = p.MailZIP,
        //                          MailCountry = p.MailCountry,
        //                          IsActive = p.IsActive,
        //                          PassportNo = p.PassportNo,
        //                          DrivingLicenseNo = p.DrivingLicenseNo,
        //                          Deleted = p.Deleted,
        //                          CreatedDate = p.CreatedDate,
        //                          CreatedBy = p.CreatedBy,
        //                          ModifiedDate = p.ModifiedDate,
        //                          ModifiedBy = p.ModifiedBy,
        //                          PatientAccountNumber = p.PatientAccountNumber,
        //                          SalutationID = p.SalutationID,
        //                          DeathDate = p.DeathDate,
        //                          CauseOfDeath = p.CauseOfDeath,
        //                          PreferredLanguageID = p.PreferredLanguageID,
        //                          MothersMaidenNameFirst = p.MothersMaidenNameFirst,
        //                          MothersMaidenNameLast = p.MothersMaidenNameLast,
        //                          MedicalRecordNumber = p.MedicalRecordNumber,
        //                          OtherEthnicity = p.OtherEthnicity,
        //                          OtherLanguage = p.OtherLanguage,
        //                          OtherRace = p.OtherRace,
        //                      }).AsEnumerable().Select(x => new PatientModel
        //                      {
        //                          PatientID = x.PatientID,
        //                          PatientSSN = x.PatientSSN,
        //                          NameLast = x.NameLast,
        //                          NameFirst = x.NameFirst,
        //                          NameMiddle = x.NameMiddle,
        //                          NamePrefix = x.NamePrefix,
        //                          NameSuffix = x.NameSuffix,
        //                          GenderID = x.GenderID,
        //                          MaritalStatusID = x.MaritalStatusID,
        //                          RaceID = x.RaceID,
        //                          EthnicityID = x.EthnicityID,
        //                          LanguageID = x.LanguageID,
        //                          AddressLine1 = x.AddressLine1,
        //                          AddressLine2 = x.AddressLine2,
        //                          City = x.City,
        //                          State = x.State,
        //                          County = x.County,
        //                          ZIP = x.ZIP,
        //                          AddressEffectiveDate = x.AddressEffectiveDate,
        //                          AddressTermDate = x.AddressTermDate,
        //                          Country = x.County,
        //                          Phone = x.Phone,
        //                          AlternatePhone = x.AlternatePhone,
        //                          Email = x.Email,
        //                          MailAddressLine1 = x.MailAddressLine1,
        //                          MailAddressLine2 = x.MailAddressLine2,
        //                          MailCity = x.MailCity,
        //                          MailState = x.MailState,
        //                          MailCounty = x.MailCounty,
        //                          MailZIP = x.MailZIP,
        //                          MailCountry = x.MailCountry,
        //                          IsActive = x.IsActive,
        //                          PassportNo = x.PassportNo,
        //                          DrivingLicenseNo = x.DrivingLicenseNo,
        //                          Deleted = x.Deleted,
        //                          CreatedDate = x.CreatedDate,
        //                          CreatedBy = x.CreatedBy,
        //                          ModifiedDate = x.ModifiedDate,
        //                          ModifiedBy = x.ModifiedBy,
        //                          PatientAccountNumber = x.PatientAccountNumber,
        //                          SalutationID = x.SalutationID,
        //                          DeathDate = x.DeathDate,
        //                          CauseOfDeath = x.CauseOfDeath,
        //                          PreferredLanguageID = x.PreferredLanguageID,
        //                          MothersMaidenNameFirst = x.MothersMaidenNameFirst,
        //                          MothersMaidenNameLast = x.MothersMaidenNameLast,
        //                          MedicalRecordNumber = x.MedicalRecordNumber,
        //                          OtherEthnicity = x.OtherEthnicity,
        //                          OtherLanguage = x.OtherLanguage,
        //                          OtherRace = x.OtherRace,
        //                          BirthDate = x.BirthDate,
        //                          PatientName = x.NameFirst + " " + x.NameMiddle + " " + x.NameLast,
        //                          Age = x.BirthDate != null ? (DateTime.Now - x.BirthDate.Value).Days / 365 : 0,
        //                          GenderDescription = x.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(xx => xx.CommonMasterID == x.GenderID).FirstOrDefault().Description : "",
        //                          allergynames = this.getallergynamesbyPatientID(x.PatientID)

        //                      }).OrderBy(x => x.PatientName).ToList();


        //    return patientess;

        //}


        public List<PatientModel> GetPatientModelscallbySearch(string Searchkey)
        {
            List<PatientModel> patientModels = (from a in this._uow.GenericRepository<Patient>().Table()

                                                select new
                                                {
                                                    PatientID = a.PatientID,
                                                    MedicalRecordNumber = a.MedicalRecordNumber,
                                                    PatientSSN = a.PatientSSN,
                                                    NameLast = a.NameLast,
                                                    NameFirst = a.NameFirst,
                                                    NameMiddle = a.NameMiddle,
                                                    NamePrefix = a.NamePrefix,
                                                    NameSuffix = a.NameSuffix,
                                                    GenderID = a.GenderID,
                                                    BirthDate = a.BirthDate,
                                                    MaritalStatusID = a.MaritalStatusID,
                                                    RaceID = a.RaceID,
                                                    EthnicityID = a.EthnicityID,
                                                    LanguageID = a.LanguageID,
                                                    AddressLine1 = a.AddressLine1,
                                                    AddressLine2 = a.AddressLine2,
                                                    City = a.City,
                                                    State = a.State,
                                                    County = a.County,
                                                    ZIP = a.ZIP,
                                                    AddressEffectiveDate = a.AddressEffectiveDate,
                                                    AddressTermDate = a.AddressTermDate,
                                                    Country = a.County,
                                                    Phone = a.Phone,
                                                    AlternatePhone = a.AlternatePhone,
                                                    Email = a.Email,
                                                    MailAddressLine1 = a.MailAddressLine1,
                                                    MailAddressLine2 = a.MailAddressLine2,
                                                    MailCity = a.MailCity,
                                                    MailState = a.MailState,
                                                    MailCounty = a.MailCounty,
                                                    MailZIP = a.MailZIP,
                                                    MailCountry = a.MailCountry,
                                                    IsActive = a.IsActive,
                                                    PassportNo = a.PassportNo,
                                                    DrivingLicenseNo = a.DrivingLicenseNo,
                                                    Deleted = a.Deleted,
                                                    CreatedDate = a.CreatedDate,
                                                    CreatedBy = a.CreatedBy,
                                                    ModifiedDate = a.ModifiedDate,
                                                    ModifiedBy = a.ModifiedBy,
                                                    PatientAccountNumber = a.PatientAccountNumber,
                                                    SalutationID = a.SalutationID,
                                                    DeathDate = a.DeathDate,
                                                    CauseOfDeath = a.CauseOfDeath,
                                                    PreferredLanguageID = a.PreferredLanguageID,
                                                    MothersMaidenNameFirst = a.MothersMaidenNameFirst,
                                                    MothersMaidenNameLast = a.MothersMaidenNameLast,
                                                    OtherEthnicity = a.OtherEthnicity,
                                                    OtherLanguage = a.OtherLanguage,
                                                    OtherRace = a.OtherRace,
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
                                                    PatientName = x.NameFirst + " " + x.NameMiddle + " " + x.NameLast,
                                                    Age = x.BirthDate != null ? (DateTime.Now - x.BirthDate.Value).Days / 365 : 0,
                                                    GenderDescription = x.GenderID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(xx => xx.CommonMasterID == x.GenderID).FirstOrDefault().Description : "",
                                                    allergynames = this.getallergynamesbyPatientID(x.PatientID)

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


        public EPrescriptionModel addupdateeprescriptionmodel(EPrescriptionModel ePrescriptionModel)
        {
            var eprescription = this._uow.GenericRepository<EPrescription>().Table().Where(x => x.EPrescriptionID == ePrescriptionModel.EPrescriptionID).FirstOrDefault();

            if (eprescription == null)
            {
                eprescription = new EPrescription();

                eprescription.EPrescriptionNumber = ePrescriptionModel.EPrescriptionNumber;
                eprescription.EPrescriptionDate = ePrescriptionModel.EPrescriptionDate;
                eprescription.PatientID = ePrescriptionModel.PatientID;
                eprescription.PharmacyID = ePrescriptionModel.PharmacyID;
                eprescription.PrescriberType = ePrescriptionModel.PrescriberType;
                eprescription.PrescriptionStatusID = ePrescriptionModel.PrescriptionStatusID;
                eprescription.PrescriberID = ePrescriptionModel.PrescriberID;
                eprescription.Deleted = false;
                eprescription.CreatedDate = DateTime.Now;
                eprescription.CreatedBy = "user";

                this._uow.GenericRepository<EPrescription>().Insert(eprescription);
            }
            else
            {

                eprescription.EPrescriptionNumber = ePrescriptionModel.EPrescriptionNumber;
                eprescription.EPrescriptionDate = ePrescriptionModel.EPrescriptionDate;
                eprescription.PatientID = ePrescriptionModel.PatientID;
                eprescription.PharmacyID = ePrescriptionModel.PharmacyID;
                eprescription.PrescriberType = ePrescriptionModel.PrescriberType;
                eprescription.PrescriptionStatusID = ePrescriptionModel.PrescriptionStatusID;
                eprescription.PrescriberID = ePrescriptionModel.PrescriberID;
                eprescription.Deleted = false;
                eprescription.CreatedDate = DateTime.Now;
                eprescription.CreatedBy = "user";
                eprescription.ModifiedDate = DateTime.Now;
                eprescription.ModifiedBy = ePrescriptionModel.ModifiedBy;


                this._uow.GenericRepository<EPrescription>().Update(eprescription);
            }

            this._uow.Save();
            ePrescriptionModel.EPrescriptionID = eprescription.EPrescriptionID;

            var prescriptiondedetils = this._uow.GenericRepository<EPrescriptionDetail>().Table().Where(x => x.EPrescriptionID == eprescription.EPrescriptionID).ToList();

            if (prescriptiondedetils.Count > 0)
            {
                for (int i = 0; i < prescriptiondedetils.Count(); i++)
                {
                    var detilsdelete = this._uow.GenericRepository<EPrescriptionDetail>().Table().FirstOrDefault(x => x.EPrescriptionDetailID == prescriptiondedetils[i].EPrescriptionDetailID);
                    if (detilsdelete != null)
                    {
                        this._uow.GenericRepository<EPrescriptionDetail>().Delete(detilsdelete);
                        this._uow.Save();

                    }
                }

            }
            if (eprescription.EPrescriptionID > 0 && ePrescriptionModel.EPrescriptionDetails != null && ePrescriptionModel.EPrescriptionDetails.Count() > 0)
            {
                for (int i = 0; i < ePrescriptionModel.EPrescriptionDetails.Count(); i++)
                {
                    EPrescriptionDetail prescription = new EPrescriptionDetail();

                    prescription.EPrescriptionID = eprescription.EPrescriptionID;
                    prescription.DiagnosisCode1 = ePrescriptionModel.EPrescriptionDetails[i].DiagnosisCode1;
                    prescription.DrugCodeID = ePrescriptionModel.EPrescriptionDetails[i].DrugCodeID;
                    prescription.SigCodeID = ePrescriptionModel.EPrescriptionDetails[i].SigCodeID;
                    prescription.InstructionToPatient = ePrescriptionModel.EPrescriptionDetails[i].InstructionToPatient;
                    prescription.Quantity = ePrescriptionModel.EPrescriptionDetails[i].Quantity;
                    prescription.Refill = ePrescriptionModel.EPrescriptionDetails[i].Refill;
                    prescription.AllowSubstitution = ePrescriptionModel.EPrescriptionDetails[i].AllowSubstitution;
                    prescription.SubDrugCodeID = ePrescriptionModel.EPrescriptionDetails[i].SubDrugCodeID;
                    prescription.NotesToPharmacist = ePrescriptionModel.EPrescriptionDetails[i].NotesToPharmacist;
                    prescription.DispenseAsWritten = ePrescriptionModel.EPrescriptionDetails[i].DispenseAsWritten;
                    prescription.AddToMedication = ePrescriptionModel.EPrescriptionDetails[i].AddToMedication;
                    prescription.StartDate = ePrescriptionModel.EPrescriptionDetails[i].StartDate;
                    prescription.EndDate = ePrescriptionModel.EPrescriptionDetails[i].EndDate;
                    prescription.AllergyDiscussed = ePrescriptionModel.EPrescriptionDetails[i].AllergyDiscussed;
                    prescription.Deleted = false;
                    prescription.CreatedDate = DateTime.Now;
                    prescription.CreatedBy = "User";
                    prescription.DiagnosisCode2 = ePrescriptionModel.EPrescriptionDetails[i].DiagnosisCode2;
                    prescription.Weight = ePrescriptionModel.EPrescriptionDetails[i].Weight;
                    prescription.Height = ePrescriptionModel.EPrescriptionDetails[i].Height;
                    prescription.UnitsofMeasure = ePrescriptionModel.EPrescriptionDetails[i].UnitsofMeasure;
                    prescription.DEA = ePrescriptionModel.EPrescriptionDetails[i].DEA;
                    prescription.Indications = ePrescriptionModel.EPrescriptionDetails[i].Indications;

                    this._uow.GenericRepository<EPrescriptionDetail>().Insert(prescription);
                }
                this._uow.Save();

            }

            prescriptiondedetils = this._uow.GenericRepository<EPrescriptionDetail>().Table().Where(x => x.EPrescriptionID == eprescription.EPrescriptionID).ToList();
            if (prescriptiondedetils.Count() > 0)
            {
                for (int i = 0; i < prescriptiondedetils.Count(); i++)
                {
                    PatientMedication patmedadd = new PatientMedication();

                    patmedadd.PatientID = eprescription.PatientID;
                    patmedadd.StartedDate = this._iMasterService.GetLocalTime(eprescription.EPrescriptionDate.Value);
                    patmedadd.DrugCodeID = prescriptiondedetils[i].DrugCodeID;
                    patmedadd.Quantity = prescriptiondedetils[i].Quantity;
                    patmedadd.Refill = prescriptiondedetils[i].Refill;
                    patmedadd.CurrentStatus = this._uow.GenericRepository<CommonMaster>().Table().
                                        Where(x => x.Category.ToLower().Trim() == "medicalhistorystatus" && x.Description.ToLower().Trim() == "active").FirstOrDefault().CommonMasterID;
                    patmedadd.AllowSubstitution = prescriptiondedetils[i].AllowSubstitution;
                    patmedadd.NotesToPharmacist = prescriptiondedetils[i].NotesToPharmacist;
                    patmedadd.Sig = prescriptiondedetils[i].SigCodeID > 0 ? this._uow.GenericRepository<SigCode>().Table().
                                    Where(x => x.SigCodeID == prescriptiondedetils[i].SigCodeID).FirstOrDefault().Description : "";
                    patmedadd.DispenseAsWritten = prescriptiondedetils[i].DispenseAsWritten;
                    patmedadd.MedicatedDate = this._iMasterService.GetLocalTime(eprescription.EPrescriptionDate.Value);
                    patmedadd.CreatedDate = DateTime.Now;
                    patmedadd.CreatedBy = "User";

                    this._uow.GenericRepository<PatientMedication>().Insert(patmedadd);

                }
                this._uow.Save();
            }



            return ePrescriptionModel;

        }

        public List<ProviderModel> GetProvidersSearchkeymodel(string Searchkey)
        {
            var provider = (from a in this._uow.GenericRepository<Provider>().Table()
                            where (Searchkey == null || (a.NPI.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.NameFirst.ToLower().Trim().Contains(Searchkey.ToLower().Trim())) ||
                                                       (a.NameMiddle.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.NameLast.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                            select new Provider
                            {
                                ProviderID = a.ProviderID,
                                NameFirst = a.NameFirst,
                                NameMiddle = a.NameMiddle,
                                NameLast = a.NameLast,
                                NPI = a.NPI

                            }).AsEnumerable().Select(pm => new ProviderModel
                            {
                                ProviderID = pm.ProviderID,
                                NameFirst = pm.NameFirst + " " + pm.NameMiddle + "" + pm.NameLast,
                                NPI = pm.NPI

                            }).ToList();

            return provider;

        }

        public List<EPrescriptionDetailModel> GetDraftPrescriptions(int PatientID)
        {
            var preStatus = this._uow.GenericRepository<PrescriptionStatus>().Table().Where(x => x.Code.ToLower().Trim() == "saved").FirstOrDefault();
            var details = (from pres in this._uow.GenericRepository<EPrescription>().Table().Where(x => x.Deleted != true & x.PatientID == PatientID & x.PrescriptionStatusID == preStatus.PrescriptionStatusID)
                           join epreDet in this._uow.GenericRepository<EPrescriptionDetail>().Table()
                           on pres.EPrescriptionID equals epreDet.EPrescriptionID

                           select
                           new
                           {
                               epreDet.EPrescriptionDetailID,
                               epreDet.EPrescriptionID,
                               epreDet.DiagnosisCode1,
                               epreDet.DrugCodeID,
                               epreDet.SigCodeID,
                               epreDet.InstructionToPatient,
                               epreDet.Quantity,
                               epreDet.Refill,
                               epreDet.AllowSubstitution,
                               epreDet.SubDrugCodeID,
                               epreDet.NotesToPharmacist,
                               epreDet.DispenseAsWritten,
                               epreDet.AddToMedication,
                               epreDet.StartDate,
                               epreDet.EndDate,
                               epreDet.AllergyDiscussed,
                               epreDet.Deleted,
                               epreDet.CreatedDate,
                               epreDet.CreatedBy,
                               epreDet.ModifiedBy,
                               epreDet.ModifiedDate,
                               epreDet.DiagnosisCode2,
                               epreDet.Weight,
                               epreDet.Height,
                               epreDet.UnitsofMeasure,
                               epreDet.DEA,
                               epreDet.Indications,

                           }).AsEnumerable().Select(epd => new EPrescriptionDetailModel
                           {
                               EPrescriptionDetailID = epd.EPrescriptionDetailID,
                               EPrescriptionID = epd.EPrescriptionID,
                               DiagnosisCode1 = epd.DiagnosisCode1,
                               DrugCodeID = epd.DrugCodeID,
                               SigCodeID = epd.SigCodeID,
                               InstructionToPatient = epd.InstructionToPatient,
                               Quantity = epd.Quantity,
                               Refill = epd.Refill,
                               AllowSubstitution = epd.AllowSubstitution,
                               SubDrugCodeID = epd.SubDrugCodeID,
                               NotesToPharmacist = epd.NotesToPharmacist,
                               DispenseAsWritten = epd.DispenseAsWritten,
                               AddToMedication = epd.AddToMedication,
                               StartDate = epd.StartDate,
                               EndDate = epd.EndDate,
                               AllergyDiscussed = epd.AllergyDiscussed,
                               Deleted = epd.Deleted,
                               CreatedDate = epd.CreatedDate,
                               CreatedBy = epd.CreatedBy,
                               ModifiedBy = epd.ModifiedBy,
                               ModifiedDate = epd.ModifiedDate,
                               DiagnosisCode2 = epd.DiagnosisCode2,
                               Weight = epd.Weight,
                               Height = epd.Height,
                               UnitsofMeasure = epd.UnitsofMeasure,
                               DEA = epd.DEA,
                               Indications = epd.Indications,
                               DiagnosisCodeDescription1 = (epd.DiagnosisCode1 != null && epd.DiagnosisCode1 != "") ? this._uow.GenericRepository<DiagnosisCode>().Table().
                                                            Where(x => x.ICDCode.ToLower().Trim().Contains(epd.DiagnosisCode1.ToLower().Trim()) || x.ShortDescription.ToLower().Trim().Contains(epd.DiagnosisCode1.ToLower().Trim())
                                                            || x.Description.ToLower().Trim().Contains(epd.DiagnosisCode1.ToLower().Trim()) || x.LongDescription.ToLower().Trim().Contains(epd.DiagnosisCode1.ToLower().Trim())).FirstOrDefault().Description : "",
                               DrugCodeDescription = (epd.DrugCodeID!= null || epd.DrugCodeID > 0) ? this._uow.GenericRepository<DrugCode>().Table().Where(x => x.DrugCodeID == epd.DrugCodeID).FirstOrDefault().Description : "",
                               SigCodeDescription = (epd.DrugCodeID != null || epd.SigCodeID > 0) ? this._uow.GenericRepository<SigCode>().Table().Where(x => x.SigCodeID == epd.SigCodeID).FirstOrDefault().Description : ""

                           }).ToList();

            return details;

        }

        public List<PatientMedicationModel> GetRxHistoryMedicationsforPatient(int PatientID)
        {
            var getmedication = (from a in this._uow.GenericRepository<PatientMedication>().Table().Where(x => x.Deleted != true & x.PatientID == PatientID)
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
                                     Frequency = ss.Frequency,
                                     PackageDescription = ss.PackageDescription,
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

        public List<PrescriptionStatus> GetPrescriptionStatuses()
        {
            var status = this._uow.GenericRepository<PrescriptionStatus>().Table().ToList();

            return status;

        }


    }

}
