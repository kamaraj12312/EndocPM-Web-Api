using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class VitalSign
    {
        public int VitalSignID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public Nullable<DateTime> RecordedTime { get; set; }
        public DateTime RecordedDate { get; set; }
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
        public Nullable<int> BloodSugarRandom { get; set; }
        public Nullable<int> ExternalVitalSignID { get; set; }

    }
}