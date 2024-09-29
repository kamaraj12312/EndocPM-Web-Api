using System;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    
    public class LabRxAuditReport
    {
        public int LabRxAuditReportID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientNumber { get; set; }
        public string UserName { get; set; }
        public string Data { get; set; }
        public string ActionMethodName { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public string ActionStatus { get; set; }
        public string ScreenName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ActionRequestedFor { get; set; }
        public int UniqueIDForRequest { get; set; }


    }
}
