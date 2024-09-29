using System.Collections.Generic;

namespace EndocPM.WebAPI
{ 
    public class SOAPNotesModel
    {
        public List<VitalSignModel> VitalSign { get; set; }
        public List<PatientMedicationModel> PatientMedication { get; set; }
        public List<PatientAllergyModel> patientAllergy { get; set; }
        public List<PatientWorkHistoryModel> patientWorkHistory { get; set; }
        public List<FamilyHealthHistoryModel> FamilyHealthHistory { get; set; }
        public List<PatientImmunizationModel> patientImmunization { get; set; }
        public List<PatientDiagnosticListModel> patientDiagnosticList { get; set; }
        public List<PatientTobaccoAlcoholHistoryModel> SocialHistory { get; set; }
        public List<PatientFamilyModel> PatientFamily { get; set; }
        public List<PatientROSModel> ROSDetails { get; set; }
        public List<PatientProblemListModel> ProblemList { get; set; }
        public List<PatientModel> Patients { get; set; }

        public PatientModel PatientRecord { get; set; }

        //public SOAPNotesConfigModel Config = new SOAPNotesConfigModel();




    }
}
