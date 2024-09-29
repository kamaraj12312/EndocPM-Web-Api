using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EndocPM.WebAPI
{
    public class ELabService : IELabService
    {

        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _MasterService;

        //public string ConnectionString = ConfigurationManager.ConnectionStrings["EndocDataContext"].ConnectionString;
        public ELabService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService masterService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _MasterService = masterService;
        }

        #region ELaborder 

        #region ELaborder 

        public PatientLabOrderTestModel AddupdatePatientLabOrder(PatientLabOrderTestModel patientLabOrderTestModel)
        {
            var patlab = this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => x.PatientLabOrderTestID == patientLabOrderTestModel.PatientLabOrderTestID).FirstOrDefault();

            if (patlab == null)
            {
                patlab = new PatientLabOrderTest();

                patlab.FacilityID = patientLabOrderTestModel.FacilityID;
                patlab.FacilityName = patientLabOrderTestModel.FacilityName.ToString();
                patlab.EmdeonLabID = patientLabOrderTestModel.EmdeonLabID;
                patlab.ProviderID = patientLabOrderTestModel.ProviderID;
                patlab.ProviderName = patientLabOrderTestModel.ProviderName;
                patlab.PatientVisitID = patientLabOrderTestModel.PatientVisitID;
                patlab.OrderingProviderID = patientLabOrderTestModel.OrderingProviderID;
                patlab.OrderingProviderName = patientLabOrderTestModel.OrderingProviderName;
                patlab.PatientID = patientLabOrderTestModel.PatientID;
                patlab.LabTestDate = patientLabOrderTestModel.LabTestDate;
                patlab.LabName = patientLabOrderTestModel.LabName;
                patlab.LabAddressLine1 = patientLabOrderTestModel.LabAddressLine1;
                patlab.LabAddressLine2 = patientLabOrderTestModel.LabAddressLine2;
                patlab.LabCity = patientLabOrderTestModel.LabCity;
                patlab.LabState = patientLabOrderTestModel.LabState;
                patlab.LabCounty = patientLabOrderTestModel.LabCounty;
                patlab.LabZIP = patientLabOrderTestModel.LabZIP;
                patlab.LoincCode1 = patientLabOrderTestModel.LoincCode1;
                patlab.LoincCode1Result = patientLabOrderTestModel.LoincCode1Result;
                patlab.LoincCode1ResultUnits = patientLabOrderTestModel.LoincCode1ResultUnits;
                patlab.LoincCode1ResultDate = patientLabOrderTestModel.LoincCode1ResultDate;
                patlab.LoincCode2 = patientLabOrderTestModel.LoincCode2;
                patlab.LoincCode2Result = patientLabOrderTestModel.LoincCode2Result;
                patlab.LoincCode2ResultUnits = patientLabOrderTestModel.LoincCode2ResultUnits;
                patlab.LoincCode2ResultDate = patientLabOrderTestModel.LoincCode2ResultDate;
                patlab.LoincCode3 = patientLabOrderTestModel.LoincCode3;
                patlab.LoincCode3Result = patientLabOrderTestModel.LoincCode3Result;
                patlab.LoincCode3ResultUnits = patientLabOrderTestModel.LoincCode3ResultUnits;
                patlab.LoincCode3ResultDate = patientLabOrderTestModel.LoincCode3ResultDate;
                patlab.LoincCode4 = patientLabOrderTestModel.LoincCode4;
                patlab.LoincCode4Result = patientLabOrderTestModel.LoincCode4Result;
                patlab.LoincCode4ResultUnits = patientLabOrderTestModel.LoincCode4ResultUnits;
                patlab.LoincCode4ResultDate = patientLabOrderTestModel.LoincCode4ResultDate;
                patlab.LoincCode5 = patientLabOrderTestModel.LoincCode5;
                patlab.LoincCode5Result = patientLabOrderTestModel.LoincCode5Result;
                patlab.LoincCode5ResultUnits = patientLabOrderTestModel.LoincCode5ResultUnits;
                patlab.LoincCode5ResultDate = patientLabOrderTestModel.LoincCode5ResultDate;
                patlab.LoincCode6 = patientLabOrderTestModel.LoincCode6;
                patlab.LoincCode6Result = patientLabOrderTestModel.LoincCode6Result;
                patlab.LoincCode6ResultUnits = patientLabOrderTestModel.LoincCode6ResultUnits;
                patlab.LoincCode6ResultDate = patientLabOrderTestModel.LoincCode6ResultDate;
                patlab.LoincCode7 = patientLabOrderTestModel.LoincCode7;
                patlab.LoincCode7Result = patientLabOrderTestModel.LoincCode7Result;
                patlab.LoincCode7ResultUnits = patientLabOrderTestModel.LoincCode7ResultUnits;
                patlab.LoincCode7ResultDate = patientLabOrderTestModel.LoincCode7ResultDate;
                patlab.LoincCode8 = patientLabOrderTestModel.LoincCode8;
                patlab.LoincCode8Result = patientLabOrderTestModel.LoincCode8Result;
                patlab.LoincCode8ResultUnits = patientLabOrderTestModel.LoincCode8ResultUnits;
                patlab.LoincCode8ResultDate = patientLabOrderTestModel.LoincCode8ResultDate;
                patlab.LoincCode9 = patientLabOrderTestModel.LoincCode9;
                patlab.LoincCode9Result = patientLabOrderTestModel.LoincCode9Result;
                patlab.LoincCode9ResultUnits = patientLabOrderTestModel.LoincCode9ResultUnits;
                patlab.LoincCode9ResultDate = patientLabOrderTestModel.LoincCode9ResultDate;
                patlab.LoincCode10 = patientLabOrderTestModel.LoincCode10;
                patlab.LoincCode10Result = patientLabOrderTestModel.LoincCode10Result;
                patlab.LoincCode10ResultUnits = patientLabOrderTestModel.LoincCode10ResultUnits;
                patlab.LoincCode10ResultDate = patientLabOrderTestModel.LoincCode10ResultDate;
                patlab.LoincCode11 = patientLabOrderTestModel.LoincCode11;
                patlab.LoincCode11Result = patientLabOrderTestModel.LoincCode11Result;
                patlab.LoincCode11ResultUnits = patientLabOrderTestModel.LoincCode11ResultUnits;
                patlab.LoincCode11ResultDate = patientLabOrderTestModel.LoincCode11ResultDate;
                patlab.LoincCode12 = patientLabOrderTestModel.LoincCode12;
                patlab.LoincCode12Result = patientLabOrderTestModel.LoincCode12Result;
                patlab.LoincCode12ResultUnits = patientLabOrderTestModel.LoincCode12ResultUnits;
                patlab.LoincCode12ResultDate = patientLabOrderTestModel.LoincCode12ResultDate;
                patlab.LoincCode13 = patientLabOrderTestModel.LoincCode13;
                patlab.LoincCode13Result = patientLabOrderTestModel.LoincCode13Result;
                patlab.LoincCode13ResultUnits = patientLabOrderTestModel.LoincCode13ResultUnits;
                patlab.LoincCode13ResultDate = patientLabOrderTestModel.LoincCode13ResultDate;
                patlab.LoincCode14 = patientLabOrderTestModel.LoincCode14;
                patlab.LoincCode14Result = patientLabOrderTestModel.LoincCode14Result;
                patlab.LoincCode14ResultUnits = patientLabOrderTestModel.LoincCode14ResultUnits;
                patlab.LoincCode14ResultDate = patientLabOrderTestModel.LoincCode14ResultDate;
                patlab.LoincCode15 = patientLabOrderTestModel.LoincCode15;
                patlab.LoincCode15Result = patientLabOrderTestModel.LoincCode15Result;
                patlab.LoincCode15ResultUnits = patientLabOrderTestModel.LoincCode15ResultUnits;
                patlab.LoincCode15ResultDate = patientLabOrderTestModel.LoincCode15ResultDate;
                patlab.LoincCode16 = patientLabOrderTestModel.LoincCode16;
                patlab.LoincCode16Result = patientLabOrderTestModel.LoincCode16Result;
                patlab.LoincCode16ResultUnits = patientLabOrderTestModel.LoincCode16ResultUnits;
                patlab.LoincCode16ResultDate = patientLabOrderTestModel.LoincCode16ResultDate;
                patlab.ICDCode1 = patientLabOrderTestModel.ICDCode1;
                patlab.ICDCode2 = patientLabOrderTestModel.ICDCode2;
                patlab.ICDCode3 = patientLabOrderTestModel.ICDCode3;
                patlab.ICDCode4 = patientLabOrderTestModel.ICDCode4;
                patlab.ICDCode5 = patientLabOrderTestModel.ICDCode5;
                patlab.ICDCode6 = patientLabOrderTestModel.ICDCode6;
                patlab.ICDCode7 = patientLabOrderTestModel.ICDCode7;
                patlab.ICDCode8 = patientLabOrderTestModel.ICDCode8;
                patlab.ICDCode9 = patientLabOrderTestModel.ICDCode9;
                patlab.ICDCode10 = patientLabOrderTestModel.ICDCode10;
                patlab.Notes = patientLabOrderTestModel.Notes;
                patlab.Deleted = false;
                patlab.CreatedBy = "User";
                patlab.CreatedDate = DateTime.Now;
                patlab.DocumentReferenceIds = patientLabOrderTestModel.DocumentReferenceIds;
                patlab.ScheduledTestStatusID = patientLabOrderTestModel.ScheduledTestStatusID;
                patlab.IsPrinted = patientLabOrderTestModel.IsPrinted;
                patlab.IsEditable = patientLabOrderTestModel.IsEditable;
                patlab.OrderTypeID = patientLabOrderTestModel.OrderTypeID;
                patlab.BillTypeID = patientLabOrderTestModel.BillTypeID;
                patlab.InsuranceCodeId = patientLabOrderTestModel.InsuranceCodeId;
                patlab.Template = patientLabOrderTestModel.Template;
                patlab.PrepaidAmount = patientLabOrderTestModel.PrepaidAmount;
                patlab.STAT = patientLabOrderTestModel.STAT;
                patlab.CollectionDate = patientLabOrderTestModel.CollectionDate;
                patlab.PreferredlanguageId = patientLabOrderTestModel.PreferredlanguageId;
                patlab.PatientRaceID = patientLabOrderTestModel.PatientRaceID;
                patlab.PatientEthnicityID = patientLabOrderTestModel.PatientEthnicityID;
                patlab.GenderIdentityID = patientLabOrderTestModel.GenderIdentityID;
                patlab.SexualOrientationID = patientLabOrderTestModel.SexualOrientationID;
                patlab.Instructions = patientLabOrderTestModel.Instructions;
                patlab.ReportComments = patientLabOrderTestModel.ReportComments;
                patlab.Phonenumber = patientLabOrderTestModel.Phonenumber;
                patlab.Fax = patientLabOrderTestModel.Fax;


                this._uow.GenericRepository<PatientLabOrderTest>().Insert(patlab);

            }

            else
            {

                patlab.FacilityID = patientLabOrderTestModel.FacilityID;
                patlab.FacilityName = patientLabOrderTestModel.FacilityName.ToString();
                patlab.EmdeonLabID = patientLabOrderTestModel.EmdeonLabID;
                patlab.ProviderID = patientLabOrderTestModel.ProviderID;
                patlab.ProviderName = patientLabOrderTestModel.ProviderName;
                patlab.PatientVisitID = patientLabOrderTestModel.PatientVisitID;
                patlab.OrderingProviderID = patientLabOrderTestModel.OrderingProviderID;
                patlab.OrderingProviderName = patientLabOrderTestModel.OrderingProviderName;
                patlab.PatientID = patientLabOrderTestModel.PatientID;
                patlab.LabTestDate = patientLabOrderTestModel.LabTestDate;
                patlab.LabName = patientLabOrderTestModel.LabName;
                patlab.LabAddressLine1 = patientLabOrderTestModel.LabAddressLine1;
                patlab.LabAddressLine2 = patientLabOrderTestModel.LabAddressLine2;
                patlab.LabCity = patientLabOrderTestModel.LabCity;
                patlab.LabState = patientLabOrderTestModel.LabState;
                patlab.LabCounty = patientLabOrderTestModel.LabCounty;
                patlab.LabZIP = patientLabOrderTestModel.LabZIP;
                patlab.LoincCode1 = patientLabOrderTestModel.LoincCode1;
                patlab.LoincCode1Result = patientLabOrderTestModel.LoincCode1Result;
                patlab.LoincCode1ResultUnits = patientLabOrderTestModel.LoincCode1ResultUnits;
                patlab.LoincCode1ResultDate = patientLabOrderTestModel.LoincCode1ResultDate;
                patlab.LoincCode2 = patientLabOrderTestModel.LoincCode2;
                patlab.LoincCode2Result = patientLabOrderTestModel.LoincCode2Result;
                patlab.LoincCode2ResultUnits = patientLabOrderTestModel.LoincCode2ResultUnits;
                patlab.LoincCode2ResultDate = patientLabOrderTestModel.LoincCode2ResultDate;
                patlab.LoincCode3 = patientLabOrderTestModel.LoincCode3;
                patlab.LoincCode3Result = patientLabOrderTestModel.LoincCode3Result;
                patlab.LoincCode3ResultUnits = patientLabOrderTestModel.LoincCode3ResultUnits;
                patlab.LoincCode3ResultDate = patientLabOrderTestModel.LoincCode3ResultDate;
                patlab.LoincCode4 = patientLabOrderTestModel.LoincCode4;
                patlab.LoincCode4Result = patientLabOrderTestModel.LoincCode4Result;
                patlab.LoincCode4ResultUnits = patientLabOrderTestModel.LoincCode4ResultUnits;
                patlab.LoincCode4ResultDate = patientLabOrderTestModel.LoincCode4ResultDate;
                patlab.LoincCode5 = patientLabOrderTestModel.LoincCode5;
                patlab.LoincCode5Result = patientLabOrderTestModel.LoincCode5Result;
                patlab.LoincCode5ResultUnits = patientLabOrderTestModel.LoincCode5ResultUnits;
                patlab.LoincCode5ResultDate = patientLabOrderTestModel.LoincCode5ResultDate;
                patlab.LoincCode6 = patientLabOrderTestModel.LoincCode6;
                patlab.LoincCode6Result = patientLabOrderTestModel.LoincCode6Result;
                patlab.LoincCode6ResultUnits = patientLabOrderTestModel.LoincCode6ResultUnits;
                patlab.LoincCode6ResultDate = patientLabOrderTestModel.LoincCode6ResultDate;
                patlab.LoincCode7 = patientLabOrderTestModel.LoincCode7;
                patlab.LoincCode7Result = patientLabOrderTestModel.LoincCode7Result;
                patlab.LoincCode7ResultUnits = patientLabOrderTestModel.LoincCode7ResultUnits;
                patlab.LoincCode7ResultDate = patientLabOrderTestModel.LoincCode7ResultDate;
                patlab.LoincCode8 = patientLabOrderTestModel.LoincCode8;
                patlab.LoincCode8Result = patientLabOrderTestModel.LoincCode8Result;
                patlab.LoincCode8ResultUnits = patientLabOrderTestModel.LoincCode8ResultUnits;
                patlab.LoincCode8ResultDate = patientLabOrderTestModel.LoincCode8ResultDate;
                patlab.LoincCode9 = patientLabOrderTestModel.LoincCode9;
                patlab.LoincCode9Result = patientLabOrderTestModel.LoincCode9Result;
                patlab.LoincCode9ResultUnits = patientLabOrderTestModel.LoincCode9ResultUnits;
                patlab.LoincCode9ResultDate = patientLabOrderTestModel.LoincCode9ResultDate;
                patlab.LoincCode10 = patientLabOrderTestModel.LoincCode10;
                patlab.LoincCode10Result = patientLabOrderTestModel.LoincCode10Result;
                patlab.LoincCode10ResultUnits = patientLabOrderTestModel.LoincCode10ResultUnits;
                patlab.LoincCode10ResultDate = patientLabOrderTestModel.LoincCode10ResultDate;
                patlab.LoincCode11 = patientLabOrderTestModel.LoincCode11;
                patlab.LoincCode11Result = patientLabOrderTestModel.LoincCode11Result;
                patlab.LoincCode11ResultUnits = patientLabOrderTestModel.LoincCode11ResultUnits;
                patlab.LoincCode11ResultDate = patientLabOrderTestModel.LoincCode11ResultDate;
                patlab.LoincCode12 = patientLabOrderTestModel.LoincCode12;
                patlab.LoincCode12Result = patientLabOrderTestModel.LoincCode12Result;
                patlab.LoincCode12ResultUnits = patientLabOrderTestModel.LoincCode12ResultUnits;
                patlab.LoincCode12ResultDate = patientLabOrderTestModel.LoincCode12ResultDate;
                patlab.LoincCode13 = patientLabOrderTestModel.LoincCode13;
                patlab.LoincCode13Result = patientLabOrderTestModel.LoincCode13Result;
                patlab.LoincCode13ResultUnits = patientLabOrderTestModel.LoincCode13ResultUnits;
                patlab.LoincCode13ResultDate = patientLabOrderTestModel.LoincCode13ResultDate;
                patlab.LoincCode14 = patientLabOrderTestModel.LoincCode14;
                patlab.LoincCode14Result = patientLabOrderTestModel.LoincCode14Result;
                patlab.LoincCode14ResultUnits = patientLabOrderTestModel.LoincCode14ResultUnits;
                patlab.LoincCode14ResultDate = patientLabOrderTestModel.LoincCode14ResultDate;
                patlab.LoincCode15 = patientLabOrderTestModel.LoincCode15;
                patlab.LoincCode15Result = patientLabOrderTestModel.LoincCode15Result;
                patlab.LoincCode15ResultUnits = patientLabOrderTestModel.LoincCode15ResultUnits;
                patlab.LoincCode15ResultDate = patientLabOrderTestModel.LoincCode15ResultDate;
                patlab.LoincCode16 = patientLabOrderTestModel.LoincCode16;
                patlab.LoincCode16Result = patientLabOrderTestModel.LoincCode16Result;
                patlab.LoincCode16ResultUnits = patientLabOrderTestModel.LoincCode16ResultUnits;
                patlab.LoincCode16ResultDate = patientLabOrderTestModel.LoincCode16ResultDate;
                patlab.ICDCode1 = patientLabOrderTestModel.ICDCode1;
                patlab.ICDCode2 = patientLabOrderTestModel.ICDCode2;
                patlab.ICDCode3 = patientLabOrderTestModel.ICDCode3;
                patlab.ICDCode4 = patientLabOrderTestModel.ICDCode4;
                patlab.ICDCode5 = patientLabOrderTestModel.ICDCode5;
                patlab.ICDCode6 = patientLabOrderTestModel.ICDCode6;
                patlab.ICDCode7 = patientLabOrderTestModel.ICDCode7;
                patlab.ICDCode8 = patientLabOrderTestModel.ICDCode8;
                patlab.ICDCode9 = patientLabOrderTestModel.ICDCode9;
                patlab.ICDCode10 = patientLabOrderTestModel.ICDCode10;
                patlab.Notes = patientLabOrderTestModel.Notes;
                patlab.Deleted = false;
                patlab.ModifiedBy = "User";
                patlab.ModifiedDate = DateTime.Now;
                patlab.DocumentReferenceIds = patientLabOrderTestModel.DocumentReferenceIds;
                patlab.ScheduledTestStatusID = patientLabOrderTestModel.ScheduledTestStatusID;
                patlab.IsPrinted = patientLabOrderTestModel.IsPrinted;
                patlab.IsEditable = patientLabOrderTestModel.IsEditable;
                patlab.OrderTypeID = patientLabOrderTestModel.OrderTypeID;
                patlab.BillTypeID = patientLabOrderTestModel.BillTypeID;
                patlab.InsuranceCodeId = patientLabOrderTestModel.InsuranceCodeId;
                patlab.Template = patientLabOrderTestModel.Template;
                patlab.PrepaidAmount = patientLabOrderTestModel.PrepaidAmount;
                patlab.STAT = patientLabOrderTestModel.STAT;
                patlab.CollectionDate = patientLabOrderTestModel.CollectionDate;
                patlab.PreferredlanguageId = patientLabOrderTestModel.PreferredlanguageId;
                patlab.PatientRaceID = patientLabOrderTestModel.PatientRaceID;
                patlab.PatientEthnicityID = patientLabOrderTestModel.PatientEthnicityID;
                patlab.GenderIdentityID = patientLabOrderTestModel.GenderIdentityID;
                patlab.SexualOrientationID = patientLabOrderTestModel.SexualOrientationID;
                patlab.Instructions = patientLabOrderTestModel.Instructions;
                patlab.ReportComments = patientLabOrderTestModel.ReportComments;
                patlab.Phonenumber = patientLabOrderTestModel.Phonenumber;
                patlab.Fax = patientLabOrderTestModel.Fax;

                this._uow.GenericRepository<PatientLabOrderTest>().Update(patlab);

            }
            this._uow.Save();

            patientLabOrderTestModel.PatientLabOrderTestID = patlab.PatientLabOrderTestID;

            return patientLabOrderTestModel;

        }

        public List<PatientLabOrderTestModel> GetELabOrderTest()
        {
            //string scheduledTestStatus = clsCommon.GetEnumDescription(clsCommon.CommonMasterCategory.ScheduledTestStatus);
            var queryPatientLabOrderTest = (from plot in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => (!x.Deleted))
                                            join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on plot.PatientID equals p.PatientID into patientJoin
                                            from p in patientJoin.DefaultIfEmpty()
                                            join pr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.ProviderID equals pr.ProviderID into providerJoin
                                            from pr in providerJoin.DefaultIfEmpty()
                                            join opr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.OrderingProviderID equals opr.ProviderID into orderingproviderJoin
                                            from opr in orderingproviderJoin.DefaultIfEmpty()
                                            join f in this._uow.GenericRepository<Facility>().Table().Where(x => !x.Deleted) on plot.FacilityID equals f.FacilityID into fac
                                            from facility in fac.DefaultIfEmpty()
                                            join sch in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted && x.Category == "scheduledTestStatus") on plot.ScheduledTestStatusID equals sch.CommonMasterID into cu
                                            from currr in cu.DefaultIfEmpty()
                                            join pv in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted) on plot.PatientVisitID equals pv.PatientVisitID into allergyVisitJoin
                                            from pv in allergyVisitJoin.DefaultIfEmpty()
                                            join lrhl7 in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => !x.Deleted) on plot.PatientLabOrderTestID equals lrhl7.PatientLabOrderTestID
                                            into patientLabOrderTestID

                                            from lrhl in patientLabOrderTestID.DefaultIfEmpty()
                                            orderby plot.CreatedDate descending
                                            select new
                                            {
                                                PatientLabOrderTestID = plot.PatientLabOrderTestID,
                                                FacilityID = plot.FacilityID,
                                                FacilityName = facility.FacilityName,
                                                EmdeonLabID = plot.EmdeonLabID,
                                                LabFacilityName = plot.FacilityName,
                                                ProviderID = plot.ProviderID,
                                                ProviderNameLast = pr.NameLast,
                                                VisitDate = pv.VisitDate,
                                                ProviderNameFirst = pr.NameFirst,
                                                ProviderNameMiddle = pr.NameMiddle,
                                                OrderingProviderID = plot.OrderingProviderID,
                                                OrderingProviderNameLast = opr.NameLast,
                                                OrderingProviderNameFirst = opr.NameFirst,
                                                OrderingProviderNameMiddle = opr.NameMiddle,
                                                ProviderName = plot.ProviderName,
                                                OrderingProviderName = plot.OrderingProviderName,
                                                PatientID = plot.PatientID,
                                                PatientNameFirst = p.NameFirst,
                                                PatientNameLast = p.NameLast,
                                                PatientNameMiddle = p.NameMiddle,
                                                LabTestDate = plot.LabTestDate,
                                                LabName = plot.LabName,
                                                LabAddressLine1 = plot.LabAddressLine1,
                                                LabAddressLine2 = plot.LabAddressLine2,
                                                LabCity = plot.LabCity,
                                                LabState = plot.LabState,
                                                LabCounty = plot.LabCounty,
                                                LabZIP = plot.LabZIP,
                                                LoincCode1 = plot.LoincCode1,
                                                LoincCode1Result = plot.LoincCode1Result,
                                                LoincCode1ResultUnits = plot.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = plot.LoincCode1ResultDate,
                                                LoincCode2 = plot.LoincCode2,
                                                LoincCode2Result = plot.LoincCode2Result,
                                                LoincCode2ResultUnits = plot.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = plot.LoincCode2ResultDate,
                                                LoincCode3 = plot.LoincCode3,
                                                LoincCode3Result = plot.LoincCode3Result,
                                                LoincCode3ResultUnits = plot.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = plot.LoincCode3ResultDate,
                                                LoincCode4 = plot.LoincCode4,
                                                LoincCode4Result = plot.LoincCode4Result,
                                                LoincCode4ResultUnits = plot.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = plot.LoincCode4ResultDate,
                                                LoincCode5 = plot.LoincCode5,
                                                LoincCode5Result = plot.LoincCode5Result,
                                                LoincCode5ResultUnits = plot.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = plot.LoincCode5ResultDate,
                                                LoincCode6 = plot.LoincCode6,
                                                LoincCode6Result = plot.LoincCode6Result,
                                                LoincCode6ResultUnits = plot.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = plot.LoincCode6ResultDate,
                                                LoincCode7 = plot.LoincCode7,
                                                LoincCode7Result = plot.LoincCode7Result,
                                                LoincCode7ResultUnits = plot.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = plot.LoincCode7ResultDate,
                                                LoincCode8 = plot.LoincCode8,
                                                LoincCode8Result = plot.LoincCode8Result,
                                                LoincCode8ResultUnits = plot.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = plot.LoincCode8ResultDate,
                                                LoincCode9 = plot.LoincCode9,
                                                LoincCode9Result = plot.LoincCode9Result,
                                                LoincCode9ResultUnits = plot.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = plot.LoincCode9ResultDate,
                                                LoincCode10 = plot.LoincCode10,
                                                LoincCode10Result = plot.LoincCode10Result,
                                                LoincCode10ResultUnits = plot.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = plot.LoincCode10ResultDate,
                                                LoincCode11 = plot.LoincCode11,
                                                LoincCode11Result = plot.LoincCode11Result,
                                                LoincCode11ResultUnits = plot.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = plot.LoincCode11ResultDate,
                                                LoincCode12 = plot.LoincCode12,
                                                LoincCode12Result = plot.LoincCode12Result,
                                                LoincCode12ResultUnits = plot.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = plot.LoincCode12ResultDate,
                                                LoincCode13 = plot.LoincCode13,
                                                LoincCode13Result = plot.LoincCode13Result,
                                                LoincCode13ResultUnits = plot.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = plot.LoincCode13ResultDate,
                                                LoincCode14 = plot.LoincCode14,
                                                LoincCode14Result = plot.LoincCode14Result,
                                                LoincCode14ResultUnits = plot.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = plot.LoincCode14ResultDate,
                                                LoincCode15 = plot.LoincCode15,
                                                LoincCode15Result = plot.LoincCode15Result,
                                                LoincCode15ResultUnits = plot.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = plot.LoincCode15ResultDate,
                                                LoincCode16 = plot.LoincCode16,
                                                LoincCode16Result = plot.LoincCode16Result,
                                                LoincCode16ResultUnits = plot.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = plot.LoincCode16ResultDate,
                                                ICDCode1 = plot.ICDCode1,
                                                ICDCode2 = plot.ICDCode2,
                                                ICDCode3 = plot.ICDCode3,
                                                ICDCode4 = plot.ICDCode4,
                                                ICDCode5 = plot.ICDCode5,
                                                ICDCode6 = plot.ICDCode6,
                                                ICDCode7 = plot.ICDCode7,
                                                ICDCode8 = plot.ICDCode8,
                                                ICDCode9 = plot.ICDCode9,
                                                ICDCode10 = plot.ICDCode10,
                                                Notes = plot.Notes,
                                                Deleted = plot.Deleted,
                                                CreatedBy = plot.CreatedBy,
                                                CreatedDate = plot.CreatedDate,
                                                ModifiedBy = plot.ModifiedBy,
                                                ModifiedDate = plot.ModifiedDate,
                                                PatientVisitID = plot.PatientVisitID,
                                                PatientTransactionDate = pv.VisitDate,
                                                VisitTime = pv.VisitTime,
                                                DocumentReferenceIDs = plot.DocumentReferenceIds,
                                                ScheduledTestStatusID = plot.ScheduledTestStatusID,
                                                ScheduledTestStatusDescription = currr.Description,
                                                LabResponseHL7ID = (lrhl.LabResponseHL7ID > 0) ? 0 : lrhl.LabResponseHL7ID,
                                                IsEditable = plot.IsEditable,
                                                IsPrinted = plot.IsPrinted,
                                                OrderTypeID = plot.OrderTypeID,
                                                BillTypeID = plot.BillTypeID,
                                                InsuranceCodeId = plot.InsuranceCodeId,
                                                Template = plot.Template,
                                                PrepaidAmount = plot.PrepaidAmount,
                                                STAT = plot.STAT,
                                                CollectionDate = plot.CollectionDate,
                                                PreferredlanguageId = plot.PreferredlanguageId,
                                                PatientRaceID = plot.PatientRaceID,
                                                PatientEthnicityID = plot.PatientEthnicityID,
                                                GenderIdentityID = plot.GenderIdentityID,
                                                SexualOrientationID = plot.SexualOrientationID,
                                                Instructions = plot.Instructions,
                                                ReportComments = plot.ReportComments,
                                                Phonenumber = plot.Phonenumber,
                                                Fax = plot.Fax

                                            })
                                            .AsEnumerable()
                                            .Select(x => new PatientLabOrderTestModel
                                            {
                                                PatientLabOrderTestID = x.PatientLabOrderTestID,
                                                EmdeonLabID = x.EmdeonLabID,
                                                PatientLabOrderTestFacilityID = x.FacilityID,
                                                FacilityName = x.FacilityID > 0 ? this._uow.GenericRepository<Facility>().Table().Where(y => y.FacilityID == x.FacilityID).FirstOrDefault().FacilityName : "",
                                                PatientLabOrderTestProviderID = x.ProviderID,
                                                ProviderNameLabOrder = x.ProviderNameLast + " " + x.ProviderNameFirst + " " + x.ProviderNameMiddle,
                                                OrderingProviderNameLabOrder = x.OrderingProviderNameLast + " " + x.OrderingProviderNameFirst + " " + x.OrderingProviderNameMiddle,
                                                PatientLabOrderTestOrderingProviderID = x.OrderingProviderID,
                                                PatientID = x.PatientID,
                                                PatientName = x.PatientNameLast + " " + x.PatientNameFirst + " " + x.PatientNameMiddle,
                                                PatientVisitID = x.PatientVisitID,
                                                VisitTime = x.VisitTime,
                                                LabTestDate = x.LabTestDate,
                                                LabName = x.LabName,
                                                LabAddressLine1 = (x.LabAddressLine1 == null ? "" : (x.LabAddressLine1 + ",")) + (x.LabAddressLine2 == null ? "" : (x.LabAddressLine2 + ",")) + (x.LabZIP == null ? "" : x.LabZIP == null ? "" : (x.LabZIP + ",")) + (x.LabCity == null ? "" : (x.LabCity + ",")) + (x.LabState == null ? "" : (x.LabState)) + (x.LabCounty == null ? "" : (x.LabCounty)),
                                                LabAddressLine2 = x.LabAddressLine2,
                                                LabCity = x.LabCity,
                                                LabState = x.LabState,
                                                LabCounty = x.LabCounty,
                                                LabZIP = x.LabZIP,
                                                LoincCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.LoincCode1 + " " + GetLoincCodeDescription(x.LoincCode1), x.LoincCode2 + " " + GetLoincCodeDescription(x.LoincCode2), x.LoincCode3 + " " + GetLoincCodeDescription(x.LoincCode3), x.LoincCode4 + " " + GetLoincCodeDescription(x.LoincCode4), x.LoincCode5 + " " + GetLoincCodeDescription(x.LoincCode5), x.LoincCode6 + " " + GetLoincCodeDescription(x.LoincCode6),
                                                x.LoincCode7 + " " + GetLoincCodeDescription(x.LoincCode7), x.LoincCode8 + " " + GetLoincCodeDescription(x.LoincCode8), x.LoincCode9 + " " + GetLoincCodeDescription(x.LoincCode9), x.LoincCode10 + " " + GetLoincCodeDescription(x.LoincCode10), x.LoincCode11 + " " + GetLoincCodeDescription(x.LoincCode11), x.LoincCode12 + " " + GetLoincCodeDescription(x.LoincCode12), x.LoincCode13 + " " + GetLoincCodeDescription(x.LoincCode13), x.LoincCode14 + " " + GetLoincCodeDescription(x.LoincCode14), x.LoincCode15 + " " + GetLoincCodeDescription(x.LoincCode15), x.LoincCode16 + " " + GetLoincCodeDescription(x.LoincCode16)).Replace(",,", "").Replace(" ,", "")).ToString()),
                                                ICDCode1 = x.ICDCode1,
                                                ICDCode2 = x.ICDCode2,
                                                ICDCode3 = x.ICDCode3,
                                                ICDCode4 = x.ICDCode4,
                                                ICDCode5 = x.ICDCode5,
                                                ICDCode6 = x.ICDCode6,
                                                ICDCode7 = x.ICDCode7,
                                                ICDCode8 = x.ICDCode8,
                                                ICDCode9 = x.ICDCode9,
                                                ICDCode10 = x.ICDCode10,
                                                LoincCode1 = x.LoincCode1,
                                                LoincCode1Description = GetLoincCodeDescription(x.LoincCode1),
                                                LoincCode1Result = x.LoincCode1Result,
                                                LoincCode1ResultUnits = x.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = x.LoincCode1ResultDate,
                                                LoincCode2 = x.LoincCode2,
                                                LoincCode2Description = GetLoincCodeDescription(x.LoincCode2),
                                                LoincCode2Result = x.LoincCode2Result,
                                                LoincCode2ResultUnits = x.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = x.LoincCode2ResultDate,
                                                LoincCode3 = x.LoincCode3,
                                                LoincCode3Description = GetLoincCodeDescription(x.LoincCode3),
                                                LoincCode3Result = x.LoincCode3Result,
                                                LoincCode3ResultUnits = x.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = x.LoincCode3ResultDate,
                                                LoincCode4 = x.LoincCode4,
                                                LoincCode4Description = GetLoincCodeDescription(x.LoincCode4),
                                                LoincCode4Result = x.LoincCode4Result,
                                                LoincCode4ResultUnits = x.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = x.LoincCode4ResultDate,
                                                LoincCode5 = x.LoincCode5,
                                                LoincCode5Description = GetLoincCodeDescription(x.LoincCode5),
                                                LoincCode5Result = x.LoincCode5Result,
                                                LoincCode5ResultUnits = x.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = x.LoincCode5ResultDate,
                                                LoincCode6 = x.LoincCode6,
                                                LoincCode6Description = GetLoincCodeDescription(x.LoincCode6),
                                                LoincCode6Result = x.LoincCode6Result,
                                                LoincCode6ResultUnits = x.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = x.LoincCode6ResultDate,
                                                LoincCode7 = x.LoincCode7,
                                                LoincCode7Description = GetLoincCodeDescription(x.LoincCode7),
                                                LoincCode7Result = x.LoincCode7Result,
                                                LoincCode7ResultUnits = x.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = x.LoincCode7ResultDate,
                                                LoincCode8 = x.LoincCode8,
                                                LoincCode8Result = x.LoincCode8Result,
                                                LoincCode8ResultUnits = x.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = x.LoincCode8ResultDate,
                                                LoincCode8Description = GetLoincCodeDescription(x.LoincCode8),
                                                LoincCode9 = x.LoincCode9,
                                                LoincCode9Description = GetLoincCodeDescription(x.LoincCode9),
                                                LoincCode9Result = x.LoincCode9Result,
                                                LoincCode9ResultUnits = x.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = x.LoincCode9ResultDate,
                                                LoincCode10 = x.LoincCode10,
                                                LoincCode10Description = GetLoincCodeDescription(x.LoincCode10),
                                                LoincCode10Result = x.LoincCode10Result,
                                                LoincCode10ResultUnits = x.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = x.LoincCode10ResultDate,
                                                LoincCode11 = x.LoincCode11,
                                                LoincCode11Description = GetLoincCodeDescription(x.LoincCode11),
                                                LoincCode11Result = x.LoincCode11Result,
                                                LoincCode11ResultUnits = x.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = x.LoincCode11ResultDate,
                                                LoincCode12 = x.LoincCode12,
                                                LoincCode12Description = GetLoincCodeDescription(x.LoincCode12),
                                                LoincCode12Result = x.LoincCode12Result,
                                                LoincCode12ResultUnits = x.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = x.LoincCode12ResultDate,
                                                LoincCode13 = x.LoincCode13,
                                                LoincCode13Description = GetLoincCodeDescription(x.LoincCode13),
                                                LoincCode13Result = x.LoincCode13Result,
                                                LoincCode13ResultUnits = x.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = x.LoincCode13ResultDate,
                                                LoincCode14 = x.LoincCode14,
                                                LoincCode14Description = GetLoincCodeDescription(x.LoincCode14),
                                                LoincCode14Result = x.LoincCode14Result,
                                                LoincCode14ResultUnits = x.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = x.LoincCode14ResultDate,
                                                LoincCode15 = x.LoincCode15,
                                                LoincCode15Description = GetLoincCodeDescription(x.LoincCode15),
                                                LoincCode15Result = x.LoincCode15Result,
                                                LoincCode15ResultUnits = x.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = x.LoincCode15ResultDate,
                                                LoincCode16 = x.LoincCode16,
                                                LoincCode16Description = GetLoincCodeDescription(x.LoincCode16),
                                                LoincCode16Result = x.LoincCode16Result,
                                                LoincCode16ResultUnits = x.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = x.LoincCode16ResultDate,
                                                DiagnosisCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.ICDCode1, x.ICDCode2, x.ICDCode3, x.ICDCode4, x.ICDCode5, x.ICDCode6,
                        x.ICDCode7, x.ICDCode7, x.ICDCode9, x.ICDCode10).Replace(",,", "")).ToString()),
                                                Notes = x.Notes,
                                                PatientTransactionDateString = x.PatientTransactionDate.ToString(),
                                                Deleted = x.Deleted,
                                                CreatedDate = x.CreatedDate,
                                                CreatedBy = x.CreatedBy,
                                                ModifiedDate = x.ModifiedDate,
                                                ModifiedBy = x.ModifiedBy,
                                                DocumentReferenceIds = x.DocumentReferenceIDs,
                                                ScheduledTestStatusID = x.ScheduledTestStatusID,
                                                LabOrderScheduledTestStatusDescription = x.ScheduledTestStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                                IsPatientLabOrderTestIDHave = x.LabResponseHL7ID != 0 ? true : false,
                                                IsEditable = x.IsEditable,
                                                IsPrinted = x.IsPrinted,
                                                OrderTypeID = x.OrderTypeID,
                                                OrderTypeDescription = x.OrderTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.OrderTypeID).FirstOrDefault().Description : "",
                                                BillTypeID = x.BillTypeID,
                                                BillTypeDescription = x.BillTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.BillTypeID).FirstOrDefault().Description : "",
                                                InsuranceCodeId = x.InsuranceCodeId,
                                                Template = x.Template,
                                                PrepaidAmount = x.PrepaidAmount,
                                                STAT = x.STAT,
                                                CollectionDate = x.CollectionDate,
                                                PreferredlanguageId = x.PreferredlanguageId,
                                                PreferredLanguageDescription = x.PreferredlanguageId > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(y => y.RegionalLanguageID == x.PreferredlanguageId).FirstOrDefault().Description : "",
                                                PatientRaceID = x.PatientRaceID,
                                                PatientRaceDescription = x.PatientRaceID > 0 ? this._uow.GenericRepository<Race>().Table().Where(y => y.RaceID == x.PatientRaceID).FirstOrDefault().Description : "",
                                                PatientEthnicityID = x.PatientEthnicityID,
                                                PatientEthnicityDescription = x.PatientEthnicityID > 0 ? this._uow.GenericRepository<Ethnicity>().Table().Where(y => y.EthnicityID == x.PatientEthnicityID).FirstOrDefault().Description : "",
                                                GenderIdentityID = x.GenderIdentityID,
                                                GenderDescription = x.GenderIdentityID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.GenderIdentityID).FirstOrDefault().Description : "",
                                                SexualOrientationID = x.SexualOrientationID,
                                                SexualOrientationDescription = x.SexualOrientationID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.SexualOrientationID).FirstOrDefault().Description : "",
                                                Instructions = x.Instructions,
                                                ReportComments = x.ReportComments,
                                                Phonenumber = x.Phonenumber,
                                                Fax = x.Fax
                                            }).ToList();
            return queryPatientLabOrderTest;

        }

        public List<PatientLabOrderTestModel> GetELabOrderTestByPatientId(int PatientId)
        {
            //string scheduledTestStatus = clsCommon.GetEnumDescription(clsCommon.CommonMasterCategory.ScheduledTestStatus);
            var queryPatientLabOrderTest = (from plot in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => (!x.Deleted) && (x.PatientID == PatientId))
                                            join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on plot.PatientID equals p.PatientID into patientJoin
                                            from p in patientJoin.DefaultIfEmpty()
                                            join pr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.ProviderID equals pr.ProviderID into providerJoin
                                            from pr in providerJoin.DefaultIfEmpty()
                                            join opr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.OrderingProviderID equals opr.ProviderID into orderingproviderJoin
                                            from opr in orderingproviderJoin.DefaultIfEmpty()
                                            join f in this._uow.GenericRepository<Facility>().Table().Where(x => !x.Deleted) on plot.FacilityID equals f.FacilityID into fac
                                            from facility in fac.DefaultIfEmpty()
                                            join sch in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted && x.Category == "scheduledTestStatus") on plot.ScheduledTestStatusID equals sch.CommonMasterID into cu
                                            from currr in cu.DefaultIfEmpty()
                                            join pv in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted) on plot.PatientVisitID equals pv.PatientVisitID into allergyVisitJoin
                                            from pv in allergyVisitJoin.DefaultIfEmpty()
                                            join lrhl7 in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => !x.Deleted) on plot.PatientLabOrderTestID equals lrhl7.PatientLabOrderTestID
                                            into patientLabOrderTestID

                                            from lrhl in patientLabOrderTestID.DefaultIfEmpty()
                                            orderby plot.CreatedDate descending
                                            select new
                                            {
                                                PatientLabOrderTestID = plot.PatientLabOrderTestID,
                                                FacilityID = plot.FacilityID,
                                                FacilityName = facility.FacilityName,
                                                EmdeonLabID = plot.EmdeonLabID,
                                                LabFacilityName = plot.FacilityName,
                                                ProviderID = plot.ProviderID,
                                                ProviderNameLast = pr.NameLast,
                                                VisitDate = pv.VisitDate,
                                                ProviderNameFirst = pr.NameFirst,
                                                ProviderNameMiddle = pr.NameMiddle,
                                                OrderingProviderID = plot.OrderingProviderID,
                                                OrderingProviderNameLast = opr.NameLast,
                                                OrderingProviderNameFirst = opr.NameFirst,
                                                OrderingProviderNameMiddle = opr.NameMiddle,
                                                ProviderName = plot.ProviderName,
                                                OrderingProviderName = plot.OrderingProviderName,
                                                PatientID = plot.PatientID,
                                                PatientNameFirst = p.NameFirst,
                                                PatientNameLast = p.NameLast,
                                                PatientNameMiddle = p.NameMiddle,
                                                LabTestDate = plot.LabTestDate,
                                                LabName = plot.LabName,
                                                LabAddressLine1 = plot.LabAddressLine1,
                                                LabAddressLine2 = plot.LabAddressLine2,
                                                LabCity = plot.LabCity,
                                                LabState = plot.LabState,
                                                LabCounty = plot.LabCounty,
                                                LabZIP = plot.LabZIP,
                                                LoincCode1 = plot.LoincCode1,
                                                LoincCode1Result = plot.LoincCode1Result,
                                                LoincCode1ResultUnits = plot.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = plot.LoincCode1ResultDate,
                                                LoincCode2 = plot.LoincCode2,
                                                LoincCode2Result = plot.LoincCode2Result,
                                                LoincCode2ResultUnits = plot.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = plot.LoincCode2ResultDate,
                                                LoincCode3 = plot.LoincCode3,
                                                LoincCode3Result = plot.LoincCode3Result,
                                                LoincCode3ResultUnits = plot.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = plot.LoincCode3ResultDate,
                                                LoincCode4 = plot.LoincCode4,
                                                LoincCode4Result = plot.LoincCode4Result,
                                                LoincCode4ResultUnits = plot.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = plot.LoincCode4ResultDate,
                                                LoincCode5 = plot.LoincCode5,
                                                LoincCode5Result = plot.LoincCode5Result,
                                                LoincCode5ResultUnits = plot.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = plot.LoincCode5ResultDate,
                                                LoincCode6 = plot.LoincCode6,
                                                LoincCode6Result = plot.LoincCode6Result,
                                                LoincCode6ResultUnits = plot.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = plot.LoincCode6ResultDate,
                                                LoincCode7 = plot.LoincCode7,
                                                LoincCode7Result = plot.LoincCode7Result,
                                                LoincCode7ResultUnits = plot.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = plot.LoincCode7ResultDate,
                                                LoincCode8 = plot.LoincCode8,
                                                LoincCode8Result = plot.LoincCode8Result,
                                                LoincCode8ResultUnits = plot.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = plot.LoincCode8ResultDate,
                                                LoincCode9 = plot.LoincCode9,
                                                LoincCode9Result = plot.LoincCode9Result,
                                                LoincCode9ResultUnits = plot.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = plot.LoincCode9ResultDate,
                                                LoincCode10 = plot.LoincCode10,
                                                LoincCode10Result = plot.LoincCode10Result,
                                                LoincCode10ResultUnits = plot.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = plot.LoincCode10ResultDate,
                                                LoincCode11 = plot.LoincCode11,
                                                LoincCode11Result = plot.LoincCode11Result,
                                                LoincCode11ResultUnits = plot.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = plot.LoincCode11ResultDate,
                                                LoincCode12 = plot.LoincCode12,
                                                LoincCode12Result = plot.LoincCode12Result,
                                                LoincCode12ResultUnits = plot.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = plot.LoincCode12ResultDate,
                                                LoincCode13 = plot.LoincCode13,
                                                LoincCode13Result = plot.LoincCode13Result,
                                                LoincCode13ResultUnits = plot.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = plot.LoincCode13ResultDate,
                                                LoincCode14 = plot.LoincCode14,
                                                LoincCode14Result = plot.LoincCode14Result,
                                                LoincCode14ResultUnits = plot.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = plot.LoincCode14ResultDate,
                                                LoincCode15 = plot.LoincCode15,
                                                LoincCode15Result = plot.LoincCode15Result,
                                                LoincCode15ResultUnits = plot.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = plot.LoincCode15ResultDate,
                                                LoincCode16 = plot.LoincCode16,
                                                LoincCode16Result = plot.LoincCode16Result,
                                                LoincCode16ResultUnits = plot.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = plot.LoincCode16ResultDate,
                                                ICDCode1 = plot.ICDCode1,
                                                ICDCode2 = plot.ICDCode2,
                                                ICDCode3 = plot.ICDCode3,
                                                ICDCode4 = plot.ICDCode4,
                                                ICDCode5 = plot.ICDCode5,
                                                ICDCode6 = plot.ICDCode6,
                                                ICDCode7 = plot.ICDCode7,
                                                ICDCode8 = plot.ICDCode8,
                                                ICDCode9 = plot.ICDCode9,
                                                ICDCode10 = plot.ICDCode10,
                                                Notes = plot.Notes,
                                                Deleted = plot.Deleted,
                                                CreatedBy = plot.CreatedBy,
                                                CreatedDate = plot.CreatedDate,
                                                ModifiedBy = plot.ModifiedBy,
                                                ModifiedDate = plot.ModifiedDate,
                                                PatientVisitID = plot.PatientVisitID,
                                                PatientTransactionDate = pv.VisitDate,
                                                VisitTime = pv.VisitTime,
                                                DocumentReferenceIDs = plot.DocumentReferenceIds,
                                                ScheduledTestStatusID = plot.ScheduledTestStatusID,
                                                ScheduledTestStatusDescription = currr.Description,
                                                LabResponseHL7ID = (lrhl.LabResponseHL7ID > 0) ? 0 : lrhl.LabResponseHL7ID,
                                                IsEditable = plot.IsEditable,
                                                IsPrinted = plot.IsPrinted,
                                                OrderTypeID = plot.OrderTypeID,
                                                BillTypeID = plot.BillTypeID,
                                                InsuranceCodeId = plot.InsuranceCodeId,
                                                Template = plot.Template,
                                                PrepaidAmount = plot.PrepaidAmount,
                                                STAT = plot.STAT,
                                                CollectionDate = plot.CollectionDate,
                                                PreferredlanguageId = plot.PreferredlanguageId,
                                                PatientRaceID = plot.PatientRaceID,
                                                PatientEthnicityID = plot.PatientEthnicityID,
                                                GenderIdentityID = plot.GenderIdentityID,
                                                SexualOrientationID = plot.SexualOrientationID,
                                                Instructions = plot.Instructions,
                                                ReportComments = plot.ReportComments,
                                                Phonenumber = plot.Phonenumber,
                                                Fax = plot.Fax

                                            })
                                            .AsEnumerable()
                                            .Select(x => new PatientLabOrderTestModel
                                            {
                                                PatientLabOrderTestID = x.PatientLabOrderTestID,
                                                EmdeonLabID = x.EmdeonLabID,
                                                PatientLabOrderTestFacilityID = x.FacilityID,
                                                FacilityName = x.FacilityID > 0 ? this._uow.GenericRepository<Facility>().Table().Where(y => y.FacilityID == x.FacilityID).FirstOrDefault().FacilityName : "",
                                                PatientLabOrderTestProviderID = x.ProviderID,
                                                ProviderNameLabOrder = x.ProviderNameLast + " " + x.ProviderNameFirst + " " + x.ProviderNameMiddle,
                                                OrderingProviderNameLabOrder = x.OrderingProviderNameLast + " " + x.OrderingProviderNameFirst + " " + x.OrderingProviderNameMiddle,
                                                PatientLabOrderTestOrderingProviderID = x.OrderingProviderID,
                                                PatientID = x.PatientID,
                                                PatientName = x.PatientNameLast + " " + x.PatientNameFirst + " " + x.PatientNameMiddle,
                                                PatientVisitID = x.PatientVisitID,
                                                VisitTime = x.VisitTime,
                                                LabTestDate = x.LabTestDate,
                                                LabName = x.LabName,
                                                LabAddressLine1 = (x.LabAddressLine1 == null ? "" : (x.LabAddressLine1 + ",")) + (x.LabAddressLine2 == null ? "" : (x.LabAddressLine2 + ",")) + (x.LabZIP == null ? "" : x.LabZIP == null ? "" : (x.LabZIP + ",")) + (x.LabCity == null ? "" : (x.LabCity + ",")) + (x.LabState == null ? "" : (x.LabState)) + (x.LabCounty == null ? "" : (x.LabCounty)),
                                                LabAddressLine2 = x.LabAddressLine2,
                                                LabCity = x.LabCity,
                                                LabState = x.LabState,
                                                LabCounty = x.LabCounty,
                                                LabZIP = x.LabZIP,
                                                LoincCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.LoincCode1 + " " + GetLoincCodeDescription(x.LoincCode1), x.LoincCode2 + " " + GetLoincCodeDescription(x.LoincCode2), x.LoincCode3 + " " + GetLoincCodeDescription(x.LoincCode3), x.LoincCode4 + " " + GetLoincCodeDescription(x.LoincCode4), x.LoincCode5 + " " + GetLoincCodeDescription(x.LoincCode5), x.LoincCode6 + " " + GetLoincCodeDescription(x.LoincCode6),
                                                x.LoincCode7 + " " + GetLoincCodeDescription(x.LoincCode7), x.LoincCode8 + " " + GetLoincCodeDescription(x.LoincCode8), x.LoincCode9 + " " + GetLoincCodeDescription(x.LoincCode9), x.LoincCode10 + " " + GetLoincCodeDescription(x.LoincCode10), x.LoincCode11 + " " + GetLoincCodeDescription(x.LoincCode11), x.LoincCode12 + " " + GetLoincCodeDescription(x.LoincCode12), x.LoincCode13 + " " + GetLoincCodeDescription(x.LoincCode13), x.LoincCode14 + " " + GetLoincCodeDescription(x.LoincCode14), x.LoincCode15 + " " + GetLoincCodeDescription(x.LoincCode15), x.LoincCode16 + " " + GetLoincCodeDescription(x.LoincCode16)).Replace(",,", "").Replace(" ,", "")).ToString()),
                                                ICDCode1 = x.ICDCode1,
                                                ICDCode2 = x.ICDCode2,
                                                ICDCode3 = x.ICDCode3,
                                                ICDCode4 = x.ICDCode4,
                                                ICDCode5 = x.ICDCode5,
                                                ICDCode6 = x.ICDCode6,
                                                ICDCode7 = x.ICDCode7,
                                                ICDCode8 = x.ICDCode8,
                                                ICDCode9 = x.ICDCode9,
                                                ICDCode10 = x.ICDCode10,
                                                LoincCode1 = x.LoincCode1,
                                                LoincCode1Description = GetLoincCodeDescription(x.LoincCode1),
                                                LoincCode1Result = x.LoincCode1Result,
                                                LoincCode1ResultUnits = x.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = x.LoincCode1ResultDate,
                                                LoincCode2 = x.LoincCode2,
                                                LoincCode2Description = GetLoincCodeDescription(x.LoincCode2),
                                                LoincCode2Result = x.LoincCode2Result,
                                                LoincCode2ResultUnits = x.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = x.LoincCode2ResultDate,
                                                LoincCode3 = x.LoincCode3,
                                                LoincCode3Description = GetLoincCodeDescription(x.LoincCode3),
                                                LoincCode3Result = x.LoincCode3Result,
                                                LoincCode3ResultUnits = x.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = x.LoincCode3ResultDate,
                                                LoincCode4 = x.LoincCode4,
                                                LoincCode4Description = GetLoincCodeDescription(x.LoincCode4),
                                                LoincCode4Result = x.LoincCode4Result,
                                                LoincCode4ResultUnits = x.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = x.LoincCode4ResultDate,
                                                LoincCode5 = x.LoincCode5,
                                                LoincCode5Description = GetLoincCodeDescription(x.LoincCode5),
                                                LoincCode5Result = x.LoincCode5Result,
                                                LoincCode5ResultUnits = x.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = x.LoincCode5ResultDate,
                                                LoincCode6 = x.LoincCode6,
                                                LoincCode6Description = GetLoincCodeDescription(x.LoincCode6),
                                                LoincCode6Result = x.LoincCode6Result,
                                                LoincCode6ResultUnits = x.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = x.LoincCode6ResultDate,
                                                LoincCode7 = x.LoincCode7,
                                                LoincCode7Description = GetLoincCodeDescription(x.LoincCode7),
                                                LoincCode7Result = x.LoincCode7Result,
                                                LoincCode7ResultUnits = x.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = x.LoincCode7ResultDate,
                                                LoincCode8 = x.LoincCode8,
                                                LoincCode8Result = x.LoincCode8Result,
                                                LoincCode8ResultUnits = x.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = x.LoincCode8ResultDate,
                                                LoincCode8Description = GetLoincCodeDescription(x.LoincCode8),
                                                LoincCode9 = x.LoincCode9,
                                                LoincCode9Description = GetLoincCodeDescription(x.LoincCode9),
                                                LoincCode9Result = x.LoincCode9Result,
                                                LoincCode9ResultUnits = x.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = x.LoincCode9ResultDate,
                                                LoincCode10 = x.LoincCode10,
                                                LoincCode10Description = GetLoincCodeDescription(x.LoincCode10),
                                                LoincCode10Result = x.LoincCode10Result,
                                                LoincCode10ResultUnits = x.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = x.LoincCode10ResultDate,
                                                LoincCode11 = x.LoincCode11,
                                                LoincCode11Description = GetLoincCodeDescription(x.LoincCode11),
                                                LoincCode11Result = x.LoincCode11Result,
                                                LoincCode11ResultUnits = x.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = x.LoincCode11ResultDate,
                                                LoincCode12 = x.LoincCode12,
                                                LoincCode12Description = GetLoincCodeDescription(x.LoincCode12),
                                                LoincCode12Result = x.LoincCode12Result,
                                                LoincCode12ResultUnits = x.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = x.LoincCode12ResultDate,
                                                LoincCode13 = x.LoincCode13,
                                                LoincCode13Description = GetLoincCodeDescription(x.LoincCode13),
                                                LoincCode13Result = x.LoincCode13Result,
                                                LoincCode13ResultUnits = x.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = x.LoincCode13ResultDate,
                                                LoincCode14 = x.LoincCode14,
                                                LoincCode14Description = GetLoincCodeDescription(x.LoincCode14),
                                                LoincCode14Result = x.LoincCode14Result,
                                                LoincCode14ResultUnits = x.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = x.LoincCode14ResultDate,
                                                LoincCode15 = x.LoincCode15,
                                                LoincCode15Description = GetLoincCodeDescription(x.LoincCode15),
                                                LoincCode15Result = x.LoincCode15Result,
                                                LoincCode15ResultUnits = x.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = x.LoincCode15ResultDate,
                                                LoincCode16 = x.LoincCode16,
                                                LoincCode16Description = GetLoincCodeDescription(x.LoincCode16),
                                                LoincCode16Result = x.LoincCode16Result,
                                                LoincCode16ResultUnits = x.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = x.LoincCode16ResultDate,
                                                DiagnosisCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.ICDCode1, x.ICDCode2, x.ICDCode3, x.ICDCode4, x.ICDCode5, x.ICDCode6,
                        x.ICDCode7, x.ICDCode7, x.ICDCode9, x.ICDCode10).Replace(",,", "")).ToString()),
                                                Notes = x.Notes,
                                                PatientTransactionDateString = x.PatientTransactionDate.ToString(),
                                                Deleted = x.Deleted,
                                                CreatedDate = x.CreatedDate,
                                                CreatedBy = x.CreatedBy,
                                                ModifiedDate = x.ModifiedDate,
                                                ModifiedBy = x.ModifiedBy,
                                                DocumentReferenceIds = x.DocumentReferenceIDs,
                                                ScheduledTestStatusID = x.ScheduledTestStatusID,
                                                LabOrderScheduledTestStatusDescription = x.ScheduledTestStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                                IsPatientLabOrderTestIDHave = x.LabResponseHL7ID != 0 ? true : false,
                                                IsEditable = x.IsEditable,
                                                IsPrinted = x.IsPrinted,
                                                OrderTypeID = x.OrderTypeID,
                                                OrderTypeDescription = x.OrderTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.OrderTypeID).FirstOrDefault().Description : "",
                                                BillTypeID = x.BillTypeID,
                                                BillTypeDescription = x.BillTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.BillTypeID).FirstOrDefault().Description : "",
                                                InsuranceCodeId = x.InsuranceCodeId,
                                                Template = x.Template,
                                                PrepaidAmount = x.PrepaidAmount,
                                                STAT = x.STAT,
                                                CollectionDate = x.CollectionDate,
                                                PreferredlanguageId = x.PreferredlanguageId,
                                                PreferredLanguageDescription = x.PreferredlanguageId > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(y => y.RegionalLanguageID == x.PreferredlanguageId).FirstOrDefault().Description : "",
                                                PatientRaceID = x.PatientRaceID,
                                                PatientRaceDescription = x.PatientRaceID > 0 ? this._uow.GenericRepository<Race>().Table().Where(y => y.RaceID == x.PatientRaceID).FirstOrDefault().Description : "",
                                                PatientEthnicityID = x.PatientEthnicityID,
                                                PatientEthnicityDescription = x.PatientEthnicityID > 0 ? this._uow.GenericRepository<Ethnicity>().Table().Where(y => y.EthnicityID == x.PatientEthnicityID).FirstOrDefault().Description : "",
                                                GenderIdentityID = x.GenderIdentityID,
                                                GenderDescription = x.GenderIdentityID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.GenderIdentityID).FirstOrDefault().Description : "",
                                                SexualOrientationID = x.SexualOrientationID,
                                                SexualOrientationDescription = x.SexualOrientationID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.SexualOrientationID).FirstOrDefault().Description : "",
                                                Instructions = x.Instructions,
                                                ReportComments = x.ReportComments,
                                                Phonenumber = x.Phonenumber,
                                                Fax = x.Fax
                                            }).ToList();
            return queryPatientLabOrderTest;

        }

        public List<PatientLabOrderTestModel> GetELabOrderTestbyPatientLabOrderTestID(int patientLabOrderTestId)
        {
            //string scheduledTestStatus = clsCommon.GetEnumDescription(clsCommon.CommonMasterCategory.ScheduledTestStatus);
            var queryPatientLabOrderTest = (from plot in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => x.Deleted != true && x.PatientLabOrderTestID == patientLabOrderTestId)
                                            join p in this._uow.GenericRepository<Patient>().Table().Where(x => !x.Deleted) on plot.PatientID equals p.PatientID into patientJoin
                                            from p in patientJoin.DefaultIfEmpty()
                                            join pr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.ProviderID equals pr.ProviderID into providerJoin
                                            from pr in providerJoin.DefaultIfEmpty()
                                            join opr in this._uow.GenericRepository<Provider>().Table().Where(x => !x.Deleted) on plot.OrderingProviderID equals opr.ProviderID into orderingproviderJoin
                                            from opr in orderingproviderJoin.DefaultIfEmpty()
                                            join f in this._uow.GenericRepository<Facility>().Table().Where(x => !x.Deleted) on plot.FacilityID equals f.FacilityID into fac
                                            from facility in fac.DefaultIfEmpty()
                                            join sch in this._uow.GenericRepository<CommonMaster>().Table().Where(x => !x.Deleted && x.Category == "scheduledTestStatus") on plot.ScheduledTestStatusID equals sch.CommonMasterID into cu
                                            from currr in cu.DefaultIfEmpty()
                                            join pv in this._uow.GenericRepository<PatientVisit>().Table().Where(x => !x.Deleted) on plot.PatientVisitID equals pv.PatientVisitID into allergyVisitJoin
                                            from pv in allergyVisitJoin.DefaultIfEmpty()
                                            join lrhl7 in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => !x.Deleted) on plot.PatientLabOrderTestID equals lrhl7.PatientLabOrderTestID
                                            into patientLabOrderTestID

                                            from lrhl in patientLabOrderTestID.DefaultIfEmpty()
                                            orderby plot.CreatedDate descending
                                            select new
                                            {
                                                PatientLabOrderTestID = plot.PatientLabOrderTestID,
                                                FacilityID = plot.FacilityID,
                                                FacilityName = facility.FacilityName,
                                                EmdeonLabID = plot.EmdeonLabID,
                                                LabFacilityName = plot.FacilityName,
                                                ProviderID = plot.ProviderID,
                                                ProviderNameLast = pr.NameLast,
                                                VisitDate = pv.VisitDate,
                                                ProviderNameFirst = pr.NameFirst,
                                                ProviderNameMiddle = pr.NameMiddle,
                                                OrderingProviderID = plot.OrderingProviderID,
                                                OrderingProviderNameLast = opr.NameLast,
                                                OrderingProviderNameFirst = opr.NameFirst,
                                                OrderingProviderNameMiddle = opr.NameMiddle,
                                                ProviderName = plot.ProviderName,
                                                OrderingProviderName = plot.OrderingProviderName,
                                                PatientID = plot.PatientID,
                                                PatientNameFirst = p.NameFirst,
                                                PatientNameLast = p.NameLast,
                                                PatientNameMiddle = p.NameMiddle,
                                                LabTestDate = plot.LabTestDate,
                                                LabName = plot.LabName,
                                                LabAddressLine1 = plot.LabAddressLine1,
                                                LabAddressLine2 = plot.LabAddressLine2,
                                                LabCity = plot.LabCity,
                                                LabState = plot.LabState,
                                                LabCounty = plot.LabCounty,
                                                LabZIP = plot.LabZIP,
                                                LoincCode1 = plot.LoincCode1,
                                                LoincCode1Result = plot.LoincCode1Result,
                                                LoincCode1ResultUnits = plot.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = plot.LoincCode1ResultDate,
                                                LoincCode2 = plot.LoincCode2,
                                                LoincCode2Result = plot.LoincCode2Result,
                                                LoincCode2ResultUnits = plot.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = plot.LoincCode2ResultDate,
                                                LoincCode3 = plot.LoincCode3,
                                                LoincCode3Result = plot.LoincCode3Result,
                                                LoincCode3ResultUnits = plot.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = plot.LoincCode3ResultDate,
                                                LoincCode4 = plot.LoincCode4,
                                                LoincCode4Result = plot.LoincCode4Result,
                                                LoincCode4ResultUnits = plot.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = plot.LoincCode4ResultDate,
                                                LoincCode5 = plot.LoincCode5,
                                                LoincCode5Result = plot.LoincCode5Result,
                                                LoincCode5ResultUnits = plot.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = plot.LoincCode5ResultDate,
                                                LoincCode6 = plot.LoincCode6,
                                                LoincCode6Result = plot.LoincCode6Result,
                                                LoincCode6ResultUnits = plot.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = plot.LoincCode6ResultDate,
                                                LoincCode7 = plot.LoincCode7,
                                                LoincCode7Result = plot.LoincCode7Result,
                                                LoincCode7ResultUnits = plot.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = plot.LoincCode7ResultDate,
                                                LoincCode8 = plot.LoincCode8,
                                                LoincCode8Result = plot.LoincCode8Result,
                                                LoincCode8ResultUnits = plot.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = plot.LoincCode8ResultDate,
                                                LoincCode9 = plot.LoincCode9,
                                                LoincCode9Result = plot.LoincCode9Result,
                                                LoincCode9ResultUnits = plot.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = plot.LoincCode9ResultDate,
                                                LoincCode10 = plot.LoincCode10,
                                                LoincCode10Result = plot.LoincCode10Result,
                                                LoincCode10ResultUnits = plot.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = plot.LoincCode10ResultDate,
                                                LoincCode11 = plot.LoincCode11,
                                                LoincCode11Result = plot.LoincCode11Result,
                                                LoincCode11ResultUnits = plot.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = plot.LoincCode11ResultDate,
                                                LoincCode12 = plot.LoincCode12,
                                                LoincCode12Result = plot.LoincCode12Result,
                                                LoincCode12ResultUnits = plot.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = plot.LoincCode12ResultDate,
                                                LoincCode13 = plot.LoincCode13,
                                                LoincCode13Result = plot.LoincCode13Result,
                                                LoincCode13ResultUnits = plot.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = plot.LoincCode13ResultDate,
                                                LoincCode14 = plot.LoincCode14,
                                                LoincCode14Result = plot.LoincCode14Result,
                                                LoincCode14ResultUnits = plot.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = plot.LoincCode14ResultDate,
                                                LoincCode15 = plot.LoincCode15,
                                                LoincCode15Result = plot.LoincCode15Result,
                                                LoincCode15ResultUnits = plot.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = plot.LoincCode15ResultDate,
                                                LoincCode16 = plot.LoincCode16,
                                                LoincCode16Result = plot.LoincCode16Result,
                                                LoincCode16ResultUnits = plot.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = plot.LoincCode16ResultDate,
                                                ICDCode1 = plot.ICDCode1,
                                                ICDCode2 = plot.ICDCode2,
                                                ICDCode3 = plot.ICDCode3,
                                                ICDCode4 = plot.ICDCode4,
                                                ICDCode5 = plot.ICDCode5,
                                                ICDCode6 = plot.ICDCode6,
                                                ICDCode7 = plot.ICDCode7,
                                                ICDCode8 = plot.ICDCode8,
                                                ICDCode9 = plot.ICDCode9,
                                                ICDCode10 = plot.ICDCode10,
                                                Notes = plot.Notes,
                                                Deleted = plot.Deleted,
                                                CreatedBy = plot.CreatedBy,
                                                CreatedDate = plot.CreatedDate,
                                                ModifiedBy = plot.ModifiedBy,
                                                ModifiedDate = plot.ModifiedDate,
                                                PatientVisitID = plot.PatientVisitID,
                                                PatientTransactionDate = pv.VisitDate,
                                                VisitTime = pv.VisitTime,
                                                DocumentReferenceIDs = plot.DocumentReferenceIds,
                                                ScheduledTestStatusID = plot.ScheduledTestStatusID,
                                                ScheduledTestStatusDescription = currr.Description,
                                                LabResponseHL7ID = (lrhl.LabResponseHL7ID > 0) ? 0 : lrhl.LabResponseHL7ID,
                                                IsEditable = plot.IsEditable,
                                                IsPrinted = plot.IsPrinted,
                                                OrderTypeID = plot.OrderTypeID,
                                                BillTypeID = plot.BillTypeID,
                                                InsuranceCodeId = plot.InsuranceCodeId,
                                                Template = plot.Template,
                                                PrepaidAmount = plot.PrepaidAmount,
                                                STAT = plot.STAT,
                                                CollectionDate = plot.CollectionDate,
                                                PreferredlanguageId = plot.PreferredlanguageId,
                                                PatientRaceID = plot.PatientRaceID,
                                                PatientEthnicityID = plot.PatientEthnicityID,
                                                GenderIdentityID = plot.GenderIdentityID,
                                                SexualOrientationID = plot.SexualOrientationID,
                                                Instructions = plot.Instructions,
                                                ReportComments = plot.ReportComments,
                                                Phonenumber = plot.Phonenumber,
                                                Fax = plot.Fax

                                            })
                                            .AsEnumerable()
                                            .Select(x => new PatientLabOrderTestModel
                                            {
                                                PatientLabOrderTestID = x.PatientLabOrderTestID,
                                                EmdeonLabID = x.EmdeonLabID,
                                                PatientLabOrderTestFacilityID = x.FacilityID,
                                                FacilityName = x.FacilityID > 0 ? this._uow.GenericRepository<Facility>().Table().Where(y => y.FacilityID == x.FacilityID).FirstOrDefault().FacilityName : "",
                                                PatientLabOrderTestProviderID = x.ProviderID,
                                                ProviderNameLabOrder = x.ProviderNameLast + " " + x.ProviderNameFirst + " " + x.ProviderNameMiddle,
                                                OrderingProviderNameLabOrder = x.OrderingProviderNameLast + " " + x.OrderingProviderNameFirst + " " + x.OrderingProviderNameMiddle,
                                                PatientLabOrderTestOrderingProviderID = x.OrderingProviderID,
                                                PatientID = x.PatientID,
                                                PatientName = x.PatientNameLast + " " + x.PatientNameFirst + " " + x.PatientNameMiddle,
                                                PatientVisitID = x.PatientVisitID,
                                                VisitTime = x.VisitTime,
                                                LabTestDate = x.LabTestDate,
                                                LabName = x.LabName,
                                                LabAddressLine1 = (x.LabAddressLine1 == null ? "" : (x.LabAddressLine1 + ",")) + (x.LabAddressLine2 == null ? "" : (x.LabAddressLine2 + ",")) + (x.LabZIP == null ? "" : x.LabZIP == null ? "" : (x.LabZIP + ",")) + (x.LabCity == null ? "" : (x.LabCity + ",")) + (x.LabState == null ? "" : (x.LabState)) + (x.LabCounty == null ? "" : (x.LabCounty)),
                                                LabAddressLine2 = x.LabAddressLine2,
                                                LabCity = x.LabCity,
                                                LabState = x.LabState,
                                                LabCounty = x.LabCounty,
                                                LabZIP = x.LabZIP,
                                                LoincCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.LoincCode1 + " " + GetLoincCodeDescription(x.LoincCode1), x.LoincCode2 + " " + GetLoincCodeDescription(x.LoincCode2), x.LoincCode3 + " " + GetLoincCodeDescription(x.LoincCode3), x.LoincCode4 + " " + GetLoincCodeDescription(x.LoincCode4), x.LoincCode5 + " " + GetLoincCodeDescription(x.LoincCode5), x.LoincCode6 + " " + GetLoincCodeDescription(x.LoincCode6),
                                                x.LoincCode7 + " " + GetLoincCodeDescription(x.LoincCode7), x.LoincCode8 + " " + GetLoincCodeDescription(x.LoincCode8), x.LoincCode9 + " " + GetLoincCodeDescription(x.LoincCode9), x.LoincCode10 + " " + GetLoincCodeDescription(x.LoincCode10), x.LoincCode11 + " " + GetLoincCodeDescription(x.LoincCode11), x.LoincCode12 + " " + GetLoincCodeDescription(x.LoincCode12), x.LoincCode13 + " " + GetLoincCodeDescription(x.LoincCode13), x.LoincCode14 + " " + GetLoincCodeDescription(x.LoincCode14), x.LoincCode15 + " " + GetLoincCodeDescription(x.LoincCode15), x.LoincCode16 + " " + GetLoincCodeDescription(x.LoincCode16)).Replace(",,", "").Replace(" ,", "")).ToString()),
                                                ICDCode1 = x.ICDCode1,
                                                ICDCode2 = x.ICDCode2,
                                                ICDCode3 = x.ICDCode3,
                                                ICDCode4 = x.ICDCode4,
                                                ICDCode5 = x.ICDCode5,
                                                ICDCode6 = x.ICDCode6,
                                                ICDCode7 = x.ICDCode7,
                                                ICDCode8 = x.ICDCode8,
                                                ICDCode9 = x.ICDCode9,
                                                ICDCode10 = x.ICDCode10,
                                                LoincCode1 = x.LoincCode1,
                                                LoincCode1Description = GetLoincCodeDescription(x.LoincCode1),
                                                LoincCode1Result = x.LoincCode1Result,
                                                LoincCode1ResultUnits = x.LoincCode1ResultUnits,
                                                LoincCode1ResultDate = x.LoincCode1ResultDate,
                                                LoincCode2 = x.LoincCode2,
                                                LoincCode2Description = GetLoincCodeDescription(x.LoincCode2),
                                                LoincCode2Result = x.LoincCode2Result,
                                                LoincCode2ResultUnits = x.LoincCode2ResultUnits,
                                                LoincCode2ResultDate = x.LoincCode2ResultDate,
                                                LoincCode3 = x.LoincCode3,
                                                LoincCode3Description = GetLoincCodeDescription(x.LoincCode3),
                                                LoincCode3Result = x.LoincCode3Result,
                                                LoincCode3ResultUnits = x.LoincCode3ResultUnits,
                                                LoincCode3ResultDate = x.LoincCode3ResultDate,
                                                LoincCode4 = x.LoincCode4,
                                                LoincCode4Description = GetLoincCodeDescription(x.LoincCode4),
                                                LoincCode4Result = x.LoincCode4Result,
                                                LoincCode4ResultUnits = x.LoincCode4ResultUnits,
                                                LoincCode4ResultDate = x.LoincCode4ResultDate,
                                                LoincCode5 = x.LoincCode5,
                                                LoincCode5Description = GetLoincCodeDescription(x.LoincCode5),
                                                LoincCode5Result = x.LoincCode5Result,
                                                LoincCode5ResultUnits = x.LoincCode5ResultUnits,
                                                LoincCode5ResultDate = x.LoincCode5ResultDate,
                                                LoincCode6 = x.LoincCode6,
                                                LoincCode6Description = GetLoincCodeDescription(x.LoincCode6),
                                                LoincCode6Result = x.LoincCode6Result,
                                                LoincCode6ResultUnits = x.LoincCode6ResultUnits,
                                                LoincCode6ResultDate = x.LoincCode6ResultDate,
                                                LoincCode7 = x.LoincCode7,
                                                LoincCode7Description = GetLoincCodeDescription(x.LoincCode7),
                                                LoincCode7Result = x.LoincCode7Result,
                                                LoincCode7ResultUnits = x.LoincCode7ResultUnits,
                                                LoincCode7ResultDate = x.LoincCode7ResultDate,
                                                LoincCode8 = x.LoincCode8,
                                                LoincCode8Result = x.LoincCode8Result,
                                                LoincCode8ResultUnits = x.LoincCode8ResultUnits,
                                                LoincCode8ResultDate = x.LoincCode8ResultDate,
                                                LoincCode8Description = GetLoincCodeDescription(x.LoincCode8),
                                                LoincCode9 = x.LoincCode9,
                                                LoincCode9Description = GetLoincCodeDescription(x.LoincCode9),
                                                LoincCode9Result = x.LoincCode9Result,
                                                LoincCode9ResultUnits = x.LoincCode9ResultUnits,
                                                LoincCode9ResultDate = x.LoincCode9ResultDate,
                                                LoincCode10 = x.LoincCode10,
                                                LoincCode10Description = GetLoincCodeDescription(x.LoincCode10),
                                                LoincCode10Result = x.LoincCode10Result,
                                                LoincCode10ResultUnits = x.LoincCode10ResultUnits,
                                                LoincCode10ResultDate = x.LoincCode10ResultDate,
                                                LoincCode11 = x.LoincCode11,
                                                LoincCode11Description = GetLoincCodeDescription(x.LoincCode11),
                                                LoincCode11Result = x.LoincCode11Result,
                                                LoincCode11ResultUnits = x.LoincCode11ResultUnits,
                                                LoincCode11ResultDate = x.LoincCode11ResultDate,
                                                LoincCode12 = x.LoincCode12,
                                                LoincCode12Description = GetLoincCodeDescription(x.LoincCode12),
                                                LoincCode12Result = x.LoincCode12Result,
                                                LoincCode12ResultUnits = x.LoincCode12ResultUnits,
                                                LoincCode12ResultDate = x.LoincCode12ResultDate,
                                                LoincCode13 = x.LoincCode13,
                                                LoincCode13Description = GetLoincCodeDescription(x.LoincCode13),
                                                LoincCode13Result = x.LoincCode13Result,
                                                LoincCode13ResultUnits = x.LoincCode13ResultUnits,
                                                LoincCode13ResultDate = x.LoincCode13ResultDate,
                                                LoincCode14 = x.LoincCode14,
                                                LoincCode14Description = GetLoincCodeDescription(x.LoincCode14),
                                                LoincCode14Result = x.LoincCode14Result,
                                                LoincCode14ResultUnits = x.LoincCode14ResultUnits,
                                                LoincCode14ResultDate = x.LoincCode14ResultDate,
                                                LoincCode15 = x.LoincCode15,
                                                LoincCode15Description = GetLoincCodeDescription(x.LoincCode15),
                                                LoincCode15Result = x.LoincCode15Result,
                                                LoincCode15ResultUnits = x.LoincCode15ResultUnits,
                                                LoincCode15ResultDate = x.LoincCode15ResultDate,
                                                LoincCode16 = x.LoincCode16,
                                                LoincCode16Description = GetLoincCodeDescription(x.LoincCode16),
                                                LoincCode16Result = x.LoincCode16Result,
                                                LoincCode16ResultUnits = x.LoincCode16ResultUnits,
                                                LoincCode16ResultDate = x.LoincCode16ResultDate,
                                                DiagnosisCodeList = DiagnosisAndLonicCodeFormat((string.Join(",", x.ICDCode1, x.ICDCode2, x.ICDCode3, x.ICDCode4, x.ICDCode5, x.ICDCode6,
                        x.ICDCode7, x.ICDCode7, x.ICDCode9, x.ICDCode10).Replace(",,", "")).ToString()),
                                                Notes = x.Notes,
                                                PatientTransactionDateString = x.PatientTransactionDate.ToString(),
                                                Deleted = x.Deleted,
                                                CreatedDate = x.CreatedDate,
                                                CreatedBy = x.CreatedBy,
                                                ModifiedDate = x.ModifiedDate,
                                                ModifiedBy = x.ModifiedBy,
                                                DocumentReferenceIds = x.DocumentReferenceIDs,
                                                ScheduledTestStatusID = x.ScheduledTestStatusID,
                                                LabOrderScheduledTestStatusDescription = x.ScheduledTestStatusID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.ScheduledTestStatusID).FirstOrDefault().Description : "",
                                                IsPatientLabOrderTestIDHave = x.LabResponseHL7ID != 0 ? true : false,
                                                IsEditable = x.IsEditable,
                                                IsPrinted = x.IsPrinted,
                                                OrderTypeID = x.OrderTypeID,
                                                OrderTypeDescription = x.OrderTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.OrderTypeID).FirstOrDefault().Description : "",
                                                BillTypeID = x.BillTypeID,
                                                BillTypeDescription = x.BillTypeID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.BillTypeID).FirstOrDefault().Description : "",
                                                InsuranceCodeId = x.InsuranceCodeId,
                                                Template = x.Template,
                                                PrepaidAmount = x.PrepaidAmount,
                                                STAT = x.STAT,
                                                CollectionDate = x.CollectionDate,
                                                PreferredlanguageId = x.PreferredlanguageId,
                                                PreferredLanguageDescription = x.PreferredlanguageId > 0 ? this._uow.GenericRepository<RegionalLanguage>().Table().Where(y => y.RegionalLanguageID == x.PreferredlanguageId).FirstOrDefault().Description : "",
                                                PatientRaceID = x.PatientRaceID,
                                                PatientRaceDescription = x.PatientRaceID > 0 ? this._uow.GenericRepository<Race>().Table().Where(y => y.RaceID == x.PatientRaceID).FirstOrDefault().Description : "",
                                                PatientEthnicityID = x.PatientEthnicityID,
                                                PatientEthnicityDescription = x.PatientEthnicityID > 0 ? this._uow.GenericRepository<Ethnicity>().Table().Where(y => y.EthnicityID == x.PatientEthnicityID).FirstOrDefault().Description : "",
                                                GenderIdentityID = x.GenderIdentityID,
                                                GenderDescription = x.GenderIdentityID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.GenderIdentityID).FirstOrDefault().Description : "",
                                                SexualOrientationID = x.SexualOrientationID,
                                                SexualOrientationDescription = x.SexualOrientationID > 0 ? this._uow.GenericRepository<CommonMaster>().Table().Where(y => y.CommonMasterID == x.SexualOrientationID).FirstOrDefault().Description : "",
                                                Instructions = x.Instructions,
                                                ReportComments = x.ReportComments,
                                                Phonenumber = x.Phonenumber,
                                                Fax = x.Fax
                                            }).ToList();
            return queryPatientLabOrderTest;

        }

        public string GetLoincCodeDescription(string loincCode)
        {
            var queryLonic = "";
            if (!string.IsNullOrEmpty(loincCode))
            {
                queryLonic = (this._uow.GenericRepository<Lonic>().Table().Where(x => !x.Deleted && x.Code == loincCode).Select(x => x.ShortName)).FirstOrDefault();
            }
            return queryLonic;
        }

        ///Diagnosis Code Format in List      
        private string DiagnosisAndLonicCodeFormat(string diagnosisCode)
        {
            if (diagnosisCode != string.Empty)
            {
                string lastValue = diagnosisCode.Substring(diagnosisCode.Length - 1, 1);
                if (lastValue == ",")
                {
                    return diagnosisCode.Remove(diagnosisCode.Length - 1, 1);
                }
                else
                {
                    return diagnosisCode;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #endregion


        #region Emdeon Lab
        /// <summary>
        /// Get Emdeon Lab Request Recent Placer Order By PatientID
        /// </summary>
        /// <param name="patientID">Integer</param>
        /// <returns>String</returns>
        public string GetEmdeonLabRequestPlacerOrderByPatientID(int patientID)//--------------- Method created for temporary access.
        {
            var placerorderNumber = "";
            var query = (from lr in this._uow.GenericRepository<LabRequest>().Table()
                         where lr.PatientID == patientID && lr.OrderStatus.ToUpper() != "F" && lr.Deleted == false
                         select lr.OrderNumber).Max();
            if (query != null)
            {
                placerorderNumber = ((from lr in this._uow.GenericRepository<LabRequest>().Table()
                                      where lr.PatientID == patientID && lr.OrderNumber == query && lr.Deleted == false
                                      select lr.PlacerOrderNumber)).FirstOrDefault();
            }
            return placerorderNumber;
        }

        /// <summary>
        /// Get Emdeon Lab Request By ID
        /// </summary>
        /// <param name="labrequest">LabRequestModel></param>
        /// <returns>LabRequestModel</returns>
        public LabRequestModel GetEmdeonLabRequestByID(LabRequestModel labrequest)
        {
            if (labrequest.PlacerOrderNumber == null)
            {
                return null;
            }
            var query = (from lr in this._uow.GenericRepository<LabRequest>().Table()
                         where lr.PlacerOrderNumber == labrequest.PlacerOrderNumber && lr.PatientID == labrequest.PatientID
                             && lr.Deleted == false
                         select new LabRequestModel
                         {
                             PlacerOrderNumber = lr.PlacerOrderNumber,
                             OrderNumber = lr.OrderNumber,
                             LabRequestID = lr.LabRequestID,
                             OrderStatus = lr.OrderStatus,
                             IsResponseDownloaded = lr.IsResponseDownloaded
                         }).FirstOrDefault();
            return query;
        }

        public LabRequestModel AddUpdateLabRequest (LabRequestModel labRequestModel)
        {
            var req =  this._uow.GenericRepository<LabRequest>().Table().Where(x => x.LabRequestID == labRequestModel.LabRequestID).FirstOrDefault();


            if (req == null)
            {
                req = new LabRequest();

                req.LabRequestID = labRequestModel.LabRequestID;
                req.PlacerOrderNumber = labRequestModel.PlacerOrderNumber;
                req.OrderNumber = labRequestModel.OrderNumber;
                req.OrderStatus = labRequestModel.OrderStatus;
                req.OrderType = labRequestModel.OrderType;
                req.LabID = labRequestModel.LabID;
                req.LabName = labRequestModel.LabName;
                req.RequestDate = labRequestModel.RequestDate;
                req.CollectionDate = labRequestModel.CollectionDate;
                req.RespondedDate = labRequestModel.RespondedDate;
                req.OrderingOrganizationID = labRequestModel.OrderingOrganizationID;
                req.OrderedUser = labRequestModel.OrderedUser;
                req.ProviderID = (int)labRequestModel.ProviderID;
                req.ReferringCareGiver = labRequestModel.ReferringCareGiver;
                req.ReferringCareGiverUPIN = labRequestModel.ReferringCareGiverUPIN;
                req.ReferringCareGiverNameLast = labRequestModel.ReferringCareGiverNameLast;
                req.ReferringCareGiverNameFirst = labRequestModel.ReferringCareGiverNameFirst;
                req.ReferringCareGiverID = labRequestModel.ReferringCareGiverID;
                req.PatientID = (int)labRequestModel.PatientID;
                req.PersonHSI = labRequestModel.PersonHSI;
                req.PersonID = labRequestModel.PersonID;
                req.PatientNameLast = labRequestModel.PatientNameLast;
                req.PatientNameFirst = labRequestModel.PatientNameFirst;
                req.PatientNameMiddle = labRequestModel.PatientNameMiddle;
                req.IsResponseDownloaded = labRequestModel.IsResponseDownloaded;
                req.IsResponseImportedIntoSystem = labRequestModel.IsResponseImportedIntoSystem;
                req.UniversalServiceIdentifier = labRequestModel.UniversalServiceIdentifier;
                req.UniversalServiceIdentifierText = labRequestModel.UniversalServiceIdentifierText;
                req.Deleted = labRequestModel.Deleted;
                req.CreatedDate = DateTime.Now;
                req.CreatedBy = "User";

                this._uow.GenericRepository<LabRequest>().Insert(req);

            }
            else
            {
                req.LabRequestID = labRequestModel.LabRequestID;
                req.PlacerOrderNumber = labRequestModel.PlacerOrderNumber;
                req.OrderNumber = labRequestModel.OrderNumber;
                req.OrderStatus = labRequestModel.OrderStatus;
                req.OrderType = labRequestModel.OrderType;
                req.LabID = labRequestModel.LabID;
                req.LabName = labRequestModel.LabName;
                req.RequestDate = labRequestModel.RequestDate;
                req.CollectionDate = labRequestModel.CollectionDate;
                req.RespondedDate = labRequestModel.RespondedDate;
                req.OrderingOrganizationID = labRequestModel.OrderingOrganizationID;
                req.OrderedUser = labRequestModel.OrderedUser;
                req.ProviderID = (int)labRequestModel.ProviderID;
                req.ReferringCareGiver = labRequestModel.ReferringCareGiver;
                req.ReferringCareGiverUPIN = labRequestModel.ReferringCareGiverUPIN;
                req.ReferringCareGiverNameLast = labRequestModel.ReferringCareGiverNameLast;
                req.ReferringCareGiverNameFirst = labRequestModel.ReferringCareGiverNameFirst;
                req.ReferringCareGiverID = labRequestModel.ReferringCareGiverID;
                req.PatientID = (int)labRequestModel.PatientID;
                req.PersonHSI = labRequestModel.PersonHSI;
                req.PersonID = labRequestModel.PersonID;
                req.PatientNameLast = labRequestModel.PatientNameLast;
                req.PatientNameFirst = labRequestModel.PatientNameFirst;
                req.PatientNameMiddle = labRequestModel.PatientNameMiddle;
                req.IsResponseDownloaded = labRequestModel.IsResponseDownloaded;
                req.IsResponseImportedIntoSystem = labRequestModel.IsResponseImportedIntoSystem;
                req.UniversalServiceIdentifier = labRequestModel.UniversalServiceIdentifier;
                req.UniversalServiceIdentifierText = labRequestModel.UniversalServiceIdentifierText;
                req.Deleted = labRequestModel.Deleted;
                req.ModifiedDate = DateTime.Now;
                req.ModifiedBy = "User";

                this._uow.GenericRepository<LabRequest>().Insert(req);
            }
            this._uow.Save();
            labRequestModel.LabRequestID = req.LabRequestID;

            return labRequestModel;

        }
        public List<LabRequestModel> GetLabRequestList()
        {
            var req = (from l in this._uow.GenericRepository<LabRequest>().Table()
                       select new
                       {
                          l.LabRequestID,
                          l.PlacerOrderNumber, 
                          l.OrderNumber,
                          l.OrderStatus, 
                          l.OrderType ,
                          l.LabID ,
                          l.LabName ,
                          l.RequestDate ,
                          l.CollectionDate ,
                          l.RespondedDate ,           
                          l.OrderingOrganizationID ,
                          l.OrderedUser,
                          l.ProviderID ,
                          l.ReferringCareGiver,
                          l.ReferringCareGiverUPIN ,
                          l.ReferringCareGiverNameLast,
                          l.ReferringCareGiverNameFirst ,
                          l.ReferringCareGiverID ,
                          l.PatientID,
                          l.PersonHSI ,
                          l.PersonID ,
                          l.PatientNameLast ,
                          l.PatientNameFirst,
                          l.PatientNameMiddle ,
                          l.IsResponseDownloaded ,
                          l.IsResponseImportedIntoSystem ,
                          l.UniversalServiceIdentifier,
                          l.UniversalServiceIdentifierText ,
                          l.Deleted ,
                          l.ModifiedBy ,
                          l.ModifiedDate 
              }).AsEnumerable().Select(x => new LabRequestModel
              {
                           LabRequestID = x.LabRequestID,
                           PlacerOrderNumber = x.PlacerOrderNumber,
                           OrderNumber = x.OrderNumber,
                           OrderStatus = x.OrderStatus,
                           OrderType  = x.OrderType,
                           LabID  = x.LabID,
                           LabName = x.LabName,
                           RequestDate = x.RequestDate,
                           CollectionDate = x.CollectionDate,
                           RespondedDate = x.RespondedDate,
                           OrderingOrganizationID = x.OrderingOrganizationID,
                           OrderedUser= x.OrderedUser,
                           ProviderID = (int)x.ProviderID,
                           ReferringCareGiver= x.ReferringCareGiver,
                           ReferringCareGiverUPIN = x.ReferringCareGiverUPIN,
                           ReferringCareGiverNameLast= x.ReferringCareGiverNameLast,
                           ReferringCareGiverNameFirst = x.ReferringCareGiverNameFirst,
                           ReferringCareGiverID = x.ReferringCareGiverID,
                           PatientID= (int)x.PatientID,
                           PersonHSI = x.PersonHSI,
                           PersonID = x.PersonID,
                           PatientNameLast = x.PatientNameLast,
                           PatientNameFirst= x.PatientNameFirst,
                           PatientNameMiddle = x.PatientNameMiddle,
                           IsResponseDownloaded = x.IsResponseDownloaded,
                           IsResponseImportedIntoSystem = x.IsResponseImportedIntoSystem,
                           UniversalServiceIdentifier= x.UniversalServiceIdentifier,
                           UniversalServiceIdentifierText = x.UniversalServiceIdentifierText,
                           Deleted = x.Deleted,
                           ModifiedBy = x.ModifiedBy,
                           ModifiedDate = x.ModifiedDate
              }).ToList();

            return req;

        }

        public List<LabRequestModel> GetLabRequestListbyLabRequestID(int LabRequestID)
        {
            var req = (from l in this._uow.GenericRepository<LabRequest>().Table().Where(x=>x.LabRequestID == LabRequestID)
                       select new
                       {
                           l.LabRequestID,
                           l.PlacerOrderNumber,
                           l.OrderNumber,
                           l.OrderStatus,
                           l.OrderType,
                           l.LabID,
                           l.LabName,
                           l.RequestDate,
                           l.CollectionDate,
                           l.RespondedDate,
                           l.OrderingOrganizationID,
                           l.OrderedUser,
                           l.ProviderID,
                           l.ReferringCareGiver,
                           l.ReferringCareGiverUPIN,
                           l.ReferringCareGiverNameLast,
                           l.ReferringCareGiverNameFirst,
                           l.ReferringCareGiverID,
                           l.PatientID,
                           l.PersonHSI,
                           l.PersonID,
                           l.PatientNameLast,
                           l.PatientNameFirst,
                           l.PatientNameMiddle,
                           l.IsResponseDownloaded,
                           l.IsResponseImportedIntoSystem,
                           l.UniversalServiceIdentifier,
                           l.UniversalServiceIdentifierText,
                           l.Deleted,
                           l.ModifiedBy,
                           l.ModifiedDate
                       }).AsEnumerable().Select(x => new LabRequestModel
                       {
                           LabRequestID = x.LabRequestID,
                           PlacerOrderNumber = x.PlacerOrderNumber,
                           OrderNumber = x.OrderNumber,
                           OrderStatus = x.OrderStatus,
                           OrderType = x.OrderType,
                           LabID = x.LabID,
                           LabName = x.LabName,
                           RequestDate = x.RequestDate,
                           CollectionDate = x.CollectionDate,
                           RespondedDate = x.RespondedDate,
                           OrderingOrganizationID = x.OrderingOrganizationID,
                           OrderedUser = x.OrderedUser,
                           ProviderID = (int)x.ProviderID,
                           ReferringCareGiver = x.ReferringCareGiver,
                           ReferringCareGiverUPIN = x.ReferringCareGiverUPIN,
                           ReferringCareGiverNameLast = x.ReferringCareGiverNameLast,
                           ReferringCareGiverNameFirst = x.ReferringCareGiverNameFirst,
                           ReferringCareGiverID = x.ReferringCareGiverID,
                           PatientID = (int)x.PatientID,
                           PersonHSI = x.PersonHSI,
                           PersonID = x.PersonID,
                           PatientNameLast = x.PatientNameLast,
                           PatientNameFirst = x.PatientNameFirst,
                           PatientNameMiddle = x.PatientNameMiddle,
                           IsResponseDownloaded = x.IsResponseDownloaded,
                           IsResponseImportedIntoSystem = x.IsResponseImportedIntoSystem,
                           UniversalServiceIdentifier = x.UniversalServiceIdentifier,
                           UniversalServiceIdentifierText = x.UniversalServiceIdentifierText,
                           Deleted = x.Deleted,
                           ModifiedBy = x.ModifiedBy,
                           ModifiedDate = x.ModifiedDate
                       }).ToList();

            return req;

        }

        #endregion


        #region LabResponse

        public LabResponseHL7Model AddUpdateLabResponseHL7 (LabResponseHL7Model labResponseHL7Model)
        {
            var labres = this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => x.LabResponseHL7ID == labResponseHL7Model.LabResponseHL7ID).FirstOrDefault();

            if (labres == null)
            {
                labres = new LabResponseHL7();

                labres.LabResponseHL7ID = labResponseHL7Model.LabResponseHL7ID;
                labres.LabRequestID = labResponseHL7Model.LabRequestID;
                labres.ResponseData = labResponseHL7Model.ResponseData;
                labres.ResponseDownloadDate = (DateTime)labResponseHL7Model.ResponseDownloadDate;
                labres.Deleted = labResponseHL7Model.Deleted;
                labres.PatientID = labResponseHL7Model.PatientID;
                labres.PatientLabOrderTestID = labResponseHL7Model.PatientLabOrderTestID;
                labres.CreatedDate = DateTime.Now;
                labres.CreatedBy = "User";

                this._uow.GenericRepository<LabResponseHL7>().Insert(labres);
            }

            else
            {
                labres.LabResponseHL7ID = labResponseHL7Model.LabResponseHL7ID;
                labres.LabRequestID = labResponseHL7Model.LabRequestID;
                labres.ResponseData = labResponseHL7Model.ResponseData;
                labres.ResponseDownloadDate = (DateTime)labResponseHL7Model.ResponseDownloadDate;
                labres.Deleted = labResponseHL7Model.Deleted;
                labres.PatientID = labResponseHL7Model.PatientID;
                labres.PatientLabOrderTestID = labResponseHL7Model.PatientLabOrderTestID;
                labres.ModifiedDate = DateTime.Now;
                labres.ModifiedBy = "User";

                this._uow.GenericRepository<LabResponseHL7>().Update(labres);
            }
            this._uow.Save();

            labResponseHL7Model.PatientLabOrderTestID = labres.PatientLabOrderTestID;

            return labResponseHL7Model;


        }
        public LabResponseHL7Model GetLabResponseDataByID(int labrequestID)
        {
            if (labrequestID > 0)
            {
                var query = (from lr in this._uow.GenericRepository<LabResponseHL7>().Table()
                             where lr.LabRequestID == labrequestID
                                 && lr.Deleted == false
                             select new LabResponseHL7Model
                             {
                                 LabRequestID = (int)lr.LabRequestID,
                                 LabResponseHL7ID = lr.LabResponseHL7ID,
                                 ResponseData = lr.ResponseData,
                             }).FirstOrDefault();
                return query;
            }
            return null;
        }

        #region LabHL7Xml
        /// <summary>
        /// Get Lab Report Reponse Xml
        /// </summary>
        /// <param name="patientLabOrderTestID">Patient Lab Order Test Identifier</param>
        /// <returns>String. Response Data</returns>
        public string GetLabReportReponseXml(int patientLabOrderTestID)
        {
            var labXml = (from lr in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => !x.Deleted && x.PatientLabOrderTestID == patientLabOrderTestID)
                          select lr.ResponseData).FirstOrDefault();
            return labXml;
        }

        #endregion

        public List<LabResponseHL7Model> GetLabResponseHL7 ()
        {
            var lab = (from la in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => (!x.Deleted))
                       select new
                       {
                           la.LabResponseHL7ID,
                           la.LabRequestID,
                           la.ResponseData,
                           la.ResponseDownloadDate,
                           la.Deleted,
                           la.PatientID,
                           la.PatientLabOrderTestID,
                           la.CreatedDate,
                           la.CreatedBy
                       }).AsEnumerable().Select(x => new LabResponseHL7Model
                       {
                           LabResponseHL7ID = x.LabResponseHL7ID,
                           LabRequestID = (int)x.LabRequestID,
                           ResponseData = x.ResponseData,
                           ResponseDownloadDate = x.ResponseDownloadDate,
                           Deleted = x.Deleted,
                           PatientID = x.PatientID,
                           PatientLabOrderTestID = x.PatientLabOrderTestID,
                           CreatedDate = x.CreatedDate,
                           CreatedBy = x.CreatedBy

                       }).ToList();
            return lab;

        }

        public List<LabResponseHL7Model> GetLabResponseHL7byLabResponseID(int LabResponseHLID)
        {
            var lab = (from la in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => (!x.Deleted) && (x.LabResponseHL7ID == LabResponseHLID))
                       select new
                       {
                           la.LabResponseHL7ID,
                           la.LabRequestID,
                           la.ResponseData,
                           la.ResponseDownloadDate,
                           la.Deleted,
                           la.PatientID,
                           la.PatientLabOrderTestID,
                           la.CreatedDate,
                           la.CreatedBy
                       }).AsEnumerable().Select(x => new LabResponseHL7Model
                       {
                           LabResponseHL7ID = x.LabResponseHL7ID,
                           LabRequestID = (int)x.LabRequestID,
                           ResponseData = x.ResponseData,
                           ResponseDownloadDate = x.ResponseDownloadDate,
                           Deleted = x.Deleted,
                           PatientID = x.PatientID,
                           PatientLabOrderTestID = x.PatientLabOrderTestID,
                           CreatedDate = x.CreatedDate,
                           CreatedBy = x.CreatedBy

                       }).ToList();
            return lab;
        }

        public List<LabResponseHL7Model> GetLabResponseHL7byPatientLabOrderTestID(int PatientLabOrderTestID)
        {
            var lab = (from la in this._uow.GenericRepository<LabResponseHL7>().Table().Where(x => x.Deleted != true && x.PatientLabOrderTestID == PatientLabOrderTestID)
                       join p in this._uow.GenericRepository<PatientLabOrderTest>().Table().Where(x => !x.Deleted) on la.PatientLabOrderTestID equals p.PatientLabOrderTestID
                       select new
                       {
                           la.LabResponseHL7ID,
                           la.LabRequestID,
                           la.ResponseData,
                           la.ResponseDownloadDate,
                           la.Deleted,
                           la.PatientID,
                           la.PatientLabOrderTestID,
                           la.CreatedDate,
                           la.CreatedBy
                       }).AsEnumerable().Select(x => new LabResponseHL7Model
                       {
                           LabResponseHL7ID = x.LabResponseHL7ID,
                           LabRequestID = (int)x.LabRequestID,
                           ResponseData = x.ResponseData,
                           ResponseDownloadDate = x.ResponseDownloadDate,
                           Deleted = x.Deleted,
                           PatientID = x.PatientID,
                           PatientLabOrderTestID = x.PatientLabOrderTestID,
                           CreatedDate = x.CreatedDate,
                           CreatedBy = x.CreatedBy

                       }).ToList();
            return lab;


        }

        #endregion

        #region EmdeonUserSetup
        public List<EmdeonUserSetupModel> GetEmdeonUserSetups()
        {
            var user = (from u in this._uow.GenericRepository<EmdeonUserSetup>().Table()
                        select new
                        {
                            u.EmdeonUserSetupID,
                            u.EmdeonUserName,
                            u.EmdeonPassword,
                            u.BmsUserID,
                            u.Deleted,
                            u.CreatedDate,
                            u.CreatedBy,
                            u.ModifiedDate,
                            u.ModifiedBy
                        }).AsEnumerable().Select(x => new EmdeonUserSetupModel
                        { 
                        EmdeonUserSetupID = x.EmdeonUserSetupID,
                        EmdeonUserName = x.EmdeonUserName,
                        EmdeonPassword = x.EmdeonPassword,
                        BmsUserID = x.BmsUserID,
                        Deleted  = x.Deleted,
                        CreatedDate = x.CreatedDate,
                        CreatedBy = x.CreatedBy,
                        ModifiedDate = x.ModifiedDate,
                        ModifiedBy = x.ModifiedBy

                        }).ToList();

            return user;
        }

        #endregion

    }
}
