using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class CommonMasterMap : EntityTypeConfiguration<CommonMaster>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public CommonMasterMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public CommonMasterMap()
        {

        }



        public void Configure(EntityTypeBuilder<CommonMaster> builder)
        {
            builder.ToTable("CommonMaster", "Tenant2");
            builder.HasKey(x => x.CommonMasterID);
            builder.Property(x => x.Category).HasColumnName("Category").HasMaxLength(50);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(10);
            builder.Property(x => x.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(200);
            builder.Property(x => x.HIPAACode).HasColumnName("HIPAACode").HasMaxLength(20);
            builder.Property(x => x.DisplayOrder).HasColumnName("DisplayOrder");
            builder.Property(x => x.Notes).HasColumnName("Notes").HasMaxLength(50);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(200);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);

        }
       
           
    }
}
