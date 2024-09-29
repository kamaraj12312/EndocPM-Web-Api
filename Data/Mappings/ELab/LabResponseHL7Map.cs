using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndocPM.WebAPI
{
    public class LabResponseHL7Map : IEntityTypeConfiguration<LabResponseHL7>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public LabResponseHL7Map(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public LabResponseHL7Map()
        {

        }

        public void Configure(EntityTypeBuilder<LabResponseHL7> builder)
        {
            builder.ToTable("LabResponseHL7", "Tenant2");
            builder.HasKey(x => x.LabResponseHL7ID);

            builder.Property(x => x.LabResponseHL7ID).HasColumnName("LabResponseHL7ID");
            builder.Property(x => x.LabRequestID).HasColumnName("LabRequestID");
            builder.Property(x => x.ResponseData).HasColumnName("ResponseData").HasMaxLength(2000);
            builder.Property(x => x.ResponseDownloadDate).HasColumnName("ResponseDownloadDate");
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.PatientLabOrderTestID).HasColumnName("PatientLabOrderTestID");
            builder.Property(x => x.PatientID).HasColumnName("PatientID");



        }
    }
}
