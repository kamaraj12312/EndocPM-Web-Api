using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientVisit
    {
        public int PatientVisitID { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }
        public Nullable<int> PatientAppointmentID { get; set; }
        public string VisitNumber { get; set; }
        public Nullable<DateTime> VisitDate { get; set; }
        public string VisitTime { get; set; }
        public Nullable<int> VisitCategoryID { get; set; }
        public string ReferringProvider { get; set; }
        public Nullable<int> ConsultingProviderID { get; set; }
        public string ChiefComplaint { get; set; }
        public string InitialICDCode1 { get; set; }
        public string InitialICDCode2 { get; set; }
        public string InitialICDCode3 { get; set; }
        public string InitialICDCode4 { get; set; }
        public string InitialICDCode5 { get; set; }
        public string InitialICDCode6 { get; set; }
        public string InitialICDCode7 { get; set; }
        public string InitialICDCode8 { get; set; }
        public string InitialICDCode9 { get; set; }
        public string InitialICDCode10 { get; set; }
        public string InitialICDCode11 { get; set; }
        public string InitialICDCode12 { get; set; }
        public Nullable<int> VisitTypeID { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SyndromicRecordSendStatus { get; set; }
        public string ADTType { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsPrintReasonInHL7 { get; set; }
        public Nullable<int> ReferringProviderID { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID1 { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID2 { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID3 { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID4 { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID5 { get; set; }
        public Nullable<int> PhysicalExamSnomedCTID6 { get; set; }
        public string ProcedureCode { get; set; }

        public Nullable<DateTime> DischargeDate { get; set; }
        public Nullable<int> PatientAdmissionID { get; set; }
        public string ProviderToProviderCommunicationCode { get; set; }
        public string ProviderToProviderRefusalReasonCode { get; set; }
        public string PatientToProviderCommunicationCode { get; set; }
        public string PatientToProviderRefusalReasonCode { get; set; }
        public string ProviderToPatientCommunicationCode { get; set; }
        public string ProviderToPatientRefusalReasonCode { get; set; }
        public Nullable<DateTime> CommunicationDate { get; set; }

    }
}