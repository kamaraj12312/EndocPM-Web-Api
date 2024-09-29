 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class VitalSignModel
    {
        public VitalSignModel()
        {
           // RecordedDate = DateTime.UtcNow;
           // RecordedTimeString = string.Format("{0:HH:mm}", DateTime.Now);
        }
        #region ModelProperties
        public int VitalSignID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public DateTime RecordedDate { get; set; }
        public Nullable<DateTime> RecordedTime { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> Temperature { get; set; }
        public Nullable<int> TemperatureLocationID { get; set; }
        public Nullable<decimal> OxygenSaturation { get; set; }
        public Nullable<decimal> BloodPressureSystolic { get; set; }
        public Nullable<decimal> BloodPressureDiastolic { get; set; }
        public Nullable<decimal> HeartRate { get; set; }
        public Nullable<decimal> RespiratoryRate { get; set; }
        public Nullable<decimal> HeadCircumference { get; set; }
        public Nullable<decimal> WaistCircumference { get; set; }
        public Nullable<int> SmokingCategoryID { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string NotesSnomedCT { get; set; }
        public bool IsPrinted { get; set; }
        public string VitalCodeForCDS { get; set; }

        public decimal PatientAge { get; set; }

        #endregion

        #region New Fields
        public string RecordedBy { get; set; }
        public Nullable<int> RecordedDuringID { get; set; }
        public string RecordedDuringName { get; set; }
        public string PainArea { get; set; }
        public Nullable<int> PainScale { get; set; }
        public Nullable<decimal> PulseRate { get; set; }
        public Nullable<int> BloodPressureLocationID { get; set; }
        public string BloodPressureLocationName { get; set; }
        public Nullable<int> BloodPressurePositionID { get; set; }
        public string BloodPressurePositionName { get; set; }
        public Nullable<int> BloodSugarFast { get; set; }
        public Nullable<int> BloodSugarPP { get; set; }
        public string LastMeal { get; set; }
        public Nullable<DateTime> LastMealTime { get; set; }
        public Nullable<int> BloodSugarRandom { get; set; }
        #endregion

        #region Search Property
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #region Referance Properties
        public virtual PatientModel Patient { get; set; }
        // public virtual PatientEncounterModel PatientEncounter { get; set; }

        #endregion

        #region CustomProperties
        public string VitalSignTitle { get; set; }
        public String TemperatureLocationName { get; set; }
        public string SmokingCategoryName { get; set; }
        public Nullable<decimal> BMI { get; set; }
        public Nullable<decimal> BSA { get; set; }
        public Nullable<int> VitalSignCaseSheetBack { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string BloodPressureString { get; set; }
        public string RecordedDateString { get; set; }
        public string PatientPanelBirthDate { get; set; }
        public string IsSearch { get; set; }
        public string RecordedTimeString { get; set; }
        public string AgeCategory { get; set; }
        public string Length { get; set; }
        public int? SnomedCTID { get; set; }
        public string SnomedCTIDForMultiselect { get; set; }
        public string SnomedDescription { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string CDSMessage { get; set; }
        public int? ExternalVitalSignID { get; set; }
        public string VisitDateTimeAsString { get; set; }
        public string VisitDetailsTitle { get; set; }
        public string VitalTitle { get; set; }
        public Nullable<DateTime> VisitDate { get; set; }
        #endregion

        #region Custom Snomed Code
   
        public class CustomSnomedCodeModel
        {
            public Nullable<int> NotesArrayID { get; set; }
            public string SNOMEDCode { get; set; }
            public string NotesArrayDescription { get; set; }
        }
    
        #endregion


    }
}