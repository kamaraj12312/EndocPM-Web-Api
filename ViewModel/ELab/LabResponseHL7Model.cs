using System;

namespace EndocPM.WebAPI
{
    public class LabResponseHL7Model
    {
        public int LabResponseHL7ID { get; set; }
        public int LabRequestID { get; set; }
        public string ResponseData { get; set; }
        public Nullable<DateTime> ResponseDownloadDate { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> PatientLabOrderTestID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #region Custom Properties
        public bool IsCalledFromPatientScreen { get; set; }

        #endregion
    }
}
