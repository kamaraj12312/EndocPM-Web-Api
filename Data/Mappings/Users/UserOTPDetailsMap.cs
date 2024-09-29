using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndocPM.WebAPI
{
    public class UserOTPDetailsMap : IEntityTypeConfiguration<UserOTPDetails>
    {
        public UserOTPDetailsMap()
        {

        }

        public void Configure(EntityTypeBuilder<UserOTPDetails> builder)
        {
            //builder.ToTable("UserOTPDetails", "BmsUsers");
            builder.ToTable("UserOTPDetails", "EndocUsers");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.UserEmail).HasColumnName("UserEmail").HasMaxLength(50);
            builder.Property(x => x.OTP).HasColumnName("OTP");
            builder.Property(x => x.UserContact).HasColumnName("UserContact").HasMaxLength(15);
        }
    }
}
