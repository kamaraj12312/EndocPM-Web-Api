using Microsoft.AspNetCore.Authorization;
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
    public class PatientController : Controller
    {
        public readonly IPatientService _iPatientService;
        
        public PatientController(IPatientService iPatientService)
        {
            _iPatientService = iPatientService;
        }

        [HttpGet]
        public List<PatientModel> GetPatients()
        {
            return this._iPatientService.GetPatients();
        }
        
        [HttpGet]
        public PatientModel GetPatientModels(int PatientID)
        {
            return this._iPatientService.GetPatientModels(PatientID);
        }

        [HttpGet]
        public List<VitalSignModel> GetVitalSignModel()
        {
            return this._iPatientService.GetVitalSignModel();
        }
        
        [HttpGet]
        public List<PatientMedicationModel> PatientMedications()
        {
            return this._iPatientService.PatientMedications();
        }

        [HttpGet]
        public List<PatientAllergyModel> patientAllergyModels()
        {
            return this._iPatientService.patientAllergyModels();
        }

        [HttpGet]
        public List<PatientWorkHistoryModel> patientWorkHistoryModels()
        {
            return this._iPatientService.patientWorkHistoryModels();
        }

        [HttpGet]
        public List<FamilyHealthHistoryModel> FamilyHealthHistoryModels()
        {
            return this._iPatientService.FamilyHealthHistoryModels();
        }

        [HttpGet]
        public List<PatientImmunizationModel> patientImmunizationModels()
        {
            return this._iPatientService.patientImmunizationModels();
        }

        [HttpGet]
        public List<PatientDiagnosticListModel> patientDiagnosticListModels()
        {
            return this._iPatientService.patientDiagnosticListModels();
        }

        [HttpGet]
        public List<PatientAppointmentHistoryModel> PatientAppointmentHistoryModels()
        {
            return this._iPatientService.PatientAppointmentHistoryModels();
        }

        [HttpGet]
        public List<PatientInsuranceModel> patientInsuranceModels()
        {
            return this._iPatientService.patientInsuranceModels();
        }

        [HttpGet]
        public List<PatientLabOrderTestModel> PatientLabOrderTestModels()
        {
            return this._iPatientService.PatientLabOrderTestModels();
        }

        [HttpGet]
        public List<PatientMedicationModel> PatientMedicationModelsbyPatientID(int PatientID)
        {
            return this._iPatientService.PatientMedicationModelsbyPatientID(PatientID);
        }

        [HttpGet]
        public PatientMedicationModel GetpatientMedicationRecordByID(int PatientMedicationID)
        {
            return this._iPatientService.GetpatientMedicationRecordByID(PatientMedicationID);
        }

        [HttpGet]
        public List<PatientAllergyModel> AllergyModelByPatientID(int PatientID)
        {
            return this._iPatientService.AllergyModelByPatientID(PatientID);
        }

        [HttpGet]
        public PatientAllergyModel GetallergyRecordByID(int PatientAllergyID)
        {
            return this._iPatientService.GetallergyRecordByID(PatientAllergyID);
        }

        [HttpGet]
        public List<PatientWorkHistoryModel> patientWorkHistoryModelsByPatientID(int PatientID)
        {
            return this._iPatientService.patientWorkHistoryModelsByPatientID(PatientID);
        }

        [HttpGet]
        public PatientWorkHistoryModel GetpatientWorkHistoryRecordByID(int PatientWorkHistoryID)
        {
            return this._iPatientService.GetpatientWorkHistoryRecordByID(PatientWorkHistoryID);
        }

        [HttpGet]
        public List<FamilyHealthHistoryModel> familyHealthHistoryModelByPatientID(int PatientID)
        {
            return this._iPatientService.familyHealthHistoryModelByPatientID(PatientID);
        }

        [HttpGet]
        public FamilyHealthHistoryModel GetfamilyHealthHistoryRecordByID(int FamilyHealthHistoryID)
        {
            return this._iPatientService.GetfamilyHealthHistoryRecordByID(FamilyHealthHistoryID);
        }

        [HttpGet]
        public List<PatientImmunizationModel> patientImmunizationModelByPatientID(int PatientID)
        {
            return this._iPatientService.patientImmunizationModelByPatientID(PatientID);
        }

        [HttpGet]
        public PatientImmunizationModel GetpatientImmunizationRecordByID(int PatientImmunizationID)
        {
            return this._iPatientService.GetpatientImmunizationRecordByID(PatientImmunizationID);
        }

        [HttpGet]
        public List<PatientDiagnosticListModel> patientDiagnosticListModelByPatientID(int PatientID)
        {
            return this._iPatientService.patientDiagnosticListModelByPatientID(PatientID);
        }

        [HttpGet]
        public PatientDiagnosticListModel GetpatientDiagnosticListRecordByID(int PatientDiagnosticListID)
        {
            return this._iPatientService.GetpatientDiagnosticListRecordByID(PatientDiagnosticListID);
        }

        [HttpGet]
        public List<PatientInsuranceModel> patientInsuranceModelByPaientID(int PatientID)
        {
            return this._iPatientService.patientInsuranceModelByPaientID(PatientID);
        }

        [HttpGet]
        public List<PatientLabOrderTestModel> PatientLabOrderTestModelByPatientID(int patientID)
        {
            return this._iPatientService.PatientLabOrderTestModelByPatientID(patientID);
        }

        [HttpGet]
        public PatientLabOrderTestModel GetPatientLabOrderTestRecordByID(int patientLabOrderTestID)
        {
            return this._iPatientService.GetPatientLabOrderTestRecordByID(patientLabOrderTestID);
        }

        [HttpGet]
        public List<PatientROSModel> GetROSDetailsbyPatientID(int patientID)
        {
            return this._iPatientService.GetROSDetailsbyPatientID(patientID);
        }

        [HttpGet]
        public PatientROSModel GetPatientROSDetailbyID(int patientROSID)
        {
            return this._iPatientService.GetPatientROSDetailbyID(patientROSID);
        }

        [HttpPost]
        public PatientROSModel AddUpdateROSRecord(PatientROSModel rosModel)
        {
            return this._iPatientService.AddUpdateROSRecord(rosModel);
        }
        
        [HttpGet]
        public List<PatientProblemListModel> GetProblemListByPatientID(int patientID)
        {
            return this._iPatientService.GetProblemListByPatientID(patientID);
        }

        [HttpGet]
        public PatientProblemListModel GetProblemListRecordByID(int patientProblemListID)
        {
            return this._iPatientService.GetProblemListRecordByID(patientProblemListID);
        }

        [HttpPost]
        public PatientProblemListModel AddUpdatePatientProblemList(PatientProblemListModel problemListModel)
        {
            return this._iPatientService.AddUpdatePatientProblemList(problemListModel);
        }

        [HttpPost]
        public PatientModel AddUpdatePatient(PatientModel patientModel)
        {
            return this._iPatientService.AddUpdatePatient(patientModel);
        }

        [HttpPost]
        public PatientMedicationModel AddupdatePatientMedication(PatientMedicationModel patientMedicationModel)
        {
            return this._iPatientService.AddupdatePatientMedication(patientMedicationModel);
        }

        [HttpPost]
        public PatientAllergyModel AddupdatePatientAllergyModel(PatientAllergyModel patientAllergyModel)
        {
            return this._iPatientService.AddupdatePatientAllergyModel(patientAllergyModel);
        }

        [HttpPost]
        public PatientWorkHistoryModel AddupdatePatientWorkHistoryModel(PatientWorkHistoryModel patientWorkHistoryModel)
        {
            return this._iPatientService.AddupdatePatientWorkHistoryModel(patientWorkHistoryModel);

        }

        [HttpPost]
        public FamilyHealthHistoryModel AddupdateFamilyHealthHistoryModel(FamilyHealthHistoryModel familyHealthHistoryModel)
        {
            return this._iPatientService.AddupdateFamilyHealthHistoryModel(familyHealthHistoryModel);

        }

        [HttpPost]
        public PatientImmunizationModel AddupdatePatientImmunizationModel(PatientImmunizationModel patientImmunizationModel)
        {
            return this._iPatientService.AddupdatePatientImmunizationModel(patientImmunizationModel);
        }

        [HttpPost]
        public PatientDiagnosticListModel AddupdatePatientDiagnosticListModel(PatientDiagnosticListModel patientDiagnosticListModel)
        {
            return this._iPatientService.AddupdatePatientDiagnosticListModel(patientDiagnosticListModel);
        }
        
        [HttpGet]
        public List<PatientTobaccoAlcoholHistoryModel> GetSocialHistory()
        {
            return this._iPatientService.GetSocialHistory();
        }
        
        [HttpGet]
        public List<PatientTobaccoAlcoholHistoryModel> GetSocialHistoryByPatientID(int PatientID)
        {
            return this._iPatientService.GetSocialHistoryByPatientID(PatientID);
        }

        [HttpGet]
        public PatientTobaccoAlcoholHistoryModel GetSocialHistoryByPatientTobaccoAlcoholHistoryID(int PatientTobaccoAlcoholHistoryID)
        {
            return this._iPatientService.GetSocialHistoryByPatientTobaccoAlcoholHistoryID(PatientTobaccoAlcoholHistoryID);
        }
        
        [HttpGet]
        public List<PatientFamilyModel> GetPatientFamily()
        {
            return this._iPatientService.GetPatientFamily();
        }
        
        [HttpGet]
        public List<PatientFamilyModel> GetPatientFamilyByPatientID(int PatientID)
        {
            return this._iPatientService.GetPatientFamilyByPatientID(PatientID);
        }

        [HttpGet]
        public PatientFamilyModel GetPatientFamilyByPatientFamilyID(int PatientFamilyID)
        {
            return this._iPatientService.GetPatientFamilyByPatientFamilyID(PatientFamilyID);
        }

        [HttpPost]
        public PatientTobaccoAlcoholHistoryModel AddupdateSocialHistory(PatientTobaccoAlcoholHistoryModel patientTobaccoAlcoholHistoryModel)
        {
            return this._iPatientService.AddupdateSocialHistory(patientTobaccoAlcoholHistoryModel);
        }
        
        [HttpPost]
        public PatientFamilyModel AddupdatePatientFamilyModel(PatientFamilyModel patientFamilyModel)
        {
            return this._iPatientService.AddupdatePatientFamilyModel(patientFamilyModel);
        }

        [HttpGet]
        public SOAPNotesModel[] GetSOAPNotes(int PatientID)
        {
            SOAPNotesModel[] soapArray = new SOAPNotesModel[2];
            soapArray[0] = this._iPatientService.GetSOAPNotes(PatientID);
            soapArray[1] = new SOAPNotesModel();
            return soapArray;
        }

        [HttpGet]
        public List<PatientInsuranceModel> GetPatientInsurance()
        {
            return this._iPatientService.GetPatientInsurance();
        }

        [HttpGet]
        public List<PatientInsuranceModel> GetPatientInsurancesByPatientID(int patientID)
        {
            return this._iPatientService.GetPatientInsurancesByPatientID(patientID);
        }

        [HttpGet]
        public List<PatientInsuranceModel> GetPatientInsurancesByPatientInsuranceID(int PatientInsuranceID)
        {
            return this._iPatientService.GetPatientInsurancesByPatientInsuranceID(PatientInsuranceID);
        }

        [HttpPost]
        public PhysicalExamModel addupdatephysicalexam(PhysicalExamModel physicalExamModel)
        {
            return this._iPatientService.addupdatephysicalexam(physicalExamModel);
        }

        [HttpGet]
        public List<PhysicalExamModel> GetPhysicalExamModelsgetbyPatientID(int PatientID)
        {
            return this._iPatientService.GetPhysicalExamModelsgetbyPatientID(PatientID);
        }

        [HttpGet]
        public List<PhysicalExamModel> GetPhysicalExamModelsgetbyPhysicalExamID(int PhysicalExamID)
        {
            return this._iPatientService.GetPhysicalExamModelsgetbyPhysicalExamID(PhysicalExamID);
        }





    }
}
