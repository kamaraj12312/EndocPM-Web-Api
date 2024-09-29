using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class GenderMap : EntityTypeConfiguration<Gender>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;
        public GenderMap(IHttpContextAccessor iHttpContextAccessor)
        {


            _iHttpContextAccessor = iHttpContextAccessor;



        }
       public GenderMap()
        {

        }
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender", "Master");
            builder.HasKey(x => x.GenderID);

            builder.Property(x => x.GenderCode).HasColumnName("GenderCode").HasMaxLength(5);
            builder.Property(x => x.GenderDescription).HasColumnName("GenderDescription").HasMaxLength(25);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
       
        }

    }
}
