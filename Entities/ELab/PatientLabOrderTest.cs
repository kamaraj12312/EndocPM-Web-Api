using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EndocPM.WebAPI;

namespace EndocPM.WebAPI
{
    public class PatientLabOrderTest
    {
        public int PatientLabOrderTestID { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public string FacilityName { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string ProviderName { get; set; }
        public Nullable<int> OrderingProviderID { get; set; }
        public string OrderingProviderName { get; set; }
        public int  PatientID { get; set; }
        public DateTime RecordedDate { get; set; }
        public DateTime LabTestDate { get; set; }
        public string LabName { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string ReferenceRange { get; set; }
        public string LabAddressLine1 { get; set; }
        public string LabAddressLine2 { get; set; }
        public string LabCity { get; set; }
        public string LabState { get; set; }
        public string LabCounty { get; set; }
        public string LabZIP { get; set; }
        public string LoincCode1 { get; set; }
        public string LoincCode2 { get; set; }
        public string LoincCode3 { get; set; }
        public string LoincCode4 { get; set; }
        public string LoincCode5 { get; set; }
        public string LoincCode6 { get; set; }
        public string LoincCode7 { get; set; }
        public string LoincCode8 { get; set; }
        public string LoincCode9 { get; set; }
        public string LoincCode10 { get; set; }
        public string LoincCode11 { get; set; }
        public string LoincCode12 { get; set; }
        public string LoincCode13 { get; set; }
        public string LoincCode14 { get; set; }
        public string LoincCode15 { get; set; }
        public string LoincCode16 { get; set; }
        public string ICDCode1 { get; set; }
        public string ICDCode2 { get; set; }
        public string ICDCode3 { get; set; }
        public string ICDCode4 { get; set; }
        public string ICDCode5 { get; set; }
        public string ICDCode6 { get; set; }
        public string ICDCode7 { get; set; }
        public string ICDCode8 { get; set; }
        public string ICDCode9 { get; set; }
        public string ICDCode10 { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public bool IsPastTest { get; set; }
        public string DocumentReferenceIds { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<int> EmdeonLabID { get; set; }
        public string PlacerOrderNumber { get; set; }
        public Nullable<int> OrderRequestMSGPIDGRTORCID { get; set; }
        public Nullable<int> ScheduledTestStatusID { get; set; }
        public string LoincCode1Result { get; set; }
        public string LoincCode1ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode1ResultDate { get; set; }
        public string LoincCode2Result { get; set; }
        public string LoincCode2ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode2ResultDate { get; set; }
        public string LoincCode3Result { get; set; }
        public string LoincCode3ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode3ResultDate { get; set; }
        public string LoincCode4Result { get; set; }
        public string LoincCode4ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode4ResultDate { get; set; }
        public string LoincCode5Result { get; set; }
        public string LoincCode5ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode5ResultDate { get; set; }
        public string LoincCode6Result { get; set; }
        public string LoincCode6ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode6ResultDate { get; set; }
        public string LoincCode7Result { get; set; }
        public string LoincCode7ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode7ResultDate { get; set; }
        public string LoincCode8Result { get; set; }
        public string LoincCode8ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode8ResultDate { get; set; }
        public string LoincCode9Result { get; set; }
        public string LoincCode9ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode9ResultDate { get; set; }
        public string LoincCode10Result { get; set; }
        public string LoincCode10ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode10ResultDate { get; set; }
        public string LoincCode11Result { get; set; }
        public string LoincCode11ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode11ResultDate { get; set; }
        public string LoincCode12Result { get; set; }
        public string LoincCode12ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode12ResultDate { get; set; }
        public string LoincCode13Result { get; set; }
        public string LoincCode13ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode13ResultDate { get; set; }
        public string LoincCode14Result { get; set; }
        public string LoincCode14ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode14ResultDate { get; set; }
        public string LoincCode15Result { get; set; }
        public string LoincCode15ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode15ResultDate { get; set; }
        public string LoincCode16Result { get; set; }
        public string LoincCode16ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode16ResultDate { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public Nullable<int> OrderTypeID { get; set; }
        public Nullable<int> BillTypeID { get; set; }
        public Nullable<int> InsuranceCodeId { get; set; }
        public string Template  { get; set; }
        public Decimal PrepaidAmount { get; set; }
        public Nullable<bool> STAT { get; set; }
        public Nullable<DateTime> CollectionDate  { get; set; }
        public Nullable<int> PreferredlanguageId  { get; set; }
        public Nullable<int> PatientRaceID { get; set; }
        public Nullable<int> PatientEthnicityID { get; set; }
        public Nullable<int> GenderIdentityID { get; set; }
        public Nullable<int> SexualOrientationID { get; set; }
        public string Instructions { get; set; }
        public string ReportComments { get; set; }
        public string Phonenumber { get; set; }
        public string Fax { get; set; }





        public virtual Facility Facility { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
      //  public virtual Provider Provider1 { get; set; }


    }
}
