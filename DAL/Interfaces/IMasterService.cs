using EndocPM.WebAPI.Entities.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public interface IMasterService
    {
        List<CountryCode> GetCountryCodes();
        DateTime GetLocalTime(DateTime dateTime);
        List<StateCode> GetStateCodes();

        List<PostalCode> GetPostalCodes();

        List<UserType> GetUserTypes();

        List<CommonMasterModel> GetAllCommonMasterList();

        List<CommonMasterModel> GetMasterListByCategory(string category);

        List<CommonMasterModel> GetIntervalMessageType();
        List<ImmunizationRoute> GetImmunizationRouteList();
        List<PublicityCode> GetPublicityCodeList();

        string GetInsuranceCategoryDescriptionByID(int insuranceCategoryID);

        string GetFacilityDescriptionByID(int facilityID);

        PostalCodeModel GetCityStateCountyByZipCode(string zipCode);

        List<FeeScheduleModel> GetFeeSchedules();
        List<CommonMasterModel> GetTypeOfPayment();

        List<CommonMaster> GetBystatusMedication();

        List<StatusModel> GetStatusValues();



        //Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link);

        void UploadFile(List<IFormFile> files, string subDirectory);
        string SizeConverter(long bytes);
        void WriteMultipleFiles(List<IFormFile> Files, string modulePath);

        string SendEmail(string recipientEmail, string recipientFirstName);
        public List<clsViewFile> GetFiles(string modulePath);

        public List<clsViewFile> GetFile(string Id, string screen);
        List<string> DeleteFile(string path, string fileName);

        IList<Product> GetProducts();

        List<HumanBodySite> GetHumanBodySite();

        List<CommonMasterModel> GetAllergyseverity();
        List<CommonMasterModel> GetAllergyOnset();
        List<CommonMasterModel> GetTobaccouse();
        List<CommonMasterModel> GetAlcoholuse();
        List<CommonMasterModel> GetGender();
        List<DocumentType> GetDocumentTypeList();
        List<CommonMasterModel> GetMaritalStatus();
        List<PatientRelation> GetRelationship();
        List<CommonMaster> GetByallAllergies();
        List<CountryCode> GetCountryCodesbysearchkey(string Searchkey);
        List<PostalCode> GetCityStateCountyByZipCodebysearchkey(string searchkey);
        List<DiagnosisCode> GetAlldiagnosisCodes(string searchKey);
        List<RefusalReasonCode> GetRefusalReasonCodeModels();
        List<VFCFinancialClass> GetVFCFinancialClassModels();
        List<ImmunizationInformationSource> GetImmunizationInformationSourceModels();
        List<ImmunizationRegistryStatus> GetImmunizationRegistryStatuses();
        List<DrugCode> GetDrugCodeSearchkeys(string Searchkey);
        List<DispenseForm> GetDispenseFormDatabysearchKey(string searchKey);
        //provider model
        List<InsuranceCategory> insuranceCategories();
        List<CommonMaster> Typeofpayment();
        List<Facility> GetFacilityname();
        List<FeeSchedule> GetFeeScheduless();
        List<DosageForm> GetDosageFormModelsbysearchkey(string Searchkey);
        List<CommonMasterModel> GetRepeat();
        List<AppointmentType> GetAppointmenttype();

        List<InsuranceCompany> GetInsuranceCompanysearchkey(string SearchKey);

        List<Speciality> GetTaxonomyCode(string Searchkey);

        List<RegionalLanguage> GetRegionalLanguages(string Searchkey);

        List<PharmacyModel> PharmacyListSearch(PharmacyModel pharmacyModel);

        List<Pharmacy> GetPharmacies(string Searchkey);

        List<CommonMasterModel> GetConsultationType();
        List<CommonMasterModel> GetDuration();
        List<CommonMasterModel> GetSexualOrientation();
        List<CommonMasterModel> GetOrderType();
        List<Lonic> GetLonic();
        List<EmdeonLab> GetEmdeonLab();
        List<EmdeonLab> GetEmdeonLabbySearchKey(string SearchKey);
        List<Race> GetRace();
        List<RegionalLanguage> GetRegionalLanguages();
        List<Ethnicity> GetEthnicity();
        List<InsuranceFeeSchedule> GetInsuranceFeeSchedules();

        List<SigCode> GetSigCodesSearchkey(string Searchkey);
        List<CommonMasterModel> GetFees();
        List<CommonMasterModel> GetElabBillType();


    }
}