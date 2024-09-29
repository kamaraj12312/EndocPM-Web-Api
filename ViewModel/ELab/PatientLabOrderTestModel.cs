using System;

namespace EndocPM.WebAPI
{

    public class PatientLabOrderTestModel
    {

        public int PatientLabOrderTestID { get; set; }
        public Nullable<int> PatientLabOrderTestFacilityID { get; set; }
        public string FacilityNameLabOrder { get; set; }
        public Nullable<int> PatientLabOrderTestProviderID { get; set; }
        public string ProviderNameLabOrder { get; set; }
        public Nullable<int> PatientLabOrderTestOrderingProviderID { get; set; }
        public string OrderingProviderNameLabOrder { get; set; }
        public int PatientID { get; set; }

        public DateTime RecordedDate { get; set; }
        public DateTime LabTestDate { get; set; }
        public string LabName { get; set; }
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
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string DocumentReferenceIds { get; set; }
        public virtual FacilityModel Facility { get; set; }
        public virtual PatientModel Patient { get; set; }
        public virtual ProviderModel Provider { get; set; }
        public virtual ProviderModel Provider1 { get; set; }
        public string PatientName { get; set; }
        public string PatientLabOrderTestTitle { get; set; }
        public string PatientPastLabOrderTestTitle { get; set; }
        public string PlacerOrderNumber { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<int> OrderRequestMSGPIDGRTORCID { get; set; }
        public string PatientLabOrderTestAddressTitle { get; set; }

        public string LoincCodeTitle { get; set; }
        public string ICDCodeTitle { get; set; }
        public string FutureScheduleTestTitle { get; set; }
        public string DiagnosisCodeList { get; set; }
        public string LoincCodeList { get; set; }


        public Nullable<int> EmdeonLabID { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public string FacilityName { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string ProviderName { get; set; }
        public Nullable<int> OrderingProviderID { get; set; }
        public string OrderingProviderName { get; set; }
        public Nullable<int> DocumentTypeID { get; set; }
        public string FileUpload { get; set; }

        public string FileView { get; set; }
        public Nullable<int> LabOrderScheduledTestStatusID { get; set; }
        public Nullable<int> ScheduledTestStatusID { get; set; }
        public string LabOrderScheduledTestStatusDescription { get; set; }
        public string LoincCode1Result { get; set; }
        public string LoincCode2Result { get; set; }
        public string LoincCode3Result { get; set; }
        public string LoincCode4Result { get; set; }
        public string LoincCode5Result { get; set; }
        public string LoincCode6Result { get; set; }
        public string LoincCode7Result { get; set; }
        public string LoincCode8Result { get; set; }
        public string LoincCode9Result { get; set; }
        public string LoincCode10Result { get; set; }
        public string LoincCode11Result { get; set; }
        public string LoincCode12Result { get; set; }
        public string LoincCode13Result { get; set; }
        public string LoincCode14Result { get; set; }
        public string LoincCode15Result { get; set; }
        public string LoincCode16Result { get; set; }
        public string LoincCode1ResultUnits { get; set; }
        public string LoincCode2ResultUnits { get; set; }
        public string LoincCode3ResultUnits { get; set; }
        public string LoincCode4ResultUnits { get; set; }
        public string LoincCode5ResultUnits { get; set; }
        public string LoincCode6ResultUnits { get; set; }
        public string LoincCode7ResultUnits { get; set; }
        public string LoincCode8ResultUnits { get; set; }
        public string LoincCode9ResultUnits { get; set; }
        public string LoincCode10ResultUnits { get; set; }
        public string LoincCode11ResultUnits { get; set; }
        public string LoincCode12ResultUnits { get; set; }
        public string LoincCode13ResultUnits { get; set; }
        public string LoincCode14ResultUnits { get; set; }
        public string LoincCode15ResultUnits { get; set; }
        public string LoincCode16ResultUnits { get; set; }
        public Nullable<DateTime> LoincCode1ResultDate { get; set; }
        public Nullable<DateTime> LoincCode2ResultDate { get; set; }
        public Nullable<DateTime> LoincCode3ResultDate { get; set; }
        public Nullable<DateTime> LoincCode4ResultDate { get; set; }
        public Nullable<DateTime> LoincCode5ResultDate { get; set; }
        public Nullable<DateTime> LoincCode6ResultDate { get; set; }
        public Nullable<DateTime> LoincCode7ResultDate { get; set; }
        public Nullable<DateTime> LoincCode8ResultDate { get; set; }
        public Nullable<DateTime> LoincCode9ResultDate { get; set; }
        public Nullable<DateTime> LoincCode10ResultDate { get; set; }
        public Nullable<DateTime> LoincCode11ResultDate { get; set; }
        public Nullable<DateTime> LoincCode12ResultDate { get; set; }
        public Nullable<DateTime> LoincCode13ResultDate { get; set; }
        public Nullable<DateTime> LoincCode14ResultDate { get; set; }
        public Nullable<DateTime> LoincCode15ResultDate { get; set; }
        public Nullable<DateTime> LoincCode16ResultDate { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string LoincCode1Description { get; set; }
        public string LoincCode2Description { get; set; }
        public string LoincCode3Description { get; set; }
        public string LoincCode4Description { get; set; }
        public string LoincCode5Description { get; set; }
        public string LoincCode6Description { get; set; }
        public string LoincCode7Description { get; set; }
        public string LoincCode8Description { get; set; }
        public string LoincCode9Description { get; set; }
        public string LoincCode10Description { get; set; }
        public string LoincCode11Description { get; set; }
        public string LoincCode12Description { get; set; }
        public string LoincCode13Description { get; set; }
        public string LoincCode14Description { get; set; }
        public string LoincCode15Description { get; set; }
        public string LoincCode16Description { get; set; }

        public string LoincCode1DescriptionString { get; set; }
        public string LoincCode2DescriptionString { get; set; }
        public string LoincCode3DescriptionString { get; set; }
        public string LoincCode4DescriptionString { get; set; }
        public string LoincCode5DescriptionString { get; set; }
        public string LoincCode6DescriptionString { get; set; }
        public string LoincCode7DescriptionString { get; set; }
        public string LoincCode8DescriptionString { get; set; }
        public string LoincCode9DescriptionString { get; set; }
        public string LoincCode10DescriptionString { get; set; }
        public string LoincCode11DescriptionString { get; set; }
        public string LoincCode12DescriptionString { get; set; }
        public string LoincCode13DescriptionString { get; set; }
        public string LoincCode14DescriptionString { get; set; }
        public string LoincCode15DescriptionString { get; set; }
        public string LoincCode16DescriptionString { get; set; }


        public string LoincCodeResult { get; set; }
        public string LoincCodeResultUnits { get; set; }
        public Nullable<DateTime> LoincCodeResultDate { get; set; }
        public string LoincCodeDescription { get; set; }
        public string LoincCodeNumber { get; set; }
        public string LoincCode1Number { get; set; }
        public string LoincCode2Number { get; set; }
        public string LoincCode3Number { get; set; }
        public string LoincCode4Number { get; set; }
        public string LoincCode5Number { get; set; }
        public string LoincCode6Number { get; set; }
        public string LoincCode7Number { get; set; }
        public string LoincCode8Number { get; set; }
        public string LoincCode9Number { get; set; }
        public string LoincCode10Number { get; set; }
        public string LoincCode11Number { get; set; }
        public string LoincCode12Number { get; set; }
        public string LoincCode13Number { get; set; }
        public string LoincCode14Number { get; set; }
        public string LoincCode15Number { get; set; }
        public string LoincCode16Number { get; set; }
        public string ReturnValue { get; set; }
        public string VisitTime { get; set; }
        public int PatientLabOrderTestPatientID { get; set; }
        public Nullable<int> PatientLabOrderTestPatientVisitID { get; set; }
        public bool IsPrinted { get; set; }

        public string FacilityNPI { get; set; }
        public bool IsPatientLabOrderTestIDHave { get; set; }

        public string LoincCode { get; set; }
        public bool IsResultUpdate { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public DateTime CurrentDate { get; set; }
        public Nullable<int> OrderTypeID { get; set; }
        public Nullable<int> BillTypeID { get; set; }
        public Nullable<int> InsuranceCodeId { get; set; }
        public string Template { get; set; }
        public Decimal PrepaidAmount { get; set; }
        public Nullable<bool> STAT { get; set; }
        public Nullable<DateTime> CollectionDate { get; set; }
        public Nullable<int> PreferredlanguageId { get; set; }
        public Nullable<int> PatientRaceID { get; set; }
        public Nullable<int> PatientEthnicityID { get; set; }
        public Nullable<int> GenderIdentityID { get; set; }
        public Nullable<int> SexualOrientationID { get; set; }
        public string Instructions { get; set; }
        public string ReportComments { get; set; }
        public string Phonenumber { get; set; }
        public string Fax { get; set; }


        public string CDSMessage { get; set; }
        #region For HL7 Converion Data Synch
        public string ProviderNameLast { get; set; }
        public string ProviderNameFirst { get; set; }
        public string ProviderNameMiddle { get; set; }

        public string PatientNameLast { get; set; }
        public string PatientNameFirst { get; set; }
        public string PatientNameMiddle { get; set; }

        public string PatientGenderCode { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public int LabHL7ResponseID { get; set; }

        #endregion
        // Custom Properties

        public string PreferredLanguageDescription { get; set; }
        public string PatientRaceDescription { get; set; }
        public string PatientEthnicityDescription { get; set; }
        public string GenderDescription { get; set; }
        public string SexualOrientationDescription { get; set; }
        public string OrderTypeDescription { get; set; }
        public string BillTypeDescription { get; set; }

    }

}