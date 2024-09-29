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
    public class UserTenantSetupMap : IEntityTypeConfiguration<UserTenantSetup>
    {
        public UserTenantSetupMap()
        {

        }

        public void Configure(EntityTypeBuilder<UserTenantSetup> builder)
        {
            //builder.ToTable("UserTenantSetup", "BmsUsers");
            builder.ToTable("UserTenantSetup", "EndocUsers");
            builder.HasKey(x => x.UserTenantID);

            builder.Property(x => x.UserTenantID).HasColumnName("UserTenantID");
            builder.Property(x => x.UserID).HasColumnName("UserID");
            builder.Property(x => x.TenantIDs).HasColumnName("TenantIDs").HasMaxLength(50);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
        }
    }
}
