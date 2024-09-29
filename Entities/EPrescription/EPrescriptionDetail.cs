using System;

namespace EndocPM.WebAPI
{
    public class EPrescriptionDetail
    {
        public int EPrescriptionDetailID { get; set; }
        public int EPrescriptionID { get; set; }
        public string DiagnosisCode1 { get; set; }
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
        public virtual DrugCode DrugCode { get; set; }
        public virtual EPrescription EPrescription { get; set; }
        public virtual SigCode SigCode { get; set; }
        public string DiagnosisCode2 { get; set; }
        public string Weight { get; set; }

        public string Height { get; set; }

        public string UnitsofMeasure { get; set; }

        public string DEA { get; set; }

        public string Indications { get; set; }
    }
}
