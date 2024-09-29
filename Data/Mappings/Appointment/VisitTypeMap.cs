using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class VisitTypeMap : EntityTypeConfiguration<VisitType>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public VisitTypeMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public VisitTypeMap()
        {

        }

        public void Configure(EntityTypeBuilder<VisitType> builder)
        {
            builder.ToTable("VisitType", "Tenant2");
            builder.HasKey(x => x.VisitTypeID);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(3);
            builder.Property(x => x.VisitTypeOrder).HasColumnName("VisitTypeOrder");
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(100);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);

        }       
            
          
    }
}