using System;

namespace EndocPM.WebAPI
{
    public class LabRequestModel
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

        public int ProviderID { get; set; }
        public string ReferringCareGiver { get; set; }
        public string ReferringCareGiverUPIN { get; set; }
        public string ReferringCareGiverNameLast { get; set; }

        public string ReferringCareGiverNameFirst { get; set; }
        public string ReferringCareGiverID { get; set; }
        public int PatientID { get; set; }
        public string PersonHSI { get; set; }
        public string PersonID { get; set; }
        public string PatientNameLast { get; set; }
        public string PatientNameFirst { get; set; }
        public string PatientNameMiddle { get; set; }
        public bool IsResponseDownloaded { get; set; }
        public bool IsResponseImportedIntoSystem { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string UniversalServiceIdentifier { get; set; }
        public string UniversalServiceIdentifierText { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string test { get; set; }
        public string CDSMessage { get; set; }

        #region Pagination Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #region Custom Properties
        public string ProviderName { get; set; }
        public string PatientName { get; set; }
        public string LabRequestTitle { get; set; }
        public string ResponseData { get; set; }
        public Nullable<DateTime> RequestedFromDate { get; set; }
        public Nullable<DateTime> RequestedToDate { get; set; }
        public Nullable<DateTime> RespondedFromDate { get; set; }
        public Nullable<DateTime> RespondedToDate { get; set; }
        public string LabResponseTitle { get; set; }
        public string IsSearch { get; set; }
        public int PatientLabOrderTestID { get; set; }
        #endregion

    }
}
