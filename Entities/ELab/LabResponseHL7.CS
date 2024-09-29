using System;

namespace EndocPM.WebAPI
{
    public class LabResponseHL7
    {
        public int LabResponseHL7ID { get; set; }
        public Nullable<int> LabRequestID { get; set; }
        public String ResponseData { get; set; }
        public DateTime ResponseDownloadDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public String ModifiedBy { get; set; }
        public Nullable<int> PatientLabOrderTestID { get; set; }
        public Nullable<int> PatientID { get; set; }

        
    }
}
