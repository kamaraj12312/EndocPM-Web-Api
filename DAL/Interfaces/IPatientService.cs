using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EndocPM.WebAPI
{
    public interface IPatientService
    {

        List<PatientModel> GetPatients();

        PatientModel GetPatientModels(int PatientID);

        List<VitalSignModel> GetVitalSignModel();

        List<PatientMedicationModel> PatientMedications();

        List<PatientAllergyModel> patientAllergyModels();

        List<PatientWorkHistoryModel> patientWorkHistoryModels();

        List<FamilyHealthHistoryModel> FamilyHealthHistoryModels();

        List<PatientImmunizationModel> patientImmunizationModels();

        List<PatientDiagnosticListModel> patientDiagnosticListModels();

        List<PatientAppointmentHistoryModel> PatientAppointmentHistoryModels();

        List<PatientInsuranceModel> patientInsuranceModels();

        List<PatientLabOrderTestModel> PatientLabOrderTestModels();

        List<PatientMedicationModel> PatientMedicationModelsbyPatientID(int PatientID);
        PatientMedicationModel GetpatientMedicationRecordByID(int PatientMedicationID);
        List<PatientAllergyModel> AllergyModelByPatientID(int PatientID);

        PatientAllergyModel GetallergyRecordByID(int PatientAllergyID);
        List<PatientWorkHistoryModel> patientWorkHistoryModelsByPatientID(int PatientID);

        PatientWorkHistoryModel GetpatientWorkHistoryRecordByID(int PatientWorkHistoryID);

        List<FamilyHealthHistoryModel> familyHealthHistoryModelByPatientID(int PatientID);
        FamilyHealthHistoryModel GetfamilyHealthHistoryRecordByID(int FamilyHealthHistoryID);
        List<PatientImmunizationModel> patientImmunizationModelByPatientID(int PatientID);
        PatientImmunizationModel GetpatientImmunizationRecordByID(int PatientImmunizationID);
        List<PatientDiagnosticListModel> patientDiagnosticListModelByPatientID(int PatientID);
        PatientDiagnosticListModel GetpatientDiagnosticListRecordByID(int PatientDiagnosticListID);
        List<PatientInsuranceModel> patientInsuranceModelByPaientID(int PatientID);

        List<PatientLabOrderTestModel> PatientLabOrderTestModelByPatientID(int patientID);
        PatientLabOrderTestModel GetPatientLabOrderTestRecordByID(int patientLabOrderTestID);

        List<PatientROSModel> GetROSDetailsbyPatientID(int patientID);
        PatientROSModel GetPatientROSDetailbyID(int patientROSID);
        PatientROSModel AddUpdateROSRecord(PatientROSModel rosModel);

        PatientProblemListModel AddUpdatePatientProblemList(PatientProblemListModel problemListModel);
        List<PatientProblemListModel> GetProblemListByPatientID(int patientID);
        PatientProblemListModel GetProblemListRecordByID(int patientProblemListID);

        PatientModel AddUpdatePatient(PatientModel patientModel);

        PatientMedicationModel AddupdatePatientMedication(PatientMedicationModel patientMedicationModel);

        PatientAllergyModel AddupdatePatientAllergyModel(PatientAllergyModel patientAllergyModel);

        PatientWorkHistoryModel AddupdatePatientWorkHistoryModel(PatientWorkHistoryModel patientWorkHistoryModel);

        FamilyHealthHistoryModel AddupdateFamilyHealthHistoryModel(FamilyHealthHistoryModel familyHealthHistoryModel);

        PatientImmunizationModel AddupdatePatientImmunizationModel(PatientImmunizationModel patientImmunizationModel);
        PatientDiagnosticListModel AddupdatePatientDiagnosticListModel(PatientDiagnosticListModel patientDiagnosticListModel);
        List<PatientTobaccoAlcoholHistoryModel> GetSocialHistory();

        List<PatientFamilyModel> GetPatientFamily();

        List<PatientTobaccoAlcoholHistoryModel> GetSocialHistoryByPatientID(int PatientID);
        PatientTobaccoAlcoholHistoryModel GetSocialHistoryByPatientTobaccoAlcoholHistoryID(int PatientTobaccoAlcoholHistoryID);

        List<PatientFamilyModel> GetPatientFamilyByPatientID(int PatientID);
        PatientFamilyModel GetPatientFamilyByPatientFamilyID(int PatientFamilyID);

        PatientTobaccoAlcoholHistoryModel AddupdateSocialHistory(PatientTobaccoAlcoholHistoryModel patientTobaccoAlcoholHistoryModel);

        PatientFamilyModel AddupdatePatientFamilyModel(PatientFamilyModel patientFamilyModel);
       
        SOAPNotesModel GetSOAPNotes(int PatientID);
        List<PatientInsuranceModel> GetPatientInsurance();
        List<PatientInsuranceModel> GetPatientInsurancesByPatientID(int patientID);
        List<PatientInsuranceModel> GetPatientInsurancesByPatientInsuranceID(int PatientInsuranceID);

        PhysicalExamModel addupdatephysicalexam(PhysicalExamModel physicalExamModel);

        List<PhysicalExamModel> GetPhysicalExamModelsgetbyPatientID(int PatientID);

        List<PhysicalExamModel> GetPhysicalExamModelsgetbyPhysicalExamID(int PhysicalExamID);

    }
}
