using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        public readonly IMasterService _iMasterService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MasterController(IMasterService iMasterService, IWebHostEnvironment hostingEnvironment)
        {
            _iMasterService = iMasterService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public List<CountryCode> GetCountryCodes()
        {
            return this._iMasterService.GetCountryCodes();
        }

        [HttpGet]
        public List<CommonMasterModel> GetAllCommonMasterList()
        {
            return this._iMasterService.GetAllCommonMasterList();
        }

        [HttpGet]
        public List<CommonMasterModel> GetMasterListByCategory(string category)
        {
            return this._iMasterService.GetMasterListByCategory(category);
        }

        [HttpGet]
        public List<CommonMasterModel> GetIntervalMessageType()
        {
            return this._iMasterService.GetIntervalMessageType();
        }

        [HttpGet]
        public List<ImmunizationRoute> GetImmunizationRouteList()
        {
            return this._iMasterService.GetImmunizationRouteList();
        }

        [HttpGet]
        public List<PublicityCode> GetPublicityCodeList()
        {
            return this._iMasterService.GetPublicityCodeList();
        }

        [HttpGet]
        public string GetInsuranceCategoryDescriptionByID(int insuranceCategoryID)
        {
            return this._iMasterService.GetInsuranceCategoryDescriptionByID((int)insuranceCategoryID);
        }

        [HttpGet]
        public string GetFacilityDescriptionByID(int facilityID)
        {
            return this._iMasterService.GetFacilityDescriptionByID((int)facilityID);
        }

        [HttpGet]
        public PostalCodeModel GetCityStateCountyByZipCode(string zipCode)
        {
            return this._iMasterService.GetCityStateCountyByZipCode(zipCode);
        }

        [HttpGet]
        public List<FeeScheduleModel> GetFeeSchedules()
        {
            return this._iMasterService.GetFeeSchedules();
        }

        [HttpGet]
        public List<CommonMasterModel> GetTypeOfPayment()
        {
            return this._iMasterService.GetTypeOfPayment();
        }

        [HttpGet]
        public List<StateCode> GetStateCodes()
        {
            return this._iMasterService.GetStateCodes();
        }

        [HttpGet]
        public List<PostalCode> GetPostalCodes()
        {
            return this._iMasterService.GetPostalCodes();
        }

        [HttpGet]
        public List<DiagnosisCode> GetAlldiagnosisCodes(string searchKey)
        {
            return this._iMasterService.GetAlldiagnosisCodes(searchKey);
        }

        [AllowAnonymous]
        [HttpGet]
        public List<UserType> GetUserTypes()
        {
            return this._iMasterService.GetUserTypes();
        }

        #region Upload
        [HttpPost]
        [AllowAnonymous]
        public List<string> UploadFiles(int Id, string screen, List<IFormFile> file)
        {
            //string projectRootPath = hostingEnvironment.ContentRootPath;
            string appRootPath = _hostingEnvironment.WebRootPath;


            List<string> status = new List<string>();
            try
            {
                if (file.Count() > 0)
                {
                    if (string.IsNullOrWhiteSpace(appRootPath))
                    {
                        appRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }


                    string fullPath = "";
                    fullPath = appRootPath + "\\Documents\\" + screen + "\\" + Id;

                    if (screen.ToLower().Trim() == "provider")
                    {
                        var files = this.GetFile(Id.ToString(), screen);
                        if (files.Count() > 0)
                        {
                            foreach (var set in files)
                            {
                                var splitPath = set.FileUrl.Split("/" + set.FileName)[0];
                                var message = this._iMasterService.DeleteFile(splitPath, set.FileName);
                            }
                        }
                    }

                    this._iMasterService.WriteMultipleFiles(file, fullPath);
                    status.Add("Files successfully uploaded");


                }
                else
                {
                    status.Add("No file found");
                }
            }
            catch (Exception ex)
            {
                status.Add("Error Uploading file -" + ex.Message);
            }


            return status;
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public List<string> SendEmail(string recipientEmail, string recipientFirstName)
        {
            List<string> responses = new List<string>();
            string response = this._iMasterService.SendEmail(recipientEmail, recipientFirstName);

            responses.Add(response);

            return responses;
        }

        [HttpGet]
        public List<clsViewFile> GetFile(string Id, string screen)
        {
            List<clsViewFile> Files = new List<clsViewFile>();
            Files = this._iMasterService.GetFile(Id, screen);
            return Files;
        }

        [HttpGet]
        public List<string> DeleteFile(string path, string fileName)
        {
            return this._iMasterService.DeleteFile(path, fileName);
        }

        [HttpGet]
        public List<CommonMaster> GetBystatusMedication()
        {
            return this._iMasterService.GetBystatusMedication();
        }

        [HttpGet]
        public List<StatusModel> GetStatusValues()
        {
            return this._iMasterService.GetStatusValues();
        }

        [HttpGet]
        public IList<Product> GetProducts()
        {
            return this._iMasterService.GetProducts();
        }

        [HttpGet]
        public List<HumanBodySite> GetHumanBodySite()
        {
            return this._iMasterService.GetHumanBodySite();
        }

        [HttpGet]
        public List<CommonMasterModel> GetAllergyseverity()
        {
            return this._iMasterService.GetAllergyseverity();
        }

        [HttpGet]
        public List<CommonMasterModel> GetAllergyOnset()
        {
            return this._iMasterService.GetAllergyOnset();
        }

        [HttpGet]
        public List<CommonMasterModel> GetAlcoholuse()
        {
            return this._iMasterService.GetAlcoholuse();

        }

        [HttpGet]
        public List<CommonMasterModel> GetTobaccouse()
        {
            return this._iMasterService.GetTobaccouse();

        }

        [HttpGet]
        public List<CommonMasterModel> GetGender()
        {
            return this._iMasterService.GetGender();
        }

        [HttpGet]
        public List<CommonMasterModel> GetMaritalStatus()
        {
            return this._iMasterService.GetMaritalStatus();
        }

        [HttpGet]
        public List<DocumentType> GetDocumentTypeList()
        {
            return this._iMasterService.GetDocumentTypeList();
        }

        [HttpGet]
        public List<PatientRelation> GetRelationship()
        {
            return this._iMasterService.GetRelationship();
        }

        [HttpGet]
        public List<CommonMaster> GetByallAllergies()
        {
            return this._iMasterService.GetByallAllergies();
        }
       
        [HttpGet]
        public List<CountryCode> GetCountryCodesbysearchkey(string Searchkey)
        {
            return this._iMasterService.GetCountryCodesbysearchkey(Searchkey);
        }

        [HttpGet]
        public List<PostalCode> GetCityStateCountyByZipCodebysearchkey(string Searchkey)
        {
            return this._iMasterService.GetCityStateCountyByZipCodebysearchkey(Searchkey);
        }

        [HttpGet]
        public IList<RefusalReasonCode> GetRefusalReasonCodeModels()
        {
            return this._iMasterService.GetRefusalReasonCodeModels();
        }

        [HttpGet]
        public IList<VFCFinancialClass> GetVFCFinancialClassModels()
        {
            return this._iMasterService.GetVFCFinancialClassModels();
        }

        [HttpGet]
        public IList<ImmunizationInformationSource> GetImmunizationInformationSourceModels()
        {
            return this._iMasterService.GetImmunizationInformationSourceModels();
        }

        [HttpGet]
        public List<ImmunizationRegistryStatus> GetImmunizationRegistryStatuses()
        {
            return this._iMasterService.GetImmunizationRegistryStatuses();
        }

        [HttpGet]
        public List<DrugCode> GetDrugCodeSearchkeys(string Searchkey)
        {
            return this._iMasterService.GetDrugCodeSearchkeys(Searchkey);
        }

        [HttpGet]
        public List<DosageForm> GetDosageFormModelsbysearchkey(string Searchkey)
        {
            return this._iMasterService.GetDosageFormModelsbysearchkey(Searchkey);
        }

        [HttpGet]
        public List<DispenseForm> GetDispenseFormDatabysearchKey(string searchKey)
        {
            return this._iMasterService.GetDispenseFormDatabysearchKey(searchKey);
        }

        [HttpGet]
        public List<InsuranceCategory> insuranceCategories()
        {
            return this._iMasterService.insuranceCategories();
        }

        [HttpGet]
        public List<CommonMaster> Typeofpayment()
        {
            return this._iMasterService.Typeofpayment();
        }

        [HttpGet]
        public List<Facility> GetFacilityname()
        {
            return this._iMasterService.GetFacilityname();
        }

        [HttpGet]
        public List<FeeSchedule> GetFeeScheduless()
        {
            return this._iMasterService.GetFeeScheduless();
        }

        [HttpGet]
        public List<CommonMasterModel> GetRepeat()
        {
            return this._iMasterService.GetRepeat();
        }

        [HttpGet]
        public List<AppointmentType> GetAppointmenttype()
        {
            return this._iMasterService.GetAppointmenttype();
        }

        [HttpGet]
        public List<InsuranceCompany> GetInsuranceCompanysearchkey(string SearchKey)
        {
            return this._iMasterService.GetInsuranceCompanysearchkey(SearchKey);
        }

        [HttpGet]
        public List<Speciality> GetTaxonomyCode(string Searchkey)
        {
            return this._iMasterService.GetTaxonomyCode(Searchkey);
        }

        [HttpGet]
        public List<RegionalLanguage> GetRegionalLanguages(string Searchkey)
        {
            return this._iMasterService.GetRegionalLanguages(Searchkey);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Providerupload(int Id, string screen, List<IFormFile> formFiles)
        {
            string appRootPath = _hostingEnvironment.WebRootPath;
            if (string.IsNullOrWhiteSpace(appRootPath))
            {
                appRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            string fullPath = "";
            fullPath = appRootPath + "\\Documents\\" + screen + "\\" + Id;
            try
            {
                _iMasterService.UploadFile(formFiles, fullPath);

                return Ok(new { formFiles.Count, Size = _iMasterService.SizeConverter(formFiles.Sum(f => f.Length)) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public List<PharmacyModel> PharmacyListSearch(PharmacyModel pharmacyModel)
        {
            return this._iMasterService.PharmacyListSearch(pharmacyModel);
        }

        [HttpGet]
        public List<Pharmacy> GetPharmacies(string Searchkey)
        {
            return this._iMasterService.GetPharmacies(Searchkey);
        }

        [HttpGet]
        public List<CommonMasterModel> GetConsultationType()
        {
            return this._iMasterService.GetConsultationType();
        }

        [HttpGet]
        public List<CommonMasterModel> GetDuration()
        {
            return this._iMasterService.GetDuration();
        }

        [HttpGet]
        public List<SigCode> GetSigCodesSearchkey(string Searchkey)
        {
            return this._iMasterService.GetSigCodesSearchkey(Searchkey);
        }

        [HttpGet]
        public List<CommonMasterModel> GetSexualOrientation()
        {
            return this._iMasterService.GetSexualOrientation();
        }

        [HttpGet]
        public List<CommonMasterModel> GetOrderType()
        {
            return this._iMasterService.GetOrderType();
        }

        [HttpGet]
        public List<Lonic> GetLonic()
        {
            return this._iMasterService.GetLonic();
        }

        [HttpGet]
        public List<EmdeonLab> GetEmdeonLab()
        {
            return this._iMasterService.GetEmdeonLab();
        }

        [HttpGet]
        public List<EmdeonLab> GetEmdeonLabbySearchKey(string SearchKey)
        {
            return this._iMasterService.GetEmdeonLabbySearchKey(SearchKey);
        }

        [HttpGet]
        public List<CommonMasterModel> GetFees()

        {
            return this._iMasterService.GetFees();
        }

        [HttpGet]
        public List<Race> GetRace()
        {
            return this._iMasterService.GetRace();
        }

        [HttpGet]
        public List<RegionalLanguage> GetRegionalLanguage()
        {
            return this._iMasterService.GetRegionalLanguages();
        }

        [HttpGet]
        public List<Ethnicity> GetEthnicity()
        {
            return this._iMasterService.GetEthnicity();
        }
        [HttpGet]
        public List<InsuranceFeeSchedule> GetInsuranceFeeSchedules()
        {
            return this._iMasterService.GetInsuranceFeeSchedules();
        }

        [HttpGet]
        public List<CommonMasterModel> GetElabBillType()
        {
            return this._iMasterService.GetElabBillType();
        }
    }
}
