using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndocPM.WebAPI
{
    public class TenantsMap : IEntityTypeConfiguration<Tenants>
    {
        public TenantsMap()
        {

        }

        public void Configure(EntityTypeBuilder<Tenants> builder)
        {
            //builder.ToTable("Tenants", "BmsUsers");
            builder.ToTable("Tenants", "EndocUsers");
            builder.HasKey(x => x.TenantID);

            builder.Property(x => x.TenantID).HasColumnName("TenantID");
            builder.Property(x => x.SchemaName).HasColumnName("SchemaName").HasMaxLength(50);
            builder.Property(x => x.TenantName).HasColumnName("TenantName").HasMaxLength(50);
            builder.Property(x => x.TenantDescription).HasColumnName("TenantDescription").HasMaxLength(150);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
        }
    }
}
