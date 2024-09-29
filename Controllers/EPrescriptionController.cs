using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EPrescriptionController : Controller
    {
        public readonly IEPrescriptionService _iEPrescriptionService;

        public EPrescriptionController(IEPrescriptionService iEPrescriptionService)
        {
            _iEPrescriptionService = iEPrescriptionService;
        }

        [HttpGet]
        public List<PharmacyModel> GetPharmacyList()
        {
            return this._iEPrescriptionService.GetPharmacyList();
        }

        [HttpGet]
        public List<RxImportHistoryModel> GetRxImportHistories()
        {
            return this._iEPrescriptionService.GetRxImportHistories();
        }

        [HttpGet]
        public List<RxImportHistoryModel> getBypatientIDRxImportHistories(int PatientID)
        {
            return this._iEPrescriptionService.getBypatientIDRxImportHistories(PatientID);
        }

        [HttpGet]
        public List<SigCodeModel> GetSigCodes()
        {
            return this._iEPrescriptionService.GetSigCodes();
        }

        [HttpPost]
        public SigCode sigCodes(SigCode sigCode)
        {
            return this._iEPrescriptionService.sigCodes(sigCode);
        }

        [HttpGet]
        public List<EPrescriptionModel> GetEPrescriptionModels()
        {
            return this._iEPrescriptionService.GetEPrescriptionModels();
        }

        [HttpGet]
        public List<EPrescriptionDetailModel> GetEPrescriptionDetails()
        {
            return this._iEPrescriptionService.GetEPrescriptionDetails();
        }

   
        [HttpGet]
        public List<PharmacyModel> GetPharmacyListbyPharmacyId(int PharmacyID)
        {
            return this._iEPrescriptionService.GetPharmacyListbyPharmacyId(PharmacyID);
        }

        [HttpGet]
        public List<PatientModel> GetPatientModelscallbySearch(string SearchKey)
        {
            return this._iEPrescriptionService.GetPatientModelscallbySearch(SearchKey);
        }


        [HttpPost]
        public EPrescriptionModel addupdateeprescriptionmodel(EPrescriptionModel ePrescriptionModel)
        {
            return this._iEPrescriptionService.addupdateeprescriptionmodel(ePrescriptionModel);
        }

        [HttpGet]
        public List<ProviderModel> GetProvidersSearchkeymodel(string Searchkey)
        {
            return this._iEPrescriptionService.GetProvidersSearchkeymodel(Searchkey);
        }

        [HttpGet]
        public List<PrescriptionStatus> GetPrescriptionStatuses()
        {
            return this._iEPrescriptionService.GetPrescriptionStatuses();
        }

        [HttpGet]
        public List<PatientMedicationModel> GetRxHistoryMedicationsforPatient(int PatientID)
        {
            return this._iEPrescriptionService.GetRxHistoryMedicationsforPatient(PatientID);
        }

        [HttpGet]
        public List<EPrescriptionDetailModel> GetDraftPrescriptions(int PatientID)
        {
            return this._iEPrescriptionService.GetDraftPrescriptions(PatientID);
        }

    }
}
