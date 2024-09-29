using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Http;

namespace EndocPM.WebAPI
{
    public class CountryCodeMap : IEntityTypeConfiguration<CountryCode>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;

        public CountryCodeMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public CountryCodeMap()
        {
           
        }

        public void Configure(EntityTypeBuilder<CountryCode> builder)
        {
            //string schemaName = this._iHttpContextAccessor.HttpContext.Request.Headers["Schema"];

            //builder.ToTable("CountryCode", schemaName);
            builder.ToTable("CountryCode", "Master");
            builder.HasKey(x => x.CountryCodeID);

            builder.Property(x => x.CountryCodeID).HasColumnName("CountryCodeID");
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(3);
            builder.Property(x => x.CountryName).HasColumnName("CountryName").HasMaxLength(100);
            builder.Property(x => x.SequenceCode).HasColumnName("SequenceCode").HasMaxLength(3);
            builder.Property(x => x.CountryOrder).HasColumnName("CountryOrder");
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
        }
    }
}
