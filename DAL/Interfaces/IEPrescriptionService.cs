using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public interface IEPrescriptionService
    {
        List<PharmacyModel> GetPharmacyList();

        List<RxImportHistoryModel> GetRxImportHistories();

        List<RxImportHistoryModel> getBypatientIDRxImportHistories(int PatientID);

        List<SigCodeModel> GetSigCodes();

        List<EPrescriptionModel> GetEPrescriptionModels();

        List<EPrescriptionDetailModel> GetEPrescriptionDetails();

        SigCode sigCodes(SigCode sigCode);

        List<PharmacyModel> GetPharmacyListbyPharmacyId(int PharmacyID);


        List<PatientModel> GetPatientModelscallbySearch(string SearchKey);


        EPrescriptionModel addupdateeprescriptionmodel(EPrescriptionModel ePrescriptionModel);

        List<ProviderModel> GetProvidersSearchkeymodel(string Searchkey);

        List<PrescriptionStatus> GetPrescriptionStatuses();
        List<PatientMedicationModel> GetRxHistoryMedicationsforPatient(int PatientID);
        List<EPrescriptionDetailModel> GetDraftPrescriptions(int PatientID);
    }
}
