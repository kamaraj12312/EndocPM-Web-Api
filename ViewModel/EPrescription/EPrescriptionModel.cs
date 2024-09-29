using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public class EPrescriptionModel
    {
        public int EPrescriptionID { get; set; }
        public string EPrescriptionNumber { get; set; }
        public Nullable<DateTime> EPrescriptionDate { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PrescriberID { get; set; }
        public string PrescriberType { get; set; }
        public Nullable<int> PrescriptionStatusID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PharmacyID { get; set; }

        #region Custom Property
        public string EPrescriptionStatusDescription { get; set; }
        public string PrescriberName { get; set; }
        public string PatientName { get; set; }
        public string PharmacyName { get; set; }
        public string DiagnosisCode1 { get; set; }
        public string DiagnosisCodeDescription1 { get; set; }
        public string DiagnosisCode6 { get; set; }
        public string DiagnosisCodeDescription6 { get; set; }
        public string DiagnosisCode2 { get; set; }
        public string DiagnosisCodeDescription2 { get; set; }
        public string DiagnosisCode3 { get; set; }
        public string DiagnosisCodeDescription3 { get; set; }
        public string DiagnosisCode4 { get; set; }
        public string DiagnosisCodeDescription4 { get; set; }
        public string DiagnosisCode5 { get; set; }
        public string DiagnosisCodeDescription5 { get; set; }
        public Nullable<int> DrugCodeID { get; set; }
        public string DrugCodeDescription { get; set; }
        public Nullable<int> SigCodeID { get; set; }
        public string SigCodeDescription { get; set; }
        public string InstructionToPatient { get; set; }
        public string Quantity { get; set; }
        public Nullable<int> Refill { get; set; }
        public bool AllowSubstitution { get; set; }
        public Nullable<int> SubDrugCodeID { get; set; }
        public string SubDrugCodeDescription { get; set; }
        public string NotesToPharmacist { get; set; }
        public bool DispenseAsWritten { get; set; }
        public bool AddToMedication { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public string AllergyDiscussed { get; set; }
        public string EPrescriptionTitle { get; set; }
        public string PrNameFirst { get; set; }
        public string PrNameLast { get; set; }
        public string EPrescriptionDateString { get; set; }

        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameMiddle { get; set; }
        public string Description { get; set; }
        public List<EPrescriptionDetail> EPrescriptionDetails { get; set; }
        #endregion
    }
}
