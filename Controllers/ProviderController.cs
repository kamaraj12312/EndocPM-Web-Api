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
    public class ProviderController : Controller
    {
        public readonly IProviderService _iProviderService;
        public ProviderController(IProviderService iProviderService)
        {
            _iProviderService = iProviderService;
        }

        [HttpGet]
       public ProviderModel ProvidersModel(int providerID)
        {
            return this._iProviderService.ProvidersModel(providerID);
        }

        [HttpGet]
        public List<ProviderModel> ProviderModel()
        {
            return this._iProviderService.ProviderModel();
        }

        [HttpGet]

        public List<ProviderLocationsModel> GetProviderLocations()
        {
            return this._iProviderService.GetProviderLocations();
        }

        [HttpGet]
       public List<SchedulerSetupModel> SchedulerSetups()
        { 
        return this._iProviderService.SchedulerSetups();    
        }

        [HttpGet]

        public List<ProviderVacationModel> providerVacations()
        {
            return this._iProviderService.providerVacations();
        }

        [HttpGet]
        public List<ProviderStateLicenseModel> providerStateLincenses()
        {
            return this._iProviderService.providerStateLincenses();
        }

        [HttpGet]
        public List<ProviderInsuranceModel> GetProviderInsurances()
        {
            return this._iProviderService.GetProviderInsurances();
        }

        [HttpGet]
        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModels()
        {
            return this._iProviderService.GetProviderAwardsAndRecognitionModels();
        }


        [HttpGet]
        public List<ProviderLocationsModel> GetProviderLocationByproviderlocationID(int ProviderLocationID)
        {
            return this._iProviderService.GetProviderLocationByproviderlocationID(ProviderLocationID);
        }

        [HttpGet]
        public List<SchedulerSetupModel> SchedulerSetupsByschedulersetup(int SchedulerSetupID)
        {
            return this._iProviderService.SchedulerSetupsByschedulersetup(SchedulerSetupID);
        }

        [HttpGet]
        public  List<ProviderVacationModel> GetproviderVacationByproviderVacationID(int ProviderVacationID)
        {
            return this._iProviderService.GetproviderVacationByproviderVacationID(ProviderVacationID);
        }

        [HttpGet]
        public List<ProviderStateLicenseModel> GetproviderStateLincensesByStatelincenseID(int ProviderStateLicenseID)
        {
            return this._iProviderService.GetproviderStateLincensesByStatelincenseID(ProviderStateLicenseID);
        }

        [HttpGet]
        public List<ProviderInsuranceModel> GetProviderInsurancesByInsuranceID(int ProviderInsuranceID)
        {
            return this._iProviderService.GetProviderInsurancesByInsuranceID(ProviderInsuranceID);
        }

        [HttpGet]
        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModel(int ProviderAwardsAndRecognitionID)
        {
            return this._iProviderService.GetProviderAwardsAndRecognitionModel(ProviderAwardsAndRecognitionID);
        }

        [HttpGet]
        public List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModelByProviderID(int ProviderID)
        {
            return this.GetProviderAwardsAndRecognitionModelByProviderID(ProviderID);
        }


        [HttpPost]
        public ProviderModel AddupdateProviderModel(ProviderModel providerModel)
        {
            return this._iProviderService.AddupdateProviderModel(providerModel);
        }

        [HttpPost]
        public ProviderLocationsModel AddupdateProviderLocationModel(ProviderLocationsModel providerLocationsModel)
        {
            return this._iProviderService.AddupdateProviderLocationModel(providerLocationsModel);
        }

        [HttpPost]
        public ProviderInsuranceModel AddupdateProviderInsuranceModels(ProviderInsuranceModel providerInsuranceModel)
        {
            return this._iProviderService.AddupdateProviderInsuranceModels(providerInsuranceModel);
        }

        [HttpPost]
        public ProviderVacationModel AddupdateProviderVacationModels(ProviderVacationModel providerVacationModel)
        {
            return this._iProviderService.AddupdateProviderVacationModels(providerVacationModel);
        }

        [HttpPost]
        public ProviderStateLicenseModel AddupdateProviderStateLicenseModel(ProviderStateLicenseModel providerStateLicenseModel)
        {
            return this._iProviderService.AddupdateProviderStateLicenseModel(providerStateLicenseModel);
        }
        [HttpPost]

        public ProviderAwardsAndRecognitionModel AddupdateProviderAwardsAndRecognitionModel(ProviderAwardsAndRecognitionModel providerAwardsAndRecognitionModel)
        {
            return this._iProviderService.AddupdateProviderAwardsAndRecognitionModel(providerAwardsAndRecognitionModel);
        }


        [HttpGet]
        public List<ProviderModel> ProvidersingleID()
        {
            return this._iProviderService.ProvidersingleID();
        }


        [HttpGet]
        public List<ProviderModel> ProvidersingleIDProviderID(int ProviderID)
        {
            return this._iProviderService.ProvidersingleIDProviderID(ProviderID);
        }

        [HttpGet]
        public ProviderModel GetProviderRecordbyUserID(int userID)
        {
            return this._iProviderService.GetProviderRecordbyUserID(userID);
        }

        [HttpGet]
        public ProviderLocation DeleteProviderLocationModel(int ProviderLocationID)
        {
            return this._iProviderService.DeleteProviderLocationModel(ProviderLocationID);
        }

        [HttpGet]
        public ProviderStateLicense DeleteProviderStateLincense(int ProviderStateLicenseID)
        {
            return this._iProviderService.DeleteProviderStateLincense(ProviderStateLicenseID);
        }

        [HttpGet]
        public ProviderVacation DeleteProviderVacation(int ProviderVacationID)
        {
            return this._iProviderService.DeleteProviderVacation(ProviderVacationID);
        }

        [HttpGet]
        public ProviderAwardsAndRecognition DeleteProviderAwardsAndRecognition(int ProviderAwardsAndRecognitionID)
        {
            return this._iProviderService.DeleteProviderAwardsAndRecognition(ProviderAwardsAndRecognitionID);
        }

        [HttpGet]
        public ProviderInsurance DeleteProviderInsurance(int ProviderInsuranceID)
        {
            return this._iProviderService.DeleteProviderInsurance(ProviderInsuranceID);
        }

        [HttpGet]
        public List<ProviderVacationModel> providerVacationsbyproviderID(int ProviderID)
        {
            return this._iProviderService.providerVacationsbyproviderID(ProviderID);
        }

        [HttpGet]
        public List<ProviderVacationModel> GetvacationDatesForCalendar(string viewMode, string date, int providerId)
        {
            return this._iProviderService.GetvacationDatesForCalendar(viewMode, date, providerId);
        }

        [HttpGet]
        public List<ProviderLocationTimingModel> GetLocationDatesForCalendar(string viewMode, string date, int providerId, int facilityID)
        {
            return this._iProviderService.GetLocationDatesForCalendar(viewMode, date, providerId, facilityID);
        }

    }
}
