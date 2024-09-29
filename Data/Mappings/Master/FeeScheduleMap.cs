using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class FeeScheduleMap : EntityTypeConfiguration<FeeSchedule>
    {


        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public FeeScheduleMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public FeeScheduleMap()
        {

        }

        public void Configure(EntityTypeBuilder<FeeSchedule> builder)
        {
            builder.ToTable("FeeSchedule", "Master");
            builder.HasKey(x => x.FeeScheduleID);
            builder.Property(x => x.FeeScheduleNO).HasColumnName("FeeScheduleNO").HasMaxLength(10);
            builder.Property(x => x.CodeQualifier).HasColumnName("CodeQualifier").HasMaxLength(2);
            builder.Property(x => x.FeeScheduleStatus).HasColumnName("FeeScheduleStatus").HasMaxLength(1);
            builder.Property(x => x.StateCode).HasColumnName("StateCode").HasMaxLength(2);
            builder.Property(x => x.Locality).HasColumnName("Locality").HasMaxLength(1);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);


        }
       
        
        
     

    }
}
