using System;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
   
    public class LabRequest
    {
        public int LabRequestID { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string OrderType { get; set; }
        public string LabID { get; set; }
        public string LabName { get; set; }
        public Nullable<DateTime> RequestDate { get; set; }
        public Nullable<DateTime> CollectionDate { get; set; }
        public Nullable<DateTime> RespondedDate { get; set; }
        public string OrderingOrganizationID { get; set; }
        public string OrderedUser { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string ReferringCareGiver { get; set; }
        public string ReferringCareGiverUPIN { get; set; }
        public string ReferringCareGiverNameLast { get; set; }
        public string ReferringCareGiverNameFirst { get; set; }
        public string ReferringCareGiverID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string PersonHSI { get; set; }
        public string PersonID { get; set; }
        public string PatientNameLast { get; set; }
        public string PatientNameFirst { get; set; }
        public string PatientNameMiddle { get; set; }
        public bool IsResponseDownloaded { get; set; }
        public bool IsResponseImportedIntoSystem { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string UniversalServiceIdentifier { get; set; }
        public string UniversalServiceIdentifierText { get; set; }
        


    }
}
