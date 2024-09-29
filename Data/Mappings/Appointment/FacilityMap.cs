using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class FacilityMap : EntityTypeConfiguration<Facility>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;

        public FacilityMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public FacilityMap()
        {

        }

        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facility", "Tenant2");
            builder.HasKey(x => x.FacilityID);
            builder.Property(x => x.NPI).HasColumnName("NPI").HasMaxLength(15);
            builder.Property(x => x.TaxID).HasColumnName("TaxID").HasMaxLength(20);
            builder.Property(x => x.FacilityName).HasColumnName("FacilityName").HasMaxLength(200);
            builder.Property(x => x.OtherName).HasColumnName("OtherName").HasMaxLength(200);
            builder.Property(x => x.AddressLine1).HasColumnName("AddressLine1").HasMaxLength(100);
            builder.Property(x => x.AddressLine2).HasColumnName("AddressLine2").HasMaxLength(100);
            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(50);
            builder.Property(x => x.State).HasColumnName("State").HasMaxLength(50);
            builder.Property(x => x.ZIP).HasColumnName("ZIP").HasMaxLength(15);
            builder.Property(x => x.Telephone).HasColumnName("Telephone").HasMaxLength(20);
            builder.Property(x => x.AlternatePhone).HasColumnName("AlternatePhone").HasMaxLength(20); 
            builder.Property(x => x.Fax).HasColumnName("Fax").HasMaxLength(20);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);





        }
      

   

          
           
    }
}