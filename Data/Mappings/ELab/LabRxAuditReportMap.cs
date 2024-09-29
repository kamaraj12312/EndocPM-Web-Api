using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndocPM.WebAPI
{
    public class LabRxAuditReportMap : IEntityTypeConfiguration<LabRxAuditReport>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public LabRxAuditReportMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public LabRxAuditReportMap()
        {

        }

        public void Configure(EntityTypeBuilder<LabRxAuditReport> builder)
        {
            builder.ToTable("LabRxAuditReport", "Tenant2");
            builder.HasKey(x => x.LabRxAuditReportID);

            builder.Property(x => x.LabRxAuditReportID).HasColumnName("LabRxAuditReportID");
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.PatientName).HasColumnName("PatientName").HasMaxLength(180);
            builder.Property(x => x.PatientNumber).HasColumnName("PatientNumber").HasMaxLength(20);
            builder.Property(x => x.UserName).HasColumnName("UserName").HasMaxLength(180);
            builder.Property(x => x.Data).HasColumnName("Data").HasMaxLength(2000);
            builder.Property(x => x.ActionMethodName).HasColumnName("ActionMethodName").HasMaxLength(250);
            builder.Property(x => x.ActionName).HasColumnName("ActionName").HasMaxLength(10);
            builder.Property(x => x.ActionDescription).HasColumnName("ActionDescription").HasMaxLength(200);
            builder.Property(x => x.ActionStatus).HasColumnName("ActionStatus").HasMaxLength(20);
            builder.Property(x => x.ScreenName).HasColumnName("ScreenName").HasMaxLength(2000);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.ActionRequestedFor).HasColumnName("ActionRequestedFor").HasMaxLength(100);
            builder.Property(x => x.UniqueIDForRequest).HasColumnName("UniqueIDForRequest");

        }
    }
}