using EndocPM.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public interface IProviderService
    {
        ProviderModel ProvidersModel(int providerID);

        List<ProviderModel> ProviderModel();

        List<ProviderLocationsModel> GetProviderLocations();

        List<SchedulerSetupModel> SchedulerSetups();

        List<ProviderVacationModel> providerVacations();

        List<ProviderStateLicenseModel> providerStateLincenses();

        List<ProviderInsuranceModel> GetProviderInsurances();

        List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModels();


        List<ProviderLocationsModel> GetProviderLocationByproviderlocationID(int ProviderLocationID);

        List<SchedulerSetupModel> SchedulerSetupsByschedulersetup(int SchedulerSetupID);

        List<ProviderVacationModel> GetproviderVacationByproviderVacationID(int ProviderVacation);

        List<ProviderStateLicenseModel> GetproviderStateLincensesByStatelincenseID(int ProviderStateLicenseID);

        List<ProviderInsuranceModel> GetProviderInsurancesByInsuranceID(int ProviderInsuranceID);

        List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModel(int ProviderAwardsAndRecognitionID);

        List<ProviderAwardsAndRecognitionModel> GetProviderAwardsAndRecognitionModelByProviderID(int ProviderID);

        ProviderModel AddupdateProviderModel(ProviderModel providerModel);

        ProviderLocationsModel AddupdateProviderLocationModel(ProviderLocationsModel providerLocationsModel);

        ProviderInsuranceModel AddupdateProviderInsuranceModels(ProviderInsuranceModel providerInsuranceModel);

        ProviderVacationModel AddupdateProviderVacationModels(ProviderVacationModel providerVacationModel);

        ProviderStateLicenseModel AddupdateProviderStateLicenseModel(ProviderStateLicenseModel providerStateLicenseModel);

        ProviderAwardsAndRecognitionModel AddupdateProviderAwardsAndRecognitionModel(ProviderAwardsAndRecognitionModel providerAwardsAndRecognitionModel);
        ProviderLocation DeleteProviderLocationModel(int ProviderLocationID);

        ProviderStateLicense DeleteProviderStateLincense(int ProviderStateLicenseID);

        ProviderVacation DeleteProviderVacation(int ProviderVacationID);

        ProviderAwardsAndRecognition DeleteProviderAwardsAndRecognition(int ProviderAwardsAndRecognitionID);
        ProviderInsurance DeleteProviderInsurance(int ProviderInsuranceID);

        List<ProviderModel> ProvidersingleID();
        List<ProviderModel> ProvidersingleIDProviderID(int ProviderID);
        ProviderModel GetProviderRecordbyUserID(int userID);

        List<ProviderVacationModel> providerVacationsbyproviderID(int ProviderID);
        List<ProviderVacationModel> GetvacationDatesForCalendar(string viewMode, string date, int providerId);
        List<ProviderLocationTimingModel> GetLocationDatesForCalendar(string viewMode, string date, int providerId, int facilityID);

    }
}
