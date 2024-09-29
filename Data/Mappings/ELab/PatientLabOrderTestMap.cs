using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EndocPM.WebAPI
{
    public class PatientLabOrderTestMap : IEntityTypeConfiguration<PatientLabOrderTest>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientLabOrderTestMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientLabOrderTestMap()
        {

        }
        public void Configure(EntityTypeBuilder<PatientLabOrderTest> builder)
        {
            builder.ToTable("PatientLabOrderTest", "Tenant2");
            builder.HasKey(x => x.PatientLabOrderTestID);
            builder.Property(x => x.FacilityID).HasColumnName("FacilityID");
            builder.Property(x => x.FacilityName).HasColumnName("FacilityName").HasMaxLength(200);
            builder.Property(x => x.ProviderID).HasColumnName("ProviderID");
            builder.Property(x => x.ProviderName).HasColumnName("ProviderName").HasMaxLength(150);
            builder.Property(x => x.OrderingProviderID).HasColumnName("OrderingProviderID");
            builder.Property(x => x.OrderingProviderName).HasColumnName("OrderingProviderName").HasMaxLength(150);
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.RecordedDate).HasColumnName("RecordedDate");
            builder.Property(x => x.LabTestDate).HasColumnName("LabTestDate");
            builder.Property(x => x.LabName).HasColumnName("LabName").HasMaxLength(300);
            builder.Property(x => x.TestName).HasColumnName("TestName").HasMaxLength(200);
            builder.Property(x => x.TestResult).HasColumnName("TestResult").HasMaxLength(200);
            builder.Property(x => x.ReferenceRange).HasColumnName("ReferenceRange").HasMaxLength(300);
            builder.Property(x => x.LabAddressLine1).HasColumnName("LabAddressLine1").HasMaxLength(100);
            builder.Property(x => x.LabAddressLine2).HasColumnName("LabAddressLine2").HasMaxLength(100);
            builder.Property(x => x.LabCity).HasColumnName("LabCity").HasMaxLength(50);
            builder.Property(x => x.LabState).HasColumnName("LabState").HasMaxLength(3);
            builder.Property(x => x.LabCounty).HasColumnName("LabCounty").HasMaxLength(50);
            builder.Property(x => x.LabZIP).HasColumnName("LabZIP").HasMaxLength(10);
            builder.Property(x => x.LoincCode1).HasColumnName("LoincCode1").HasMaxLength(20);
            builder.Property(x => x.LoincCode2).HasColumnName("LoincCode2").HasMaxLength(20);
            builder.Property(x => x.LoincCode3).HasColumnName("LoincCode3").HasMaxLength(20);
            builder.Property(x => x.LoincCode4).HasColumnName("LoincCode4").HasMaxLength(20);
            builder.Property(x => x.LoincCode5).HasColumnName("LoincCode5").HasMaxLength(20);
            builder.Property(x => x.LoincCode6).HasColumnName("LoincCode6").HasMaxLength(20);
            builder.Property(x => x.LoincCode7).HasColumnName("LoincCode7").HasMaxLength(20);
            builder.Property(x => x.LoincCode8).HasColumnName("LoincCode8").HasMaxLength(20);
            builder.Property(x => x.LoincCode9).HasColumnName("LoincCode9").HasMaxLength(20);
            builder.Property(x => x.LoincCode10).HasColumnName("LoincCode10").HasMaxLength(20);
            builder.Property(x => x.LoincCode11).HasColumnName("LoincCode11").HasMaxLength(20);
            builder.Property(x => x.LoincCode12).HasColumnName("LoincCode12").HasMaxLength(20);
            builder.Property(x => x.LoincCode13).HasColumnName("LoincCode13").HasMaxLength(20);
            builder.Property(x => x.LoincCode14).HasColumnName("LoincCode14").HasMaxLength(20);
            builder.Property(x => x.LoincCode15).HasColumnName("LoincCode15").HasMaxLength(20);
            builder.Property(x => x.LoincCode16).HasColumnName("LoincCode16").HasMaxLength(20);
            builder.Property(x => x.ICDCode1).HasColumnName("ICDCode1").HasMaxLength(10);
            builder.Property(x => x.ICDCode2).HasColumnName("ICDCode2").HasMaxLength(10);
            builder.Property(x => x.ICDCode3).HasColumnName("ICDCode3").HasMaxLength(10);
            builder.Property(x => x.ICDCode4).HasColumnName("ICDCode4").HasMaxLength(10);
            builder.Property(x => x.ICDCode5).HasColumnName("ICDCode5").HasMaxLength(10);
            builder.Property(x => x.ICDCode6).HasColumnName("ICDCode6").HasMaxLength(10);
            builder.Property(x => x.ICDCode7).HasColumnName("ICDCode7").HasMaxLength(10);
            builder.Property(x => x.ICDCode8).HasColumnName("ICDCode8").HasMaxLength(10);
            builder.Property(x => x.ICDCode9).HasColumnName("ICDCode9").HasMaxLength(10);
            builder.Property(x => x.ICDCode10).HasColumnName("ICDCode10").HasMaxLength(10);
            builder.Property(x => x.Notes).HasColumnName("Notes").HasMaxLength(4000);
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.IsPastTest).HasColumnName("IsPastTest");
            builder.Property(x => x.DocumentReferenceIds).HasColumnName("DocumentReferenceIds").HasMaxLength(100);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.PatientVisitID).HasColumnName("PatientVisitID");
            builder.Property(x => x.EmdeonLabID).HasColumnName("EmdeonLabID");
            builder.Property(x => x.PlacerOrderNumber).HasColumnName("PlacerOrderNumber").HasMaxLength(20);
            builder.Property(x => x.OrderRequestMSGPIDGRTORCID).HasColumnName("OrderRequestMSGPIDGRTORCID");
            builder.Property(x => x.ScheduledTestStatusID).HasColumnName("ScheduledTestStatusID");
            builder.Property(x => x.LoincCode1Result).HasColumnName("LoincCode1Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode1ResultUnits).HasColumnName("LoincCode1ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode1ResultDate).HasColumnName("LoincCode1ResultDate");
            builder.Property(x => x.LoincCode2Result).HasColumnName("LoincCode2Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode2ResultUnits).HasColumnName("LoincCode2ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode2ResultDate).HasColumnName("LoincCode2ResultDate");
            builder.Property(x => x.LoincCode3Result).HasColumnName("LoincCode3Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode3ResultUnits).HasColumnName("LoincCode3ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode3ResultDate).HasColumnName("LoincCode3ResultDate");
            builder.Property(x => x.LoincCode4Result).HasColumnName("LoincCode4Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode4ResultUnits).HasColumnName("LoincCode4ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode4ResultDate).HasColumnName("LoincCode4ResultDate");
            builder.Property(x => x.LoincCode5Result).HasColumnName("LoincCode5Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode5ResultUnits).HasColumnName("LoincCode5ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode5ResultDate).HasColumnName("LoincCode5ResultDate");
            builder.Property(x => x.LoincCode6Result).HasColumnName("LoincCode6Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode6ResultUnits).HasColumnName("LoincCode6ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode6ResultDate).HasColumnName("LoincCode6ResultDate");
            builder.Property(x => x.LoincCode7Result).HasColumnName("LoincCode7Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode7ResultUnits).HasColumnName("LoincCode7ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode7ResultDate).HasColumnName("LoincCode7ResultDate");
            builder.Property(x => x.LoincCode8Result).HasColumnName("LoincCode8Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode8ResultUnits).HasColumnName("LoincCode8ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode8ResultDate).HasColumnName("LoincCode8ResultDate");
            builder.Property(x => x.LoincCode9Result).HasColumnName("LoincCode9Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode9ResultUnits).HasColumnName("LoincCode9ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode9ResultDate).HasColumnName("LoincCode9ResultDate");
            builder.Property(x => x.LoincCode10Result).HasColumnName("LoincCode10Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode10ResultUnits).HasColumnName("LoincCode10ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode10ResultDate).HasColumnName("LoincCode10ResultDate");
            builder.Property(x => x.LoincCode11Result).HasColumnName("LoincCode11Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode11ResultUnits).HasColumnName("LoincCode11ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode11ResultDate).HasColumnName("LoincCode11ResultDate");
            builder.Property(x => x.LoincCode12Result).HasColumnName("LoincCode12Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode12ResultUnits).HasColumnName("LoincCode12ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode12ResultDate).HasColumnName("LoincCode12ResultDate");
            builder.Property(x => x.LoincCode13Result).HasColumnName("LoincCode13Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode13ResultUnits).HasColumnName("LoincCode13ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode13ResultDate).HasColumnName("LoincCode13ResultDate");
            builder.Property(x => x.LoincCode14Result).HasColumnName("LoincCode14Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode14ResultUnits).HasColumnName("LoincCode14ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode14ResultDate).HasColumnName("LoincCode14ResultDate");
            builder.Property(x => x.LoincCode15Result).HasColumnName("LoincCode15Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode15ResultUnits).HasColumnName("LoincCode15ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode15ResultDate).HasColumnName("LoincCode15ResultDate");
            builder.Property(x => x.LoincCode16Result).HasColumnName("LoincCode16Result").HasMaxLength(250);
            builder.Property(x => x.LoincCode16ResultUnits).HasColumnName("LoincCode16ResultUnits").HasMaxLength(25);
            builder.Property(x => x.LoincCode16ResultDate).HasColumnName("LoincCode16ResultDate");
            builder.Property(x => x.IsPrinted).HasColumnName("IsPrinted");
            builder.Property(x => x.IsEditable).HasColumnName("IsEditable");








        }
    }
}
