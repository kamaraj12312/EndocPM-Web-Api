using System;

namespace EndocPM.WebAPI
{
    public class EPrescriptionDetailModel
    {
        public int EPrescriptionDetailID { get; set; }
        public int EPrescriptionID { get; set; }
        public Nullable<int> DrugCodeID { get; set; }
        public Nullable<int> SigCodeID { get; set; }
        public string InstructionToPatient { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> Refill { get; set; }
        public bool AllowSubstitution { get; set; }
        public Nullable<int> SubDrugCodeID { get; set; }
        public string NotesToPharmacist { get; set; }

        public bool DispenseAsWritten { get; set; }
        public bool AddToMedication { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string AllergyDiscussed { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DiagnosisCode1 { get; set; }
        public string DiagnosisCode2 { get; set; }
        public string Weight { get; set; }

        public string Height { get; set; }

        public string UnitsofMeasure { get; set; }

        public string DEA { get; set; }

        public string Indications { get; set; }
        public string DiagnosisCodeJoined { get; set; }
        #region Custom Proprties
        public string DiagnosisCodeDescription1 { get; set; }
        public string DiagnosisCodeDescription2 { get; set; }
        public string DiagnosisCodeDescription3 { get; set; }
        public string DiagnosisCodeDescription4 { get; set; }
        public string DiagnosisCodeDescription5 { get; set; }
        public string DiagnosisCodeDescription6 { get; set; }
        public string DrugCodeDescription { get; set; }
        public string SigCodeDescription { get; set; }
        public string SubDrugCodeDescription { get; set; }
        public string EPrescriptionDetailTitle { get; set; }
        public string DispenseAsWrittenDescription { get; set; }
        public string AddToMedicationDescription { get; set; }
        #endregion
    }
}
